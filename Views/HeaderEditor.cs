using RaGuideDesigner.Commands;
using RaGuideDesigner.Models;
using RaGuideDesigner.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RaGuideDesigner.Views
{
    public partial class HeaderEditor : BaseEditorControl
    {
        public HeaderEditor(UndoRedoService undoRedoService) : base(undoRedoService)
        {
            InitializeComponent();
            _propertyBindings.Add(txtGameTitle, nameof(WikiGuide.GameTitle));
            _propertyBindings.Add(txtMasteryIconUrl, nameof(WikiGuide.MasteryIconUrl));
            _propertyBindings.Add(txtBannerUrl, nameof(WikiGuide.BannerImageUrl));

            EnableSpellCheck(rtxtIntro);
            EnableSpellCheck(rtxtMeasuredExamples);
            EnableSpellCheck(rtxtTriggerExamples);

            WireUpEventHandlers();

            // The ComboBox for platforms has custom drawing to show group headers.
            cmbPlatform.DrawMode = DrawMode.OwnerDrawFixed;
            cmbPlatform.DrawItem += CmbPlatform_DrawItem;
            cmbPlatform.SelectedIndexChanged += cmbPlatform_SelectedIndexChanged;

            PopulatePlatformComboBox();
        }

        public void ClearCaches()
        {
            rtxtIntro.Clear();
            rtxtIntro.ClearUndo();
            rtxtMeasuredExamples.Clear();
            rtxtMeasuredExamples.ClearUndo();
            rtxtTriggerExamples.Clear();
            rtxtTriggerExamples.ClearUndo();
        }

        // Binds the main WikiGuide object to the header editor controls.
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

            txtGameTitle.Text = guide.GameTitle;

            string platformToSelect = guide.Platform;
            if (string.IsNullOrEmpty(platformToSelect))
            {
                cmbPlatform.SelectedIndex = -1;
            }
            else
            {
                // We add spaces here to match the indented items in the list.
                cmbPlatform.SelectedItem = "  " + platformToSelect;
            }

            txtMasteryIconUrl.Text = guide.MasteryIconUrl;
            txtBannerUrl.Text = guide.BannerImageUrl;

            SetRichTextContent(rtxtIntro, guide.IntroText);

            // The "- " prefix is a formatting detail handled by Markdown generator/parser, not stored in the model or shown here.
            SetRichTextContent(rtxtMeasuredExamples, guide.MeasuredIndicatorExamples);
            SetRichTextContent(rtxtTriggerExamples, guide.TriggeredIndicatorExamples);


            LoadImage(pbMasteryIcon, guide.MasteryIconUrl);
            LoadBannerImage(guide.BannerImageUrl);

            UpdateStatistics(guide);

            this.Visible = true;
            _isProgrammaticChange = false;
        }

        // Refreshes the set statistics displayed on the editor.
        public void UpdateStatistics(WikiGuide guide)
        {
            var allAchievements = guide.AchievementCategories.SelectMany(c => c.Achievements).ToList();

            lblAchCountValue.Text = allAchievements.Count.ToString();
            lblPointsValue.Text = allAchievements.Sum(a => a.Points).ToString();
            lblCategoriesValue.Text = guide.AchievementCategories.Count.ToString();
            lblLeaderboardsValue.Text = guide.Leaderboards.Count.ToString();
            lblCreditsValue.Text = guide.Credits.Count.ToString();
        }

        private void LoadImage(PictureBox pb, string url)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(url)) pb.LoadAsync(url);
                else pb.Image = null;
            }
            catch { pb.Image = null; }
        }

        // A dedicated method to load the banner and manage the hint label's visibility.
        private void LoadBannerImage(string url)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(url))
                {
                    pbBanner.LoadAsync(url);
                    lblBannerHint.Visible = false; // Hide hint when image is loading/present
                }
                else
                {
                    pbBanner.Image = null;
                    lblBannerHint.Visible = true;  // Show hint if no URL
                }
            }
            catch
            {
                pbBanner.Image = null;
                lblBannerHint.Visible = true; // Show hint on error
            }
        }

        private void txtBannerUrl_TextChanged(object sender, System.EventArgs e)
        {
            if (_isProgrammaticChange) return;
            LoadBannerImage(txtBannerUrl.Text);
        }

        private void txtMasteryIconUrl_TextChanged(object sender, System.EventArgs e)
        {
            if (_isProgrammaticChange) return;
            LoadImage(pbMasteryIcon, txtMasteryIconUrl.Text);
        }

        private void rtxtIntro_Leave(object sender, System.EventArgs e)
        {
            if (_dataContext is WikiGuide guide)
            {
                HandleRichTextLeave(rtxtIntro, guide, nameof(WikiGuide.IntroText));
            }
        }

        private void rtxtMeasuredExamples_Leave(object sender, EventArgs e)
        {
            if (_dataContext is WikiGuide guide)
            {
                var newText = MarkdownRtfConverter.ToMarkdown(rtxtMeasuredExamples.Rtf ?? "").Replace("- ", "").Trim();
                HandleRichTextLeave(rtxtMeasuredExamples, guide, nameof(WikiGuide.MeasuredIndicatorExamples));
            }
        }

        private void rtxtTriggerExamples_Leave(object sender, EventArgs e)
        {
            if (_dataContext is WikiGuide guide)
            {
                var newText = MarkdownRtfConverter.ToMarkdown(rtxtTriggerExamples.Rtf ?? "").Replace("- ", "").Trim();
                HandleRichTextLeave(rtxtTriggerExamples, guide, nameof(WikiGuide.TriggeredIndicatorExamples));
            }
        }

        #region Platform ComboBox Logic

        private void PopulatePlatformComboBox()
        {
            cmbPlatform.Items.Clear();
            cmbPlatform.Items.AddRange(PlatformMappingService.GetGroupedPlatforms().ToArray());
        }

        // This method handles the custom drawing for the platform ComboBox.
        // It draws headers in bold and with a different background color.
        private void CmbPlatform_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            string itemText = cmbPlatform.Items[e.Index]?.ToString() ?? string.Empty;
            if (string.IsNullOrEmpty(itemText)) return;

            bool isHeader = PlatformMappingService.IsHeader(itemText);

            e.DrawBackground();

            Font baseFont = e.Font ?? cmbPlatform.Font;
            if (baseFont == null) return;

            var textBounds = e.Bounds;
            Font font = baseFont;
            Brush brush = new SolidBrush(e.ForeColor);

            if (isHeader)
            {
                font = new Font(baseFont, FontStyle.Bold);
                brush = Brushes.Gray;
                using (var bgBrush = new SolidBrush(Color.FromArgb(220, 220, 220)))
                {
                    e.Graphics.FillRectangle(bgBrush, e.Bounds);
                }
            }

            e.Graphics.DrawString(itemText, font, brush, textBounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        // When the selection changes, this prevents the user from selecting a header item
        // and updates the data model if a valid platform is chosen.
        private void cmbPlatform_SelectedIndexChanged(object? sender, System.EventArgs e)
        {
            if (_isProgrammaticChange || _dataContext is not WikiGuide guide || cmbPlatform.SelectedItem is not string selectedItem) return;

            if (PlatformMappingService.IsHeader(selectedItem))
            {
                // If a header is clicked, revert the selection back to the current platform.
                _isProgrammaticChange = true;
                string platformToSelect = "  " + guide.Platform;
                if (cmbPlatform.Items.Contains(platformToSelect))
                {
                    cmbPlatform.SelectedItem = platformToSelect;
                }
                else
                {
                    cmbPlatform.SelectedIndex = -1;
                }
                _isProgrammaticChange = false;
                return;
            }

            string newPlatform = selectedItem.Trim();
            if (guide.Platform != newPlatform)
            {
                var command = new EditPropertyCommand(guide, nameof(WikiGuide.Platform), guide.Platform, newPlatform);
                _undoRedoService.Execute(command);
            }
        }

        #endregion

        // This feature scans all achievements for common keywords in their indicator text
        // and generates a few diverse examples for the footnotes section.
        private void btnGenerateFootnotes_Click(object sender, EventArgs e)
        {
            if (_dataContext is not WikiGuide guide) return;

            var measuredKeywords = new Dictionary<string, string>
            {
                { "kill", "Kills" },
                { "destr", "Objects Destroyed" },
                { "collect", "Items Collected" },
                { "gem", "Gems" },
                { "ring", "Rings" },
                { "crate", "Crates Smashed" },
                { "camera", "Cameras Disabled" },
                { "accura", "Accuracy" },
                { "point", "Points" },
                { "score", "Score" }
            };

            var foundMeasuredTypes = new HashSet<string>();
            var generatedMeasuredExamples = new List<string>();
            var foundTriggerExamples = new HashSet<string>();
            var rand = new Random();

            var allAchievements = guide.AchievementCategories.SelectMany(c => c.Achievements).ToList();

            // Analyze for Measured Indicators to compose examples
            foreach (var ach in allAchievements.Where(a => !string.IsNullOrWhiteSpace(a.MeasuredIndicator)))
            {
                var indicatorText = ach.MeasuredIndicator.ToLowerInvariant();
                var numbers = Regex.Matches(indicatorText, @"\d+").Cast<Match>().Select(m => int.Parse(m.Value)).ToList();

                foreach (var keyword in measuredKeywords)
                {
                    if (indicatorText.Contains(keyword.Key) && !foundMeasuredTypes.Contains(keyword.Value))
                    {
                        foundMeasuredTypes.Add(keyword.Value); // Ensure variety

                        if (keyword.Key == "accura")
                        {
                            generatedMeasuredExamples.Add($"{keyword.Value} - {rand.Next(40, 95)}%");
                        }
                        else if (numbers.Any())
                        {
                            int max = numbers.Last();
                            int current = rand.Next((int)(max * 0.4), (int)(max * 0.9));
                            generatedMeasuredExamples.Add($"{keyword.Value} - {current}/{max}");
                        }
                        else if (keyword.Key == "point" || keyword.Key == "score")
                        {
                            generatedMeasuredExamples.Add($"{keyword.Value} - {rand.Next(1000, 25000)}");
                        }
                        break;
                    }
                }
            }

            // Analyze for the best Triggered Indicators to use as examples
            var triggerCandidates = allAchievements
                .Where(a => !string.IsNullOrWhiteSpace(a.TriggerIndicator))
                .Select(a => a.TriggerIndicator.Trim())
                .Distinct()
                .OrderBy(s => s.Length) // Prefer shorter, more direct examples
                .ToList();

            foundTriggerExamples.UnionWith(triggerCandidates);

            if (generatedMeasuredExamples.Count == 0 && foundTriggerExamples.Count == 0)
            {
                MessageBox.Show("No relevant indicator text was found in the project to generate examples from.", "Analysis Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!string.IsNullOrWhiteSpace(guide.MeasuredIndicatorExamples) || !string.IsNullOrWhiteSpace(guide.TriggeredIndicatorExamples))
            {
                var result = MessageBox.Show("This will overwrite the current footnote examples. Are you sure you want to continue?", "Confirm Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) return;
            }

            var commands = new List<ICommand>();

            string newMeasured = string.Join("\n", generatedMeasuredExamples.Take(3).Select(ex => $"- {ex}"));
            string newTriggered = string.Join("\n", foundTriggerExamples.Take(3).Select(ex => $"- {ex}"));

            if (guide.MeasuredIndicatorExamples != newMeasured)
            {
                commands.Add(new EditPropertyCommand(guide, nameof(WikiGuide.MeasuredIndicatorExamples), guide.MeasuredIndicatorExamples, newMeasured));
            }
            if (guide.TriggeredIndicatorExamples != newTriggered)
            {
                commands.Add(new EditPropertyCommand(guide, nameof(WikiGuide.TriggeredIndicatorExamples), guide.TriggeredIndicatorExamples, newTriggered));
            }

            if (commands.Any())
            {
                _undoRedoService.Execute(new CompositeCommand(commands));
                _isProgrammaticChange = true;
                SetRichTextContent(rtxtMeasuredExamples, guide.MeasuredIndicatorExamples);
                SetRichTextContent(rtxtTriggerExamples, guide.TriggeredIndicatorExamples);
                _isProgrammaticChange = false;
            }
        }
    }
}