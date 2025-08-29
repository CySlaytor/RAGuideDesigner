using RaGuideDesigner.Models;
using RaGuideDesigner.Services;
using System;
using System.Windows.Forms;

namespace RaGuideDesigner.Views
{
    // A simple editor just for the introductory text of the entire Leaderboard section.
    public partial class LeaderboardRootEditor : BaseEditorControl
    {
        private WikiGuide? _currentGuide;

        public LeaderboardRootEditor(UndoRedoService undoRedoService) : base(undoRedoService)
        {
            InitializeComponent();
            EnableSpellCheck(rtxtIntro);
        }

        public void SetData(WikiGuide? guide)
        {
            if (_currentGuide != null)
            {
                HandleRichTextLeave(rtxtIntro, _currentGuide, nameof(WikiGuide.LeaderboardIntroText));
            }

            _isProgrammaticChange = true;
            _dataContext = guide;
            _currentGuide = guide;

            if (guide == null)
            {
                this.Visible = false;
                _isProgrammaticChange = false;
                return;
            }

            SetRichTextContent(rtxtIntro, guide.LeaderboardIntroText);

            this.Visible = true;
            _isProgrammaticChange = false;
        }

        private void rtxtIntro_Leave(object sender, EventArgs e)
        {
            if (_currentGuide != null)
            {
                HandleRichTextLeave(rtxtIntro, _currentGuide, nameof(WikiGuide.LeaderboardIntroText));
            }
        }
    }
}