namespace RaGuideDesigner.Views
{
    partial class AchievementEditor
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            cmbAchPoints = new ComboBox();
            label1 = new Label();
            lblAchId = new Label();
            label6 = new Label();
            txtAchTitle = new UndoRedoRichTextBox();
            label4 = new Label();
            pbAchBadge = new PictureBox();
            tabControl1 = new TabControl();
            tabPageGuidance = new TabPage();
            groupBoxOptional = new GroupBox();
            lblVideoHelp = new Label();
            lblImageHelp = new Label();
            txtImageUrl = new TextBox();
            label8 = new Label();
            txtVideoUrl = new TextBox();
            label2 = new Label();
            rtxtGuidance = new UndoRedoRichTextBox();
            tabPageAdvanced = new TabPage();
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            failConditionsSplitContainer = new SplitContainer();
            lstFailConditions = new ListBox();
            txtNewFailCondition = new TextBox();
            btnRemoveFail = new Button();
            btnAddFail = new Button();
            groupBox2 = new GroupBox();
            trackingSplitContainer = new SplitContainer();
            label3 = new Label();
            txtTriggerIndicator = new TextBox();
            label5 = new Label();
            txtMeasuredIndicator = new TextBox();
            tabPageNotes = new TabPage();
            notesSplitContainer = new SplitContainer();
            groupBox3 = new GroupBox();
            txtMiscNote = new TextBox();
            groupBox4 = new GroupBox();
            txtDevNote = new TextBox();
            toolTip1 = new ToolTip(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbAchBadge).BeginInit();
            tabControl1.SuspendLayout();
            tabPageGuidance.SuspendLayout();
            groupBoxOptional.SuspendLayout();
            tabPageAdvanced.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)failConditionsSplitContainer).BeginInit();
            failConditionsSplitContainer.Panel1.SuspendLayout();
            failConditionsSplitContainer.Panel2.SuspendLayout();
            failConditionsSplitContainer.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackingSplitContainer).BeginInit();
            trackingSplitContainer.Panel1.SuspendLayout();
            trackingSplitContainer.Panel2.SuspendLayout();
            trackingSplitContainer.SuspendLayout();
            tabPageNotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)notesSplitContainer).BeginInit();
            notesSplitContainer.Panel1.SuspendLayout();
            notesSplitContainer.Panel2.SuspendLayout();
            notesSplitContainer.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(cmbAchPoints);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblAchId);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtAchTitle);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(pbAchBadge);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(638, 89);
            panel1.TabIndex = 3;
            // 
            // cmbAchPoints
            // 
            cmbAchPoints.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAchPoints.FormattingEnabled = true;
            cmbAchPoints.Location = new Point(459, 8);
            cmbAchPoints.Name = "cmbAchPoints";
            cmbAchPoints.Size = new Size(71, 23);
            cmbAchPoints.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(408, 11);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 5;
            label1.Text = "Points:";
            // 
            // lblAchId
            // 
            lblAchId.AutoSize = true;
            lblAchId.Location = new Point(111, 41);
            lblAchId.Name = "lblAchId";
            lblAchId.Size = new Size(13, 15);
            lblAchId.TabIndex = 4;
            lblAchId.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(82, 41);
            label6.Name = "label6";
            label6.Size = new Size(23, 15);
            label6.TabIndex = 3;
            label6.Text = "ID:";
            // 
            // txtAchTitle
            // 
            txtAchTitle.Location = new Point(111, 8);
            txtAchTitle.Multiline = false;
            txtAchTitle.Name = "txtAchTitle";
            txtAchTitle.ScrollBars = RichTextBoxScrollBars.None;
            txtAchTitle.Size = new Size(288, 23);
            txtAchTitle.TabIndex = 2;
            txtAchTitle.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(72, 11);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 1;
            label4.Text = "Title:";
            // 
            // pbAchBadge
            // 
            pbAchBadge.BorderStyle = BorderStyle.FixedSingle;
            pbAchBadge.Location = new Point(4, 4);
            pbAchBadge.Name = "pbAchBadge";
            pbAchBadge.Size = new Size(64, 64);
            pbAchBadge.SizeMode = PictureBoxSizeMode.Zoom;
            pbAchBadge.TabIndex = 0;
            pbAchBadge.TabStop = false;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageGuidance);
            tabControl1.Controls.Add(tabPageAdvanced);
            tabControl1.Controls.Add(tabPageNotes);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(10, 99);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(638, 365);
            tabControl1.TabIndex = 6;
            // 
            // tabPageGuidance
            // 
            tabPageGuidance.Controls.Add(groupBoxOptional);
            tabPageGuidance.Controls.Add(rtxtGuidance);
            tabPageGuidance.Location = new Point(4, 24);
            tabPageGuidance.Name = "tabPageGuidance";
            tabPageGuidance.Padding = new Padding(3);
            tabPageGuidance.Size = new Size(630, 337);
            tabPageGuidance.TabIndex = 0;
            tabPageGuidance.Text = "Guidance & Insights";
            tabPageGuidance.UseVisualStyleBackColor = true;
            // 
            // groupBoxOptional
            // 
            groupBoxOptional.Controls.Add(lblVideoHelp);
            groupBoxOptional.Controls.Add(lblImageHelp);
            groupBoxOptional.Controls.Add(txtImageUrl);
            groupBoxOptional.Controls.Add(label8);
            groupBoxOptional.Controls.Add(txtVideoUrl);
            groupBoxOptional.Controls.Add(label2);
            groupBoxOptional.Dock = DockStyle.Bottom;
            groupBoxOptional.Location = new Point(3, 252);
            groupBoxOptional.Name = "groupBoxOptional";
            groupBoxOptional.Size = new Size(624, 82);
            groupBoxOptional.TabIndex = 1;
            groupBoxOptional.TabStop = false;
            groupBoxOptional.Text = "Optional Elements";
            // 
            // lblVideoHelp
            // 
            lblVideoHelp.AutoSize = true;
            lblVideoHelp.Cursor = Cursors.Help;
            lblVideoHelp.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblVideoHelp.Location = new Point(166, 52);
            lblVideoHelp.Name = "lblVideoHelp";
            lblVideoHelp.Size = new Size(20, 15);
            lblVideoHelp.TabIndex = 5;
            lblVideoHelp.Text = "[?]";
            // 
            // lblImageHelp
            // 
            lblImageHelp.AutoSize = true;
            lblImageHelp.Cursor = Cursors.Help;
            lblImageHelp.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblImageHelp.Location = new Point(86, 23);
            lblImageHelp.Name = "lblImageHelp";
            lblImageHelp.Size = new Size(20, 15);
            lblImageHelp.TabIndex = 4;
            lblImageHelp.Text = "[?]";
            // 
            // txtImageUrl
            // 
            txtImageUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtImageUrl.Location = new Point(197, 20);
            txtImageUrl.Name = "txtImageUrl";
            txtImageUrl.Size = new Size(421, 23);
            txtImageUrl.TabIndex = 3;
            txtImageUrl.Leave += txtImageUrl_Leave;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 23);
            label8.Name = "label8";
            label8.Size = new Size(82, 15);
            label8.TabIndex = 2;
            label8.Text = "🖼️ Image URL:";
            // 
            // txtVideoUrl
            // 
            txtVideoUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtVideoUrl.Location = new Point(197, 49);
            txtVideoUrl.Name = "txtVideoUrl";
            txtVideoUrl.Size = new Size(421, 23);
            txtVideoUrl.TabIndex = 1;
            txtVideoUrl.Leave += txtVideoUrl_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 52);
            label2.Name = "label2";
            label2.Size = new Size(162, 15);
            label2.TabIndex = 0;
            label2.Text = "▶️ Watch Video Walkthrough:";
            // 
            // rtxtGuidance
            // 
            rtxtGuidance.AcceptsTab = true;
            rtxtGuidance.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtxtGuidance.ContextMenuStrip = ctxMenuRichText;
            rtxtGuidance.Location = new Point(3, 3);
            rtxtGuidance.Name = "rtxtGuidance";
            rtxtGuidance.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtxtGuidance.Size = new Size(624, 243);
            rtxtGuidance.TabIndex = 0;
            rtxtGuidance.Text = "";
            rtxtGuidance.Leave += rtxtGuidance_Leave;
            // 
            // tabPageAdvanced
            // 
            tabPageAdvanced.Controls.Add(splitContainer1);
            tabPageAdvanced.Location = new Point(4, 24);
            tabPageAdvanced.Name = "tabPageAdvanced";
            tabPageAdvanced.Padding = new Padding(3);
            tabPageAdvanced.Size = new Size(630, 337);
            tabPageAdvanced.TabIndex = 1;
            tabPageAdvanced.Text = "Fail Conditions & Tracking";
            tabPageAdvanced.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Panel1MinSize = 250;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox2);
            splitContainer1.Panel2MinSize = 250;
            splitContainer1.Size = new Size(624, 331);
            splitContainer1.SplitterDistance = 340;
            splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(failConditionsSplitContainer);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(340, 331);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Fail Conditions";
            // 
            // failConditionsSplitContainer
            // 
            failConditionsSplitContainer.Dock = DockStyle.Fill;
            failConditionsSplitContainer.Location = new Point(3, 19);
            failConditionsSplitContainer.Name = "failConditionsSplitContainer";
            failConditionsSplitContainer.Orientation = Orientation.Horizontal;
            // 
            // failConditionsSplitContainer.Panel1
            // 
            failConditionsSplitContainer.Panel1.Controls.Add(lstFailConditions);
            failConditionsSplitContainer.Panel1MinSize = 100;
            // 
            // failConditionsSplitContainer.Panel2
            // 
            failConditionsSplitContainer.Panel2.Controls.Add(txtNewFailCondition);
            failConditionsSplitContainer.Panel2.Controls.Add(btnRemoveFail);
            failConditionsSplitContainer.Panel2.Controls.Add(btnAddFail);
            failConditionsSplitContainer.Panel2MinSize = 100;
            failConditionsSplitContainer.Size = new Size(334, 309);
            failConditionsSplitContainer.SplitterDistance = 150;
            failConditionsSplitContainer.TabIndex = 4;
            // 
            // lstFailConditions
            // 
            lstFailConditions.Dock = DockStyle.Fill;
            lstFailConditions.FormattingEnabled = true;
            lstFailConditions.ItemHeight = 15;
            lstFailConditions.Location = new Point(0, 0);
            lstFailConditions.Name = "lstFailConditions";
            lstFailConditions.Size = new Size(334, 150);
            lstFailConditions.TabIndex = 0;
            lstFailConditions.SelectedIndexChanged += lstFailConditions_SelectedIndexChanged;
            lstFailConditions.DoubleClick += lstFailConditions_DoubleClick;
            // 
            // txtNewFailCondition
            // 
            txtNewFailCondition.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtNewFailCondition.Location = new Point(0, 3);
            txtNewFailCondition.Multiline = true;
            txtNewFailCondition.Name = "txtNewFailCondition";
            txtNewFailCondition.ScrollBars = ScrollBars.Vertical;
            txtNewFailCondition.Size = new Size(334, 119);
            txtNewFailCondition.TabIndex = 1;
            // 
            // btnRemoveFail
            // 
            btnRemoveFail.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRemoveFail.Location = new Point(256, 128);
            btnRemoveFail.Name = "btnRemoveFail";
            btnRemoveFail.Size = new Size(75, 23);
            btnRemoveFail.TabIndex = 3;
            btnRemoveFail.Text = "Remove";
            btnRemoveFail.UseVisualStyleBackColor = true;
            btnRemoveFail.Click += btnRemoveFail_Click;
            // 
            // btnAddFail
            // 
            btnAddFail.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddFail.Location = new Point(175, 128);
            btnAddFail.Name = "btnAddFail";
            btnAddFail.Size = new Size(75, 23);
            btnAddFail.TabIndex = 2;
            btnAddFail.Text = "Add";
            btnAddFail.UseVisualStyleBackColor = true;
            btnAddFail.Click += btnAddFail_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(trackingSplitContainer);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(280, 331);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Achievement Tracking";
            // 
            // trackingSplitContainer
            // 
            trackingSplitContainer.Dock = DockStyle.Fill;
            trackingSplitContainer.Location = new Point(3, 19);
            trackingSplitContainer.Name = "trackingSplitContainer";
            trackingSplitContainer.Orientation = Orientation.Horizontal;
            // 
            // trackingSplitContainer.Panel1
            // 
            trackingSplitContainer.Panel1.Controls.Add(label3);
            trackingSplitContainer.Panel1.Controls.Add(txtTriggerIndicator);
            trackingSplitContainer.Panel1MinSize = 100;
            // 
            // trackingSplitContainer.Panel2
            // 
            trackingSplitContainer.Panel2.Controls.Add(label5);
            trackingSplitContainer.Panel2.Controls.Add(txtMeasuredIndicator);
            trackingSplitContainer.Panel2MinSize = 100;
            trackingSplitContainer.Size = new Size(274, 309);
            trackingSplitContainer.SplitterDistance = 150;
            trackingSplitContainer.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 4);
            label3.Name = "label3";
            label3.Size = new Size(97, 15);
            label3.TabIndex = 0;
            label3.Text = "Trigger Indicator:";
            // 
            // txtTriggerIndicator
            // 
            txtTriggerIndicator.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtTriggerIndicator.Location = new Point(3, 22);
            txtTriggerIndicator.Multiline = true;
            txtTriggerIndicator.Name = "txtTriggerIndicator";
            txtTriggerIndicator.ScrollBars = ScrollBars.Vertical;
            txtTriggerIndicator.Size = new Size(268, 125);
            txtTriggerIndicator.TabIndex = 1;
            txtTriggerIndicator.Leave += txtTriggerIndicator_Leave;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 4);
            label5.Name = "label5";
            label5.Size = new Size(112, 15);
            label5.TabIndex = 2;
            label5.Text = "Measured Indicator:";
            // 
            // txtMeasuredIndicator
            // 
            txtMeasuredIndicator.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtMeasuredIndicator.Location = new Point(3, 22);
            txtMeasuredIndicator.Multiline = true;
            txtMeasuredIndicator.Name = "txtMeasuredIndicator";
            txtMeasuredIndicator.ScrollBars = ScrollBars.Vertical;
            txtMeasuredIndicator.Size = new Size(268, 130);
            txtMeasuredIndicator.TabIndex = 3;
            txtMeasuredIndicator.Leave += txtMeasuredIndicator_Leave;
            // 
            // tabPageNotes
            // 
            tabPageNotes.Controls.Add(notesSplitContainer);
            tabPageNotes.Location = new Point(4, 24);
            tabPageNotes.Name = "tabPageNotes";
            tabPageNotes.Padding = new Padding(3);
            tabPageNotes.Size = new Size(630, 337);
            tabPageNotes.TabIndex = 2;
            tabPageNotes.Text = "Misc / Dev Notes";
            tabPageNotes.UseVisualStyleBackColor = true;
            // 
            // notesSplitContainer
            // 
            notesSplitContainer.Dock = DockStyle.Fill;
            notesSplitContainer.Location = new Point(3, 3);
            notesSplitContainer.Name = "notesSplitContainer";
            notesSplitContainer.Orientation = Orientation.Horizontal;
            // 
            // notesSplitContainer.Panel1
            // 
            notesSplitContainer.Panel1.Controls.Add(groupBox3);
            notesSplitContainer.Panel1MinSize = 120;
            // 
            // notesSplitContainer.Panel2
            // 
            notesSplitContainer.Panel2.Controls.Add(groupBox4);
            notesSplitContainer.Panel2MinSize = 120;
            notesSplitContainer.Size = new Size(624, 331);
            notesSplitContainer.SplitterDistance = 160;
            notesSplitContainer.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtMiscNote);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Location = new Point(0, 0);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(10);
            groupBox3.Size = new Size(624, 160);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Misc Note";
            // 
            // txtMiscNote
            // 
            txtMiscNote.Dock = DockStyle.Fill;
            txtMiscNote.Location = new Point(10, 26);
            txtMiscNote.Multiline = true;
            txtMiscNote.Name = "txtMiscNote";
            txtMiscNote.ScrollBars = ScrollBars.Vertical;
            txtMiscNote.Size = new Size(604, 124);
            txtMiscNote.TabIndex = 0;
            txtMiscNote.Leave += txtMiscNote_Leave;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(txtDevNote);
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Location = new Point(0, 0);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(10);
            groupBox4.Size = new Size(624, 167);
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "Dev Note";
            // 
            // txtDevNote
            // 
            txtDevNote.Dock = DockStyle.Fill;
            txtDevNote.Location = new Point(10, 26);
            txtDevNote.Multiline = true;
            txtDevNote.Name = "txtDevNote";
            txtDevNote.ScrollBars = ScrollBars.Vertical;
            txtDevNote.Size = new Size(604, 131);
            txtDevNote.TabIndex = 0;
            txtDevNote.Leave += txtDevNote_Leave;
            // 
            // AchievementEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Name = "AchievementEditor";
            Padding = new Padding(10);
            Size = new Size(658, 474);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbAchBadge).EndInit();
            tabControl1.ResumeLayout(false);
            tabPageGuidance.ResumeLayout(false);
            groupBoxOptional.ResumeLayout(false);
            groupBoxOptional.PerformLayout();
            tabPageAdvanced.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            failConditionsSplitContainer.Panel1.ResumeLayout(false);
            failConditionsSplitContainer.Panel2.ResumeLayout(false);
            failConditionsSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)failConditionsSplitContainer).EndInit();
            failConditionsSplitContainer.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            trackingSplitContainer.Panel1.ResumeLayout(false);
            trackingSplitContainer.Panel1.PerformLayout();
            trackingSplitContainer.Panel2.ResumeLayout(false);
            trackingSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackingSplitContainer).EndInit();
            trackingSplitContainer.ResumeLayout(false);
            tabPageNotes.ResumeLayout(false);
            notesSplitContainer.Panel1.ResumeLayout(false);
            notesSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)notesSplitContainer).EndInit();
            notesSplitContainer.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAchId;
        private System.Windows.Forms.Label label6;
        private UndoRedoRichTextBox txtAchTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbAchBadge;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageGuidance;
        private UndoRedoRichTextBox rtxtGuidance;
        private System.Windows.Forms.ComboBox cmbAchPoints;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxOptional;
        private System.Windows.Forms.TextBox txtVideoUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPageAdvanced;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRemoveFail;
        private System.Windows.Forms.Button btnAddFail;
        private System.Windows.Forms.TextBox txtNewFailCondition;
        private System.Windows.Forms.ListBox lstFailConditions;
        private System.Windows.Forms.TextBox txtMeasuredIndicator;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTriggerIndicator;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer failConditionsSplitContainer;
        private System.Windows.Forms.SplitContainer trackingSplitContainer;
        private System.Windows.Forms.TabPage tabPageNotes;
        private System.Windows.Forms.SplitContainer notesSplitContainer;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtMiscNote;
        private System.Windows.Forms.TextBox txtDevNote;
        private System.Windows.Forms.TextBox txtImageUrl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblVideoHelp;
        private System.Windows.Forms.Label lblImageHelp;
    }
}