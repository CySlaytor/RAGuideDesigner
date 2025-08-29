using RaGuideDesigner.Commands;
using RaGuideDesigner.Models;
using RaGuideDesigner.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RaGuideDesigner.Views
{
    public partial class CreditsEditor : BaseEditorControl
    {
        private Credit? _currentCredit;

        // A map defining the main roles and their available sub-roles.
        private readonly Dictionary<string, List<string>> _roleMap = new()
        {
            { "🟉 Achievement Set Developer", new List<string> { "Badge Design", "RA-Guide Author", "Collaborator" } },
            { "🟉 Code Reviewer", new List<string>() },
            { "🟉 Contributor", new List<string> { "Tester", "Writer", "Badge Design", "RA-Guide Design" } }
        };

        private bool _isUpdatingRoles = false; // Flag to prevent event feedback loops

        public CreditsEditor(UndoRedoService undoRedoService) : base(undoRedoService)
        {
            InitializeComponent();
            _propertyBindings.Add(txtCreditUsername, nameof(Credit.Username));
            _propertyBindings.Add(txtCreditAvatarUrl, nameof(Credit.AvatarUrl));

            cmbMainRole.Items.AddRange(_roleMap.Keys.ToArray());

            EnableSpellCheck(rtxtDetails);

            WireUpEventHandlers();
        }

        public void SetData(Credit? credit)
        {
            if (_currentCredit != null)
            {
                HandleRichTextLeave(rtxtDetails, _currentCredit, nameof(Credit.ContributionDetails));
            }

            _isProgrammaticChange = true;
            _isUpdatingRoles = true; // Prevent events during programmatic update

            _dataContext = credit;
            _currentCredit = credit;

            if (credit == null)
            {
                this.Visible = false;
                _isProgrammaticChange = false;
                _isUpdatingRoles = false;
                return;
            }

            txtCreditUsername.Text = credit.Username;
            txtCreditAvatarUrl.Text = credit.AvatarUrl;
            LoadImage(credit.AvatarUrl);
            SetRichTextContent(rtxtDetails, credit.ContributionDetails);

            // Parse the combined role string from the model to set the UI controls.
            ParseAndSetRoles(credit.Role);

            this.Visible = true;
            _isProgrammaticChange = false;
            _isUpdatingRoles = false;
        }

        // Takes the combined role string (e.g., "Main Role | Sub Role 1 | Sub Role 2")
        // and updates the main role dropdown and checked sub-roles accordingly.
        private void ParseAndSetRoles(string roleString)
        {
            clbSubRoles.Items.Clear();
            if (string.IsNullOrWhiteSpace(roleString))
            {
                cmbMainRole.SelectedIndex = -1;
                clbSubRoles.Visible = false;
                return;
            }

            var parts = roleString.Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).ToList();
            if (!parts.Any())
            {
                cmbMainRole.SelectedIndex = -1;
                clbSubRoles.Visible = false;
                return;
            }

            var mainRole = parts.First();
            var subRoles = parts.Skip(1).ToHashSet();

            if (cmbMainRole.Items.Contains(mainRole))
            {
                cmbMainRole.SelectedItem = mainRole;
                PopulateSubRoles(subRoles);
            }
            else
            {
                cmbMainRole.SelectedIndex = -1;
                PopulateSubRoles();
            }
        }

        // Fills the sub-role checklist based on the selected main role.
        private void PopulateSubRoles(HashSet<string>? checkedSubRoles = null)
        {
            clbSubRoles.Items.Clear();
            if (cmbMainRole.SelectedItem is not string mainRole || !_roleMap.TryGetValue(mainRole, out var subRoleList))
            {
                clbSubRoles.Visible = false;
                return;
            }

            if (subRoleList.Any())
            {
                clbSubRoles.Items.AddRange(subRoleList.ToArray());
                if (checkedSubRoles != null)
                {
                    for (int i = 0; i < clbSubRoles.Items.Count; i++)
                    {
                        if (checkedSubRoles.Contains(clbSubRoles.Items[i].ToString() ?? ""))
                        {
                            clbSubRoles.SetItemChecked(i, true);
                        }
                    }
                }
                clbSubRoles.Visible = true;
            }
            else
            {
                clbSubRoles.Visible = false;
            }
        }

        // Reads the selections from the UI and combines them into a single string for the data model.
        // This is triggered whenever the main role or sub-role selections change.
        private void UpdateRoleFromUI()
        {
            if (_isProgrammaticChange || _isUpdatingRoles || _currentCredit == null) return;

            var parts = new List<string>();
            if (cmbMainRole.SelectedItem is string mainRole)
            {
                parts.Add(mainRole);
                if (clbSubRoles.Visible)
                {
                    parts.AddRange(clbSubRoles.CheckedItems.Cast<string>());
                }
            }

            string newRole = string.Join(" | ", parts);
            string oldRole = _currentCredit.Role;

            if (oldRole != newRole)
            {
                var command = new EditPropertyCommand(_currentCredit, nameof(Credit.Role), oldRole, newRole);
                _undoRedoService.Execute(command);
            }
        }

        private void LoadImage(string url)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(url)) pbCreditAvatar.LoadAsync(url);
                else pbCreditAvatar.Image = null;
            }
            catch { pbCreditAvatar.Image = null; }
        }

        private void txtCreditAvatarUrl_TextChanged(object sender, System.EventArgs e)
        {
            if (_isProgrammaticChange) return;
            LoadImage(txtCreditAvatarUrl.Text);
        }

        private void rtxtDetails_Leave(object sender, System.EventArgs e)
        {
            if (_currentCredit != null) HandleRichTextLeave(rtxtDetails, _currentCredit, nameof(Credit.ContributionDetails));
        }

        private void cmbMainRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isProgrammaticChange) return;

            _isUpdatingRoles = true;
            // When the main role changes, repopulate sub-roles but don't check any by default.
            PopulateSubRoles();
            _isUpdatingRoles = false;

            UpdateRoleFromUI();
        }

        private void clbSubRoles_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_isProgrammaticChange || _isUpdatingRoles) return;

            // The ItemCheck event fires before the CheckedItems collection is actually updated.
            // We use BeginInvoke to slightly delay the call, ensuring we read the correct state.
            BeginInvoke(new Action(UpdateRoleFromUI));
        }
    }
}