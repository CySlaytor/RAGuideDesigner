using RaGuideDesigner.Commands;
using RaGuideDesigner.Models;
using RaGuideDesigner.Services;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace RaGuideDesigner.Views
{
    public partial class LeaderboardEditor : BaseEditorControl
    {
        private Leaderboard? _currentLeaderboard;

        public LeaderboardEditor(UndoRedoService undoRedoService) : base(undoRedoService)
        {
            InitializeComponent();
            _propertyBindings.Add(txtLeaderboardTitle, nameof(Leaderboard.Title));

            // Hook up context menus
            rtxtDescription.ContextMenuStrip = ctxMenuRichText;
            rtxtStart.ContextMenuStrip = ctxMenuRichText;
            rtxtCancel.ContextMenuStrip = ctxMenuRichText;
            rtxtSubmit.ContextMenuStrip = ctxMenuRichText;
            rtxtMeasured.ContextMenuStrip = ctxMenuRichText;

            EnableSpellCheck(rtxtDescription);
            EnableSpellCheck(rtxtStart);
            EnableSpellCheck(rtxtCancel);
            EnableSpellCheck(rtxtSubmit);
            EnableSpellCheck(rtxtMeasured);
            EnableSpellCheck(txtMiscNote);
            EnableSpellCheck(txtDevNote);

            WireUpEventHandlers();
        }

        public void ClearCaches() { }
        public void RemoveFromCache(Leaderboard lb) { }

        // Binds a Leaderboard object to the editor's controls.
        public void SetData(Leaderboard? leaderboard)
        {
            if (_currentLeaderboard != null)
            {
                CommitRichTextChanges();
            }

            _isProgrammaticChange = true;
            _dataContext = leaderboard;
            _currentLeaderboard = leaderboard;

            if (leaderboard == null)
            {
                this.Visible = false;
                _isProgrammaticChange = false;
                return;
            }

            txtLeaderboardTitle.Text = leaderboard.Title;

            SetRichTextContent(rtxtDescription, leaderboard.Description);

            // The list-based properties are joined by newlines for display in the RichTextBoxes.
            SetRichTextContent(rtxtStart, string.Join("\n", leaderboard.StartRequirements));
            SetRichTextContent(rtxtCancel, string.Join("\n", leaderboard.CancelConditions));
            SetRichTextContent(rtxtSubmit, string.Join("\n", leaderboard.SubmitConditions));
            SetRichTextContent(rtxtMeasured, string.Join("\n", leaderboard.MeasuredValue));

            SetRichTextContent(txtMiscNote, leaderboard.MiscNote);
            SetRichTextContent(txtDevNote, leaderboard.DevNote);

            this.Visible = true;
            _isProgrammaticChange = false;
        }

        // Saves all pending changes from the various RichTextBoxes.
        private void CommitRichTextChanges()
        {
            if (_currentLeaderboard == null) return;

            HandleRichTextLeave(rtxtDescription, _currentLeaderboard, nameof(Leaderboard.Description));
            HandleRichTextLeave(txtMiscNote, _currentLeaderboard, nameof(Leaderboard.MiscNote));
            HandleRichTextLeave(txtDevNote, _currentLeaderboard, nameof(Leaderboard.DevNote));

            UpdateListFromRichTextBox(rtxtStart, _currentLeaderboard.StartRequirements);
            UpdateListFromRichTextBox(rtxtCancel, _currentLeaderboard.CancelConditions);
            UpdateListFromRichTextBox(rtxtSubmit, _currentLeaderboard.SubmitConditions);
            UpdateListFromRichTextBox(rtxtMeasured, _currentLeaderboard.MeasuredValue);
        }

        // A key method that syncs a multi-line RichTextBox with a BindingList of strings.
        // It splits the text into lines, compares it to the original list, and creates
        // an undoable command if the content has changed.
        private void UpdateListFromRichTextBox(RichTextBox rtb, BindingList<string> list)
        {
            var markdownText = MarkdownRtfConverter.ToMarkdown(rtb.Rtf ?? string.Empty);
            var newLines = markdownText.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(l => l.Trim())
                                       .ToList();

            var oldLines = list.ToList();

            if (!newLines.SequenceEqual(oldLines))
            {
                var command = new ActionCommand(
                    executeAction: () =>
                    {
                        list.Clear();
                        foreach (var line in newLines) list.Add(line);
                    },
                    unexecuteAction: () =>
                    {
                        list.Clear();
                        foreach (var line in oldLines) list.Add(line);
                    }
                );
                _undoRedoService.Execute(command);
            }
        }
    }
}