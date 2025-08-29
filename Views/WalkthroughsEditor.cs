using RaGuideDesigner.Commands;
using RaGuideDesigner.Models;
using RaGuideDesigner.Services;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace RaGuideDesigner.Views
{
    // This editor handles the "Walkthroughs & Resources" section, which includes
    // lists of guides, playthroughs, general advice, and admonition notes.
    public partial class WalkthroughsEditor : BaseEditorControl
    {
        public WalkthroughsEditor(UndoRedoService undoRedoService) : base(undoRedoService)
        {
            InitializeComponent();
            dgvGuides.AutoGenerateColumns = false;
            dgvPlaythroughs.AutoGenerateColumns = false;
            cmbNoteType.DataSource = _admonitionMap.Keys.ToList();

            _propertyBindings.Add(txtAdviceTitle, nameof(WikiGuide.GeneralAdviceTitle));

            EnableSpellCheck(rtxtGeneralAdvice);
            EnableSpellCheck(rtxtNoteContent);

            WireUpEventHandlers();
        }

        public void ClearCaches()
        {
            rtxtGeneralAdvice.Clear();
            rtxtGeneralAdvice.ClearUndo();
            rtxtNoteContent.Clear();
            rtxtNoteContent.ClearUndo();
        }

        public void SetData(WikiGuide? guide)
        {
            _isProgrammaticChange = true;
            _dataContext = guide;

            if (guide == null)
            {
                this.Visible = false;
                _isProgrammaticChange = false;
                return;
            }

            dgvGuides.DataSource = new BindingSource { DataSource = guide.Guides };
            dgvPlaythroughs.DataSource = new BindingSource { DataSource = guide.Playthroughs };
            txtAdviceTitle.Text = guide.GeneralAdviceTitle;

            SetRichTextContent(rtxtGeneralAdvice, guide.GeneralAdvice);

            lstAdmonitions.DataSource = new BindingSource { DataSource = guide.Admonitions };
            UpdateNoteEditorSelection();

            this.Visible = true;
            _isProgrammaticChange = false;
        }

        // Updates the note editor panel when a different admonition is selected.
        private void UpdateNoteEditorSelection()
        {
            _isProgrammaticChange = true;
            if (lstAdmonitions.SelectedItem is Admonition selectedNote)
            {
                groupBox1.Enabled = true;
                cmbNoteType.SelectedItem = _admonitionMap.FirstOrDefault(x => x.Value == selectedNote.Type).Key;
                SetRichTextContent(rtxtNoteContent, selectedNote.Content);
            }
            else
            {
                groupBox1.Enabled = false;
                cmbNoteType.SelectedIndex = -1;
                rtxtNoteContent.Clear();
            }
            _isProgrammaticChange = false;
        }

        private void dgvGuides_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == colGuideDelete.Index && _dataContext is WikiGuide guide)
            {
                if (dgvGuides.Rows[e.RowIndex].DataBoundItem is ResourceLink item)
                {
                    var command = new RemoveListItemCommand<ResourceLink>(guide.Guides, item);
                    _undoRedoService.Execute(command);
                }
            }
        }

        private void dgvPlaythroughs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == colPlaythroughDelete.Index && _dataContext is WikiGuide guide)
            {
                if (dgvPlaythroughs.Rows[e.RowIndex].DataBoundItem is ResourceLink item)
                {
                    var command = new RemoveListItemCommand<ResourceLink>(guide.Playthroughs, item);
                    _undoRedoService.Execute(command);
                }
            }
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            if (_dataContext is WikiGuide guide) AddNewAdmonition(guide.Admonitions, lstAdmonitions);
        }

        private void btnRemoveNote_Click(object sender, EventArgs e)
        {
            if (_dataContext is WikiGuide guide && lstAdmonitions.SelectedItem is Admonition noteToRemove)
            {
                RemoveSelectedAdmonition(guide.Admonitions, lstAdmonitions);
            }
        }

        private void lstAdmonitions_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateNoteEditorSelection();
        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            _undoRedoService.CommitUnmanagedChange();
        }

        private void rtxtGeneralAdvice_Leave(object sender, EventArgs e)
        {
            if (_dataContext is WikiGuide guide)
            {
                HandleRichTextLeave(rtxtGeneralAdvice, guide, nameof(WikiGuide.GeneralAdvice));
            }
        }

        private void rtxtNoteContent_Leave(object sender, EventArgs e)
        {
            if (lstAdmonitions.SelectedItem is Admonition selectedNote)
            {
                HandleRichTextLeave(rtxtNoteContent, selectedNote, nameof(Admonition.Content));
            }
        }

        private void cmbNoteType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAdmonitions.SelectedItem is Admonition selectedNote)
            {
                UpdateAdmonition(lstAdmonitions, cmbNoteType, rtxtNoteContent);
            }
        }
    }
}