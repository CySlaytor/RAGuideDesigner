namespace RaGuideDesigner.Views
{
    partial class CreditsEditor
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.tlpUserDetails = new System.Windows.Forms.TableLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCreditUsername = new RaGuideDesigner.Views.UndoRedoRichTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCreditAvatarUrl = new RaGuideDesigner.Views.UndoRedoRichTextBox();
            this.pbCreditAvatar = new System.Windows.Forms.PictureBox();
            this.gbContribution = new System.Windows.Forms.GroupBox();
            this.tlpContribution = new System.Windows.Forms.TableLayoutPanel();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbMainRole = new System.Windows.Forms.ComboBox();
            this.clbSubRoles = new System.Windows.Forms.CheckedListBox();
            this.label17 = new System.Windows.Forms.Label();
            this.rtxtDetails = new RaGuideDesigner.Views.UndoRedoRichTextBox();
            this.pnlTop.SuspendLayout();
            this.tlpUserDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCreditAvatar)).BeginInit();
            this.gbContribution.SuspendLayout();
            this.tlpContribution.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.tlpUserDetails);
            this.pnlTop.Controls.Add(this.pbCreditAvatar);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(10, 10);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(638, 106);
            this.pnlTop.TabIndex = 20;
            // 
            // tlpUserDetails
            // 
            this.tlpUserDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpUserDetails.ColumnCount = 2;
            this.tlpUserDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpUserDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpUserDetails.Controls.Add(this.label14, 0, 0);
            this.tlpUserDetails.Controls.Add(this.txtCreditUsername, 1, 0);
            this.tlpUserDetails.Controls.Add(this.label15, 0, 1);
            this.tlpUserDetails.Controls.Add(this.txtCreditAvatarUrl, 1, 1);
            this.tlpUserDetails.Location = new System.Drawing.Point(115, 4);
            this.tlpUserDetails.Name = "tlpUserDetails";
            this.tlpUserDetails.RowCount = 2;
            this.tlpUserDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUserDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpUserDetails.Size = new System.Drawing.Size(520, 96);
            this.tlpUserDetails.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(12, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 15);
            this.label14.TabIndex = 0;
            this.label14.Text = "Username:";
            // 
            // txtCreditUsername
            // 
            this.txtCreditUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCreditUsername.Location = new System.Drawing.Point(85, 12);
            this.txtCreditUsername.Multiline = false;
            this.txtCreditUsername.Name = "txtCreditUsername";
            this.txtCreditUsername.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtCreditUsername.Size = new System.Drawing.Size(432, 23);
            this.txtCreditUsername.TabIndex = 1;
            this.txtCreditUsername.Text = "";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(3, 64);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 15);
            this.label15.TabIndex = 2;
            this.label15.Text = "Avatar URL:";
            // 
            // txtCreditAvatarUrl
            // 
            this.txtCreditAvatarUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCreditAvatarUrl.Location = new System.Drawing.Point(85, 60);
            this.txtCreditAvatarUrl.Multiline = false;
            this.txtCreditAvatarUrl.Name = "txtCreditAvatarUrl";
            this.txtCreditAvatarUrl.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtCreditAvatarUrl.Size = new System.Drawing.Size(432, 23);
            this.txtCreditAvatarUrl.TabIndex = 3;
            this.txtCreditAvatarUrl.Text = "";
            this.txtCreditAvatarUrl.TextChanged += new System.EventHandler(this.txtCreditAvatarUrl_TextChanged);
            // 
            // pbCreditAvatar
            // 
            this.pbCreditAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCreditAvatar.Location = new System.Drawing.Point(4, 4);
            this.pbCreditAvatar.Name = "pbCreditAvatar";
            this.pbCreditAvatar.Size = new System.Drawing.Size(96, 96);
            this.pbCreditAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCreditAvatar.TabIndex = 11;
            this.pbCreditAvatar.TabStop = false;
            // 
            // gbContribution
            // 
            this.gbContribution.Controls.Add(this.tlpContribution);
            this.gbContribution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbContribution.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.gbContribution.Location = new System.Drawing.Point(10, 116);
            this.gbContribution.Name = "gbContribution";
            this.gbContribution.Padding = new System.Windows.Forms.Padding(10);
            this.gbContribution.Size = new System.Drawing.Size(638, 348);
            this.gbContribution.TabIndex = 21;
            this.gbContribution.TabStop = false;
            this.gbContribution.Text = "Contribution";
            // 
            // tlpContribution
            // 
            this.tlpContribution.ColumnCount = 2;
            this.tlpContribution.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpContribution.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContribution.Controls.Add(this.label16, 0, 0);
            this.tlpContribution.Controls.Add(this.cmbMainRole, 1, 0);
            this.tlpContribution.Controls.Add(this.clbSubRoles, 1, 1);
            this.tlpContribution.Controls.Add(this.label17, 0, 2);
            this.tlpContribution.Controls.Add(this.rtxtDetails, 0, 3);
            this.tlpContribution.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContribution.Location = new System.Drawing.Point(10, 26);
            this.tlpContribution.Name = "tlpContribution";
            this.tlpContribution.RowCount = 4;
            this.tlpContribution.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContribution.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContribution.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContribution.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContribution.Size = new System.Drawing.Size(618, 312);
            this.tlpContribution.TabIndex = 0;
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(3, 7);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 15);
            this.label16.TabIndex = 0;
            this.label16.Text = "Role:";
            // 
            // cmbMainRole
            // 
            this.cmbMainRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMainRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMainRole.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbMainRole.FormattingEnabled = true;
            this.cmbMainRole.Location = new System.Drawing.Point(43, 3);
            this.cmbMainRole.Name = "cmbMainRole";
            this.cmbMainRole.Size = new System.Drawing.Size(572, 23);
            this.cmbMainRole.TabIndex = 1;
            this.cmbMainRole.SelectedIndexChanged += new System.EventHandler(this.cmbMainRole_SelectedIndexChanged);
            // 
            // clbSubRoles
            // 
            this.clbSubRoles.CheckOnClick = true;
            this.clbSubRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbSubRoles.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.clbSubRoles.FormattingEnabled = true;
            this.clbSubRoles.Location = new System.Drawing.Point(43, 32);
            this.clbSubRoles.Name = "clbSubRoles";
            this.clbSubRoles.Size = new System.Drawing.Size(572, 85);
            this.clbSubRoles.TabIndex = 2;
            this.clbSubRoles.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbSubRoles_ItemCheck);
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label17.AutoSize = true;
            this.tlpContribution.SetColumnSpan(this.label17, 2);
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label17.Location = new System.Drawing.Point(3, 123);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(125, 15);
            this.label17.TabIndex = 3;
            this.label17.Text = "Contribution Details:";
            // 
            // rtxtDetails
            // 
            this.rtxtDetails.AcceptsTab = true;
            this.tlpContribution.SetColumnSpan(this.rtxtDetails, 2);
            this.rtxtDetails.ContextMenuStrip = this.ctxMenuRichText;
            this.rtxtDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtDetails.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rtxtDetails.Location = new System.Drawing.Point(3, 141);
            this.rtxtDetails.Name = "rtxtDetails";
            this.rtxtDetails.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtxtDetails.Size = new System.Drawing.Size(612, 168);
            this.rtxtDetails.TabIndex = 4;
            this.rtxtDetails.Text = "";
            this.rtxtDetails.Leave += new System.EventHandler(this.rtxtDetails_Leave);
            // 
            // CreditsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbContribution);
            this.Controls.Add(this.pnlTop);
            this.Name = "CreditsEditor";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(658, 474);
            this.pnlTop.ResumeLayout(false);
            this.tlpUserDetails.ResumeLayout(false);
            this.tlpUserDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCreditAvatar)).EndInit();
            this.gbContribution.ResumeLayout(false);
            this.tlpContribution.ResumeLayout(false);
            this.tlpContribution.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.PictureBox pbCreditAvatar;
        private System.Windows.Forms.GroupBox gbContribution;
        private System.Windows.Forms.TableLayoutPanel tlpUserDetails;
        private System.Windows.Forms.Label label14;
        private UndoRedoRichTextBox txtCreditUsername;
        private System.Windows.Forms.Label label15;
        private UndoRedoRichTextBox txtCreditAvatarUrl;
        private System.Windows.Forms.TableLayoutPanel tlpContribution;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmbMainRole;
        private System.Windows.Forms.CheckedListBox clbSubRoles;
        private System.Windows.Forms.Label label17;
        private UndoRedoRichTextBox rtxtDetails;
    }
}