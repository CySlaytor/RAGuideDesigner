namespace RaGuideDesigner.Views
{
    partial class WalkthroughsEditor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rootSplitContainer = new System.Windows.Forms.SplitContainer();
            this.topSplitContainer = new System.Windows.Forms.SplitContainer();
            this.groupBoxGuides = new System.Windows.Forms.GroupBox();
            this.dgvGuides = new System.Windows.Forms.DataGridView();
            this.colGuideText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGuideUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGuideDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBoxPlaythroughs = new System.Windows.Forms.GroupBox();
            this.dgvPlaythroughs = new System.Windows.Forms.DataGridView();
            this.colPlaythroughText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlaythroughUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlaythroughDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.bottomSplitContainer = new System.Windows.Forms.SplitContainer();
            this.groupBoxAdvice = new System.Windows.Forms.GroupBox();
            this.rtxtGeneralAdvice = new RaGuideDesigner.Views.UndoRedoRichTextBox();
            this.txtAdviceTitle = new RaGuideDesigner.Views.UndoRedoRichTextBox();
            this.groupBoxAdmonitions = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtxtNoteContent = new RaGuideDesigner.Views.UndoRedoRichTextBox();
            this.cmbNoteType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRemoveNote = new System.Windows.Forms.Button();
            this.btnAddNote = new System.Windows.Forms.Button();
            this.lstAdmonitions = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.rootSplitContainer)).BeginInit();
            this.rootSplitContainer.Panel1.SuspendLayout();
            this.rootSplitContainer.Panel2.SuspendLayout();
            this.rootSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.topSplitContainer)).BeginInit();
            this.topSplitContainer.Panel1.SuspendLayout();
            this.topSplitContainer.Panel2.SuspendLayout();
            this.topSplitContainer.SuspendLayout();
            this.groupBoxGuides.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuides)).BeginInit();
            this.groupBoxPlaythroughs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaythroughs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bottomSplitContainer)).BeginInit();
            this.bottomSplitContainer.Panel1.SuspendLayout();
            this.bottomSplitContainer.Panel2.SuspendLayout();
            this.bottomSplitContainer.SuspendLayout();
            this.groupBoxAdvice.SuspendLayout();
            this.groupBoxAdmonitions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rootSplitContainer
            // 
            this.rootSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rootSplitContainer.Location = new System.Drawing.Point(10, 10);
            this.rootSplitContainer.Name = "rootSplitContainer";
            this.rootSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // rootSplitContainer.Panel1
            // 
            this.rootSplitContainer.Panel1.Controls.Add(this.topSplitContainer);
            this.rootSplitContainer.Panel1MinSize = 120;
            // 
            // rootSplitContainer.Panel2
            // 
            this.rootSplitContainer.Panel2.Controls.Add(this.bottomSplitContainer);
            this.rootSplitContainer.Panel2MinSize = 200;
            this.rootSplitContainer.Size = new System.Drawing.Size(769, 655);
            this.rootSplitContainer.SplitterDistance = 175;
            this.rootSplitContainer.TabIndex = 0;
            // 
            // topSplitContainer
            // 
            this.topSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.topSplitContainer.Name = "topSplitContainer";
            // 
            // topSplitContainer.Panel1
            // 
            this.topSplitContainer.Panel1.Controls.Add(this.groupBoxGuides);
            this.topSplitContainer.Panel1MinSize = 250;
            // 
            // topSplitContainer.Panel2
            // 
            this.topSplitContainer.Panel2.Controls.Add(this.groupBoxPlaythroughs);
            this.topSplitContainer.Panel2MinSize = 250;
            this.topSplitContainer.Size = new System.Drawing.Size(769, 175);
            this.topSplitContainer.SplitterDistance = 380;
            this.topSplitContainer.TabIndex = 0;
            // 
            // groupBoxGuides
            // 
            this.groupBoxGuides.Controls.Add(this.dgvGuides);
            this.groupBoxGuides.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxGuides.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxGuides.Location = new System.Drawing.Point(0, 0);
            this.groupBoxGuides.Name = "groupBoxGuides";
            this.groupBoxGuides.Size = new System.Drawing.Size(380, 175);
            this.groupBoxGuides.TabIndex = 0;
            this.groupBoxGuides.TabStop = false;
            this.groupBoxGuides.Text = "📚 Guides && Walkthroughs";
            // 
            // dgvGuides
            // 
            this.dgvGuides.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGuides.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGuideText,
            this.colGuideUrl,
            this.colGuideDelete});
            this.dgvGuides.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGuides.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvGuides.Location = new System.Drawing.Point(3, 19);
            this.dgvGuides.Name = "dgvGuides";
            this.dgvGuides.Size = new System.Drawing.Size(374, 153);
            this.dgvGuides.TabIndex = 0;
            this.dgvGuides.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGuides_CellClick);
            this.dgvGuides.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEndEdit);
            // 
            // colGuideText
            // 
            this.colGuideText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colGuideText.DataPropertyName = "Text";
            this.colGuideText.HeaderText = "Display Text";
            this.colGuideText.Name = "colGuideText";
            // 
            // colGuideUrl
            // 
            this.colGuideUrl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colGuideUrl.DataPropertyName = "Url";
            this.colGuideUrl.HeaderText = "URL";
            this.colGuideUrl.Name = "colGuideUrl";
            // 
            // colGuideDelete
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "🗑️";
            this.colGuideDelete.DefaultCellStyle = dataGridViewCellStyle1;
            this.colGuideDelete.HeaderText = "";
            this.colGuideDelete.Name = "colGuideDelete";
            this.colGuideDelete.Width = 30;
            // 
            // groupBoxPlaythroughs
            // 
            this.groupBoxPlaythroughs.Controls.Add(this.dgvPlaythroughs);
            this.groupBoxPlaythroughs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPlaythroughs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxPlaythroughs.Location = new System.Drawing.Point(0, 0);
            this.groupBoxPlaythroughs.Name = "groupBoxPlaythroughs";
            this.groupBoxPlaythroughs.Size = new System.Drawing.Size(385, 175);
            this.groupBoxPlaythroughs.TabIndex = 0;
            this.groupBoxPlaythroughs.TabStop = false;
            this.groupBoxPlaythroughs.Text = "🎮 Playthroughs && Longplays";
            // 
            // dgvPlaythroughs
            // 
            this.dgvPlaythroughs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlaythroughs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPlaythroughText,
            this.colPlaythroughUrl,
            this.colPlaythroughDelete});
            this.dgvPlaythroughs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlaythroughs.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvPlaythroughs.Location = new System.Drawing.Point(3, 19);
            this.dgvPlaythroughs.Name = "dgvPlaythroughs";
            this.dgvPlaythroughs.Size = new System.Drawing.Size(379, 153);
            this.dgvPlaythroughs.TabIndex = 0;
            this.dgvPlaythroughs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlaythroughs_CellClick);
            this.dgvPlaythroughs.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEndEdit);
            // 
            // colPlaythroughText
            // 
            this.colPlaythroughText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPlaythroughText.DataPropertyName = "Text";
            this.colPlaythroughText.HeaderText = "Display Text";
            this.colPlaythroughText.Name = "colPlaythroughText";
            // 
            // colPlaythroughUrl
            // 
            this.colPlaythroughUrl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPlaythroughUrl.DataPropertyName = "Url";
            this.colPlaythroughUrl.HeaderText = "URL";
            this.colPlaythroughUrl.Name = "colPlaythroughUrl";
            // 
            // colPlaythroughDelete
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "🗑️";
            this.colPlaythroughDelete.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPlaythroughDelete.HeaderText = "";
            this.colPlaythroughDelete.Name = "colPlaythroughDelete";
            this.colPlaythroughDelete.Width = 30;
            // 
            // bottomSplitContainer
            // 
            this.bottomSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.bottomSplitContainer.Name = "bottomSplitContainer";
            this.bottomSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // bottomSplitContainer.Panel1
            // 
            this.bottomSplitContainer.Panel1.Controls.Add(this.groupBoxAdvice);
            this.bottomSplitContainer.Panel1MinSize = 100;
            // 
            // bottomSplitContainer.Panel2
            // 
            this.bottomSplitContainer.Panel2.Controls.Add(this.groupBoxAdmonitions);
            this.bottomSplitContainer.Panel2MinSize = 220;
            this.bottomSplitContainer.Size = new System.Drawing.Size(769, 476);
            this.bottomSplitContainer.SplitterDistance = 150;
            this.bottomSplitContainer.TabIndex = 0;
            // 
            // groupBoxAdvice
            // 
            this.groupBoxAdvice.Controls.Add(this.rtxtGeneralAdvice);
            this.groupBoxAdvice.Controls.Add(this.txtAdviceTitle);
            this.groupBoxAdvice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxAdvice.Location = new System.Drawing.Point(0, 0);
            this.groupBoxAdvice.Name = "groupBoxAdvice";
            this.groupBoxAdvice.Size = new System.Drawing.Size(769, 150);
            this.groupBoxAdvice.TabIndex = 0;
            this.groupBoxAdvice.TabStop = false;
            this.groupBoxAdvice.Text = "Advice Section";
            // 
            // rtxtGeneralAdvice
            // 
            this.rtxtGeneralAdvice.ContextMenuStrip = this.ctxMenuRichText;
            this.rtxtGeneralAdvice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtGeneralAdvice.Location = new System.Drawing.Point(3, 42);
            this.rtxtGeneralAdvice.Name = "rtxtGeneralAdvice";
            this.rtxtGeneralAdvice.Size = new System.Drawing.Size(763, 105);
            this.rtxtGeneralAdvice.TabIndex = 1;
            this.rtxtGeneralAdvice.Text = "";
            this.rtxtGeneralAdvice.Leave += new System.EventHandler(this.rtxtGeneralAdvice_Leave);
            // 
            // txtAdviceTitle
            // 
            this.txtAdviceTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtAdviceTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtAdviceTitle.Location = new System.Drawing.Point(3, 19);
            this.txtAdviceTitle.Multiline = false;
            this.txtAdviceTitle.Name = "txtAdviceTitle";
            this.txtAdviceTitle.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtAdviceTitle.Size = new System.Drawing.Size(763, 23);
            this.txtAdviceTitle.TabIndex = 0;
            this.txtAdviceTitle.Text = "";
            // 
            // groupBoxAdmonitions
            // 
            this.groupBoxAdmonitions.Controls.Add(this.groupBox1);
            this.groupBoxAdmonitions.Controls.Add(this.btnRemoveNote);
            this.groupBoxAdmonitions.Controls.Add(this.btnAddNote);
            this.groupBoxAdmonitions.Controls.Add(this.lstAdmonitions);
            this.groupBoxAdmonitions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxAdmonitions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxAdmonitions.Location = new System.Drawing.Point(0, 0);
            this.groupBoxAdmonitions.Name = "groupBoxAdmonitions";
            this.groupBoxAdmonitions.Size = new System.Drawing.Size(769, 322);
            this.groupBoxAdmonitions.TabIndex = 1;
            this.groupBoxAdmonitions.TabStop = false;
            this.groupBoxAdmonitions.Text = "📝 Admonition Notes";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rtxtNoteContent);
            this.groupBox1.Controls.Add(this.cmbNoteType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBox1.Location = new System.Drawing.Point(232, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 297);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Note Editor";
            // 
            // rtxtNoteContent
            // 
            this.rtxtNoteContent.AcceptsTab = true;
            this.rtxtNoteContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtNoteContent.ContextMenuStrip = this.ctxMenuRichText;
            this.rtxtNoteContent.Location = new System.Drawing.Point(6, 52);
            this.rtxtNoteContent.Name = "rtxtNoteContent";
            this.rtxtNoteContent.Size = new System.Drawing.Size(519, 239);
            this.rtxtNoteContent.TabIndex = 12;
            this.rtxtNoteContent.Text = "";
            this.rtxtNoteContent.Leave += new System.EventHandler(this.rtxtNoteContent_Leave);
            // 
            // cmbNoteType
            // 
            this.cmbNoteType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNoteType.FormattingEnabled = true;
            this.cmbNoteType.Location = new System.Drawing.Point(87, 22);
            this.cmbNoteType.Name = "cmbNoteType";
            this.cmbNoteType.Size = new System.Drawing.Size(150, 23);
            this.cmbNoteType.TabIndex = 11;
            this.cmbNoteType.SelectedIndexChanged += new System.EventHandler(this.cmbNoteType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Note Type:";
            // 
            // btnRemoveNote
            // 
            this.btnRemoveNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveNote.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRemoveNote.Location = new System.Drawing.Point(120, 293);
            this.btnRemoveNote.Name = "btnRemoveNote";
            this.btnRemoveNote.Size = new System.Drawing.Size(110, 23);
            this.btnRemoveNote.TabIndex = 21;
            this.btnRemoveNote.Text = "Remove Selected";
            this.btnRemoveNote.UseVisualStyleBackColor = true;
            this.btnRemoveNote.Click += new System.EventHandler(this.btnRemoveNote_Click);
            // 
            // btnAddNote
            // 
            this.btnAddNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddNote.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddNote.Location = new System.Drawing.Point(7, 293);
            this.btnAddNote.Name = "btnAddNote";
            this.btnAddNote.Size = new System.Drawing.Size(110, 23);
            this.btnAddNote.TabIndex = 20;
            this.btnAddNote.Text = "Add New Note";
            this.btnAddNote.UseVisualStyleBackColor = true;
            this.btnAddNote.Click += new System.EventHandler(this.btnAddNote_Click);
            // 
            // lstAdmonitions
            // 
            this.lstAdmonitions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstAdmonitions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstAdmonitions.FormattingEnabled = true;
            this.lstAdmonitions.ItemHeight = 15;
            this.lstAdmonitions.Location = new System.Drawing.Point(7, 22);
            this.lstAdmonitions.Name = "lstAdmonitions";
            this.lstAdmonitions.Size = new System.Drawing.Size(223, 259);
            this.lstAdmonitions.TabIndex = 19;
            this.lstAdmonitions.SelectedIndexChanged += new System.EventHandler(this.lstAdmonitions_SelectedIndexChanged);
            // 
            // WalkthroughsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rootSplitContainer);
            this.Name = "WalkthroughsEditor";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(789, 675);
            this.rootSplitContainer.Panel1.ResumeLayout(false);
            this.rootSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rootSplitContainer)).EndInit();
            this.rootSplitContainer.ResumeLayout(false);
            this.topSplitContainer.Panel1.ResumeLayout(false);
            this.topSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.topSplitContainer)).EndInit();
            this.topSplitContainer.ResumeLayout(false);
            this.groupBoxGuides.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuides)).EndInit();
            this.groupBoxPlaythroughs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlaythroughs)).EndInit();
            this.bottomSplitContainer.Panel1.ResumeLayout(false);
            this.bottomSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bottomSplitContainer)).EndInit();
            this.bottomSplitContainer.ResumeLayout(false);
            this.groupBoxAdvice.ResumeLayout(false);
            this.groupBoxAdmonitions.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer rootSplitContainer;
        private System.Windows.Forms.SplitContainer topSplitContainer;
        private System.Windows.Forms.GroupBox groupBoxGuides;
        private System.Windows.Forms.DataGridView dgvGuides;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGuideText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGuideUrl;
        private System.Windows.Forms.DataGridViewButtonColumn colGuideDelete;
        private System.Windows.Forms.GroupBox groupBoxPlaythroughs;
        private System.Windows.Forms.DataGridView dgvPlaythroughs;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlaythroughText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlaythroughUrl;
        private System.Windows.Forms.DataGridViewButtonColumn colPlaythroughDelete;
        private System.Windows.Forms.SplitContainer bottomSplitContainer;
        private System.Windows.Forms.GroupBox groupBoxAdvice;
        private UndoRedoRichTextBox txtAdviceTitle;
        private System.Windows.Forms.GroupBox groupBoxAdmonitions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbNoteType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRemoveNote;
        private System.Windows.Forms.Button btnAddNote;
        private System.Windows.Forms.ListBox lstAdmonitions;
        private UndoRedoRichTextBox rtxtGeneralAdvice;
        private UndoRedoRichTextBox rtxtNoteContent;
    }
}