using NHunspell;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RaGuideDesigner.Services
{
    // A singleton service to manage spell checking across the application.
    public class SpellCheckService
    {
        private static readonly Lazy<SpellCheckService> _instance = new Lazy<SpellCheckService>(() => new SpellCheckService());
        public static SpellCheckService Instance => _instance.Value;

        private Hunspell? _hunspell;
        private bool _isInitialized = false;

        private SpellCheckService() { }

        // Loads the dictionary files. Must be called once at application startup.
        public void Initialize()
        {
            if (_isInitialized) return;

            try
            {
                // Use AppContext.BaseDirectory to be compatible with single-file publishing
                string? assemblyPath = AppContext.BaseDirectory;
                if (string.IsNullOrEmpty(assemblyPath))
                {
                    MessageBox.Show("Could not determine the application's path. Spell checking will be disabled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string hunspellPath = Path.Combine(assemblyPath, "Hunspell");
                Hunspell.NativeDllPath = hunspellPath;

                string affPath = Path.Combine(Application.StartupPath, "Dictionaries", "en_US.aff");
                string dicPath = Path.Combine(Application.StartupPath, "Dictionaries", "en_US.dic");

                if (File.Exists(affPath) && File.Exists(dicPath))
                {
                    _hunspell = new Hunspell(affPath, dicPath);

                    // Load a custom dictionary with application-specific words.
                    string customDicPath = Path.Combine(Application.StartupPath, "Dictionaries", "custom.dic");
                    if (File.Exists(customDicPath))
                    {
                        var customWords = File.ReadAllLines(customDicPath);
                        foreach (var word in customWords)
                        {
                            if (!string.IsNullOrWhiteSpace(word))
                            {
                                _hunspell.Add(word.Trim());
                            }
                        }
                    }

                    _isInitialized = true;
                }
                else
                {
                    MessageBox.Show("Spell check dictionary files not found in the 'Dictionaries' folder. Spell checking will be disabled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize spell checker: {ex.Message}", "Spell Check Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _isInitialized = false;
            }
        }

        public bool IsInitialized => _isInitialized;

        public bool CheckWord(string word)
        {
            if (!_isInitialized || string.IsNullOrWhiteSpace(word) || _hunspell == null) return true;
            return _hunspell.Spell(word);
        }

        public List<string> GetSuggestions(string word)
        {
            if (!_isInitialized || _hunspell == null) return new List<string>();
            return _hunspell.Suggest(word);
        }

        // This version is non-destructive to user formatting (bold, italic, etc.).
        public void CheckSpelling(RichTextBox rtb)
        {
            if (!_isInitialized || rtb == null) return;

            rtb.Tag = "Checking";

            int selectionStart = rtb.SelectionStart;
            int selectionLength = rtb.SelectionLength;

            SendMessage(rtb.Handle, WM_SETREDRAW, false, 0);

            for (int i = 0; i < rtb.TextLength; i++)
            {
                rtb.Select(i, 1);
                if (rtb.SelectionFont != null && rtb.SelectionFont.Underline)
                {
                    rtb.SelectionFont = new Font(rtb.SelectionFont, rtb.SelectionFont.Style & ~FontStyle.Underline);
                }
            }

            Regex wordRegex = new Regex(@"\b[\w']+\b");
            MatchCollection matches = wordRegex.Matches(rtb.Text);

            foreach (Match match in matches)
            {
                if (!CheckWord(match.Value))
                {
                    rtb.Select(match.Index, match.Length);
                    rtb.SelectionColor = Color.Red;
                    Font currentFont = rtb.SelectionFont ?? rtb.Font;
                    if (currentFont != null)
                    {
                        rtb.SelectionFont = new Font(currentFont, currentFont.Style | FontStyle.Underline);
                    }
                }
            }

            rtb.Select(selectionStart, selectionLength);
            SendMessage(rtb.Handle, WM_SETREDRAW, true, 0);
            rtb.Invalidate();

            rtb.Tag = null;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, bool wParam, int lParam);
        private const int WM_SETREDRAW = 0x0B;
    }
}