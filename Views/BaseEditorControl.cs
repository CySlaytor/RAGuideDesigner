using RaGuideDesigner.Commands;
using RaGuideDesigner.Models;
using RaGuideDesigner.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RaGuideDesigner.Views
{
    public partial class BaseEditorControl : UserControl
    {
        protected UndoRedoService _undoRedoService;
        protected bool _isProgrammaticChange = false;

        protected readonly Dictionary<Control, string> _propertyBindings = new();
        protected object? _dataContext;

        protected readonly Dictionary<string, string> _admonitionMap = new()
        {
            { "Important", "IMPORTANT" }, { "Warning", "WARNING" }, { "Caution", "CAUTION" },
            { "Tip", "TIP" }, { "Note", "NOTE" }
        };

        private readonly System.Windows.Forms.Timer _spellCheckTimer;
        private readonly List<ToolStripMenuItem> _suggestionItems = new List<ToolStripMenuItem>();
        private string _misspelledWord = string.Empty;
        private int _misspelledWordPosition = -1;

        public BaseEditorControl()
        {
            _undoRedoService = new UndoRedoService();
            _spellCheckTimer = new System.Windows.Forms.Timer();
            _spellCheckTimer.Interval = 1500;
            _spellCheckTimer.Tick += SpellCheckTimer_Tick;
            InitializeComponent();
        }

        public BaseEditorControl(UndoRedoService undoRedoService) : this()
        {
            _undoRedoService = undoRedoService;
        }

        public virtual void CommitChanges()
        {
            this.ActiveControl = null;
        }

        protected void WireUpEventHandlers()
        {
            foreach (var kvp in _propertyBindings)
            {
                kvp.Key.Leave += CommitPropertyChange_OnLeave;
            }
        }

        protected void CommitPropertyChange_OnLeave(object? sender, EventArgs e)
        {
            if (_isProgrammaticChange || _dataContext == null || sender is not Control control) return;

            if (control is RichTextBox rtb && rtb.Multiline)
            {
                return;
            }

            if (_propertyBindings.TryGetValue(control, out var propertyName))
            {
                var propInfo = _dataContext.GetType().GetProperty(propertyName);
                if (propInfo == null) return;

                object? oldValue = propInfo.GetValue(_dataContext);
                string newValue = control.Text;

                if (!Equals(oldValue, newValue))
                {
                    var command = new EditPropertyCommand(_dataContext, propertyName, oldValue ?? string.Empty, newValue);
                    _undoRedoService.Execute(command);
                }
            }
        }

        protected void HandleRichTextLeave(RichTextBox rtb, object dataContext, string propertyName)
        {
            if (_isProgrammaticChange) return;

            var propInfo = dataContext.GetType().GetProperty(propertyName);
            if (propInfo == null) return;

            object? oldValue = propInfo.GetValue(dataContext);
            string newValue = MarkdownRtfConverter.ToMarkdown(rtb.Rtf ?? string.Empty);

            if (!Equals(oldValue, newValue))
            {
                var command = new EditPropertyCommand(dataContext, propertyName, oldValue ?? string.Empty, newValue);
                _undoRedoService.Execute(command);
            }
        }

        // Changed parameter 'newMarkdownContent' to be nullable (string?) to resolve CS8604 warning.
        // The method body already handled nulls correctly with '?? string.Empty'.
        protected void SetRichTextContent(RichTextBox rtb, string? newMarkdownContent)
        {
            string newRtf = MarkdownRtfConverter.ToRtf(newMarkdownContent ?? string.Empty);
            if (rtb.Rtf != newRtf)
            {
                // Use type-pattern matching. The 'urrtb' variable will only be assigned and non-null
                // inside this 'if' block if the cast is successful.
                if (rtb is UndoRedoRichTextBox urrtb && SpellCheckService.Instance.IsInitialized)
                {
                    // We are inside the 'if', so the compiler now knows 'urrtb' is safe to use.
                    urrtb.TextChanged -= Rtb_TextChanged_SpellCheck;

                    rtb.Rtf = newRtf;
                    rtb.ClearUndo();

                    urrtb.TextChanged += Rtb_TextChanged_SpellCheck;
                }
                else
                {
                    // Fallback for standard RichTextBoxes or when spell check is disabled.
                    rtb.Rtf = newRtf;
                    rtb.ClearUndo();
                }
            }

            // This final check remains to ensure the text is highlighted correctly after being set.
            if (SpellCheckService.Instance.IsInitialized)
            {
                SpellCheckService.Instance.CheckSpelling(rtb);
            }
        }

        #region Spell Checking Logic

        protected void EnableSpellCheck(UndoRedoRichTextBox rtb)
        {
            if (!SpellCheckService.Instance.IsInitialized) return;

            rtb.TextChanged += Rtb_TextChanged_SpellCheck;
            if (rtb.ContextMenuStrip != null)
            {
                rtb.ContextMenuStrip.Opening += ContextMenuStrip_Opening_SpellCheck;
            }
        }

        private void Rtb_TextChanged_SpellCheck(object? sender, EventArgs e)
        {

            if (_isProgrammaticChange) return;

            var rtb = sender as RichTextBox;
            if (rtb?.Tag?.ToString() == "Checking") return;

            _spellCheckTimer.Stop();
            _spellCheckTimer.Tag = rtb;
            _spellCheckTimer.Start();
        }

        private void SpellCheckTimer_Tick(object? sender, EventArgs e)
        {
            _spellCheckTimer.Stop();
            if (_spellCheckTimer.Tag is RichTextBox rtb)
            {
                SpellCheckService.Instance.CheckSpelling(rtb);
            }
        }

        private void ContextMenuStrip_Opening_SpellCheck(object? sender, CancelEventArgs e)
        {
            var ctxMenu = sender as ContextMenuStrip;
            if (ctxMenu == null) return;
            var rtb = ctxMenu.SourceControl as RichTextBox;
            if (rtb == null) return;

            foreach (var item in _suggestionItems)
            {
                ctxMenu.Items.Remove(item);
            }
            _suggestionItems.Clear();

            Point cursorPoint = rtb.PointToClient(Cursor.Position);
            int charIndex = rtb.GetCharIndexFromPosition(cursorPoint);
            int lineIndex = rtb.GetLineFromCharIndex(charIndex);
            int firstCharOfLine = rtb.GetFirstCharIndexFromLine(lineIndex);
            int cursorPositionInLine = charIndex - firstCharOfLine;

            string lineText = rtb.Lines.Length > lineIndex ? rtb.Lines[lineIndex] : string.Empty;
            if (string.IsNullOrEmpty(lineText)) return;

            var wordMatches = Regex.Matches(lineText, @"\b[\w']+\b");
            foreach (Match match in wordMatches)
            {
                if (cursorPositionInLine >= match.Index && cursorPositionInLine <= match.Index + match.Length)
                {
                    _misspelledWord = match.Value;
                    _misspelledWordPosition = firstCharOfLine + match.Index;

                    if (!SpellCheckService.Instance.CheckWord(_misspelledWord))
                    {
                        var suggestions = SpellCheckService.Instance.GetSuggestions(_misspelledWord);
                        if (suggestions.Any())
                        {
                            foreach (var suggestion in suggestions.Take(5))
                            {
                                var menuItem = new ToolStripMenuItem(suggestion);
                                menuItem.Font = new Font(menuItem.Font, FontStyle.Bold);
                                menuItem.Click += Suggestion_Click;
                                _suggestionItems.Add(menuItem);
                            }
                        }
                        else
                        {
                            var noSuggestionsItem = new ToolStripMenuItem("(No suggestions)");
                            noSuggestionsItem.Enabled = false;
                            _suggestionItems.Add(noSuggestionsItem);
                        }
                        _suggestionItems.Add(new ToolStripMenuItem("-"));

                        for (int i = _suggestionItems.Count - 1; i >= 0; i--)
                        {
                            ctxMenu.Items.Insert(0, _suggestionItems[i]);
                        }
                    }
                    break;
                }
            }
        }

        private void Suggestion_Click(object? sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            if (menuItem?.Owner is ContextMenuStrip ctxMenu && ctxMenu.SourceControl is RichTextBox rtb)
            {
                if (!string.IsNullOrEmpty(_misspelledWord))
                {
                    string newText = menuItem.Text ?? string.Empty;
                    rtb.Select(_misspelledWordPosition, _misspelledWord.Length);
                    rtb.SelectedText = newText;

                    rtb.Select(_misspelledWordPosition, newText.Length);
                    rtb.SelectionColor = rtb.ForeColor;
                    Font? currentFont = rtb.SelectionFont ?? rtb.Font;
                    if (currentFont != null)
                    {
                        rtb.SelectionFont = new Font(currentFont, currentFont.Style & ~FontStyle.Underline);
                    }
                    rtb.Select(_misspelledWordPosition + newText.Length, 0);
                }
            }
        }

        #endregion

        #region Rich Text Context Menu Handlers
        protected void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((sender as ToolStripItem)?.Owner is ContextMenuStrip ctx && ctx.SourceControl is RichTextBox rtb) rtb.Cut();
        }

        protected void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((sender as ToolStripItem)?.Owner is ContextMenuStrip ctx && ctx.SourceControl is RichTextBox rtb) rtb.Copy();
        }

        protected void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((sender as ToolStripItem)?.Owner is ContextMenuStrip ctx && ctx.SourceControl is RichTextBox rtb) rtb.Paste();
        }

        protected void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Bold, sender);
        }

        protected void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Italic, sender);
        }

        protected void referenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((sender as ToolStripItem)?.Owner is ContextMenuStrip ctx && ctx.SourceControl is UndoRedoRichTextBox rtb)
            {
                rtb.InsertLink();
            }
        }

        private void ToggleFontStyle(FontStyle style, object sender)
        {
            if ((sender as ToolStripItem)?.Owner is ContextMenuStrip ctx && ctx.SourceControl is RichTextBox rtb)
            {
                Font? currentFont = rtb.SelectionFont ?? rtb.Font;
                if (currentFont != null)
                {
                    rtb.SelectionFont = new Font(currentFont, currentFont.Style ^ style);
                }
            }
        }
        #endregion

        #region Admonition Note Helpers
        protected void AddNewAdmonition(BindingList<Admonition> admonitionList, ListBox lstAdmonitions)
        {
            if (admonitionList == null) return;
            var newNote = new Admonition();
            var command = new AddListItemCommand<Admonition>(admonitionList, newNote);
            _undoRedoService.Execute(command);
            lstAdmonitions.SelectedItem = newNote;
        }

        protected void RemoveSelectedAdmonition(BindingList<Admonition> admonitionList, ListBox lstAdmonitions)
        {
            if (lstAdmonitions.SelectedItem is Admonition selectedNote && admonitionList != null)
            {
                var command = new RemoveListItemCommand<Admonition>(admonitionList, selectedNote);
                _undoRedoService.Execute(command);
            }
        }

        protected void UpdateAdmonition(ListBox lstAdmonitions, ComboBox cmbNoteType, RichTextBox rtxtNoteContent)
        {
            if (_isProgrammaticChange) return;
            if (lstAdmonitions.SelectedItem is Admonition selectedNote)
            {
                string newType = _admonitionMap[cmbNoteType.SelectedItem?.ToString() ?? "Note"];

                if (selectedNote.Type != newType)
                {
                    _undoRedoService.Execute(new EditPropertyCommand(selectedNote, nameof(Admonition.Type), selectedNote.Type, newType));
                }

                if (lstAdmonitions.DataSource is BindingSource list)
                {
                    list.ResetBindings(false);
                }
            }
        }
        #endregion
    }
}