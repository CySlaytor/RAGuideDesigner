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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbAchPoints = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAchId = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAchTitle = new RaGuideDesigner.Views.UndoRedoRichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pbAchBadge = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageGuidance = new System.Windows.Forms.TabPage();
            this.groupBoxOptional = new System.Windows.Forms.GroupBox();
            this.txtVideoUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtxtGuidance = new RaGuideDesigner.Views.UndoRedoRichTextBox();
            this.tabPageAdvanced = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.failConditionsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.lstFailConditions = new System.Windows.Forms.ListBox();
            this.txtNewFailCondition = new System.Windows.Forms.TextBox();
            this.btnRemoveFail = new System.Windows.Forms.Button();
            this.btnAddFail = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.trackingSplitContainer = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTriggerIndicator = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMeasuredIndicator = new System.Windows.Forms.TextBox();
            this.tabPageNotes = new System.Windows.Forms.TabPage();
            this.notesSplitContainer = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtMiscNote = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtDevNote = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAchBadge)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageGuidance.SuspendLayout();
            this.groupBoxOptional.SuspendLayout();
            this.tabPageAdvanced.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.failConditionsSplitContainer)).BeginInit();
            this.failConditionsSplitContainer.Panel1.SuspendLayout();
            this.failConditionsSplitContainer.Panel2.SuspendLayout();
            this.failConditionsSplitContainer.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackingSplitContainer)).BeginInit();
            this.trackingSplitContainer.Panel1.SuspendLayout();
            this.trackingSplitContainer.Panel2.SuspendLayout();
            this.trackingSplitContainer.SuspendLayout();
            this.tabPageNotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notesSplitContainer)).BeginInit();
            this.notesSplitContainer.Panel1.SuspendLayout();
            this.notesSplitContainer.Panel2.SuspendLayout();
            this.notesSplitContainer.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbAchPoints);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblAchId);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtAchTitle);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pbAchBadge);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(638, 89);
            this.panel1.TabIndex = 3;
            // 
            // cmbAchPoints
            // 
            this.cmbAchPoints.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAchPoints.FormattingEnabled = true;
            this.cmbAchPoints.Location = new System.Drawing.Point(459, 8);
            this.cmbAchPoints.Name = "cmbAchPoints";
            this.cmbAchPoints.Size = new System.Drawing.Size(71, 23);
            this.cmbAchPoints.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(408, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Points:";
            // 
            // lblAchId
            // 
            this.lblAchId.AutoSize = true;
            this.lblAchId.Location = new System.Drawing.Point(111, 41);
            this.lblAchId.Name = "lblAchId";
            this.lblAchId.Size = new System.Drawing.Size(13, 15);
            this.lblAchId.TabIndex = 4;
            this.lblAchId.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(82, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "ID:";
            // 
            // txtAchTitle
            // 
            this.txtAchTitle.Location = new System.Drawing.Point(111, 8);
            this.txtAchTitle.Multiline = false;
            this.txtAchTitle.Name = "txtAchTitle";
            this.txtAchTitle.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtAchTitle.Size = new System.Drawing.Size(288, 23);
            this.txtAchTitle.TabIndex = 2;
            this.txtAchTitle.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(72, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Title:";
            // 
            // pbAchBadge
            // 
            this.pbAchBadge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAchBadge.Location = new System.Drawing.Point(4, 4);
            this.pbAchBadge.Name = "pbAchBadge";
            this.pbAchBadge.Size = new System.Drawing.Size(64, 64);
            this.pbAchBadge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbAchBadge.TabIndex = 0;
            this.pbAchBadge.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageGuidance);
            this.tabControl1.Controls.Add(this.tabPageAdvanced);
            this.tabControl1.Controls.Add(this.tabPageNotes);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(10, 99);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(638, 365);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPageGuidance
            // 
            this.tabPageGuidance.Controls.Add(this.groupBoxOptional);
            this.tabPageGuidance.Controls.Add(this.rtxtGuidance);
            this.tabPageGuidance.Location = new System.Drawing.Point(4, 24);
            this.tabPageGuidance.Name = "tabPageGuidance";
            this.tabPageGuidance.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGuidance.Size = new System.Drawing.Size(630, 337);
            this.tabPageGuidance.TabIndex = 0;
            this.tabPageGuidance.Text = "Guidance & Insights";
            this.tabPageGuidance.UseVisualStyleBackColor = true;
            // 
            // groupBoxOptional
            // 
            this.groupBoxOptional.Controls.Add(this.txtVideoUrl);
            this.groupBoxOptional.Controls.Add(this.label2);
            this.groupBoxOptional.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxOptional.Location = new System.Drawing.Point(3, 281);
            this.groupBoxOptional.Name = "groupBoxOptional";
            this.groupBoxOptional.Size = new System.Drawing.Size(624, 53);
            this.groupBoxOptional.TabIndex = 1;
            this.groupBoxOptional.TabStop = false;
            this.groupBoxOptional.Text = "Optional Elements";
            // 
            // txtVideoUrl
            // 
            this.txtVideoUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVideoUrl.Location = new System.Drawing.Point(173, 20);
            this.txtVideoUrl.Name = "txtVideoUrl";
            this.txtVideoUrl.Size = new System.Drawing.Size(445, 23);
            this.txtVideoUrl.TabIndex = 1;
            this.txtVideoUrl.Leave += new System.EventHandler(this.txtVideoUrl_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "▶️ Watch Video Walkthrough:";
            // 
            // rtxtGuidance
            // 
            this.rtxtGuidance.AcceptsTab = true;
            this.rtxtGuidance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtGuidance.ContextMenuStrip = this.ctxMenuRichText;
            this.rtxtGuidance.Location = new System.Drawing.Point(3, 3);
            this.rtxtGuidance.Name = "rtxtGuidance";
            this.rtxtGuidance.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtxtGuidance.Size = new System.Drawing.Size(624, 272);
            this.rtxtGuidance.TabIndex = 0;
            this.rtxtGuidance.Text = "";
            this.rtxtGuidance.Leave += new System.EventHandler(this.rtxtGuidance_Leave);
            // 
            // tabPageAdvanced
            // 
            this.tabPageAdvanced.Controls.Add(this.splitContainer1);
            this.tabPageAdvanced.Location = new System.Drawing.Point(4, 24);
            this.tabPageAdvanced.Name = "tabPageAdvanced";
            this.tabPageAdvanced.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdvanced.Size = new System.Drawing.Size(630, 337);
            this.tabPageAdvanced.TabIndex = 1;
            this.tabPageAdvanced.Text = "Fail Conditions & Tracking";
            this.tabPageAdvanced.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1MinSize = 250;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2MinSize = 250;
            this.splitContainer1.Size = new System.Drawing.Size(624, 331);
            this.splitContainer1.SplitterDistance = 340;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.failConditionsSplitContainer);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 331);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fail Conditions";
            // 
            // failConditionsSplitContainer
            // 
            this.failConditionsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.failConditionsSplitContainer.Location = new System.Drawing.Point(3, 19);
            this.failConditionsSplitContainer.Name = "failConditionsSplitContainer";
            this.failConditionsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // failConditionsSplitContainer.Panel1
            // 
            this.failConditionsSplitContainer.Panel1.Controls.Add(this.lstFailConditions);
            this.failConditionsSplitContainer.Panel1MinSize = 100;
            // 
            // failConditionsSplitContainer.Panel2
            // 
            this.failConditionsSplitContainer.Panel2.Controls.Add(this.txtNewFailCondition);
            this.failConditionsSplitContainer.Panel2.Controls.Add(this.btnRemoveFail);
            this.failConditionsSplitContainer.Panel2.Controls.Add(this.btnAddFail);
            this.failConditionsSplitContainer.Panel2MinSize = 100;
            this.failConditionsSplitContainer.Size = new System.Drawing.Size(334, 309);
            this.failConditionsSplitContainer.SplitterDistance = 150;
            this.failConditionsSplitContainer.TabIndex = 4;
            // 
            // lstFailConditions
            // 
            this.lstFailConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFailConditions.FormattingEnabled = true;
            this.lstFailConditions.ItemHeight = 15;
            this.lstFailConditions.Location = new System.Drawing.Point(0, 0);
            this.lstFailConditions.Name = "lstFailConditions";
            this.lstFailConditions.Size = new System.Drawing.Size(334, 150);
            this.lstFailConditions.TabIndex = 0;
            // 
            // txtNewFailCondition
            // 
            this.txtNewFailCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewFailCondition.Location = new System.Drawing.Point(0, 3);
            this.txtNewFailCondition.Multiline = true;
            this.txtNewFailCondition.Name = "txtNewFailCondition";
            this.txtNewFailCondition.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNewFailCondition.Size = new System.Drawing.Size(334, 119);
            this.txtNewFailCondition.TabIndex = 1;
            // 
            // btnRemoveFail
            // 
            this.btnRemoveFail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveFail.Location = new System.Drawing.Point(256, 128);
            this.btnRemoveFail.Name = "btnRemoveFail";
            this.btnRemoveFail.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveFail.TabIndex = 3;
            this.btnRemoveFail.Text = "Remove";
            this.btnRemoveFail.UseVisualStyleBackColor = true;
            this.btnRemoveFail.Click += new System.EventHandler(this.btnRemoveFail_Click);
            // 
            // btnAddFail
            // 
            this.btnAddFail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFail.Location = new System.Drawing.Point(175, 128);
            this.btnAddFail.Name = "btnAddFail";
            this.btnAddFail.Size = new System.Drawing.Size(75, 23);
            this.btnAddFail.TabIndex = 2;
            this.btnAddFail.Text = "Add";
            this.btnAddFail.UseVisualStyleBackColor = true;
            this.btnAddFail.Click += new System.EventHandler(this.btnAddFail_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.trackingSplitContainer);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 331);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Achievement Tracking";
            // 
            // trackingSplitContainer
            // 
            this.trackingSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackingSplitContainer.Location = new System.Drawing.Point(3, 19);
            this.trackingSplitContainer.Name = "trackingSplitContainer";
            this.trackingSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // trackingSplitContainer.Panel1
            // 
            this.trackingSplitContainer.Panel1.Controls.Add(this.label3);
            this.trackingSplitContainer.Panel1.Controls.Add(this.txtTriggerIndicator);
            this.trackingSplitContainer.Panel1MinSize = 100;
            // 
            // trackingSplitContainer.Panel2
            // 
            this.trackingSplitContainer.Panel2.Controls.Add(this.label5);
            this.trackingSplitContainer.Panel2.Controls.Add(this.txtMeasuredIndicator);
            this.trackingSplitContainer.Panel2MinSize = 100;
            this.trackingSplitContainer.Size = new System.Drawing.Size(274, 309);
            this.trackingSplitContainer.SplitterDistance = 150;
            this.trackingSplitContainer.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Trigger Indicator:";
            // 
            // txtTriggerIndicator
            // 
            this.txtTriggerIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTriggerIndicator.Location = new System.Drawing.Point(3, 22);
            this.txtTriggerIndicator.Multiline = true;
            this.txtTriggerIndicator.Name = "txtTriggerIndicator";
            this.txtTriggerIndicator.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTriggerIndicator.Size = new System.Drawing.Size(268, 125);
            this.txtTriggerIndicator.TabIndex = 1;
            this.txtTriggerIndicator.Leave += new System.EventHandler(this.txtTriggerIndicator_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Measured Indicator:";
            // 
            // txtMeasuredIndicator
            // 
            this.txtMeasuredIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMeasuredIndicator.Location = new System.Drawing.Point(3, 22);
            this.txtMeasuredIndicator.Multiline = true;
            this.txtMeasuredIndicator.Name = "txtMeasuredIndicator";
            this.txtMeasuredIndicator.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMeasuredIndicator.Size = new System.Drawing.Size(268, 130);
            this.txtMeasuredIndicator.TabIndex = 3;
            this.txtMeasuredIndicator.Leave += new System.EventHandler(this.txtMeasuredIndicator_Leave);
            // 
            // tabPageNotes
            // 
            this.tabPageNotes.Controls.Add(this.notesSplitContainer);
            this.tabPageNotes.Location = new System.Drawing.Point(4, 24);
            this.tabPageNotes.Name = "tabPageNotes";
            this.tabPageNotes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNotes.Size = new System.Drawing.Size(630, 337);
            this.tabPageNotes.TabIndex = 2;
            this.tabPageNotes.Text = "Misc / Dev Notes";
            this.tabPageNotes.UseVisualStyleBackColor = true;
            // 
            // notesSplitContainer
            // 
            this.notesSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.notesSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.notesSplitContainer.Name = "notesSplitContainer";
            this.notesSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // notesSplitContainer.Panel1
            // 
            this.notesSplitContainer.Panel1.Controls.Add(this.groupBox3);
            this.notesSplitContainer.Panel1MinSize = 120;
            // 
            // notesSplitContainer.Panel2
            // 
            this.notesSplitContainer.Panel2.Controls.Add(this.groupBox4);
            this.notesSplitContainer.Panel2MinSize = 120;
            this.notesSplitContainer.Size = new System.Drawing.Size(624, 331);
            this.notesSplitContainer.SplitterDistance = 160;
            this.notesSplitContainer.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtMiscNote);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox3.Size = new System.Drawing.Size(624, 160);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Misc Note";
            // 
            // txtMiscNote
            // 
            this.txtMiscNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMiscNote.Location = new System.Drawing.Point(10, 26);
            this.txtMiscNote.Multiline = true;
            this.txtMiscNote.Name = "txtMiscNote";
            this.txtMiscNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMiscNote.Size = new System.Drawing.Size(604, 124);
            this.txtMiscNote.TabIndex = 0;
            this.txtMiscNote.Leave += new System.EventHandler(this.txtMiscNote_Leave);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtDevNote);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox4.Size = new System.Drawing.Size(624, 167);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Dev Note";
            // 
            // txtDevNote
            // 
            this.txtDevNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDevNote.Location = new System.Drawing.Point(10, 26);
            this.txtDevNote.Multiline = true;
            this.txtDevNote.Name = "txtDevNote";
            this.txtDevNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDevNote.Size = new System.Drawing.Size(604, 131);
            this.txtDevNote.TabIndex = 0;
            this.txtDevNote.Leave += new System.EventHandler(this.txtDevNote_Leave);
            // 
            // AchievementEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "AchievementEditor";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(658, 474);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAchBadge)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageGuidance.ResumeLayout(false);
            this.groupBoxOptional.ResumeLayout(false);
            this.groupBoxOptional.PerformLayout();
            this.tabPageAdvanced.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.failConditionsSplitContainer.Panel1.ResumeLayout(false);
            this.failConditionsSplitContainer.Panel2.ResumeLayout(false);
            this.failConditionsSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.failConditionsSplitContainer)).EndInit();
            this.failConditionsSplitContainer.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.trackingSplitContainer.Panel1.ResumeLayout(false);
            this.trackingSplitContainer.Panel1.PerformLayout();
            this.trackingSplitContainer.Panel2.ResumeLayout(false);
            this.trackingSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackingSplitContainer)).EndInit();
            this.trackingSplitContainer.ResumeLayout(false);
            this.tabPageNotes.ResumeLayout(false);
            this.notesSplitContainer.Panel1.ResumeLayout(false);
            this.notesSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.notesSplitContainer)).EndInit();
            this.notesSplitContainer.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

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
    }
}