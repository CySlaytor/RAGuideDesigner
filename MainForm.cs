using RaGuideDesigner.Commands;
using RaGuideDesigner.Models;
using RaGuideDesigner.Services;
using RaGuideDesigner.Views;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using RAGuideDesigner.Properties;

namespace RaGuideDesigner
{
    public partial class MainForm : Form
    {
        private WikiGuide _currentProject;
        private readonly ProjectService _projectService;
        private readonly RaJsonParserService _raJsonParserService;
        private readonly MarkdownGenerationService _markdownGenerationService;
        private readonly MarkdownImportService _markdownImportService;
        private readonly UndoRedoService _undoRedoService;
        private readonly TreeViewManagerService _treeViewManagerService;

        private string? _currentProjectPath = null;
        private bool _isDirty = false;
        private bool _isProgrammaticChange = false;

        private Control? _contextControlForEditMenu;

        private readonly List<TreeNode> _selectedNodes = new List<TreeNode>();
        private TreeNode? _dragStartNode;
        private Point _dragStartPoint;
        private TreeNode? _rightClickedNode;


        // These are the different editor panels (User Controls) that get swapped in and out.
        private readonly HeaderEditor _headerEditor;
        private readonly AchievementEditor _achievementEditor;
        private readonly CategoryEditor _categoryEditor;
        private readonly WalkthroughsEditor _walkthroughsEditor;
        private readonly LeaderboardEditor _leaderboardEditor;
        private readonly CreditsEditor _creditsEditor;
        private readonly CollectibleEditor _collectibleEditor;
        private readonly LeaderboardRootEditor _leaderboardRootEditor;
        private readonly Panel _placeholderPanel;

        public MainForm()
        {
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;

            spellCheckToolStripMenuItem.Checked = Settings.Default.IsSpellCheckEnabled;
            if (Settings.Default.IsSpellCheckEnabled)
            {
                SpellCheckService.Instance.Initialize();
            }

            _currentProject = new WikiGuide();

            _projectService = new ProjectService();
            _raJsonParserService = new RaJsonParserService();
            _markdownGenerationService = new MarkdownGenerationService();
            _markdownImportService = new MarkdownImportService();
            _undoRedoService = new UndoRedoService();
            _treeViewManagerService = new TreeViewManagerService();

            _undoRedoService.CommandHistoryChanged += OnCommandHistoryChanged;
            _undoRedoService.CommandUndone += (cmd) => OnUndoRedo(cmd, true);
            _undoRedoService.CommandRedone += (cmd) => OnUndoRedo(cmd, false);


            _headerEditor = new HeaderEditor(_undoRedoService) { Dock = DockStyle.Fill };
            _achievementEditor = new AchievementEditor(_undoRedoService) { Dock = DockStyle.Fill };
            _categoryEditor = new CategoryEditor(_undoRedoService) { Dock = DockStyle.Fill };
            _walkthroughsEditor = new WalkthroughsEditor(_undoRedoService) { Dock = DockStyle.Fill };
            _leaderboardEditor = new LeaderboardEditor(_undoRedoService) { Dock = DockStyle.Fill };
            _creditsEditor = new CreditsEditor(_undoRedoService) { Dock = DockStyle.Fill };
            _collectibleEditor = new CollectibleEditor(_undoRedoService) { Dock = DockStyle.Fill };
            _leaderboardRootEditor = new LeaderboardRootEditor(_undoRedoService) { Dock = DockStyle.Fill };
            _placeholderPanel = new Panel { Dock = DockStyle.Fill };
            var placeholderLabel = new Label { Text = "Select an item from the tree to edit it.", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter };
            _placeholderPanel.Controls.Add(placeholderLabel);

            pnlEditor.Controls.AddRange(new Control[] {
                _headerEditor, _achievementEditor, _categoryEditor,
                _walkthroughsEditor, _leaderboardEditor, _creditsEditor,
                _collectibleEditor, _leaderboardRootEditor, _placeholderPanel
            });

            CreateNewGuide();
        }

        public void SetDirty()
        {
            _isDirty = true;
            UpdateWindowTitle();
        }

        // Recursively finds the currently focused control, which is useful for context-sensitive menus.
        private Control? FindFocusedControl(Control container)
        {
            foreach (Control child in container.Controls)
            {
                if (child.Focused) return child;
                var focusedChild = FindFocusedControl(child);
                if (focusedChild != null) return focusedChild;
            }
            return null;
        }

        private void OnCommandHistoryChanged(ICommand? command)
        {
            _isDirty = true;
            UpdateWindowTitle();
            UpdateEditMenuState();

            if (command != null)
            {
                ScheduleTreeViewUpdate(command, isUndo: false);
            }
        }

        private void OnUndoRedo(ICommand command, bool isUndo)
        {
            _isDirty = true;
            UpdateWindowTitle();
            UpdateEditMenuState();

            ScheduleTreeViewUpdate(command, isUndo);
        }

        // Schedules a UI update to happen safely after the current operation finishes.
        // This prevents issues with modifying collections while they are being iterated over.
        private void ScheduleTreeViewUpdate(ICommand command, bool isUndo)
        {
            if (this.IsHandleCreated)
            {
                this.BeginInvoke(new Action(() =>
                {
                    UpdateTreeViewFromCommand(command, isUndo);
                    _headerEditor.UpdateStatistics(_currentProject);
                    // Also refresh the category editor stats if it's visible.
                    // This is less disruptive than a full SetData() call which causes focus loss.
                    if (_categoryEditor.Visible)
                    {
                        _categoryEditor.UpdateStatistics();
                    }
                }));
            }
        }

        // Commits changes in the currently visible editor panel.
        private void CommitPendingEditorChanges()
        {
            pnlEditor.Controls.OfType<BaseEditorControl>().FirstOrDefault(c => c.Visible)?.CommitChanges();
        }

