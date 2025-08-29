using RaGuideDesigner.Commands;
using RaGuideDesigner.Models;
using RaGuideDesigner.Services;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace RaGuideDesigner.Views
{
    public partial class AchievementEditor : BaseEditorControl
    {
        private Achievement? _currentAchievement = null;

        public AchievementEditor(UndoRedoService undoRedoService) : base(undoRedoService)
        {
            InitializeComponent();
            _propertyBindings.Add(txtAchTitle, nameof(Achievement.Title));

            cmbAchPoints.Items.AddRange(new object[] { 1, 2, 3, 4, 5, 10, 15, 25, 50, 100 });
            cmbAchPoints.SelectedIndexChanged += CmbAchPoints_SelectedIndexChanged;

            EnableSpellCheck(rtxtGuidance);

            WireUpEventHandlers();
        }

        // Binds an Achievement object to the editor's controls.
        // It also contains logic to dynamically change the UI based on whether the
        // achievement belongs to a "Progression" category, hiding unnecessary tabs.
        public void SetData(Achievement? achievement, object? parentData)
        {
            if (_currentAchievement != null)
            {
                CommitRichTextChanges();
            }

            _isProgrammaticChange = true;
            _dataContext = achievement;
            _currentAchievement = achievement;

            if (achievement == null)
            {
                this.Visible = false;
                _isProgrammaticChange = false;
                return;
            }

            // Check if the achievement's parent is a "Progression" category.
            var parentCategory = parentData as AchievementCategory;
            bool isProgression = parentCategory?.Title.Equals("Progression", StringComparison.OrdinalIgnoreCase) ?? false;

            // Show or hide the optional elements and advanced tabs based on the category name.
            // This simplifies the UI for straightforward progression achievements.
            groupBoxOptional.Visible = !isProgression;
            if (isProgression)
            {
                if (tabControl1.TabPages.Contains(tabPageAdvanced))
                {
                    tabControl1.TabPages.Remove(tabPageAdvanced);
                }
                if (tabControl1.TabPages.Contains(tabPageNotes))
                {
                    tabControl1.TabPages.Remove(tabPageNotes);
                }
            }
            else
            {
                if (!tabControl1.TabPages.Contains(tabPageAdvanced))
                {
                    tabControl1.TabPages.Add(tabPageAdvanced);
                }
                if (!tabControl1.TabPages.Contains(tabPageNotes))
                {
                    tabControl1.TabPages.Add(tabPageNotes);
                }
            }

            txtAchTitle.Text = achievement.Title;
            lblAchId.Text = achievement.Id.ToString();

            if (cmbAchPoints.Items.Contains(achievement.Points))
            {
                cmbAchPoints.SelectedItem = achievement.Points;
            }
            else
            {
                cmbAchPoints.SelectedIndex = -1;
            }

            LoadImage(achievement.BadgeUrl);

            SetRichTextContent(rtxtGuidance, achievement.GuidanceAndInsights);
            txtVideoUrl.Text = achievement.VideoWalkthroughUrl;

            lstFailConditions.DataSource = new BindingSource { DataSource = achievement.FailConditions };
            txtTriggerIndicator.Text = achievement.TriggerIndicator;
            txtMeasuredIndicator.Text = achievement.MeasuredIndicator;

            txtMiscNote.Text = achievement.MiscNote;
            txtDevNote.Text = achievement.DevNote;

            this.Visible = true;
            _isProgrammaticChange = false;
        }

        private void CommitRichTextChanges()
        {
            if (_currentAchievement == null) return;
            HandleRichTextLeave(rtxtGuidance, _currentAchievement, nameof(Achievement.GuidanceAndInsights));
        }

        private void LoadImage(string url)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(url)) pbAchBadge.LoadAsync(url);
                else pbAchBadge.Image = null;
            }
            catch { pbAchBadge.Image = null; }
        }

        private void rtxtGuidance_Leave(object sender, EventArgs e)
        {
            if (_currentAchievement != null) HandleRichTextLeave(rtxtGuidance, _currentAchievement, nameof(Achievement.GuidanceAndInsights));
        }

        private void CmbAchPoints_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_isProgrammaticChange || _currentAchievement == null || cmbAchPoints.SelectedItem == null) return;

            int oldValue = _currentAchievement.Points;
            if (int.TryParse(cmbAchPoints.SelectedItem.ToString(), out int newValue))
            {
                if (oldValue != newValue)
                {
                    var command = new EditPropertyCommand(_currentAchievement, nameof(Achievement.Points), oldValue, newValue);
                    _undoRedoService.Execute(command);
                }
            }
        }

        // --- Event handlers for simple text fields ---
        // These follow a standard pattern: check for changes on Leave, and if there are
        // any, create and execute an undoable command.
        private void txtVideoUrl_Leave(object sender, EventArgs e)
        {
            if (_isProgrammaticChange || _currentAchievement == null) return;
            var oldValue = _currentAchievement.VideoWalkthroughUrl;
            var newValue = txtVideoUrl.Text;
            if (oldValue != newValue)
            {
                _undoRedoService.Execute(new EditPropertyCommand(_currentAchievement, nameof(Achievement.VideoWalkthroughUrl), oldValue, newValue));
            }
        }

        private void btnAddFail_Click(object sender, EventArgs e)
        {
            if (_currentAchievement == null || string.IsNullOrWhiteSpace(txtNewFailCondition.Text)) return;

            var newCondition = txtNewFailCondition.Text.Trim();
            var command = new AddListItemCommand<string>(_currentAchievement.FailConditions, newCondition);
            _undoRedoService.Execute(command);

            txtNewFailCondition.Clear();
            txtNewFailCondition.Focus();
        }

        private void btnRemoveFail_Click(object sender, EventArgs e)
        {
            if (_currentAchievement == null || lstFailConditions.SelectedItem == null) return;

            if (lstFailConditions.SelectedItem is string selectedCondition)
            {
                var command = new RemoveListItemCommand<string>(_currentAchievement.FailConditions, selectedCondition);
                _undoRedoService.Execute(command);
            }
        }

        private void txtTriggerIndicator_Leave(object sender, EventArgs e)
        {
            if (_isProgrammaticChange || _currentAchievement == null) return;
            var oldValue = _currentAchievement.TriggerIndicator;
            var newValue = txtTriggerIndicator.Text;
            if (oldValue != newValue)
            {
                _undoRedoService.Execute(new EditPropertyCommand(_currentAchievement, nameof(Achievement.TriggerIndicator), oldValue, newValue));
            }
        }

        private void txtMeasuredIndicator_Leave(object sender, EventArgs e)
        {
            if (_isProgrammaticChange || _currentAchievement == null) return;
            var oldValue = _currentAchievement.MeasuredIndicator;
            var newValue = txtMeasuredIndicator.Text;
            if (oldValue != newValue)
            {
                _undoRedoService.Execute(new EditPropertyCommand(_currentAchievement, nameof(Achievement.MeasuredIndicator), oldValue, newValue));
            }
        }

        private void txtMiscNote_Leave(object sender, EventArgs e)
        {
            if (_isProgrammaticChange || _currentAchievement == null) return;
            var oldValue = _currentAchievement.MiscNote;
            var newValue = txtMiscNote.Text;
            if (oldValue != newValue)
            {
                _undoRedoService.Execute(new EditPropertyCommand(_currentAchievement, nameof(Achievement.MiscNote), oldValue, newValue));
            }
        }

        private void txtDevNote_Leave(object sender, EventArgs e)
        {
            if (_isProgrammaticChange || _currentAchievement == null) return;
            var oldValue = _currentAchievement.DevNote;
            var newValue = txtDevNote.Text;
            if (oldValue != newValue)
            {
                _undoRedoService.Execute(new EditPropertyCommand(_currentAchievement, nameof(Achievement.DevNote), oldValue, newValue));
            }
        }
    }
}