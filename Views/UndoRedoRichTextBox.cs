using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using RaGuideDesigner.Views;

namespace RaGuideDesigner.Views
{
    // A custom RichTextBox that re-enables standard keyboard shortcuts and adds
    // custom ones for formatting like bold, italic, and inserting links.
    public class UndoRedoRichTextBox : RichTextBox
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        private const int EM_SETUNDOLIMIT = 0x0447;

        public UndoRedoRichTextBox()
        {
            this.ShortcutsEnabled = true;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SendMessage(this.Handle, EM_SETUNDOLIMIT, 0, 0);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Handle Ctrl+Shift+Z for Redo to match the application's global shortcut.
            // The default Ctrl+Y will still work due to the base implementation.
            if (keyData == (Keys.Control | Keys.Shift | Keys.Z))
            {
                if (this.CanRedo)
                {
                    this.Redo();
                }
                return true;
            }
            if (keyData == (Keys.Control | Keys.B))
            {
                ToggleFontStyle(FontStyle.Bold);
                return true;
            }
            if (keyData == (Keys.Control | Keys.I))
            {
                ToggleFontStyle(FontStyle.Italic);
                return true;
            }
            if (keyData == (Keys.Control | Keys.K))
            {
                InsertLink();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Pops up a dialog to create a Markdown link from the selected text.
        public void InsertLink()
        {
            string selectedText = this.SelectedText;
            if (string.IsNullOrWhiteSpace(selectedText))
            {
                MessageBox.Show("Please select some text to create a link.", "No Text Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string input = "";
            var result = InputBoxForm.Show("Create Reference Link", "Enter the URL or Achievement ID:", ref input);
            if (result != DialogResult.OK || string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            string linkText;
            if (int.TryParse(input, out int achId))
            {
                linkText = $"[{selectedText}](#{achId})";
            }
            else
            {
                linkText = $"[{selectedText}]({input})";
            }

            this.SelectedText = linkText;
        }

        // Toggles a given font style (like Bold or Italic) on the selected text.
        private void ToggleFontStyle(FontStyle style)
        {
            Font? currentFont = this.SelectionFont ?? this.Font;
            if (currentFont != null)
            {
                this.SelectionFont = new Font(currentFont, currentFont.Style ^ style);
            }
        }
    }
}