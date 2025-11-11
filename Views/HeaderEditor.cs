using RaGuideDesigner.Commands;
using RaGuideDesigner.Models;
using RaGuideDesigner.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaGuideDesigner.Views
{
    public partial class HeaderEditor : BaseEditorControl
    {
        // Added a class to hold footnote templates and a list to store them.
        private class FootnoteTemplate
        {
            public string Name { get; set; } = "";
            public string MeasuredExamples { get; set; } = "";
            public string TriggeredExamples { get; set; } = "";
            public override string ToString() => Name;
        }

        private readonly List<FootnoteTemplate> _footnoteTemplates = new List<FootnoteTemplate>();

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

            // Populate and configure the new footnote templates ComboBox.
            PopulateFootnoteTemplates();
            cmbFootnoteTemplates.DisplayMember = "Name";
            cmbFootnoteTemplates.SelectedIndexChanged += CmbFootnoteTemplates_SelectedIndexChanged;
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
        public async void SetData(WikiGuide? guide)
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


            await LoadImage(pbMasteryIcon, guide.MasteryIconUrl);
            await LoadBannerImage(guide.BannerImageUrl);

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

        private async Task LoadImage(PictureBox pb, string url)
        {
            await ImageCacheService.Instance.LoadImageAsync(pb, url);
        }

        // A dedicated method to load the banner and manage the hint label's visibility.
        private async Task LoadBannerImage(string url)
        {
            await ImageCacheService.Instance.LoadImageAsync(pbBanner, url);
            lblBannerHint.Visible = pbBanner.Image == null;
        }

        private async void txtBannerUrl_TextChanged(object sender, System.EventArgs e)
        {
            if (_isProgrammaticChange) return;
            await LoadBannerImage(txtBannerUrl.Text);
        }

        private async void txtMasteryIconUrl_TextChanged(object sender, System.EventArgs e)
        {
            if (_isProgrammaticChange) return;
            await LoadImage(pbMasteryIcon, txtMasteryIconUrl.Text);
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
                HandleRichTextLeave(rtxtMeasuredExamples, guide, nameof(WikiGuide.MeasuredIndicatorExamples));
            }
        }

        private void rtxtTriggerExamples_Leave(object sender, EventArgs e)
        {
            if (_dataContext is WikiGuide guide)
            {
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

        // This section replaces the old "Generate Footnotes" button logic with a template system.
        #region Footnote Templates Logic
        private void PopulateFootnoteTemplates()
        {
            _footnoteTemplates.Add(new FootnoteTemplate { Name = "-- Select a Template --" });
            _footnoteTemplates.Add(new FootnoteTemplate
            {
                Name = "Standard Progress",
                MeasuredExamples = "Knock downs - 10/64\nSheep left - 5/8\nTime elapsed - 68%/100%",
                TriggeredExamples = "2 Gorilda babies are knocked down, finish the level.\nA challenge is active, complete the requirement."
            });
            _footnoteTemplates.Add(new FootnoteTemplate
            {
                Name = "Combat & Accuracy",
                MeasuredExamples = "Headshots - 7/12\nEnemies left - 11/100\nAccuracy - 47%\nCoins collected - 88%",
                TriggeredExamples = "Enough headshots acquired, finish the mission.\nAll enemies killed, kill the boss.\nPlayer has not yet taken a hit - for a hitless achievement.\nAll requirements are met, continue the game to unlock..."
            });
            _footnoteTemplates.Add(new FootnoteTemplate
            {
                Name = "Action & Kills",
                MeasuredExamples = "Kills - 7/10\nCrates smashed - 11/48\nAccuracy - 47%",
                TriggeredExamples = "The Hydra vehicle is active, eliminate all remaining hostiles.\nA secondary objective has been triggered, complete it before proceeding.\nH.R.E.F. weapon is equipped, neutralize the remaining enemies."
            });
            _footnoteTemplates.Add(new FootnoteTemplate
            {
                Name = "Racing & Events",
                MeasuredExamples = "Race Wins/Milestones - 5/7\nPolice Vehicles Involved - 7/150\nInfractions Recorded - 4/8",
                TriggeredExamples = "A pursuit is active, complete the requirement.\nA valid Challenge Series is active, finish it.\nComplete the event."
            });
            _footnoteTemplates.Add(new FootnoteTemplate
            {
                Name = "RPG Style",
                MeasuredExamples = "Experience - 450/1200\nQuests Completed - 3/10\nGold - 5,280",
                TriggeredExamples = "Sidequest 'The Lost Artifact' is active.\nYou have entered the 'Dragon's Lair' zone.\nThe 'Legendary Sword' is equipped."
            });
            _footnoteTemplates.Add(new FootnoteTemplate
            {
                Name = "Platformer Style",
                MeasuredExamples = "Gems Collected - 88/100\nGolden Statues - 4/5\nLives - 2/3",
                TriggeredExamples = "A bonus level is active.\nThe invincibility power-up is active.\nYou are in the 'Haunted Castle' world."
            });

            cmbFootnoteTemplates.DataSource = _footnoteTemplates;
        }

        private void CmbFootnoteTemplates_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_isProgrammaticChange || cmbFootnoteTemplates.SelectedIndex <= 0 || _dataContext is not WikiGuide guide)
            {
                return;
            }

            if (cmbFootnoteTemplates.SelectedItem is not FootnoteTemplate selectedTemplate) return;

            if (!string.IsNullOrWhiteSpace(guide.MeasuredIndicatorExamples) || !string.IsNullOrWhiteSpace(guide.TriggeredIndicatorExamples))
            {
                var result = MessageBox.Show("This will overwrite the current footnote examples. Are you sure you want to continue?", "Confirm Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    _isProgrammaticChange = true;
                    cmbFootnoteTemplates.SelectedIndex = 0;
                    _isProgrammaticChange = false;
                    return;
                }
            }

            var commands = new List<ICommand>();

            if (guide.MeasuredIndicatorExamples != selectedTemplate.MeasuredExamples)
            {
                commands.Add(new EditPropertyCommand(guide, nameof(WikiGuide.MeasuredIndicatorExamples), guide.MeasuredIndicatorExamples ?? "", selectedTemplate.MeasuredExamples));
            }
            if (guide.TriggeredIndicatorExamples != selectedTemplate.TriggeredExamples)
            {
                commands.Add(new EditPropertyCommand(guide, nameof(WikiGuide.TriggeredIndicatorExamples), guide.TriggeredIndicatorExamples ?? "", selectedTemplate.TriggeredExamples));
            }

            if (commands.Any())
            {
                _undoRedoService.Execute(new CompositeCommand(commands));
                _isProgrammaticChange = true;
                SetRichTextContent(rtxtMeasuredExamples, guide.MeasuredIndicatorExamples);
                SetRichTextContent(rtxtTriggerExamples, guide.TriggeredIndicatorExamples);
                _isProgrammaticChange = false;
            }

            _isProgrammaticChange = true;
            cmbFootnoteTemplates.SelectedIndex = 0;
            _isProgrammaticChange = false;
        }
        #endregion


        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}