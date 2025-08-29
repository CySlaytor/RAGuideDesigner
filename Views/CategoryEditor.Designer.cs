namespace RaGuideDesigner.Views
{
    partial class CategoryEditor
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
            this.label11 = new System.Windows.Forms.Label();
            this.txtCatTitle = new RaGuideDesigner.Views.UndoRedoRichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtxtDescription = new RaGuideDesigner.Views.UndoRedoRichTextBox();
            this.groupBoxAdmonitions = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtxtNoteContent = new RaGuideDesigner.Views.UndoRedoRichTextBox();
            this.cmbNoteType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRemoveNote = new System.Windows.Forms.Button();
            this.btnAddNote = new System.Windows.Forms.Button();
            this.lstAdmonitions = new System.Windows.Forms.ListBox();
            this.btnEditAdditionalNotes = new System.Windows.Forms.Button();
            this.cmbCatIcon = new System.Windows.Forms.ComboBox();
            this.lblTotalPoints = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxAdmonitions.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(365, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "Icon:";
            // 
            // txtCatTitle
            // 
            this.txtCatTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCatTitle.Location = new System.Drawing.Point(54, 14);
            this.txtCatTitle.Multiline = false;
            this.txtCatTitle.Name = "txtCatTitle";
            this.txtCatTitle.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtCatTitle.Size = new System.Drawing.Size(294, 23);
            this.txtCatTitle.TabIndex = 1;
            this.txtCatTitle.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(13, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Title:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(13, 43);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBoxAdmonitions);
            this.splitContainer1.Panel2MinSize = 220;
            this.splitContainer1.Size = new System.Drawing.Size(632, 418);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtxtDescription);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(632, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Description";
            // 
            // rtxtDescription
            // 
            this.rtxtDescription.AcceptsTab = true;
            this.rtxtDescription.ContextMenuStrip = this.ctxMenuRichText;
            this.rtxtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rtxtDescription.Location = new System.Drawing.Point(3, 19);
            this.rtxtDescription.Name = "rtxtDescription";
            this.rtxtDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtxtDescription.Size = new System.Drawing.Size(626, 128);
            this.rtxtDescription.TabIndex = 0;
            this.rtxtDescription.Text = "";
            this.rtxtDescription.Leave += new System.EventHandler(this.rtxtDescription_Leave);
            // 
            // groupBoxAdmonitions
            // 
            this.groupBoxAdmonitions.Controls.Add(this.groupBox2);
            this.groupBoxAdmonitions.Controls.Add(this.btnRemoveNote);
            this.groupBoxAdmonitions.Controls.Add(this.btnAddNote);
            this.groupBoxAdmonitions.Controls.Add(this.lstAdmonitions);
            this.groupBoxAdmonitions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxAdmonitions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxAdmonitions.Location = new System.Drawing.Point(0, 0);
            this.groupBoxAdmonitions.Name = "groupBoxAdmonitions";
            this.groupBoxAdmonitions.Size = new System.Drawing.Size(632, 264);
            this.groupBoxAdmonitions.TabIndex = 0;
            this.groupBoxAdmonitions.TabStop = false;
            this.groupBoxAdmonitions.Text = "📝 Admonition Notes";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rtxtNoteContent);
            this.groupBox2.Controls.Add(this.cmbNoteType);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBox2.Location = new System.Drawing.Point(230, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 239);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selected Note Editor";
            // 
            // rtxtNoteContent
            // 
            this.rtxtNoteContent.AcceptsTab = true;
            this.rtxtNoteContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtNoteContent.ContextMenuStrip = this.ctxMenuRichText;
            this.rtxtNoteContent.Location = new System.Drawing.Point(6, 51);
            this.rtxtNoteContent.Name = "rtxtNoteContent";
            this.rtxtNoteContent.Size = new System.Drawing.Size(384, 182);
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
            this.btnRemoveNote.Location = new System.Drawing.Point(118, 235);
            this.btnRemoveNote.Name = "btnRemoveNote";
            this.btnRemoveNote.Size = new System.Drawing.Size(110, 23);
            this.btnRemoveNote.TabIndex = 25;
            this.btnRemoveNote.Text = "Remove Selected";
            this.btnRemoveNote.UseVisualStyleBackColor = true;
            this.btnRemoveNote.Click += new System.EventHandler(this.btnRemoveNote_Click);
            // 
            // btnAddNote
            // 
            this.btnAddNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddNote.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddNote.Location = new System.Drawing.Point(5, 235);
            this.btnAddNote.Name = "btnAddNote";
            this.btnAddNote.Size = new System.Drawing.Size(110, 23);
            this.btnAddNote.TabIndex = 24;
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
            this.lstAdmonitions.Location = new System.Drawing.Point(5, 22);
            this.lstAdmonitions.Name = "lstAdmonitions";
            this.lstAdmonitions.Size = new System.Drawing.Size(223, 199);
            this.lstAdmonitions.TabIndex = 23;
            this.lstAdmonitions.SelectedIndexChanged += new System.EventHandler(this.lstAdmonitions_SelectedIndexChanged);
            // 
            // btnEditAdditionalNotes
            // 
            this.btnEditAdditionalNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditAdditionalNotes.Location = new System.Drawing.Point(475, 13);
            this.btnEditAdditionalNotes.Name = "btnEditAdditionalNotes";
            this.btnEditAdditionalNotes.Size = new System.Drawing.Size(170, 24);
            this.btnEditAdditionalNotes.TabIndex = 7;
            this.btnEditAdditionalNotes.Text = "Add/Edit Additional Notes...";
            this.btnEditAdditionalNotes.UseVisualStyleBackColor = true;
            this.btnEditAdditionalNotes.Click += new System.EventHandler(this.btnEditAdditionalNotes_Click);
            // 
            // cmbCatIcon
            // 
            this.cmbCatIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCatIcon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCatIcon.FormattingEnabled = true;
            this.cmbCatIcon.Location = new System.Drawing.Point(404, 14);
            this.cmbCatIcon.Name = "cmbCatIcon";
            this.cmbCatIcon.Size = new System.Drawing.Size(50, 23);
            this.cmbCatIcon.TabIndex = 8;
            this.cmbCatIcon.SelectedIndexChanged += new System.EventHandler(this.cmbCatIcon_SelectedIndexChanged);
            // 
            // lblTotalPoints
            // 
            this.lblTotalPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPoints.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPoints.Location = new System.Drawing.Point(475, 38);
            this.lblTotalPoints.Name = "lblTotalPoints";
            this.lblTotalPoints.Size = new System.Drawing.Size(170, 15);
            this.lblTotalPoints.TabIndex = 9;
            this.lblTotalPoints.Text = "Total Points: 0";
            this.lblTotalPoints.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CategoryEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTotalPoints);
            this.Controls.Add(this.cmbCatIcon);
            this.Controls.Add(this.btnEditAdditionalNotes);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCatTitle);
            this.Controls.Add(this.label10);
            this.Name = "CategoryEditor";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(658, 474);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBoxAdmonitions.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Label label11;
        private UndoRedoRichTextBox txtCatTitle;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxAdmonitions;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbNoteType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRemoveNote;
        private System.Windows.Forms.Button btnAddNote;
        private System.Windows.Forms.ListBox lstAdmonitions;
        private System.Windows.Forms.Button btnEditAdditionalNotes;
        private UndoRedoRichTextBox rtxtDescription;
        private UndoRedoRichTextBox rtxtNoteContent;
        private System.Windows.Forms.ComboBox cmbCatIcon;
        private System.Windows.Forms.Label lblTotalPoints;
    }
}