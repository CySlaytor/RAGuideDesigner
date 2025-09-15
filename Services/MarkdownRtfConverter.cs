using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RaGuideDesigner.Services
{
    public static class MarkdownRtfConverter
    {
        private static readonly RichTextBox _converterRtb = new RichTextBox();

        // Converts a simple Markdown string into RTF for display in a RichTextBox.
        // It handles bold, italics, and newlines. Crucially, it also manually escapes
        // Unicode characters (like emojis) so they display correctly in the RTF control.
        public static string ToRtf(string markdown)
        {
            // Add \uc1 to the header to indicate Unicode support. This is crucial for emojis.
            const string rtfHeader = @"{\rtf1\ansi\deff0{\fonttbl{\f0 Segoe UI;}}\uc1\pard\fs20 ";
            const string rtfFooter = @"\par}";

            if (string.IsNullOrEmpty(markdown))
            {
                return rtfHeader + rtfFooter;
            }

            // Manually build the RTF content string, properly escaping unicode characters.
            // This ensures characters outside the default ANSI code page (like emojis) are preserved.
            var sb = new StringBuilder();
            foreach (char c in markdown)
            {
                if (c == '\\' || c == '{' || c == '}')
                {
                    sb.Append('\\').Append(c);
                }
                else if (c < 128) // Standard ASCII characters can be appended directly.
                {
                    sb.Append(c);
                }
                else // Non-ASCII (Unicode) characters must be escaped.
                {
                    // RTF uses \u followed by the character's signed 16-bit integer value.
                    // A fallback character '?' is included for non-Unicode-aware readers.
                    // Directly casting the char to a short correctly handles values > 32767
                    // by wrapping them into the negative range, which is what RTF expects.
                    sb.Append(@"\u").Append((short)c).Append('?');
                }
            }
            string rtfContent = sb.ToString();

            // Apply bold and italic formatting after character escaping.
            rtfContent = Regex.Replace(rtfContent, @"\*\*(.*?)\*\*", @"{\b $1}");
            rtfContent = Regex.Replace(rtfContent, @"\*(.*?)\*", @"{\i $1}");

            // Convert newlines to RTF paragraph markers.
            rtfContent = rtfContent.Replace("\n", @"\par ");

            return rtfHeader + rtfContent + rtfFooter;
        }

        // Converts an RTF string back into a simple Markdown string.
        // It uses a hidden RichTextBox to get the plain text, then iterates through
        // it to check for bold/italic formatting and re-applies markdown syntax.
        public static string ToMarkdown(string rtf)
        {
            if (string.IsNullOrWhiteSpace(rtf)) return "";

            try
            {
                _converterRtb.Rtf = rtf ?? "";
            }
            catch (System.ArgumentException)
            {
                // If the RTF is invalid, just return the plain text content.
                return _converterRtb.Text;
            }

            var sb = new StringBuilder();
            var text = _converterRtb.Text;
            bool isBold = false;
            bool isItalic = false;

            for (int i = 0; i < text.Length; i++)
            {
                _converterRtb.Select(i, 1);
                var charFont = _converterRtb.SelectionFont;

                if (charFont == null)
                {
                    sb.Append(text[i]);
                    continue;
                }

                bool currentBold = charFont.Bold;
                bool currentItalic = charFont.Italic;

                // Close tags when formatting ends.
                if (isBold && !currentBold) sb.Append("**");
                if (isItalic && !currentItalic) sb.Append("*");
                // Open tags when formatting begins.
                if (!isBold && currentBold) sb.Append("**");
                if (!isItalic && currentItalic) sb.Append("*");

                sb.Append(text[i]);

                isBold = currentBold;
                isItalic = currentItalic;
            }

            // Close any remaining open tags at the end of the text.
            if (isBold) sb.Append("**");
            if (isItalic) sb.Append("*");

            return sb.ToString();
        }
    }
}