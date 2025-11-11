namespace RaGuideDesigner.Views
{
    partial class HeaderEditor
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
            pbMasteryIcon = new PictureBox();
            label3 = new Label();
            label2 = new Label();
            label7 = new Label();
            label1 = new Label();
            txtGameTitle = new UndoRedoRichTextBox();
            txtMasteryIconUrl = new UndoRedoRichTextBox();
            txtBannerUrl = new UndoRedoRichTextBox();
            pnlBannerFrame = new Panel();
            lblBannerHint = new Label();
            pbBanner = new PictureBox();
            cmbPlatform = new ComboBox();
            tlpHeaderInputs = new TableLayoutPanel();
            pnlTop = new Panel();
            tabControlHeader = new TabControl();
            tabPageHeader = new TabPage();
            splitIntroStats = new SplitContainer();
            pnlIntro = new Panel();
            rtxtIntro = new UndoRedoRichTextBox();
            label8 = new Label();
            grpStatistics = new GroupBox();
            tlpStats = new TableLayoutPanel();
            label6 = new Label();
            lblAchCountValue = new Label();
            label9 = new Label();
            lblPointsValue = new Label();
            label11 = new Label();
            lblCategoriesValue = new Label();
            label13 = new Label();
            lblLeaderboardsValue = new Label();
            label15 = new Label();
            lblCreditsValue = new Label();
            tabPageFootnotes = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            rtxtMeasuredExamples = new UndoRedoRichTextBox();
            label4 = new Label();
            groupBox2 = new GroupBox();
            rtxtTriggerExamples = new UndoRedoRichTextBox();
            label5 = new Label();
            pnlFootnoteTemplate = new Panel();
            cmbFootnoteTemplates = new ComboBox();
            lblFootnoteTemplate = new Label();
            ((System.ComponentModel.ISupportInitialize)pbMasteryIcon).BeginInit();
            pnlBannerFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbBanner).BeginInit();
            tlpHeaderInputs.SuspendLayout();
            pnlTop.SuspendLayout();
            tabControlHeader.SuspendLayout();
            tabPageHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitIntroStats).BeginInit();
            splitIntroStats.Panel1.SuspendLayout();
            splitIntroStats.Panel2.SuspendLayout();
            splitIntroStats.SuspendLayout();
            pnlIntro.SuspendLayout();
            grpStatistics.SuspendLayout();
            tlpStats.SuspendLayout();
            tabPageFootnotes.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            pnlFootnoteTemplate.SuspendLayout();
            SuspendLayout();
            // 
            // pbMasteryIcon
            // 
            pbMasteryIcon.BorderStyle = BorderStyle.FixedSingle;
            pbMasteryIcon.Dock = DockStyle.Right;
            pbMasteryIcon.Location = new Point(628, 0);
            pbMasteryIcon.Name = "pbMasteryIcon";
            pbMasteryIcon.Size = new Size(96, 92);
            pbMasteryIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pbMasteryIcon.TabIndex = 21;
            pbMasteryIcon.TabStop = false;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(9, 37);
            label3.Name = "label3";
            label3.Size = new Size(82, 15);
            label3.TabIndex = 19;
            label3.Text = "Mastery Icon:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(3, 68);
            label2.Name = "label2";
            label2.Size = new Size(88, 15);
            label2.TabIndex = 16;
            label2.Text = "Banner Image:";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(331, 7);
            label7.Name = "label7";
            label7.Size = new Size(59, 15);
            label7.TabIndex = 14;
            label7.Text = "Platform:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(20, 7);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 12;
            label1.Text = "Game Title:";
            // 
            // txtGameTitle
            // 
            txtGameTitle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtGameTitle.Location = new Point(97, 3);
            txtGameTitle.Multiline = false;
            txtGameTitle.Name = "txtGameTitle";
            txtGameTitle.ScrollBars = RichTextBoxScrollBars.None;
            txtGameTitle.Size = new Size(228, 23);
            txtGameTitle.TabIndex = 13;
            txtGameTitle.Text = "";
            // 
            // txtMasteryIconUrl
            // 
            txtMasteryIconUrl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tlpHeaderInputs.SetColumnSpan(txtMasteryIconUrl, 3);
            txtMasteryIconUrl.Location = new Point(97, 33);
            txtMasteryIconUrl.Multiline = false;
            txtMasteryIconUrl.Name = "txtMasteryIconUrl";
            txtMasteryIconUrl.ScrollBars = RichTextBoxScrollBars.None;
            txtMasteryIconUrl.Size = new Size(528, 23);
            txtMasteryIconUrl.TabIndex = 20;
            txtMasteryIconUrl.Text = "";
            // 
            // txtBannerUrl
            // 
            txtBannerUrl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tlpHeaderInputs.SetColumnSpan(txtBannerUrl, 3);
            txtBannerUrl.Location = new Point(97, 64);
            txtBannerUrl.Multiline = false;
            txtBannerUrl.Name = "txtBannerUrl";
            txtBannerUrl.ScrollBars = RichTextBoxScrollBars.None;
            txtBannerUrl.Size = new Size(528, 23);
            txtBannerUrl.TabIndex = 17;
            txtBannerUrl.Text = "";
            // 
            // pnlBannerFrame
            // 
            pnlBannerFrame.BackColor = SystemColors.ControlDark;
            pnlBannerFrame.BorderStyle = BorderStyle.FixedSingle;
            pnlBannerFrame.Controls.Add(lblBannerHint);
            pnlBannerFrame.Controls.Add(pbBanner);
            pnlBannerFrame.Dock = DockStyle.Top;
            pnlBannerFrame.Location = new Point(10, 102);
            pnlBannerFrame.Name = "pnlBannerFrame";
            pnlBannerFrame.Padding = new Padding(10);
            pnlBannerFrame.Size = new Size(724, 302);
            pnlBannerFrame.TabIndex = 24;
            // 
            // lblBannerHint
            // 
            lblBannerHint.BackColor = SystemColors.ControlLight;
            lblBannerHint.Dock = DockStyle.Fill;
            lblBannerHint.Font = new Font("Dosis", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBannerHint.ForeColor = SystemColors.ActiveCaptionText;
            lblBannerHint.Location = new Point(10, 10);
            lblBannerHint.Name = "lblBannerHint";
            lblBannerHint.Size = new Size(702, 280);
            lblBannerHint.TabIndex = 20;
            lblBannerHint.Text = "Recommended size: 600x280";
            lblBannerHint.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pbBanner
            // 
            pbBanner.BackColor = Color.Transparent;
            pbBanner.Dock = DockStyle.Fill;
            pbBanner.Location = new Point(10, 10);
            pbBanner.Name = "pbBanner";
            pbBanner.Size = new Size(702, 280);
            pbBanner.SizeMode = PictureBoxSizeMode.Zoom;
            pbBanner.TabIndex = 19;
            pbBanner.TabStop = false;
            // 
            // cmbPlatform
            // 
            cmbPlatform.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbPlatform.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPlatform.FormattingEnabled = true;
            cmbPlatform.Location = new Point(396, 3);
            cmbPlatform.Name = "cmbPlatform";
            cmbPlatform.Size = new Size(229, 23);
            cmbPlatform.TabIndex = 24;
            // 
            // tlpHeaderInputs
            // 
            tlpHeaderInputs.ColumnCount = 4;
            tlpHeaderInputs.ColumnStyles.Add(new ColumnStyle());
            tlpHeaderInputs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpHeaderInputs.ColumnStyles.Add(new ColumnStyle());
            tlpHeaderInputs.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpHeaderInputs.Controls.Add(label1, 0, 0);
            tlpHeaderInputs.Controls.Add(cmbPlatform, 3, 0);
            tlpHeaderInputs.Controls.Add(txtGameTitle, 1, 0);
            tlpHeaderInputs.Controls.Add(label7, 2, 0);
            tlpHeaderInputs.Controls.Add(label3, 0, 1);
            tlpHeaderInputs.Controls.Add(txtMasteryIconUrl, 1, 1);
            tlpHeaderInputs.Controls.Add(label2, 0, 2);
            tlpHeaderInputs.Controls.Add(txtBannerUrl, 1, 2);
            tlpHeaderInputs.Dock = DockStyle.Fill;
            tlpHeaderInputs.Location = new Point(0, 0);
            tlpHeaderInputs.Name = "tlpHeaderInputs";
            tlpHeaderInputs.RowCount = 3;
            tlpHeaderInputs.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tlpHeaderInputs.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tlpHeaderInputs.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333F));
            tlpHeaderInputs.Size = new Size(628, 92);
            tlpHeaderInputs.TabIndex = 26;
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(tlpHeaderInputs);
            pnlTop.Controls.Add(pbMasteryIcon);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(10, 10);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(724, 92);
            pnlTop.TabIndex = 27;
            // 
            // tabControlHeader
            // 
            tabControlHeader.Controls.Add(tabPageHeader);
            tabControlHeader.Controls.Add(tabPageFootnotes);
            tabControlHeader.Dock = DockStyle.Fill;
            tabControlHeader.Location = new Point(10, 404);
            tabControlHeader.Name = "tabControlHeader";
            tabControlHeader.SelectedIndex = 0;
            tabControlHeader.Size = new Size(724, 306);
            tabControlHeader.TabIndex = 28;
            // 
            // tabPageHeader
            // 
            tabPageHeader.Controls.Add(splitIntroStats);
            tabPageHeader.Location = new Point(4, 24);
            tabPageHeader.Name = "tabPageHeader";
            tabPageHeader.Padding = new Padding(3);
            tabPageHeader.Size = new Size(716, 278);
            tabPageHeader.TabIndex = 0;
            tabPageHeader.Text = "Header & Intro";
            tabPageHeader.UseVisualStyleBackColor = true;
            // 
            // splitIntroStats
            // 
            splitIntroStats.Dock = DockStyle.Fill;
            splitIntroStats.Location = new Point(3, 3);
            splitIntroStats.Name = "splitIntroStats";
            // 
            // splitIntroStats.Panel1
            // 
            splitIntroStats.Panel1.Controls.Add(pnlIntro);
            splitIntroStats.Panel1.Controls.Add(label8);
            splitIntroStats.Panel1MinSize = 280;
            // 
            // splitIntroStats.Panel2
            // 
            splitIntroStats.Panel2.Controls.Add(grpStatistics);
            splitIntroStats.Panel2MinSize = 250;
            splitIntroStats.Size = new Size(710, 272);
            splitIntroStats.SplitterDistance = 456;
            splitIntroStats.TabIndex = 29;
            // 
            // pnlIntro
            // 
            pnlIntro.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlIntro.Controls.Add(rtxtIntro);
            pnlIntro.Location = new Point(3, 21);
            pnlIntro.Name = "pnlIntro";
            pnlIntro.Size = new Size(450, 248);
            pnlIntro.TabIndex = 24;
            // 
            // rtxtIntro
            // 
            rtxtIntro.AcceptsTab = true;
            rtxtIntro.ContextMenuStrip = ctxMenuRichText;
            rtxtIntro.Dock = DockStyle.Fill;
            rtxtIntro.Location = new Point(0, 0);
            rtxtIntro.Name = "rtxtIntro";
            rtxtIntro.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtxtIntro.Size = new Size(450, 248);
            rtxtIntro.TabIndex = 0;
            rtxtIntro.Text = "";
            rtxtIntro.Leave += rtxtIntro_Leave;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(0, 3);
            label8.Name = "label8";
            label8.Size = new Size(109, 15);
            label8.TabIndex = 23;
            label8.Text = "Introductory Text:";
            // 
            // grpStatistics
            // 
            grpStatistics.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            grpStatistics.Controls.Add(tlpStats);
            grpStatistics.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpStatistics.Location = new Point(3, 125);
            grpStatistics.Name = "grpStatistics";
            grpStatistics.Padding = new Padding(10);
            grpStatistics.Size = new Size(244, 144);
            grpStatistics.TabIndex = 26;
            grpStatistics.TabStop = false;
            grpStatistics.Text = "Set Statistics";
            // 
            // tlpStats
            // 
            tlpStats.ColumnCount = 2;
            tlpStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpStats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpStats.Controls.Add(label6, 0, 0);
            tlpStats.Controls.Add(lblAchCountValue, 1, 0);
            tlpStats.Controls.Add(label9, 0, 1);
            tlpStats.Controls.Add(lblPointsValue, 1, 1);
            tlpStats.Controls.Add(label11, 0, 2);
            tlpStats.Controls.Add(lblCategoriesValue, 1, 2);
            tlpStats.Controls.Add(label13, 0, 3);
            tlpStats.Controls.Add(lblLeaderboardsValue, 1, 3);
            tlpStats.Controls.Add(label15, 0, 4);
            tlpStats.Controls.Add(lblCreditsValue, 1, 4);
            tlpStats.Dock = DockStyle.Fill;
            tlpStats.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tlpStats.Location = new Point(10, 26);
            tlpStats.Name = "tlpStats";
            tlpStats.RowCount = 5;
            tlpStats.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpStats.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpStats.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpStats.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpStats.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpStats.Size = new Size(224, 108);
            tlpStats.TabIndex = 0;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(19, 3);
            label6.Name = "label6";
            label6.Size = new Size(90, 15);
            label6.TabIndex = 0;
            label6.Text = "Achievements:";
            // 
            // lblAchCountValue
            // 
            lblAchCountValue.Anchor = AnchorStyles.Left;
            lblAchCountValue.AutoSize = true;
            lblAchCountValue.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAchCountValue.Location = new Point(115, 3);
            lblAchCountValue.Name = "lblAchCountValue";
            lblAchCountValue.Size = new Size(13, 15);
            lblAchCountValue.TabIndex = 0;
            lblAchCountValue.Text = "0";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(35, 24);
            label9.Name = "label9";
            label9.Size = new Size(74, 15);
            label9.TabIndex = 1;
            label9.Text = "Total Points:";
            // 
            // lblPointsValue
            // 
            lblPointsValue.Anchor = AnchorStyles.Left;
            lblPointsValue.AutoSize = true;
            lblPointsValue.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPointsValue.Location = new Point(115, 24);
            lblPointsValue.Name = "lblPointsValue";
            lblPointsValue.Size = new Size(13, 15);
            lblPointsValue.TabIndex = 2;
            lblPointsValue.Text = "0";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(40, 45);
            label11.Name = "label11";
            label11.Size = new Size(69, 15);
            label11.TabIndex = 3;
            label11.Text = "Categories:";
            // 
            // lblCategoriesValue
            // 
            lblCategoriesValue.Anchor = AnchorStyles.Left;
            lblCategoriesValue.AutoSize = true;
            lblCategoriesValue.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCategoriesValue.Location = new Point(115, 45);
            lblCategoriesValue.Name = "lblCategoriesValue";
            lblCategoriesValue.Size = new Size(13, 15);
            lblCategoriesValue.TabIndex = 4;
            lblCategoriesValue.Text = "0";
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(24, 66);
            label13.Name = "label13";
            label13.Size = new Size(85, 15);
            label13.TabIndex = 5;
            label13.Text = "Leaderboards:";
            // 
            // lblLeaderboardsValue
            // 
            lblLeaderboardsValue.Anchor = AnchorStyles.Left;
            lblLeaderboardsValue.AutoSize = true;
            lblLeaderboardsValue.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLeaderboardsValue.Location = new Point(115, 66);
            lblLeaderboardsValue.Name = "lblLeaderboardsValue";
            lblLeaderboardsValue.Size = new Size(13, 15);
            lblLeaderboardsValue.TabIndex = 6;
            lblLeaderboardsValue.Text = "0";
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Right;
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(60, 88);
            label15.Name = "label15";
            label15.Size = new Size(49, 15);
            label15.TabIndex = 7;
            label15.Text = "Credits:";
            // 
            // lblCreditsValue
            // 
            lblCreditsValue.Anchor = AnchorStyles.Left;
            lblCreditsValue.Location = new Point(115, 88);
            lblCreditsValue.Name = "lblCreditsValue";
            lblCreditsValue.Size = new Size(13, 15);
            lblCreditsValue.TabIndex = 8;
            lblCreditsValue.Text = "0";
            // 
            // tabPageFootnotes
            // 
            tabPageFootnotes.Controls.Add(tableLayoutPanel1);
            tabPageFootnotes.Controls.Add(pnlFootnoteTemplate);
            tabPageFootnotes.Location = new Point(4, 24);
            tabPageFootnotes.Name = "tabPageFootnotes";
            tabPageFootnotes.Padding = new Padding(3);
            tabPageFootnotes.Size = new Size(716, 278);
            tabPageFootnotes.TabIndex = 1;
            tabPageFootnotes.Text = "Footnotes";
            tabPageFootnotes.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(groupBox2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 46);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(710, 229);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rtxtMeasuredExamples);
            groupBox1.Controls.Add(label4);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(349, 223);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Measured Indicator";
            // 
            // rtxtMeasuredExamples
            // 
            rtxtMeasuredExamples.AcceptsTab = true;
            rtxtMeasuredExamples.ContextMenuStrip = ctxMenuRichText;
            rtxtMeasuredExamples.Dock = DockStyle.Fill;
            rtxtMeasuredExamples.Location = new Point(3, 69);
            rtxtMeasuredExamples.Name = "rtxtMeasuredExamples";
            rtxtMeasuredExamples.Size = new Size(343, 151);
            rtxtMeasuredExamples.TabIndex = 1;
            rtxtMeasuredExamples.Text = "";
            rtxtMeasuredExamples.Leave += rtxtMeasuredExamples_Leave;
            // 
            // label4
            // 
            label4.Dock = DockStyle.Top;
            label4.Location = new Point(3, 19);
            label4.Name = "label4";
            label4.Size = new Size(343, 50);
            label4.TabIndex = 0;
            label4.Text = "An indicator displayed by the RetroAchievements overlay, often used to track specific progress within an achievement.";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rtxtTriggerExamples);
            groupBox2.Controls.Add(label5);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(358, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(349, 223);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Triggered Indicator";
            // 
            // rtxtTriggerExamples
            // 
            rtxtTriggerExamples.AcceptsTab = true;
            rtxtTriggerExamples.ContextMenuStrip = ctxMenuRichText;
            rtxtTriggerExamples.Dock = DockStyle.Fill;
            rtxtTriggerExamples.Location = new Point(3, 69);
            rtxtTriggerExamples.Name = "rtxtTriggerExamples";
            rtxtTriggerExamples.Size = new Size(343, 151);
            rtxtTriggerExamples.TabIndex = 2;
            rtxtTriggerExamples.Text = "";
            rtxtTriggerExamples.Leave += rtxtTriggerExamples_Leave;
            // 
            // label5
            // 
            label5.Dock = DockStyle.Top;
            label5.Location = new Point(3, 19);
            label5.Name = "label5";
            label5.Size = new Size(343, 50);
            label5.TabIndex = 1;
            label5.Text = "An indicator displayed by the RetroAchievements overlay, typically used to show when a challenge is active. If this indicator disappears, it often signals a failure.";
            label5.Click += label5_Click;
            // 
            // pnlFootnoteTemplate
            // 
            pnlFootnoteTemplate.Controls.Add(cmbFootnoteTemplates);
            pnlFootnoteTemplate.Controls.Add(lblFootnoteTemplate);
            pnlFootnoteTemplate.Dock = DockStyle.Top;
            pnlFootnoteTemplate.Location = new Point(3, 3);
            pnlFootnoteTemplate.Name = "pnlFootnoteTemplate";
            pnlFootnoteTemplate.Size = new Size(710, 43);
            pnlFootnoteTemplate.TabIndex = 2;
            // 
            // cmbFootnoteTemplates
            // 
            cmbFootnoteTemplates.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbFootnoteTemplates.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFootnoteTemplates.FormattingEnabled = true;
            cmbFootnoteTemplates.Location = new Point(130, 10);
            cmbFootnoteTemplates.Name = "cmbFootnoteTemplates";
            cmbFootnoteTemplates.Size = new Size(572, 23);
            cmbFootnoteTemplates.TabIndex = 1;
            // 
            // lblFootnoteTemplate
            // 
            lblFootnoteTemplate.AutoSize = true;
            lblFootnoteTemplate.Location = new Point(8, 13);
            lblFootnoteTemplate.Name = "lblFootnoteTemplate";
            lblFootnoteTemplate.Size = new Size(116, 15);
            lblFootnoteTemplate.TabIndex = 0;
            lblFootnoteTemplate.Text = "Example Templates:";
            // 
            // HeaderEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControlHeader);
            Controls.Add(pnlBannerFrame);
            Controls.Add(pnlTop);
            Name = "HeaderEditor";
            Padding = new Padding(10);
            Size = new Size(744, 720);
            ((System.ComponentModel.ISupportInitialize)pbMasteryIcon).EndInit();
            pnlBannerFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbBanner).EndInit();
            tlpHeaderInputs.ResumeLayout(false);
            tlpHeaderInputs.PerformLayout();
            pnlTop.ResumeLayout(false);
            tabControlHeader.ResumeLayout(false);
            tabPageHeader.ResumeLayout(false);
            splitIntroStats.Panel1.ResumeLayout(false);
            splitIntroStats.Panel1.PerformLayout();
            splitIntroStats.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitIntroStats).EndInit();
            splitIntroStats.ResumeLayout(false);
            pnlIntro.ResumeLayout(false);
            grpStatistics.ResumeLayout(false);
            tlpStats.ResumeLayout(false);
            tlpStats.PerformLayout();
            tabPageFootnotes.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            pnlFootnoteTemplate.ResumeLayout(false);
            pnlFootnoteTemplate.PerformLayout();
            ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.PictureBox pbMasteryIcon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private UndoRedoRichTextBox txtGameTitle;
        private UndoRedoRichTextBox txtMasteryIconUrl;
        private UndoRedoRichTextBox txtBannerUrl;
        private System.Windows.Forms.Panel pnlBannerFrame;
        private System.Windows.Forms.PictureBox pbBanner;
        private System.Windows.Forms.ComboBox cmbPlatform;
        private System.Windows.Forms.TableLayoutPanel tlpHeaderInputs;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.TabControl tabControlHeader;
        private System.Windows.Forms.TabPage tabPageHeader;
        private System.Windows.Forms.SplitContainer splitIntroStats;
        private System.Windows.Forms.Panel pnlIntro;
        private UndoRedoRichTextBox rtxtIntro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox grpStatistics;
        private System.Windows.Forms.TableLayoutPanel tlpStats;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAchCountValue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblPointsValue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblCategoriesValue;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblLeaderboardsValue;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblCreditsValue;
        private System.Windows.Forms.TabPage tabPageFootnotes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private UndoRedoRichTextBox rtxtMeasuredExamples;
        private System.Windows.Forms.Label label4;
        private UndoRedoRichTextBox rtxtTriggerExamples;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBannerHint;
        private Panel pnlFootnoteTemplate;
        private ComboBox cmbFootnoteTemplates;
        private Label lblFootnoteTemplate;
    }
}