        #region Unsaved Changes Prompt
        private bool PromptToSaveChanges()
        {
            if (!_isDirty) return true;

            var result = MessageBox.Show(
                "You have unsaved changes. Would you like to save them now?",
                "Unsaved Changes",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);

            switch (result)
            {
                case DialogResult.Yes:
                    saveProjectToolStripMenuItem_Click(this, EventArgs.Empty);
                    return !_isDirty; // Return true only if the save was successful.
                case DialogResult.No:
                    return true;
                case DialogResult.Cancel:
                    return false;
                default:
                    return false;
            }
        }

        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            CommitPendingEditorChanges();
            if (!PromptToSaveChanges())
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region File Menu Handlers
        private void newGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommitPendingEditorChanges();
            if (PromptToSaveChanges())
            {
                CreateNewGuide();
            }
        }

        private void loadProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommitPendingEditorChanges();
            if (!PromptToSaveChanges()) return;

            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "RA Guide Project (*.raguide)|*.raguide|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _headerEditor.ClearCaches();
                    var loadedProject = _projectService.Load(ofd.FileName);
                    if (loadedProject != null)
                    {
                        _currentProject = loadedProject;
                        _currentProjectPath = ofd.FileName;
                        _undoRedoService.Clear();
                        _isDirty = false;
                        UpdateWindowTitle();
                        PopulateTreeView();
                    }
                    else
                    {
                        MessageBox.Show("Failed to load project file.", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommitPendingEditorChanges();
            if (string.IsNullOrEmpty(_currentProjectPath))
            {
                saveProjectAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                _projectService.Save(_currentProject, _currentProjectPath);
                _isDirty = false;
                UpdateWindowTitle();
            }
        }

        private void saveProjectAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommitPendingEditorChanges();
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "RA Guide Project (*.raguide)|*.raguide|All files (*.*)|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    _currentProjectPath = sfd.FileName;
                    saveProjectToolStripMenuItem_Click(sender, e);
                }
            }
        }

        private void importFromRAJSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommitPendingEditorChanges();

            bool shouldOverwrite = true;
            if (_currentProject.AchievementCategories.SelectMany(c => c.Achievements).Any())
            {
                var result = MessageBox.Show(
                    "You have an active project. Would you like to merge the achievement points from the JSON file into your current project?\n\nChoosing 'No' will discard your current project and import a new one from the JSON file.",
                    "Merge or Overwrite?",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Cancel) return;
                shouldOverwrite = (result == DialogResult.No);
            }

            if (shouldOverwrite && !PromptToSaveChanges()) return;

            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "JSON File (*.json)|*.json|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _headerEditor.ClearCaches();
                        var jsonData = _raJsonParserService.Parse(ofd.FileName);

                        if (shouldOverwrite)
                        {
                            var newProject = CreateDefaultGuide();
                            newProject.GameTitle = jsonData.GameTitle;
                            newProject.MasteryIconUrl = jsonData.MasteryIconUrl;
                            newProject.AchievementCategories = jsonData.AchievementCategories;
                            newProject.Leaderboards = jsonData.Leaderboards;
                            _currentProject = newProject;

                            AddAsolidSnackCreditIfNeeded(_currentProject);
                            _currentProjectPath = null;
                            _undoRedoService.Clear();
                            _isDirty = true;
                            UpdateWindowTitle();
                            PopulateTreeView();
                        }
                        else
                        {
                            if (!string.Equals(_currentProject.GameTitle.Trim(), jsonData.GameTitle.Trim(), StringComparison.OrdinalIgnoreCase))
                            {
                                var mismatchResult = MessageBox.Show(
                                    $"Warning: The JSON file appears to be for a different game ('{jsonData.GameTitle}') than your current project ('{_currentProject.GameTitle}').\n\nDo you want to proceed with merging the data anyway?",
                                    "Game Title Mismatch",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning);

                                if (mismatchResult == DialogResult.No) return;
                            }
                            MergeAchievementData(jsonData);
                            MessageBox.Show("Achievement points and badge URLs have been successfully merged into the current project.", "Merge Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to parse RA JSON file. Error: {ex.Message}", "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Handles merging achievement data (like points) from a JSON file into the current project.
        private void MergeAchievementData(WikiGuide sourceGuide)
        {
            var commands = new List<ICommand>();
            var sourceAchievements = sourceGuide.AchievementCategories
                                               .SelectMany(c => c.Achievements)
                                               .ToDictionary(a => a.Id);

            foreach (var achievement in _currentProject.AchievementCategories.SelectMany(c => c.Achievements))
            {
                if (sourceAchievements.TryGetValue(achievement.Id, out var sourceAch))
                {
                    if (achievement.Points != sourceAch.Points)
                    {
                        commands.Add(new EditPropertyCommand(achievement, nameof(Achievement.Points), achievement.Points, sourceAch.Points));
                    }
                    if (achievement.BadgeUrl != sourceAch.BadgeUrl)
                    {
                        commands.Add(new EditPropertyCommand(achievement, nameof(Achievement.BadgeUrl), achievement.BadgeUrl, sourceAch.BadgeUrl));
                    }
                }
            }

            if (commands.Any())
            {
                _undoRedoService.Execute(new CompositeCommand(commands));
            }
        }


        private void importFromMarkdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommitPendingEditorChanges();
            if (!PromptToSaveChanges()) return;

            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "RA Wiki Guide (*.txt)|*.txt|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _headerEditor.ClearCaches();
                        _currentProject = _markdownImportService.Parse(ofd.FileName);
                        AddAsolidSnackCreditIfNeeded(_currentProject);
                        _currentProjectPath = null;
                        _undoRedoService.Clear();
                        _isDirty = true;
                        UpdateWindowTitle();
                        PopulateTreeView();
                        MessageBox.Show("Markdown guide imported successfully!", "Import Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to parse Markdown file. The file may not match the expected format.\n\nError: {ex.Message}", "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void generateMarkdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommitPendingEditorChanges();
            var markdown = _markdownGenerationService.Generate(_currentProject);
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Text File (*.txt)|*.txt";
                sfd.FileName = "Markdown.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(sfd.FileName, markdown);
                    MessageBox.Show("Markdown file generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();
        #endregion

        #region Edit Menu Handlers
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control? context = _contextControlForEditMenu ?? FindFocusedControl(this);

            if (context is RichTextBox rtb && rtb.CanUndo)
            {
                rtb.Undo();
            }
            else
            {
                CommitPendingEditorChanges();
                _undoRedoService.Undo();
            }
            UpdateEditMenuState();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control? context = _contextControlForEditMenu ?? FindFocusedControl(this);

            if (context is RichTextBox rtb && rtb.CanRedo)
            {
                rtb.Redo();
            }
            else
            {
                CommitPendingEditorChanges();
                _undoRedoService.Redo();
            }
            UpdateEditMenuState();
        }

        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            _contextControlForEditMenu = FindFocusedControl(this);
            UpdateEditMenuState();
        }

        private void UpdateEditMenuState()
        {
            Control? currentContext = _contextControlForEditMenu ?? FindFocusedControl(this);

            bool canGlobalUndo = _undoRedoService.CanUndo;
            bool canGlobalRedo = _undoRedoService.CanRedo;

            bool canLocalUndo = false;
            bool canLocalRedo = false;

            if (currentContext is RichTextBox rtb)
            {
                canLocalUndo = rtb.CanUndo;
                canLocalRedo = rtb.CanRedo;
            }

            undoToolStripMenuItem.Enabled = canGlobalUndo || canLocalUndo;
            redoToolStripMenuItem.Enabled = canGlobalRedo || canLocalRedo;
        }

        private void spellCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.IsSpellCheckEnabled = spellCheckToolStripMenuItem.Checked;
            Settings.Default.Save();
            MessageBox.Show(
                "Please restart the application for the spell check setting to take full effect.",
                "Restart Required",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        #endregion

        #region Help Menu Handlers
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var aboutForm = new AboutForm())
            {
                aboutForm.ShowDialog(this);
            }
        }
        #endregion

        #region UI and Data Logic
        private string ReadEmbeddedResource(string resourceName)
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new FileNotFoundException($"Embedded resource '{resourceName}' not found. Ensure the file exists, the path is correct, and its 'Build Action' is set to 'Embedded Resource'.");
                }

                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        private WikiGuide CreateDefaultGuide()
        {
            string defaultMarkdown = ReadEmbeddedResource("RAGuideDesigner.Resources.Default.txt");
            return _markdownImportService.ParseFromString(defaultMarkdown);
        }

        private void CreateNewGuide()
        {
            _headerEditor.ClearCaches();
            _currentProject = CreateDefaultGuide();

            _currentProjectPath = null;
            _undoRedoService.Clear();
            _isDirty = false;
            UpdateWindowTitle();
            PopulateTreeView();
        }

        private Credit GetDefaultCredit() => new Credit
        {
            Username = "ASolidSnack",
            AvatarUrl = "https://media.retroachievements.org/UserPic/ASolidSnack.png",
            Role = "🟉 Contributor | RA-Guide Design",
            ContributionDetails = "Provided the template design and feature specifications for this tool."
        };

        private void AddAsolidSnackCreditIfNeeded(WikiGuide guide)
        {
            if (!guide.Credits.Any(c => c.Username.Equals("ASolidSnack", StringComparison.OrdinalIgnoreCase)))
            {
                guide.Credits.Add(GetDefaultCredit());
            }
        }

        private void PopulateTreeView()
        {
            _isProgrammaticChange = true;
            tvGuideStructure.BeginUpdate();
            tvGuideStructure.Nodes.Clear();
            _treeViewManagerService.PopulateTreeView(tvGuideStructure, _currentProject);
            ClearAndSelectNode(tvGuideStructure.Nodes[0]);
            UpdateSelectionAppearance();
            tvGuideStructure.SelectedNode = tvGuideStructure.Nodes[0];
            tvGuideStructure.EndUpdate();
            _isProgrammaticChange = false;
            UpdateEditorPanel();
        }

        private void tvGuideStructure_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (_isProgrammaticChange) return;
            UpdateEditorPanel();
        }

        // The main logic for showing the correct editor panel based on the selected tree node.
        private void UpdateEditorPanel()
        {
            var lastSelectedNode = _selectedNodes.LastOrDefault() ?? tvGuideStructure.SelectedNode;
            if (lastSelectedNode?.Tag == null)
            {
                ShowEditor(_placeholderPanel);
                return;
            }

            var tag = lastSelectedNode.Tag;

            if (tag is string stringTag)
            {
                switch (stringTag)
                {
                    case "Header": ShowEditor(_headerEditor, _currentProject); break;
                    case "Walkthroughs": ShowEditor(_walkthroughsEditor, _currentProject); break;
                    case "LeaderboardGuideRoot": ShowEditor(_leaderboardRootEditor, _currentProject); break;
                    default: ShowEditor(_placeholderPanel); break;
                }
            }
            else if (tag is IGuideItem item)
            {
                switch (item)
                {
                    case Achievement ach:
                        var parentNode = lastSelectedNode.Parent;
                        var parentCategory = parentNode?.Tag as AchievementCategory;
                        if (parentCategory != null && parentCategory.IsCollectibleType)
                        {
                            ShowEditor(_collectibleEditor, ach, parentCategory);
                        }
                        else
                        {
                            ShowEditor(_achievementEditor, ach, parentCategory);
                        }
                        break;
                    case AchievementCategory cat: ShowEditor(_categoryEditor, cat); break;
                    case Leaderboard lb: ShowEditor(_leaderboardEditor, lb); break;
                    case Credit credit: ShowEditor(_creditsEditor, credit); break;
                    default: ShowEditor(_placeholderPanel); break;
                }
            }
            else
            {
                ShowEditor(_placeholderPanel);
            }
        }

        // Swaps the visible editor panel in the UI.
        private void ShowEditor(Control editor, object? data = null, object? parentData = null)
        {
            CommitPendingEditorChanges();
            foreach (Control c in pnlEditor.Controls) c.Visible = false;

            var method = editor.GetType().GetMethod("SetData");
            if (method?.GetParameters().Length == 2)
            {
                method.Invoke(editor, new[] { data, parentData });
            }
            else if (method?.GetParameters().Length == 1)
            {
                method.Invoke(editor, new[] { data });
            }

            editor.Visible = true;
        }


        private void UpdateWindowTitle()
        {
            var title = "RetroAchievements Guide Designer";
            if (!string.IsNullOrEmpty(_currentProjectPath))
                title += $" - {System.IO.Path.GetFileName(_currentProjectPath)}";
            if (_isDirty) title += "*";
            this.Text = title;
        }
        #endregion

        #region Multi-Select, Context Menu & Drag-Drop Logic

        private void tvGuideStructure_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _rightClickedNode = e.Node;
                if (!_selectedNodes.Contains(e.Node))
                {
                    ClearAndSelectNode(e.Node);
                    UpdateSelectionAppearance();
                    tvGuideStructure.SelectedNode = e.Node;
                }
                return;
            }

            _isProgrammaticChange = true;
            if (ModifierKeys == Keys.Control)
            {
                if (_selectedNodes.Contains(e.Node))
                    _selectedNodes.Remove(e.Node);
                else
                    _selectedNodes.Add(e.Node);
            }
            else if (ModifierKeys == Keys.Shift)
            {
                var lastNode = _selectedNodes.LastOrDefault();
                if (lastNode != null && lastNode.Parent == e.Node.Parent && lastNode != e.Node)
                {
                    var parent = e.Node.Parent;
                    if (parent != null)
                    {
                        var nodes = parent.Nodes;
                        int index1 = nodes.IndexOf(lastNode);
                        int index2 = nodes.IndexOf(e.Node);
                        int start = Math.Min(index1, index2);
                        int end = Math.Max(index1, index2);

                        for (int i = start; i <= end; i++)
                        {
                            if (!_selectedNodes.Contains(nodes[i]))
                                _selectedNodes.Add(nodes[i]);
                        }
                    }
                }
                else
                {
                    ClearAndSelectNode(e.Node);
                }
            }
            else
            {
                ClearAndSelectNode(e.Node);
            }
            UpdateSelectionAppearance();
            tvGuideStructure.SelectedNode = e.Node;
            _isProgrammaticChange = false;
            tvGuideStructure_AfterSelect(sender, new TreeViewEventArgs(e.Node));
        }

        private void ClearAndSelectNode(TreeNode? node)
        {
            _selectedNodes.Clear();
            if (node != null) _selectedNodes.Add(node);
        }

        private void UpdateSelectionAppearance()
        {
            foreach (TreeNode node in tvGuideStructure.Nodes)
            {
                ResetNodeAppearance(node);
            }
            foreach (var node in _selectedNodes)
            {
                node.BackColor = SystemColors.Highlight;
                node.ForeColor = SystemColors.HighlightText;
            }
        }

        private void ResetNodeAppearance(TreeNode rootNode)
        {
            rootNode.BackColor = tvGuideStructure.BackColor;
            rootNode.ForeColor = tvGuideStructure.ForeColor;
            foreach (TreeNode node in rootNode.Nodes)
            {
                ResetNodeAppearance(node);
            }
        }

        private void tvGuideStructure_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down))
            {
                e.SuppressKeyPress = true;
                if (e.KeyCode == Keys.Up)
                {
                    MoveSelectedItemsUp();
                }
                else
                {
                    MoveSelectedItemsDown();
                }
            }
        }

        private enum MenuType { ExpandCollapse, EditItems }

        private void ShowContextMenu(MenuType type)
        {
            bool isExpandCollapse = type == MenuType.ExpandCollapse;

            expandAllToolStripMenuItem.Visible = isExpandCollapse;
            collapseAllToolStripMenuItem.Visible = isExpandCollapse;
            toolStripSeparator5.Visible = isExpandCollapse;

            foreach (ToolStripItem item in cmTree.Items)
            {
                if (item != expandAllToolStripMenuItem && item != collapseAllToolStripMenuItem && item != toolStripSeparator5)
                {
                    item.Visible = !isExpandCollapse;
                }
            }

            if (isExpandCollapse) return;

            var selectedItems = _selectedNodes.Select(n => n.Tag).ToList();
            var clickedItem = _rightClickedNode?.Tag;

            addAchievementCategoryToolStripMenuItem.Visible = clickedItem is string s && s == "AchievementGuideRoot";
            addAchievementToolStripMenuItem.Visible = clickedItem is AchievementCategory && _selectedNodes.Count == 1;
            addLeaderboardToolStripMenuItem.Visible = clickedItem is string s2 && s2 == "LeaderboardGuideRoot";
            addCreditToolStripMenuItem.Visible = clickedItem is string s3 && s3 == "CreditsRoot";

            var firstItem = selectedItems.FirstOrDefault();
            if (firstItem == null) return;

            bool areAllSameType = selectedItems.All(i => i?.GetType() == firstItem.GetType());
            bool canMoveOrDelete = areAllSameType && firstItem is IGuideItem;
            bool canDuplicate = areAllSameType && (firstItem is Achievement || firstItem is AchievementCategory);

            deleteToolStripMenuItem.Visible = canMoveOrDelete;
            duplicateToolStripMenuItem.Visible = canDuplicate;
            moveUpToolStripMenuItem.Visible = canMoveOrDelete && !(firstItem is Credit);
            moveDownToolStripMenuItem.Visible = canMoveOrDelete && !(firstItem is Credit);

            toolStripSeparator4.Visible = addAchievementCategoryToolStripMenuItem.Visible || addAchievementToolStripMenuItem.Visible || addLeaderboardToolStripMenuItem.Visible || addCreditToolStripMenuItem.Visible;
            toolStripSeparator3.Visible = duplicateToolStripMenuItem.Visible || moveUpToolStripMenuItem.Visible || moveDownToolStripMenuItem.Visible;
        }

        private void cmTree_Opening(object sender, CancelEventArgs e)
        {
            if (_rightClickedNode == null)
            {
                e.Cancel = true;
                return;
            }

            var tag = _rightClickedNode.Tag;

            if (tag is WikiGuide)
            {
                ShowContextMenu(MenuType.ExpandCollapse);
            }
            else if (tag is string strTag && strTag == "AchievementGuideRoot")
            {
                ShowContextMenu(MenuType.EditItems);

                expandAllToolStripMenuItem.Visible = true;
                collapseAllToolStripMenuItem.Visible = true;
                toolStripSeparator5.Visible = true;
            }
            else if (tag is string strTag2 && (strTag2 == "Header" || strTag2 == "Walkthroughs"))
            {
                e.Cancel = true;
            }
            else
            {
                ShowContextMenu(MenuType.EditItems);
            }
        }

        private void expandAllToolStripMenuItem_Click(object sender, EventArgs e) => _rightClickedNode?.ExpandAll();

        private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e) => _rightClickedNode?.Collapse(false);

        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e) => MoveSelectedItemsUp();
        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e) => MoveSelectedItemsDown();

        private void addAchievementCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newCategory = new AchievementCategory();
            var command = new AddListItemCommand<AchievementCategory>(_currentProject.AchievementCategories, newCategory);
            _undoRedoService.Execute(command);
        }

        private void addAchievementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedNodes.FirstOrDefault()?.Tag is AchievementCategory cat)
            {
                var newAch = new Achievement();
                var command = new AddListItemCommand<Achievement>(cat.Achievements, newAch);
                _undoRedoService.Execute(command);
            }
        }
        private void addLeaderboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newLb = new Leaderboard();
            var command = new AddListItemCommand<Leaderboard>(_currentProject.Leaderboards, newLb);
            _undoRedoService.Execute(command);
        }

        private void addCreditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newCredit = new Credit();
            var command = new AddListItemCommand<Credit>(_currentProject.Credits, newCredit);
            _undoRedoService.Execute(command);
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_selectedNodes.Any()) return;

            var commands = new List<ICommand>();
            var firstItem = _selectedNodes.First().Tag;

            if (firstItem is AchievementCategory)
            {
                var categoriesToDuplicate = _selectedNodes
                    .Select(n => n.Tag)
                    .OfType<AchievementCategory>()
                    .OrderBy(c => _currentProject.AchievementCategories.IndexOf(c))
                    .ToList();

                foreach (var cat in categoriesToDuplicate)
                {
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(cat);
                    var clone = Newtonsoft.Json.JsonConvert.DeserializeObject<AchievementCategory>(json);
                    if (clone == null) continue;

                    clone.Title += " (Copy)";
                    foreach (var ach in clone.Achievements)
                    {
                        ach.Id = 0; // Reset ID for duplicated achievements
                    }

                    int originalIndex = _currentProject.AchievementCategories.IndexOf(cat);
                    commands.Add(new AddListItemCommand<AchievementCategory>(_currentProject.AchievementCategories, clone, originalIndex + 1));
                }
            }
            else if (firstItem is Achievement)
            {
                var achievementsByParent = _selectedNodes
                    .Select(n => new { Node = n, Achievement = n.Tag as Achievement })
                    .Where(x => x.Achievement != null)
                    .GroupBy(x => x.Node.Parent?.Tag as AchievementCategory)
                    .Where(g => g.Key != null);

                foreach (var grouping in achievementsByParent)
                {
                    AchievementCategory parentCat = grouping.Key!;
                    var achievementsToDuplicate = grouping
                        .Select(x => x.Achievement!)
                        .OrderBy(a => parentCat.Achievements.IndexOf(a))
                        .ToList();

                    foreach (var ach in achievementsToDuplicate)
                    {
                        var json = Newtonsoft.Json.JsonConvert.SerializeObject(ach);
                        var clone = Newtonsoft.Json.JsonConvert.DeserializeObject<Achievement>(json);
                        if (clone == null) continue;

                        clone.Title += " (Copy)";
                        clone.Id = 0;

                        int originalIndex = parentCat.Achievements.IndexOf(ach);
                        commands.Add(new AddListItemCommand<Achievement>(parentCat.Achievements, clone, originalIndex + 1));
                    }
                }
            }

            if (commands.Any())
            {
                _undoRedoService.Execute(new CompositeCommand(commands));
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_selectedNodes.Any()) return;

            string itemText = _selectedNodes.Count > 1 ? $"{_selectedNodes.Count} items" : $"'{(_selectedNodes.First().Tag as IGuideItem)?.DisplayText}'";
            var result = MessageBox.Show($"Are you sure you want to delete {itemText}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No) return;

            var commands = new List<ICommand>();
            foreach (var node in _selectedNodes)
            {
                if (node.Tag is not IGuideItem item) continue;
                switch (item)
                {
                    case Achievement ach:
                        var parentCat = _currentProject.AchievementCategories.FirstOrDefault(c => c.Achievements.Contains(ach));
                        if (parentCat != null) commands.Add(new RemoveListItemCommand<Achievement>(parentCat.Achievements, ach));
                        break;
                    case AchievementCategory cat:
                        commands.Add(new RemoveListItemCommand<AchievementCategory>(_currentProject.AchievementCategories, cat));
                        break;
                    case Leaderboard lb:
                        commands.Add(new RemoveListItemCommand<Leaderboard>(_currentProject.Leaderboards, lb));
                        break;
                    case Credit credit:
                        commands.Add(new RemoveListItemCommand<Credit>(_currentProject.Credits, credit));
                        break;
                }
            }

            if (commands.Any())
            {
                _undoRedoService.Execute(new CompositeCommand(commands));
            }
        }

        private void tvGuideStructure_MouseDown(object sender, MouseEventArgs e)
        {
            var nodeUnderMouse = tvGuideStructure.GetNodeAt(e.X, e.Y);

            // If we're clicking a different node or empty space, commit the changes from the currently active editor.
            if (nodeUnderMouse == null || !_selectedNodes.Contains(nodeUnderMouse))
            {
                CommitPendingEditorChanges();
            }

            _dragStartNode = nodeUnderMouse;
            _dragStartPoint = e.Location;

            if (e.Button == MouseButtons.Right)
            {
                _rightClickedNode = _dragStartNode;
            }

            if (nodeUnderMouse == null) // Clicked empty space
            {
                ClearAndSelectNode(null);
                UpdateSelectionAppearance();
                UpdateEditorPanel();
            }
        }

        private void tvGuideStructure_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _dragStartNode != null)
            {
                int deltaX = Math.Abs(e.X - _dragStartPoint.X);
                int deltaY = Math.Abs(e.Y - _dragStartPoint.Y);
                if (deltaX > SystemInformation.DragSize.Width || deltaY > SystemInformation.DragSize.Height)
                {
                    if (!_selectedNodes.Contains(_dragStartNode))
                    {
                        ClearAndSelectNode(_dragStartNode);
                        UpdateSelectionAppearance();
                        tvGuideStructure.SelectedNode = _dragStartNode;
                    }

                    DoDragDrop(_selectedNodes, DragDropEffects.Move);
                    _dragStartNode = null;
                }
            }
        }

        private void tvGuideStructure_DragEnter(object sender, DragEventArgs e) => e.Effect = DragDropEffects.Move;

        private void tvGuideStructure_DragOver(object sender, DragEventArgs e) => tvGuideStructure.SelectedNode = tvGuideStructure.GetNodeAt(tvGuideStructure.PointToClient(new Point(e.X, e.Y)));

        private void tvGuideStructure_DragDrop(object sender, DragEventArgs e)
        {
            var targetNode = tvGuideStructure.GetNodeAt(tvGuideStructure.PointToClient(new Point(e.X, e.Y)));
            if (e.Data?.GetData(typeof(List<TreeNode>)) is not List<TreeNode> draggedNodes || !draggedNodes.Any() || targetNode == null) return;

            var firstDraggedItem = draggedNodes.First().Tag;
            var commands = new List<ICommand>();

            if (firstDraggedItem is Achievement)
            {
                var achievements = draggedNodes.Select(n => n.Tag).OfType<Achievement>().ToList();
                if (!achievements.Any()) return;
                var firstAchievement = achievements.First();
                var sourceCat = _currentProject.AchievementCategories.FirstOrDefault(c => c.Achievements.Contains(firstAchievement));
                var targetCat = targetNode.Tag as AchievementCategory ?? targetNode.Parent?.Tag as AchievementCategory;

                if (sourceCat != null && targetCat != null)
                {
                    var targetAch = targetNode.Tag as Achievement;
                    int targetIndex = (targetAch != null && targetCat.Achievements.Contains(targetAch)) ? targetCat.Achievements.IndexOf(targetAch) : targetCat.Achievements.Count;

                    var sortedAchievements = achievements
                        .OrderByDescending(a => sourceCat.Achievements.IndexOf(a))
                        .ToList();

                    foreach (var ach in sortedAchievements)
                    {
                        int originalIndex = sourceCat.Achievements.IndexOf(ach);
                        int newTargetIndex = targetIndex;
                        if (ReferenceEquals(sourceCat, targetCat) && originalIndex != -1 && originalIndex < newTargetIndex)
                        {
                            newTargetIndex--;
                        }
                        commands.Add(new MoveListItemCommand<Achievement>(sourceCat.Achievements, targetCat.Achievements, ach, newTargetIndex, originalIndex));
                    }
                }
            }
            else if (firstDraggedItem is AchievementCategory)
            {
                var categories = draggedNodes.Select(n => n.Tag).OfType<AchievementCategory>().ToList();
                if (targetNode.Tag is AchievementCategory targetCat && categories.Any())
                {
                    int targetIndex = _currentProject.AchievementCategories.IndexOf(targetCat);
                    if (targetIndex < 0) targetIndex = _currentProject.AchievementCategories.Count;

                    var sortedCategories = categories
                        .OrderByDescending(c => _currentProject.AchievementCategories.IndexOf(c))
                        .ToList();

                    foreach (var cat in sortedCategories)
                    {
                        int originalIndex = _currentProject.AchievementCategories.IndexOf(cat);
                        int newTargetIndex = targetIndex;
                        if (originalIndex != -1 && originalIndex < newTargetIndex)
                        {
                            newTargetIndex--;
                        }
                        commands.Add(new MoveListItemCommand<AchievementCategory>(_currentProject.AchievementCategories, _currentProject.AchievementCategories, cat, newTargetIndex, originalIndex));
                        targetIndex++;
                    }
                }
            }

            if (commands.Any())
            {
                _undoRedoService.Execute(new CompositeCommand(commands));
            }
        }

        private void MoveSelectedItemsUp()
        {
            var movableNodes = _selectedNodes
                .Where(n => n.Tag is IGuideItem && n.Parent != null)
                .OrderBy(n => n.Index)
                .ToList();

            if (!movableNodes.Any() || movableNodes.First().Index == 0) return;

            var firstItem = movableNodes.First().Tag;
            var commands = new List<ICommand>();

            if (firstItem is Achievement)
            {
                var parentList = (movableNodes.First().Parent.Tag as AchievementCategory)?.Achievements;
                if (parentList == null) return;
                var achievementsToMove = movableNodes.Select(n => n.Tag).OfType<Achievement>().ToList();
                foreach (var ach in achievementsToMove)
                {
                    int currentIndex = parentList.IndexOf(ach);
                    if (currentIndex > 0)
                    {
                        commands.Add(new MoveListItemCommand<Achievement>(parentList, parentList, ach, currentIndex - 1, currentIndex));
                    }
                }
            }
            else if (firstItem is AchievementCategory)
            {
                var categoriesToMove = movableNodes.Select(n => n.Tag).OfType<AchievementCategory>().ToList();
                foreach (var cat in categoriesToMove)
                {
                    int currentIndex = _currentProject.AchievementCategories.IndexOf(cat);
                    if (currentIndex > 0)
                    {
                        commands.Add(new MoveListItemCommand<AchievementCategory>(_currentProject.AchievementCategories, _currentProject.AchievementCategories, cat, currentIndex - 1, currentIndex));
                    }
                }
            }

            if (commands.Any())
            {
                _undoRedoService.Execute(new CompositeCommand(commands));
            }
        }

        private void MoveSelectedItemsDown()
        {
            var movableNodes = _selectedNodes
                .Where(n => n.Tag is IGuideItem && n.Parent != null)
                .OrderByDescending(n => n.Index)
                .ToList();

            if (!movableNodes.Any()) return;

            var firstNode = movableNodes.First();
            var parentNode = firstNode.Parent;
            if (parentNode == null || firstNode.Index >= parentNode.Nodes.Count - 1) return;

            var firstItem = firstNode.Tag;
            var commands = new List<ICommand>();

            if (firstItem is Achievement)
            {
                var parentList = (parentNode.Tag as AchievementCategory)?.Achievements;
                if (parentList == null) return;
                var achievementsToMove = movableNodes.Select(n => n.Tag).OfType<Achievement>().ToList();
                foreach (var ach in achievementsToMove)
                {
                    int currentIndex = parentList.IndexOf(ach);
                    if (currentIndex != -1 && currentIndex < parentList.Count - 1)
                    {
                        commands.Add(new MoveListItemCommand<Achievement>(parentList, parentList, ach, currentIndex + 1, currentIndex));
                    }
                }
            }
            else if (firstItem is AchievementCategory)
            {
                var categoriesToMove = movableNodes.Select(n => n.Tag).OfType<AchievementCategory>().ToList();
                foreach (var cat in categoriesToMove)
                {
                    int currentIndex = _currentProject.AchievementCategories.IndexOf(cat);
                    if (currentIndex != -1 && currentIndex < _currentProject.AchievementCategories.Count - 1)
                    {
                        commands.Add(new MoveListItemCommand<AchievementCategory>(_currentProject.AchievementCategories, _currentProject.AchievementCategories, cat, currentIndex + 1, currentIndex));
                    }
                }
            }

            if (commands.Any())
            {
                _undoRedoService.Execute(new CompositeCommand(commands));
            }
        }

        // After a command is executed, undone, or redone, this method updates the TreeView
        // to reflect the new state of the data model.
        private void UpdateTreeViewFromCommand(ICommand command, bool isUndo)
        {
            tvGuideStructure.BeginUpdate();

            var modelsToReselect = new List<object?>();

            if (command is CompositeCommand composite)
            {
                var subCommands = isUndo ? composite.Commands.Reverse() : composite.Commands;
                foreach (var subCmd in subCommands)
                {
                    modelsToReselect.AddRange(HandleSingleCommand(subCmd, isUndo));
                }
            }
            else
            {
                modelsToReselect.AddRange(HandleSingleCommand(command, isUndo));
            }

            ReselectNodesFromModels(modelsToReselect);

            tvGuideStructure.EndUpdate();
            UpdateEditorPanel();
        }

        // Processes a single command to determine how the TreeView should be updated.
        private List<object?> HandleSingleCommand(ICommand command, bool isUndo)
        {
            var affectedModels = new List<object?>();
            switch (command)
            {
                case AddListItemCommand<Achievement> cmd: affectedModels.Add(HandleAdd(cmd.Item, isUndo, cmd)); break;
                case AddListItemCommand<AchievementCategory> cmd: affectedModels.Add(HandleAdd(cmd.Item, isUndo, cmd)); break;
                case AddListItemCommand<Leaderboard> cmd: affectedModels.Add(HandleAdd(cmd.Item, isUndo, cmd)); break;
                case AddListItemCommand<Credit> cmd: affectedModels.Add(HandleAdd(cmd.Item, isUndo, cmd)); break;
                case RemoveListItemCommand<Achievement> cmd: affectedModels.Add(HandleRemove(cmd.Item, isUndo, cmd.OriginalIndex)); break;
                case RemoveListItemCommand<AchievementCategory> cmd: affectedModels.Add(HandleRemove(cmd.Item, isUndo, cmd.OriginalIndex)); break;
                case RemoveListItemCommand<Leaderboard> cmd: affectedModels.Add(HandleRemove(cmd.Item, isUndo, cmd.OriginalIndex)); break;
                case RemoveListItemCommand<Credit> cmd: affectedModels.Add(HandleRemove(cmd.Item, isUndo, cmd.OriginalIndex)); break;
                case MoveListItemCommand<Achievement> cmd: affectedModels.Add(HandleMove(cmd, isUndo)); break;
                case MoveListItemCommand<AchievementCategory> cmd: affectedModels.Add(HandleMove(cmd, isUndo)); break;
                case EditPropertyCommand cmd when cmd.IsMajorChange: affectedModels.Add(HandleEdit(cmd.TargetObject)); break;
            }
            return affectedModels;
        }

        private IGuideItem? HandleAdd<T>(IGuideItem item, bool isUndo, AddListItemCommand<T> cmd)
        {
            if (isUndo)
            {
                return HandleRemove(item, false, -1);
            }
            else
            {
                int index = -1;
                if (item is AchievementCategory cat) index = _currentProject.AchievementCategories.IndexOf(cat);
                else if (item is Achievement ach)
                {
                    var parentCat = _currentProject.AchievementCategories.FirstOrDefault(c => c.Achievements.Contains(ach));
                    if (parentCat != null) index = parentCat.Achievements.IndexOf(ach);
                }

                return HandleAdd(item, index);
            }
        }

        private IGuideItem? HandleAdd(IGuideItem item, int index)
        {
            var parentNode = FindParentNode(item);
            if (parentNode != null)
            {
                var newNode = _treeViewManagerService.CreateNodeForItem(item);

                int finalIndex = index;
                if (item is AchievementCategory && parentNode.Tag is string tag && tag == "AchievementGuideRoot")
                {
                    finalIndex++;
                }

                if (finalIndex >= 0 && finalIndex < parentNode.Nodes.Count)
                {
                    parentNode.Nodes.Insert(finalIndex, newNode);
                }
                else
                {
                    parentNode.Nodes.Add(newNode);
                }
                return item;
            }
            return null;
        }

        private IGuideItem? HandleRemove(IGuideItem item, bool isUndo, int originalIndex)
        {
            if (isUndo)
            {
                return HandleAdd(item, originalIndex);
            }
            else
            {
                var nodeToRemove = _treeViewManagerService.FindNodeByModel(tvGuideStructure.Nodes, item);
                if (nodeToRemove != null)
                {
                    nodeToRemove.Remove();
                }
                return item;
            }
        }

        private IGuideItem? HandleMove<T>(MoveListItemCommand<T> cmd, bool isUndo) where T : IGuideItem
        {
            var item = cmd.Item;
            var originalSourceList = cmd.SourceList;
            var originalDestinationList = cmd.DestinationList;

            var currentSourceList = isUndo ? originalDestinationList : originalSourceList;
            var targetDestinationList = isUndo ? originalSourceList : originalDestinationList;
            int targetIndex = targetDestinationList.IndexOf(item);

            var sourceParentNode = FindParentNode(currentSourceList);
            var destParentNode = FindParentNode(targetDestinationList);

            if (sourceParentNode == null) return null;
            var nodeToMove = _treeViewManagerService.FindNodeByModel(sourceParentNode.Nodes, item);

            if (nodeToMove != null && destParentNode != null && targetIndex >= 0)
            {
                nodeToMove.Remove();
                int finalIndex = targetIndex;
                if (item is AchievementCategory && destParentNode.Tag is string tag && tag == "AchievementGuideRoot")
                {
                    finalIndex += 1; // +1 to account for the "Walkthroughs & Resources" node
                }
                destParentNode.Nodes.Insert(finalIndex, nodeToMove);
                return item;
            }
            return null;
        }

        private object? HandleEdit(object item)
        {
            var nodeToUpdate = _treeViewManagerService.FindNodeByModel(tvGuideStructure.Nodes, item);
            if (nodeToUpdate != null && nodeToUpdate.Tag is IGuideItem guideItem)
            {
                nodeToUpdate.Text = guideItem.DisplayText;
                return item;
            }
            return null;
        }

        private void ReselectNodesFromModels(IEnumerable<object?> modelsToSelect)
        {
            _selectedNodes.Clear();
            var distinctModels = modelsToSelect.OfType<object>().Distinct().ToList();
            foreach (var model in distinctModels)
            {
                var node = _treeViewManagerService.FindNodeByModel(tvGuideStructure.Nodes, model);
                if (node != null) _selectedNodes.Add(node);
            }

            UpdateSelectionAppearance();

            if (_selectedNodes.Any())
            {
                var lastNode = _selectedNodes.Last();
                tvGuideStructure.SelectedNode = lastNode;
                lastNode.EnsureVisible();
            }

            if (!tvGuideStructure.Focused)
            {
                tvGuideStructure.Focus();
            }
        }

        private TreeNode? FindParentNode(object itemOrList)
        {
            if (itemOrList is AchievementCategory)
            {
                return _treeViewManagerService.FindNodeByModel(tvGuideStructure.Nodes, "AchievementGuideRoot");
            }
            if (itemOrList is Achievement ach)
            {
                var parentCat = _currentProject.AchievementCategories.FirstOrDefault(c => c.Achievements.Contains(ach));
                if (parentCat == null) return null;
                return _treeViewManagerService.FindNodeByModel(tvGuideStructure.Nodes, parentCat);
            }
            if (itemOrList is Leaderboard)
            {
                return _treeViewManagerService.FindNodeByModel(tvGuideStructure.Nodes, "LeaderboardGuideRoot");
            }
            if (itemOrList is Credit)
            {
                return _treeViewManagerService.FindNodeByModel(tvGuideStructure.Nodes, "CreditsRoot");
            }
            if (itemOrList is BindingList<Achievement> achList)
            {
                var parentCat = _currentProject.AchievementCategories.FirstOrDefault(c => c.Achievements == achList);
                if (parentCat == null) return null;
                return _treeViewManagerService.FindNodeByModel(tvGuideStructure.Nodes, parentCat);
            }
            if (itemOrList is BindingList<AchievementCategory> catList)
            {
                if (catList == _currentProject.AchievementCategories)
                {
                    return _treeViewManagerService.FindNodeByModel(tvGuideStructure.Nodes, "AchievementGuideRoot");
                }
            }

            return null;
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}