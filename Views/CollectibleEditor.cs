using RaGuideDesigner.Commands;
using RaGuideDesigner.Models;
using RaGuideDesigner.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace RaGuideDesigner.Views
{
    public partial class CollectibleEditor : BaseEditorControl
    {
        private Achievement? _currentAchievement = null;
        private readonly List<TreeNode> _selectedNodes = new List<TreeNode>();
        private TreeNode? _dragStartNode;
        private Point _dragStartPoint;
        private TreeNode? _rightClickedNode;

        public CollectibleEditor(UndoRedoService undoRedoService) : base(undoRedoService)
        {
            InitializeComponent();
            cmbAchPoints.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 10, 15, 25, 50, 100 });

            EnableSpellCheck(rtxtIntro);
            EnableSpellCheck(rtxtItemDescription);
        }

        public void ClearCaches() { }

        // This method saves any pending changes from the active editor panel to the model.
        // It's carefully designed to handle multi-selection, where the panels are blank,
        // to avoid accidentally overwriting data.
        public override void CommitChanges()
        {
            // If more than one item is selected, the editor panel is blank by design.
            // Do not proceed, as this would wipe the data of the last focused item.
            if (_selectedNodes.Count > 1) return;

            if (_isProgrammaticChange || _currentAchievement == null) return;

            var lastSelectedNode = _selectedNodes.LastOrDefault();
            if (lastSelectedNode == null) return;

            var commands = new List<ICommand>();

            // General Achievement Properties
            if (_currentAchievement.CollectibleIntro != MarkdownRtfConverter.ToMarkdown(rtxtIntro.Rtf ?? ""))
            {
                commands.Add(new EditPropertyCommand(_currentAchievement, nameof(Achievement.CollectibleIntro), _currentAchievement.CollectibleIntro, MarkdownRtfConverter.ToMarkdown(rtxtIntro.Rtf ?? "")));
            }
            if (_currentAchievement.MeasuredIndicator != txtOutro.Text)
            {
                commands.Add(new EditPropertyCommand(_currentAchievement, nameof(Achievement.MeasuredIndicator), _currentAchievement.MeasuredIndicator, txtOutro.Text));
            }

            // Selected Item Properties
            if (lastSelectedNode.Tag is CollectibleGroup group)
            {
                if (group.Title != txtGroupTitle.Text)
                {
                    commands.Add(new EditPropertyCommand(group, nameof(CollectibleGroup.Title), group.Title, txtGroupTitle.Text));
                }
            }
            else if (lastSelectedNode.Tag is CollectibleItem item)
            {
                string newDescription = MarkdownRtfConverter.ToMarkdown(rtxtItemDescription.Rtf ?? string.Empty);
                if (item.Description != newDescription)
                {
                    commands.Add(new EditPropertyCommand(item, nameof(CollectibleItem.Description), item.Description ?? "", newDescription));
                }

                if (item.UrlText != txtItemUrlText.Text)
                {
                    commands.Add(new EditPropertyCommand(item, nameof(CollectibleItem.UrlText), item.UrlText, txtItemUrlText.Text));
                }

                if (item.Url != txtItemUrl.Text)
                {
                    commands.Add(new EditPropertyCommand(item, nameof(CollectibleItem.Url), item.Url, txtItemUrl.Text));
                }
            }

            if (commands.Any())
            {
                ExecuteUndoableTextChange(new CompositeCommand(commands));
            }
        }

        // A special method to wrap text changes with another command that reserializes
        // the achievement's main `GuidanceAndInsights` property.
        private void ExecuteUndoableTextChange(ICommand primaryCommand)
        {
            if (_currentAchievement == null) return;

            var oldGuidance = _currentAchievement.SerializeCollectibleGuidance();
            var updateGuidanceCmd = new ActionCommand(
                executeAction: () =>
                {
                    var newGuidance = _currentAchievement.SerializeCollectibleGuidance();
                    _currentAchievement.GetType().GetProperty(nameof(Achievement.GuidanceAndInsights))?.SetValue(_currentAchievement, newGuidance);
                },
                unexecuteAction: () =>
                {
                    _currentAchievement.GetType().GetProperty(nameof(Achievement.GuidanceAndInsights))?.SetValue(_currentAchievement, oldGuidance);
                }
            );

            var composite = new CompositeCommand(new[] { primaryCommand, updateGuidanceCmd });
            _undoRedoService.Execute(composite);
        }

        // This is called when the structure of the collectible tree changes (e.g., add, delete, move).
        // It reserializes the guidance string and rebuilds the TreeView to reflect the new structure.
        private void CommitStructuralChange()
        {
            if (_currentAchievement == null) return;

            _currentAchievement.GuidanceAndInsights = _currentAchievement.SerializeCollectibleGuidance();
            _undoRedoService.CommitUnmanagedChange();

            var selectedTags = _selectedNodes.Select(n => n.Tag).ToList();
            PopulateTreeView(_currentAchievement.CollectibleGroups);
            ReselectNodesByTags(selectedTags);
            UpdateEditorPanelForSelection();
        }

        // Shows the correct editor panel (group or item) based on the current selection.
        // If nothing or multiple items are selected, both panels are disabled.
        private void UpdateEditorPanelForSelection()
        {
            _isProgrammaticChange = true;
            var node = _selectedNodes.LastOrDefault();
            bool singleNodeSelected = node != null && _selectedNodes.Count == 1;

            if (singleNodeSelected && node?.Tag is CollectibleGroup group)
            {
                grpGroupEditor.Enabled = true;
                grpItemEditor.Enabled = false;
                txtGroupTitle.Text = group.Title;
                rtxtItemDescription.Clear();
                txtItemUrlText.Clear();
                txtItemUrl.Clear();
            }
            else if (singleNodeSelected && node?.Tag is CollectibleItem item)
            {
                grpGroupEditor.Enabled = false;
                grpItemEditor.Enabled = true;
                txtGroupTitle.Clear();
                SetRichTextContent(rtxtItemDescription, item.Description);
                txtItemUrlText.Text = item.UrlText;
                txtItemUrl.Text = item.Url;
            }
            else // No selection or multi-selection
            {
                grpGroupEditor.Enabled = false;
                grpItemEditor.Enabled = false;
                txtGroupTitle.Clear();
                rtxtItemDescription.Clear();
                txtItemUrlText.Clear();
                txtItemUrl.Clear();
            }
            _isProgrammaticChange = false;
        }

        #region Data and UI Sync
        // Binds an achievement to the editor, first parsing its guidance text into the tree structure.
        public void SetData(Achievement? achievement, object? parentData)
        {
            if (_currentAchievement != null && _currentAchievement != achievement)
            {
                CommitChanges();
            }

            _isProgrammaticChange = true;
            _dataContext = achievement;
            _currentAchievement = achievement;
            _selectedNodes.Clear();


            if (achievement == null)
            {
                this.Visible = false;
                _isProgrammaticChange = false;
                return;
            }

            achievement.ParseGuidanceAsCollectible();

            txtAchTitle.Text = achievement.Title;
            lblAchId.Text = achievement.Id.ToString();
            cmbAchPoints.SelectedItem = achievement.Points;
            LoadImage(achievement.BadgeUrl);

            SetRichTextContent(rtxtIntro, achievement.CollectibleIntro);
            PopulateTreeView(achievement.CollectibleGroups);
            txtOutro.Text = achievement.MeasuredIndicator;

            UpdateEditorPanelForSelection();

            this.Visible = true;
            _isProgrammaticChange = false;
        }

        private void PopulateTreeView(BindingList<CollectibleGroup> groups)
        {
            tvCollectibles.BeginUpdate();
            tvCollectibles.Nodes.Clear();
            foreach (var group in groups)
            {
                var groupNode = new TreeNode(group.Title) { Tag = group };
                foreach (var item in group.Items)
                {
                    var itemText = item.Description?.Replace("\n", " ").Trim() ?? "New Item";
                    if (itemText.Length > 50) itemText = itemText.Substring(0, 50) + "...";
                    if (string.IsNullOrWhiteSpace(itemText)) itemText = "New Item";
                    groupNode.Nodes.Add(new TreeNode(itemText) { Tag = item });
                }
                tvCollectibles.Nodes.Add(groupNode);
            }
            tvCollectibles.ExpandAll();
            tvCollectibles.EndUpdate();
        }

        private void tvCollectibles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (_isProgrammaticChange) return;
            UpdateEditorPanelForSelection();
        }
        #endregion

        #region Standard UI Event Handlers
        private void cmbAchPoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isProgrammaticChange || _currentAchievement == null || cmbAchPoints.SelectedItem == null) return;
            int oldValue = _currentAchievement.Points;
            if (int.TryParse(cmbAchPoints.SelectedItem.ToString(), out int newValue) && oldValue != newValue)
            {
                var command = new EditPropertyCommand(_currentAchievement, nameof(Achievement.Points), oldValue, newValue);
                _undoRedoService.Execute(command);
            }
        }

        private void LoadImage(string url)
        {
            try { if (!string.IsNullOrWhiteSpace(url)) pbAchBadge.LoadAsync(url); else pbAchBadge.Image = null; }
            catch { pbAchBadge.Image = null; }
        }
        #endregion

        #region Multi-select, Context Menu, Drag-Drop, and Keyboard Logic

        // This is a custom mouse click handler to implement Ctrl-click and Shift-click multi-selection.
        private void tvCollectibles_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // Commit any pending changes from the *previous* selection state BEFORE processing the new click.
            CommitChanges();

            _rightClickedNode = e.Node;

            if (e.Button == MouseButtons.Left)
            {
                if (ModifierKeys == Keys.Control)
                {
                    if (_selectedNodes.Contains(e.Node)) _selectedNodes.Remove(e.Node);
                    else _selectedNodes.Add(e.Node);
                }
                else if (ModifierKeys == Keys.Shift)
                {
                    var lastNode = _selectedNodes.LastOrDefault();
                    if (lastNode != null && lastNode.Parent == e.Node.Parent && lastNode != e.Node)
                    {
                        var parent = e.Node.Parent;
                        var nodes = parent?.Nodes ?? tvCollectibles.Nodes;
                        int index1 = nodes.IndexOf(lastNode);
                        int index2 = nodes.IndexOf(e.Node);
                        int start = Math.Min(index1, index2);
                        int end = Math.Max(index1, index2);

                        _selectedNodes.Clear();
                        for (int i = start; i <= end; i++)
                        {
                            if (!_selectedNodes.Contains(nodes[i]))
                            {
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
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (e.Node != null && !_selectedNodes.Contains(e.Node))
                {
                    ClearAndSelectNode(e.Node);
                }
            }

            UpdateSelectionAppearance();
            if (tvCollectibles.SelectedNode != _selectedNodes.LastOrDefault())
            {
                tvCollectibles.SelectedNode = _selectedNodes.LastOrDefault();
            }
            UpdateEditorPanelForSelection();
        }

        private void tvCollectibles_MouseDown(object sender, MouseEventArgs e)
        {
            var nodeUnderMouse = tvCollectibles.GetNodeAt(e.X, e.Y);

            // If we're clicking a different node or empty space, commit the changes from the currently active editor.
            if (nodeUnderMouse == null || !_selectedNodes.Contains(nodeUnderMouse))
            {
                CommitChanges();
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
                UpdateEditorPanelForSelection();
            }
        }

        private void addCollectibleGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentAchievement == null) return;
            var newGroup = new CollectibleGroup();
            _currentAchievement.CollectibleGroups.Add(newGroup);
            _selectedNodes.Clear();
            _selectedNodes.Add(new TreeNode() { Tag = newGroup });
            CommitStructuralChange();
        }

        private void addCollectibleItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentAchievement == null || _rightClickedNode == null) return;
            CollectibleGroup? targetGroup = (_rightClickedNode.Tag as CollectibleGroup) ?? (_rightClickedNode.Parent?.Tag as CollectibleGroup);

            if (targetGroup != null)
            {
                var newItem = new CollectibleItem { Description = "New Item" };
                targetGroup.Items.Add(newItem);
                _selectedNodes.Clear();
                _selectedNodes.Add(new TreeNode() { Tag = newItem });
                CommitStructuralChange();
            }
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentAchievement == null || !_selectedNodes.Any()) return;
            bool changed = false;
            var newSelectionTags = new List<object>();

            var orderedSelection = _selectedNodes.OrderBy(n => n.Index).ToList();

            foreach (var node in orderedSelection)
            {
                if (node.Tag is CollectibleGroup group)
                {
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(group);
                    var clone = Newtonsoft.Json.JsonConvert.DeserializeObject<CollectibleGroup>(json);
                    if (clone == null) continue;
                    clone.Title += " (Copy)";

                    int index = _currentAchievement.CollectibleGroups.IndexOf(group);
                    if (index != -1)
                    {
                        _currentAchievement.CollectibleGroups.Insert(index + 1, clone);
                        newSelectionTags.Add(clone);
                        changed = true;
                    }
                }
                else if (node.Tag is CollectibleItem item)
                {
                    var parentGroup = _currentAchievement.CollectibleGroups.FirstOrDefault(g => g.Items.Contains(item));
                    if (parentGroup == null) continue;

                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(item);
                    var clone = Newtonsoft.Json.JsonConvert.DeserializeObject<CollectibleItem>(json);
                    if (clone == null) continue;

                    clone.ItemNumber = null;
                    if (!string.IsNullOrEmpty(clone.Description)) clone.Description += " (Copy)";
                    else clone.Description = "New Item (Copy)";

                    int index = parentGroup.Items.IndexOf(item);
                    if (index != -1)
                    {
                        parentGroup.Items.Insert(index + 1, clone);
                        newSelectionTags.Add(clone);
                        changed = true;
                    }
                }
            }

            if (changed)
            {
                _selectedNodes.Clear();
                _selectedNodes.AddRange(newSelectionTags.Select(tag => new TreeNode { Tag = tag }));
                CommitStructuralChange();
            }
        }


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentAchievement == null || !_selectedNodes.Any()) return;

            var groupsToDelete = _selectedNodes.Select(n => n.Tag).OfType<CollectibleGroup>().ToList();
            foreach (var group in groupsToDelete) _currentAchievement.CollectibleGroups.Remove(group);

            var itemsToDelete = _selectedNodes.Select(n => n.Tag).OfType<CollectibleItem>().ToList();
            var itemsByGroup = itemsToDelete.GroupBy(item => _currentAchievement.CollectibleGroups.FirstOrDefault(g => g.Items.Contains(item)));
            foreach (var grouping in itemsByGroup)
            {
                if (grouping.Key is CollectibleGroup parentGroup)
                {
                    foreach (var item in grouping) parentGroup.Items.Remove(item);
                }
            }

            _selectedNodes.Clear();
            CommitStructuralChange();
        }

        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e) => MoveSelectedItemsUp();
        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e) => MoveSelectedItemsDown();

        private void ctxMenuTree_Opening(object sender, CancelEventArgs e)
        {
            bool isNodeClicked = _rightClickedNode != null;
            bool canAddGroup = !isNodeClicked;
            bool canAddItem = isNodeClicked && _selectedNodes.Count == 1;

            addCollectibleGroupToolStripMenuItem.Visible = canAddGroup;
            addCollectibleItemToolStripMenuItem.Visible = canAddItem;

            duplicateToolStripMenuItem.Visible = isNodeClicked;
            deleteToolStripMenuItem.Visible = isNodeClicked;
            moveUpToolStripMenuItem.Visible = isNodeClicked;
            moveDownToolStripMenuItem.Visible = isNodeClicked;

            toolStripSeparator3.Visible = canAddItem || canAddGroup;
            toolStripSeparator2.Visible = isNodeClicked;
        }

        private void tvCollectibles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                deleteToolStripMenuItem_Click(sender, e);
            }
            else if (e.Alt && (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down))
            {
                e.SuppressKeyPress = true;
                if (e.KeyCode == Keys.Up) MoveSelectedItemsUp();
                else MoveSelectedItemsDown();
            }
        }

        private void tvCollectibles_MouseMove(object sender, MouseEventArgs e)
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
                    }
                    DoDragDrop(_selectedNodes, DragDropEffects.Move);
                    _dragStartNode = null;
                }
            }
        }

        private void tvCollectibles_DragEnter(object sender, DragEventArgs e) => e.Effect = DragDropEffects.Move;
        private void tvCollectibles_DragOver(object sender, DragEventArgs e) => tvCollectibles.SelectedNode = tvCollectibles.GetNodeAt(tvCollectibles.PointToClient(new Point(e.X, e.Y)));

        // Handles the logic for dropping nodes onto other nodes to reorder them.
        private void tvCollectibles_DragDrop(object sender, DragEventArgs e)
        {
            var targetNode = tvCollectibles.GetNodeAt(tvCollectibles.PointToClient(new Point(e.X, e.Y)));
            if (e.Data?.GetData(typeof(List<TreeNode>)) is not List<TreeNode> draggedNodes || !draggedNodes.Any() || _currentAchievement == null) return;

            bool changed = false;
            var firstDraggedItem = draggedNodes.First().Tag;

            if (firstDraggedItem is CollectibleGroup)
            {
                var groups = draggedNodes.Select(n => n.Tag).OfType<CollectibleGroup>().ToList();
                var list = _currentAchievement.CollectibleGroups;
                int targetIndex = (targetNode?.Tag is CollectibleGroup tg) ? list.IndexOf(tg) : list.Count;
                var sortedGroups = groups.OrderByDescending(list.IndexOf).ToList();
                foreach (var group in sortedGroups)
                {
                    int originalIndex = list.IndexOf(group);
                    if (originalIndex != -1)
                    {
                        list.RemoveAt(originalIndex);
                        int newIndex = targetIndex;
                        if (originalIndex < newIndex) newIndex--;
                        list.Insert(newIndex, group);
                        changed = true;
                    }
                }
            }
            else if (firstDraggedItem is CollectibleItem)
            {
                var items = draggedNodes.Select(n => n.Tag).OfType<CollectibleItem>().ToList();
                var sourceGroup = _currentAchievement.CollectibleGroups.FirstOrDefault(g => g.Items.Contains(items.First()));
                var targetGroup = (targetNode?.Tag as CollectibleGroup) ?? (targetNode?.Parent?.Tag as CollectibleGroup);

                if (sourceGroup != null && targetGroup != null)
                {
                    var targetItem = targetNode?.Tag as CollectibleItem;
                    int targetIndex = (targetItem != null && targetGroup.Items.Contains(targetItem)) ? targetGroup.Items.IndexOf(targetItem) : targetGroup.Items.Count;
                    var sortedItems = items.OrderByDescending(i => sourceGroup.Items.Contains(i) ? sourceGroup.Items.IndexOf(i) : -1).ToList();

                    foreach (var item in sortedItems)
                    {
                        int originalIndex = sourceGroup.Items.IndexOf(item);
                        if (originalIndex == -1) continue;

                        int newIndex = targetIndex;
                        if (ReferenceEquals(sourceGroup, targetGroup) && originalIndex < newIndex) newIndex--;

                        sourceGroup.Items.RemoveAt(originalIndex);
                        targetGroup.Items.Insert(newIndex, item);
                        changed = true;
                    }
                }
            }

            if (changed) CommitStructuralChange();
        }

        #endregion

        #region Helper Methods (Multi-select, Move, etc.)
        private void ClearAndSelectNode(TreeNode? node)
        {
            _selectedNodes.Clear();
            if (node != null) _selectedNodes.Add(node);
        }

        private void UpdateSelectionAppearance()
        {
            foreach (TreeNode node in tvCollectibles.Nodes)
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
            rootNode.BackColor = tvCollectibles.BackColor;
            rootNode.ForeColor = tvCollectibles.ForeColor;
            foreach (TreeNode node in rootNode.Nodes)
            {
                ResetNodeAppearance(node);
            }
        }

        private void ReselectNodesByTags(IEnumerable<object?> tags)
        {
            _selectedNodes.Clear();
            foreach (var tag in tags)
            {
                if (tag == null) continue;
                var node = FindNodeByTag(tvCollectibles.Nodes, tag);
                if (node != null) _selectedNodes.Add(node);
            }
            UpdateSelectionAppearance();
            if (_selectedNodes.Any())
            {
                var lastNode = _selectedNodes.Last();
                tvCollectibles.SelectedNode = lastNode;
                lastNode.EnsureVisible();
            }
        }

        private TreeNode? FindNodeByTag(TreeNodeCollection nodes, object tag)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Tag != null && node.Tag.Equals(tag)) return node;
                var foundInChild = FindNodeByTag(node.Nodes, tag);
                if (foundInChild != null) return foundInChild;
            }
            return null;
        }

        private void MoveSelectedItemsUp()
        {
            if (_currentAchievement == null || !_selectedNodes.Any()) return;
            bool changed = false;

            var firstItem = _selectedNodes.First().Tag;

            if (firstItem is CollectibleGroup)
            {
                var list = _currentAchievement.CollectibleGroups;
                var groupsToMove = _selectedNodes.Select(n => n.Tag).OfType<CollectibleGroup>().OrderBy(list.IndexOf).ToList();
                foreach (var group in groupsToMove)
                {
                    int index = list.IndexOf(group);
                    if (index > 0)
                    {
                        list.RemoveAt(index);
                        list.Insert(index - 1, group);
                        changed = true;
                    }
                }
            }
            else if (firstItem is CollectibleItem itemToMove)
            {
                var parentGroup = _currentAchievement.CollectibleGroups.FirstOrDefault(g => g.Items.Contains(itemToMove));
                if (parentGroup == null) return;
                var list = parentGroup.Items;
                var itemsToMove = _selectedNodes.Select(n => n.Tag).OfType<CollectibleItem>().OrderBy(list.IndexOf).ToList();
                foreach (var item in itemsToMove)
                {
                    int index = list.IndexOf(item);
                    if (index > 0)
                    {
                        list.RemoveAt(index);
                        list.Insert(index - 1, item);
                        changed = true;
                    }
                }
            }
            if (changed) CommitStructuralChange();
        }

        private void MoveSelectedItemsDown()
        {
            if (_currentAchievement == null || !_selectedNodes.Any()) return;
            bool changed = false;

            var firstItem = _selectedNodes.First().Tag;

            if (firstItem is CollectibleGroup)
            {
                var list = _currentAchievement.CollectibleGroups;
                var groupsToMove = _selectedNodes.Select(n => n.Tag).OfType<CollectibleGroup>().OrderByDescending(list.IndexOf).ToList();
                foreach (var group in groupsToMove)
                {
                    int index = list.IndexOf(group);
                    if (index < list.Count - 1)
                    {
                        list.RemoveAt(index);
                        list.Insert(index + 1, group);
                        changed = true;
                    }
                }
            }
            else if (firstItem is CollectibleItem itemToMove)
            {
                var parentGroup = _currentAchievement.CollectibleGroups.FirstOrDefault(g => g.Items.Contains(itemToMove));
                if (parentGroup == null) return;
                var list = parentGroup.Items;
                var itemsToMove = _selectedNodes.Select(n => n.Tag).OfType<CollectibleItem>().OrderByDescending(list.IndexOf).ToList();
                foreach (var item in itemsToMove)
                {
                    int index = list.IndexOf(item);
                    if (index < list.Count - 1)
                    {
                        list.RemoveAt(index);
                        list.Insert(index + 1, item);
                        changed = true;
                    }
                }
            }
            if (changed) CommitStructuralChange();
        }

        #endregion

        #region Textbox Context Menu
        private void cutToolStripMenuItem1_Click(object sender, EventArgs e) => txtGroupTitle.Cut();
        private void copyToolStripMenuItem1_Click(object sender, EventArgs e) => txtGroupTitle.Copy();
        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e) => txtGroupTitle.Paste();
        #endregion
    }
}