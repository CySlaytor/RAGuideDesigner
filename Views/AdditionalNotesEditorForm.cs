using RaGuideDesigner.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RaGuideDesigner.Views
{
    // A pop-up editor for the "Additional Notes" section of an achievement category,
    // which supports more complex formatting like sub-headers and blockquotes.
    public partial class AdditionalNotesEditorForm : Form
    {
        // Used to prevent the RichTextBox from flickering during format updates.
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, bool wParam, int lParam);
        private const int WM_SETREDRAW = 0x0B;

        public string NotesContent { get; set; } = "";

        private const string AdditionalNotesHeader = "## Additional Notes";
        private const int BlockquoteIndent = 200;

        private readonly Font _header2Font;
        private readonly Font _header3Font;
        private readonly Font _normalFont;
        // A helper RichTextBox for processing RTF snippets without affecting the main display.
        private readonly RichTextBox _helperRtb = new RichTextBox();

        private bool _isDirty = false;
        private bool _isProgrammaticChange = false;

        // Static variables to remember the form's size and position between sessions.
        private static bool _isFirstLoad = true;
        private static FormWindowState _lastWindowState = FormWindowState.Normal;
        private static Rectangle _lastBounds;

        private readonly System.Windows.Forms.Timer _spellCheckTimer;
        private readonly List<ToolStripMenuItem> _suggestionItems = new List<ToolStripMenuItem>();
        private string _misspelledWord = string.Empty;
        private int _misspelledWordPosition = -1;

        public AdditionalNotesEditorForm()
        {
            InitializeComponent();
            _normalFont = new Font("Segoe UI", 9.75f, FontStyle.Regular);
            _header2Font = new Font("Segoe UI", 14, FontStyle.Bold);
            _header3Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rtxtNotes.Font = _normalFont;

            this.rtxtNotes.TextChanged += new System.EventHandler(this.rtxtNotes_TextChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdditionalNotesEditorForm_FormClosing);

            _spellCheckTimer = new System.Windows.Forms.Timer();
            _spellCheckTimer.Interval = 1500;
            _spellCheckTimer.Tick += SpellCheckTimer_Tick;
            EnableSpellCheck(rtxtNotes);
        }

        private void AdditionalNotesEditorForm_Load(object? sender, EventArgs e)
        {
            _isProgrammaticChange = true;
            RenderMarkdownToRtf(NotesContent);
            _isProgrammaticChange = false;
            _isDirty = false;

            // Apply the remembered state when the form loads.
            if (_isFirstLoad)
            {
                _isFirstLoad = false;
                _lastBounds = this.Bounds;
            }
            else
            {
                this.WindowState = _lastWindowState;
                if (this.WindowState == FormWindowState.Normal)
                {
                    this.Bounds = _lastBounds;
                }
            }
        }

        private void AdditionalNotesEditorForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            // Save the current window state before closing.
            _lastWindowState = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                _lastBounds = this.Bounds;
            }
            else
            {
                _lastBounds = this.RestoreBounds;
            }
        }

        // When the user clicks OK, convert the formatted text back to Markdown.
        private void btnOk_Click(object? sender, EventArgs e)
        {
            if (_isDirty)
            {
                NotesContent = ConvertRtfToMarkdown();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Takes the raw Markdown string and converts it into formatted text for the RichTextBox.
        // It handles headers, blockquotes, and inline styles.
        private void RenderMarkdownToRtf(string markdown)
        {
            _isProgrammaticChange = true;
            SendMessage(rtxtNotes.Handle, WM_SETREDRAW, false, 0); // Turn off drawing

            rtxtNotes.Clear();

            string contentToRender = markdown;
            if (contentToRender.StartsWith(AdditionalNotesHeader))
            {
                contentToRender = contentToRender.Substring(AdditionalNotesHeader.Length).TrimStart();
            }

            if (string.IsNullOrWhiteSpace(contentToRender))
            {
                SendMessage(rtxtNotes.Handle, WM_SETREDRAW, true, 0); // Turn drawing back on
                rtxtNotes.Invalidate();
                _isProgrammaticChange = false;
                return;
            }

            var lines = contentToRender.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            foreach (var originalLine in lines)
            {
                string line = originalLine;
                bool isBlockquote = line.TrimStart().StartsWith(">");
                if (isBlockquote)
                {
                    line = line.TrimStart().Substring(1).Trim();
                }

                // Check for headers and set the font accordingly.
                Font font = _normalFont;
                if (line.StartsWith("###")) { font = _header3Font; line = line.Substring(3).Trim(); }
                else if (line.StartsWith("##")) { font = _header2Font; line = line.Substring(2).Trim(); }

                rtxtNotes.Select(rtxtNotes.TextLength, 0);
                rtxtNotes.SelectionFont = font;
                rtxtNotes.SelectionIndent = isBlockquote ? BlockquoteIndent : 0;
                rtxtNotes.SelectionCharOffset = 0;

                rtxtNotes.AppendText(line + "\n");
            }

            // After setting all block-level formatting, go back and apply inline styles.
            ApplyInlineFormatting(rtxtNotes, @"\*\*(.*?)\*\*", FontStyle.Bold);
            ApplyInlineFormatting(rtxtNotes, @"\*(.*?)\*", FontStyle.Italic);

            rtxtNotes.Select(0, 0);

            SendMessage(rtxtNotes.Handle, WM_SETREDRAW, true, 0); // Turn drawing back on
            rtxtNotes.Invalidate();
            rtxtNotes.Update();
            rtxtNotes.ClearUndo();
            rtxtNotes.Focus();
            _isProgrammaticChange = false;
        }

        private void rtxtNotes_TextChanged(object? sender, EventArgs e)
        {
            if (_isProgrammaticChange) return;
            _isDirty = true;
        }

        // A helper that finds markdown syntax (like **bold**) and applies RTF formatting.
        private void ApplyInlineFormatting(RichTextBox rtb, string pattern, FontStyle style)
        {
            var matches = Regex.Matches(rtb.Text, pattern);
            // We go backwards to avoid messing up the indexes of subsequent matches.
            foreach (Match match in matches.Cast<Match>().Reverse())
            {
                rtb.Select(match.Index, match.Length);
                rtb.SelectedText = match.Groups[1].Value; // Replace the text without the markdown symbols.

                rtb.Select(match.Index, match.Groups[1].Length);
                Font? currentFont = rtb.SelectionFont ?? rtb.Font;
                rtb.SelectionFont = new Font(currentFont, currentFont.Style | style);
            }
        }

        // Reads the formatting from the RichTextBox and converts it back into a Markdown string.
        private string ConvertRtfToMarkdown()
        {
            // Preserve the user's current view and selection state.
            bool originalWordWrap = rtxtNotes.WordWrap;
            int originalSelectionStart = rtxtNotes.SelectionStart;
            int originalSelectionLength = rtxtNotes.SelectionLength;

            try
            {
                SendMessage(rtxtNotes.Handle, WM_SETREDRAW, false, 0);
                rtxtNotes.WordWrap = false;

                var sb = new StringBuilder();
                var lines = rtxtNotes.Lines;

                // Go through the document line by line to check for formatting.
                for (int i = 0; i < lines.Length; i++)
                {
                    int lineStart = rtxtNotes.GetFirstCharIndexFromLine(i);
                    int lineLength = lines[i].Length;
                    rtxtNotes.Select(lineStart, lineLength);

                    // Check for block-level styles first.
                    bool isBlockquote = rtxtNotes.SelectionIndent >= BlockquoteIndent;

                    _helperRtb.Clear();
                    _helperRtb.SelectedRtf = rtxtNotes.SelectedRtf; // Copy the line's RTF to our helper.

                    if (string.IsNullOrWhiteSpace(_helperRtb.Text))
                    {
                        if (isBlockquote && lines.Length > 1) sb.AppendLine(">");
                        else sb.AppendLine();
                        continue;
                    }

                    _helperRtb.Select(0, 1);
                    var font = _helperRtb.SelectionFont ?? _normalFont;

                    // Convert the single line from RTF to Markdown to handle inline styles.
                    string lineMarkdown = MarkdownRtfConverter.ToMarkdown(_helperRtb.Rtf ?? string.Empty).Trim();

                    string prefix = "";
                    if (isBlockquote) prefix += "> ";
                    if (font.Size == _header2Font.Size && font.Bold) prefix += "## ";
                    else if (font.Size == _header3Font.Size && font.Bold) prefix += "### ";

                    sb.AppendLine(prefix + lineMarkdown);
                }

                string content = sb.ToString().Trim();

                if (!string.IsNullOrWhiteSpace(content))
                {
                    return $"{AdditionalNotesHeader}\n{content}";
                }
                return string.Empty;
            }
            finally
            {
                // Restore the RichTextBox to how the user left it.
                rtxtNotes.WordWrap = originalWordWrap;
                rtxtNotes.Select(originalSelectionStart, originalSelectionLength);
                SendMessage(rtxtNotes.Handle, WM_SETREDRAW, true, 0);
                rtxtNotes.Invalidate();
            }
        }

        #region Spell Checking Logic

        private void EnableSpellCheck(UndoRedoRichTextBox rtb)
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
                    rtb.Select(_misspelledWordPosition + newText.Length, 0);
                }
            }
        }

        #endregion

        // Applies the H2 or H3 style to the selected line(s).
        private void ApplySubheaderStyle(int level)
        {
            var font = level switch
            {
                2 => _header2Font,
                3 => _header3Font,
                _ => _normalFont
            };
            ApplyLineStyle(font);
        }

        // A helper to apply a font to the currently selected line(s).
        private void ApplyLineStyle(Font font)
        {
            _isProgrammaticChange = true;
            int selectionStart = rtxtNotes.SelectionStart;
            int selectionLength = rtxtNotes.SelectionLength;
            int startLine = rtxtNotes.GetLineFromCharIndex(selectionStart);
            int endLine = rtxtNotes.GetLineFromCharIndex(selectionStart + selectionLength);

            SendMessage(rtxtNotes.Handle, WM_SETREDRAW, false, 0);
            for (int i = startLine; i <= endLine; i++)
            {
                int lineStart = rtxtNotes.GetFirstCharIndexFromLine(i);
                int lineLength = rtxtNotes.Lines[i].Length;
                rtxtNotes.Select(lineStart, lineLength);
                rtxtNotes.SelectionFont = font;
            }
            rtxtNotes.Select(selectionStart, selectionLength);
            SendMessage(rtxtNotes.Handle, WM_SETREDRAW, true, 0);
            rtxtNotes.Invalidate();
            rtxtNotes.Focus();
            _isProgrammaticChange = false;
            _isDirty = true;
        }

        // Toggles the blockquote formatting (indentation) for the selected line(s).
        private void ToggleBlockquoteStyle()
        {
            _isProgrammaticChange = true;
            int selectionStart = rtxtNotes.SelectionStart;
            int selectionLength = rtxtNotes.SelectionLength;
            int startLine = rtxtNotes.GetLineFromCharIndex(selectionStart);
            int endLine = rtxtNotes.GetLineFromCharIndex(selectionStart + selectionLength);

            rtxtNotes.Select(rtxtNotes.GetFirstCharIndexFromLine(startLine), 0);
            bool shouldAdd = rtxtNotes.SelectionIndent < BlockquoteIndent;

            SendMessage(rtxtNotes.Handle, WM_SETREDRAW, false, 0);
            for (int i = startLine; i <= endLine; i++)
            {
                int lineStart = rtxtNotes.GetFirstCharIndexFromLine(i);
                rtxtNotes.Select(lineStart, rtxtNotes.Lines[i].Length);
                rtxtNotes.SelectionIndent = shouldAdd ? BlockquoteIndent : 0;
            }
            rtxtNotes.Select(selectionStart, selectionLength);
            SendMessage(rtxtNotes.Handle, WM_SETREDRAW, true, 0);
            rtxtNotes.Invalidate();
            rtxtNotes.Focus();
            _isProgrammaticChange = false;
            _isDirty = true;
        }

        #region Rich Text Context Menu Handlers
        private void cutToolStripMenuItem_Click(object? sender, EventArgs e) => rtxtNotes.Cut();
        private void copyToolStripMenuItem_Click(object? sender, EventArgs e) => rtxtNotes.Copy();
        private void pasteToolStripMenuItem_Click(object? sender, EventArgs e) => rtxtNotes.Paste();
        private void boldToolStripMenuItem_Click(object? sender, EventArgs e) => ToggleFontStyle(FontStyle.Bold);
        private void italicToolStripMenuItem_Click(object? sender, EventArgs e) => ToggleFontStyle(FontStyle.Italic);
        private void referenceToolStripMenuItem_Click(object? sender, EventArgs e) => rtxtNotes.InsertLink();

        private void ToggleFontStyle(FontStyle style)
        {
            _isProgrammaticChange = true;
            Font? currentFont = rtxtNotes.SelectionFont ?? rtxtNotes.Font;
            if (currentFont != null)
            {
                rtxtNotes.SelectionFont = new Font(currentFont, currentFont.Style ^ style);
            }
            _isProgrammaticChange = false;
            _isDirty = true;
        }
        #endregion

        private void applyHeader2ToolStripMenuItem_Click(object? sender, EventArgs e) => ApplySubheaderStyle(2);
        private void applyHeader3ToolStripMenuItem_Click(object? sender, EventArgs e) => ApplySubheaderStyle(3);
        private void toggleBlockquoteToolStripMenuItem_Click(object? sender, EventArgs e) => ToggleBlockquoteStyle();
    }
}