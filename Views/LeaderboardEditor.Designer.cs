namespace RaGuideDesigner.Views
{
    partial class LeaderboardEditor
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
            this.components = new System.ComponentModel.Container();
            this.label18 = new System.Windows.Forms.Label();
            this.txtLeaderboardTitle = new RaGuideDesigner.Views.UndoRedoRichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDescription = new System.Windows.Forms.TabPage();
            this.rtxtDescription = new RaGuideDesigner.Views.UndoRedoRichTextBox();
            this.tabConditions = new System.Windows.Forms.TabPage();
            this.tlpConditions = new System.Windows.Forms.TableLayoutPanel();
            this.grpStart = new System.Windows.Forms.GroupBox();
            this.rtxtStart = new RaGuideDesigner.Views.UndoRedoRichTextBox();
            this.grpCancel = new System.Windows.Forms.GroupBox();
            this.rtxtCancel = new RaGuideDesigner.Views.UndoRedoRichTextBox();
            this.grpSubmit = new System.Windows.Forms.GroupBox();
            this.rtxtSubmit = new RaGuideDesigner.Views.UndoRedoRichTextBox();
            this.grpMeasured = new System.Windows.Forms.GroupBox();
            this.rtxtMeasured = new RaGuideDesigner.Views.UndoRedoRichTextBox();
            this.tabNotes = new System.Windows.Forms.TabPage();
            this.notesSplitContainer = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtMiscNote = new RaGuideDesigner.Views.UndoRedoRichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtDevNote = new RaGuideDesigner.Views.UndoRedoRichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabDescription.SuspendLayout();
            this.tabConditions.SuspendLayout();
            this.tlpConditions.SuspendLayout();
            this.grpStart.SuspendLayout();
            this.grpCancel.SuspendLayout();
            this.grpSubmit.SuspendLayout();
            this.grpMeasured.SuspendLayout();
            this.tabNotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notesSplitContainer)).BeginInit();
            this.notesSplitContainer.Panel1.SuspendLayout();
            this.notesSplitContainer.Panel2.SuspendLayout();
            this.notesSplitContainer.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(14, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 15);
            this.label18.TabIndex = 4;
            this.label18.Text = "Title:";
            // 
            // txtLeaderboardTitle
            // 
            this.txtLeaderboardTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLeaderboardTitle.Location = new System.Drawing.Point(55, 13);
            this.txtLeaderboardTitle.Multiline = false;
            this.txtLeaderboardTitle.Name = "txtLeaderboardTitle";
            this.txtLeaderboardTitle.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtLeaderboardTitle.Size = new System.Drawing.Size(590, 23);
            this.txtLeaderboardTitle.TabIndex = 5;
            this.txtLeaderboardTitle.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabDescription);
            this.tabControl1.Controls.Add(this.tabConditions);
            this.tabControl1.Controls.Add(this.tabNotes);
            this.tabControl1.Location = new System.Drawing.Point(14, 42);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(631, 419);
            this.tabControl1.TabIndex = 8;
            // 
            // tabDescription
            // 
            this.tabDescription.Controls.Add(this.rtxtDescription);
            this.tabDescription.Location = new System.Drawing.Point(4, 24);
            this.tabDescription.Name = "tabDescription";
            this.tabDescription.Padding = new System.Windows.Forms.Padding(10);
            this.tabDescription.Size = new System.Drawing.Size(623, 391);
            this.tabDescription.TabIndex = 0;
            this.tabDescription.Text = "Description";
            this.tabDescription.UseVisualStyleBackColor = true;
            // 
            // rtxtDescription
            // 
            this.rtxtDescription.AcceptsTab = true;
            this.rtxtDescription.ContextMenuStrip = this.ctxMenuRichText;
            this.rtxtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtDescription.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rtxtDescription.Location = new System.Drawing.Point(10, 10);
            this.rtxtDescription.Name = "rtxtDescription";
            this.rtxtDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtxtDescription.Size = new System.Drawing.Size(603, 371);
            this.rtxtDescription.TabIndex = 0;
            this.rtxtDescription.Text = "";
            // 
            // tabConditions
            // 
            this.tabConditions.Controls.Add(this.tlpConditions);
            this.tabConditions.Location = new System.Drawing.Point(4, 24);
            this.tabConditions.Name = "tabConditions";
            this.tabConditions.Padding = new System.Windows.Forms.Padding(3);
            this.tabConditions.Size = new System.Drawing.Size(623, 391);
            this.tabConditions.TabIndex = 1;
            this.tabConditions.Text = "Conditions & Scoring";
            this.tabConditions.UseVisualStyleBackColor = true;
            // 
            // tlpConditions
            // 
            this.tlpConditions.ColumnCount = 2;
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpConditions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpConditions.Controls.Add(this.grpStart, 0, 0);
            this.tlpConditions.Controls.Add(this.grpCancel, 1, 0);
            this.tlpConditions.Controls.Add(this.grpSubmit, 0, 1);
            this.tlpConditions.Controls.Add(this.grpMeasured, 1, 1);
            this.tlpConditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpConditions.Location = new System.Drawing.Point(3, 3);
            this.tlpConditions.Name = "tlpConditions";
            this.tlpConditions.RowCount = 2;
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpConditions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpConditions.Size = new System.Drawing.Size(617, 385);
            this.tlpConditions.TabIndex = 0;
            // 
            // grpStart
            // 
            this.grpStart.Controls.Add(this.rtxtStart);
            this.grpStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpStart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpStart.Location = new System.Drawing.Point(3, 3);
            this.grpStart.Name = "grpStart";
            this.grpStart.Size = new System.Drawing.Size(302, 186);
            this.grpStart.TabIndex = 0;
            this.grpStart.TabStop = false;
            this.grpStart.Text = "Start Requirements";
            // 
            // rtxtStart
            // 
            this.rtxtStart.AcceptsTab = true;
            this.rtxtStart.ContextMenuStrip = this.ctxMenuRichText;
            this.rtxtStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rtxtStart.Location = new System.Drawing.Point(3, 19);
            this.rtxtStart.Name = "rtxtStart";
            this.rtxtStart.Size = new System.Drawing.Size(296, 164);
            this.rtxtStart.TabIndex = 0;
            this.rtxtStart.Text = "";
            // 
            // grpCancel
            // 
            this.grpCancel.Controls.Add(this.rtxtCancel);
            this.grpCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpCancel.Location = new System.Drawing.Point(311, 3);
            this.grpCancel.Name = "grpCancel";
            this.grpCancel.Size = new System.Drawing.Size(303, 186);
            this.grpCancel.TabIndex = 1;
            this.grpCancel.TabStop = false;
            this.grpCancel.Text = "Cancel Conditions";
            // 
            // rtxtCancel
            // 
            this.rtxtCancel.AcceptsTab = true;
            this.rtxtCancel.ContextMenuStrip = this.ctxMenuRichText;
            this.rtxtCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rtxtCancel.Location = new System.Drawing.Point(3, 19);
            this.rtxtCancel.Name = "rtxtCancel";
            this.rtxtCancel.Size = new System.Drawing.Size(297, 164);
            this.rtxtCancel.TabIndex = 0;
            this.rtxtCancel.Text = "";
            // 
            // grpSubmit
            // 
            this.grpSubmit.Controls.Add(this.rtxtSubmit);
            this.grpSubmit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSubmit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpSubmit.Location = new System.Drawing.Point(3, 195);
            this.grpSubmit.Name = "grpSubmit";
            this.grpSubmit.Size = new System.Drawing.Size(302, 187);
            this.grpSubmit.TabIndex = 2;
            this.grpSubmit.TabStop = false;
            this.grpSubmit.Text = "Submit Conditions";
            // 
            // rtxtSubmit
            // 
            this.rtxtSubmit.AcceptsTab = true;
            this.rtxtSubmit.ContextMenuStrip = this.ctxMenuRichText;
            this.rtxtSubmit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtSubmit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rtxtSubmit.Location = new System.Drawing.Point(3, 19);
            this.rtxtSubmit.Name = "rtxtSubmit";
            this.rtxtSubmit.Size = new System.Drawing.Size(296, 165);
            this.rtxtSubmit.TabIndex = 0;
            this.rtxtSubmit.Text = "";
            // 
            // grpMeasured
            // 
            this.grpMeasured.Controls.Add(this.rtxtMeasured);
            this.grpMeasured.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMeasured.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpMeasured.Location = new System.Drawing.Point(311, 195);
            this.grpMeasured.Name = "grpMeasured";
            this.grpMeasured.Size = new System.Drawing.Size(303, 187);
            this.grpMeasured.TabIndex = 3;
            this.grpMeasured.TabStop = false;
            this.grpMeasured.Text = "Measured Value";
            // 
            // rtxtMeasured
            // 
            this.rtxtMeasured.AcceptsTab = true;
            this.rtxtMeasured.ContextMenuStrip = this.ctxMenuRichText;
            this.rtxtMeasured.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtMeasured.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rtxtMeasured.Location = new System.Drawing.Point(3, 19);
            this.rtxtMeasured.Name = "rtxtMeasured";
            this.rtxtMeasured.Size = new System.Drawing.Size(297, 165);
            this.rtxtMeasured.TabIndex = 0;
            this.rtxtMeasured.Text = "";
            // 
            // tabNotes
            // 
            this.tabNotes.Controls.Add(this.notesSplitContainer);
            this.tabNotes.Location = new System.Drawing.Point(4, 24);
            this.tabNotes.Name = "tabNotes";
            this.tabNotes.Padding = new System.Windows.Forms.Padding(3);
            this.tabNotes.Size = new System.Drawing.Size(623, 391);
            this.tabNotes.TabIndex = 2;
            this.tabNotes.Text = "Misc / Dev Notes";
            this.tabNotes.UseVisualStyleBackColor = true;
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
            // 
            // notesSplitContainer.Panel2
            // 
            this.notesSplitContainer.Panel2.Controls.Add(this.groupBox4);
            this.notesSplitContainer.Size = new System.Drawing.Size(617, 385);
            this.notesSplitContainer.SplitterDistance = 190;
            this.notesSplitContainer.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtMiscNote);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox3.Size = new System.Drawing.Size(617, 190);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Misc Note";
            // 
            // txtMiscNote
            // 
            this.txtMiscNote.ContextMenuStrip = this.ctxMenuRichText;
            this.txtMiscNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMiscNote.Location = new System.Drawing.Point(10, 26);
            this.txtMiscNote.Name = "txtMiscNote";
            this.txtMiscNote.Size = new System.Drawing.Size(597, 154);
            this.txtMiscNote.TabIndex = 0;
            this.txtMiscNote.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtDevNote);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox4.Size = new System.Drawing.Size(617, 191);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Dev Note";
            // 
            // txtDevNote
            // 
            this.txtDevNote.ContextMenuStrip = this.ctxMenuRichText;
            this.txtDevNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDevNote.Location = new System.Drawing.Point(10, 26);
            this.txtDevNote.Name = "txtDevNote";
            this.txtDevNote.Size = new System.Drawing.Size(597, 155);
            this.txtDevNote.TabIndex = 0;
            this.txtDevNote.Text = "";
            // 
            // LeaderboardEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtLeaderboardTitle);
            this.Controls.Add(this.label18);
            this.Name = "LeaderboardEditor";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(658, 474);
            this.tabControl1.ResumeLayout(false);
            this.tabDescription.ResumeLayout(false);
            this.tabConditions.ResumeLayout(false);
            this.tlpConditions.ResumeLayout(false);
            this.grpStart.ResumeLayout(false);
            this.grpCancel.ResumeLayout(false);
            this.grpSubmit.ResumeLayout(false);
            this.grpMeasured.ResumeLayout(false);
            this.tabNotes.ResumeLayout(false);
            this.notesSplitContainer.Panel1.ResumeLayout(false);
            this.notesSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.notesSplitContainer)).EndInit();
            this.notesSplitContainer.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Label label18;
        private UndoRedoRichTextBox txtLeaderboardTitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDescription;
        private UndoRedoRichTextBox rtxtDescription;
        private System.Windows.Forms.TabPage tabConditions;
        private System.Windows.Forms.TableLayoutPanel tlpConditions;
        private System.Windows.Forms.GroupBox grpStart;
        private UndoRedoRichTextBox rtxtStart;
        private System.Windows.Forms.GroupBox grpCancel;
        private UndoRedoRichTextBox rtxtCancel;
        private System.Windows.Forms.GroupBox grpSubmit;
        private UndoRedoRichTextBox rtxtSubmit;
        private System.Windows.Forms.GroupBox grpMeasured;
        private UndoRedoRichTextBox rtxtMeasured;
        private System.Windows.Forms.TabPage tabNotes;
        private System.Windows.Forms.SplitContainer notesSplitContainer;
        private System.Windows.Forms.GroupBox groupBox3;
        private UndoRedoRichTextBox txtMiscNote;
        private System.Windows.Forms.GroupBox groupBox4;
        private UndoRedoRichTextBox txtDevNote;
    }
}