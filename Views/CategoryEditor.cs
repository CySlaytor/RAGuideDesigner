using RaGuideDesigner.Commands;
using RaGuideDesigner.Models;
using RaGuideDesigner.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace RaGuideDesigner.Views
{
    public partial class CategoryEditor : BaseEditorControl
    {
        private AchievementCategory? _currentCategory;

        public CategoryEditor(UndoRedoService undoRedoService) : base(undoRedoService)
        {
            InitializeComponent();
            cmbNoteType.DataSource = _admonitionMap.Keys.ToList();
            _propertyBindings.Add(txtCatTitle, nameof(AchievementCategory.Title));

            cmbCatIcon.Items.AddRange(new string[] { "🏆", "🎖️", "🏵️" });

            EnableSpellCheck(rtxtDescription);
            EnableSpellCheck(rtxtNoteContent);

            WireUpEventHandlers();
        }

        // Binds an AchievementCategory object to the editor controls.
        public void SetData(AchievementCategory? category)
        {
            if (_currentCategory != null)
            {
                CommitRichTextChanges();
            }

            _isProgrammaticChange = true;
            _dataContext = category;
            _currentCategory = category;

            if (category == null)
            {
                this.Visible = false;
                _isProgrammaticChange = false;
                return;
            }

            txtCatTitle.Text = category.Title;

            if (cmbCatIcon.Items.Contains(category.Icon))
            {
                cmbCatIcon.SelectedItem = category.Icon;
            }
            else
            {
                cmbCatIcon.SelectedIndex = 0; // Default to "🏆"
            }

            SetRichTextContent(rtxtDescription, category.Description);

            int totalPoints = category.Achievements.Sum(a => a.Points);
            lblTotalPoints.Text = $"Total Points: {totalPoints}";

            lstAdmonitions.DataSource = new BindingSource { DataSource = category.Admonitions };
            UpdateNoteEditorSelection();

            this.Visible = true;
            _isProgrammaticChange = false;
        }

        public void UpdateStatistics()
        {
            if (_dataContext is AchievementCategory category)
            {
                int totalPoints = category.Achievements.Sum(a => a.Points);
                lblTotalPoints.Text = $"Total Points: {totalPoints}";
            }
        }

        // Makes sure any pending changes in the RichTextBoxes are saved.
        private void CommitRichTextChanges()
        {
            if (_currentCategory == null) return;
            HandleRichTextLeave(rtxtDescription, _currentCategory, nameof(AchievementCategory.Description));
            if (lstAdmonitions.SelectedItem is Admonition selectedNote)
            {
                HandleRichTextLeave(rtxtNoteContent, selectedNote, nameof(Admonition.Content));
            }
        }

        // Updates the note editor panel when a different note is selected from the list.
        private void UpdateNoteEditorSelection()
        {
            _isProgrammaticChange = true;
            if (lstAdmonitions.SelectedItem is Admonition selectedNote)
            {
                groupBox2.Enabled = true;
                cmbNoteType.SelectedItem = _admonitionMap.FirstOrDefault(x => x.Value == selectedNote.Type).Key;
                SetRichTextContent(rtxtNoteContent, selectedNote.Content);
            }
            else
            {
                groupBox2.Enabled = false;
                cmbNoteType.SelectedIndex = -1;
                rtxtNoteContent.Clear();
            }
            _isProgrammaticChange = false;
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            if (_dataContext is AchievementCategory cat) AddNewAdmonition(cat.Admonitions, lstAdmonitions);
        }

        private void btnRemoveNote_Click(object sender, EventArgs e)
        {
            if (_dataContext is AchievementCategory cat && lstAdmonitions.SelectedItem is Admonition noteToRemove)
            {
                RemoveSelectedAdmonition(cat.Admonitions, lstAdmonitions);
            }
        }

        private void lstAdmonitions_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateNoteEditorSelection();
        }

        // Opens the dedicated pop-up form for editing the "Additional Notes" section.
        private void btnEditAdditionalNotes_Click(object sender, EventArgs e)
        {
            if (_dataContext is not AchievementCategory category) return;
            using (var form = new AdditionalNotesEditorForm())
            {
                form.NotesContent = category.AdditionalNotes;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (category.AdditionalNotes != form.NotesContent)
                    {
                        var command = new EditPropertyCommand(category, nameof(AchievementCategory.AdditionalNotes), category.AdditionalNotes, form.NotesContent);
                        _undoRedoService.Execute(command);
                    }
                }
            }
        }

        private void rtxtDescription_Leave(object sender, EventArgs e)
        {
            if (_currentCategory != null) HandleRichTextLeave(rtxtDescription, _currentCategory, nameof(AchievementCategory.Description));
        }

        private void rtxtNoteContent_Leave(object sender, EventArgs e)
        {
            if (lstAdmonitions.SelectedItem is Admonition selectedNote)
            {
                // This will create a command and execute it, which modifies the model
                HandleRichTextLeave(rtxtNoteContent, selectedNote, nameof(Admonition.Content));

                // Because Admonition.ToString() depends on Content, we need to tell the listbox to update its text
                if (lstAdmonitions.DataSource is BindingSource bs)
                {
                    // Find the object in the list that matches the one we just edited
                    int index = bs.IndexOf(selectedNote);
                    if (index != -1)
                        bs.ResetItem(index); // This tells the binding source that the item at this index has changed
                }
            }
        }

        private void cmbNoteType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAdmonitions.SelectedItem is Admonition selectedNote)
            {
                UpdateAdmonition(lstAdmonitions, cmbNoteType, rtxtNoteContent);
            }
        }

        private void cmbCatIcon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isProgrammaticChange || _currentCategory == null) return;

            string oldValue = _currentCategory.Icon;
            string newValue = cmbCatIcon.SelectedItem?.ToString() ?? "🏆";

            if (oldValue != newValue)
            {
                var command = new EditPropertyCommand(_currentCategory, nameof(AchievementCategory.Icon), oldValue, newValue);
                _undoRedoService.Execute(command);
            }
        }
    }
}