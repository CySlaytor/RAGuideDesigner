namespace RaGuideDesigner.Views
{
    partial class AdditionalNotesEditorForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.rtxtNotes = new RaGuideDesigner.Views.UndoRedoRichTextBox();
            this.ctxMenuRichText = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.boldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.italicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.referenceSeparatorToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.referenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.applyHeader2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyHeader3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toggleBlockquoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.ctxMenuRichText.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtxtNotes
            // 
            this.rtxtNotes.AcceptsTab = true;
            this.rtxtNotes.ContextMenuStrip = this.ctxMenuRichText;
            this.rtxtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtNotes.Location = new System.Drawing.Point(10, 10);
            this.rtxtNotes.Name = "rtxtNotes";
            this.rtxtNotes.Size = new System.Drawing.Size(564, 292);
            this.rtxtNotes.TabIndex = 0;
            this.rtxtNotes.Text = "";
            // 
            // ctxMenuRichText
            // 
            this.ctxMenuRichText.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator1,
            this.boldToolStripMenuItem,
            this.italicToolStripMenuItem,
            this.referenceSeparatorToolStripMenuItem,
            this.referenceToolStripMenuItem,
            this.toolStripSeparator2,
            this.applyHeader2ToolStripMenuItem,
            this.applyHeader3ToolStripMenuItem,
            this.toolStripSeparator3,
            this.toggleBlockquoteToolStripMenuItem});
            this.ctxMenuRichText.Name = "ctxMenuRichText";
            this.ctxMenuRichText.Size = new System.Drawing.Size(217, 226);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+X";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.cutToolStripMenuItem.Text = "Cu&t";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+V";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
            // 
            // boldToolStripMenuItem
            // 
            this.boldToolStripMenuItem.Name = "boldToolStripMenuItem";
            this.boldToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+B";
            this.boldToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.boldToolStripMenuItem.Text = "&Bold";
            this.boldToolStripMenuItem.Click += new System.EventHandler(this.boldToolStripMenuItem_Click);
            // 
            // italicToolStripMenuItem
            // 
            this.italicToolStripMenuItem.Name = "italicToolStripMenuItem";
            this.italicToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+I";
            this.italicToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.italicToolStripMenuItem.Text = "&Italic";
            this.italicToolStripMenuItem.Click += new System.EventHandler(this.italicToolStripMenuItem_Click);
            // 
            // referenceSeparatorToolStripMenuItem
            // 
            this.referenceSeparatorToolStripMenuItem.Name = "referenceSeparatorToolStripMenuItem";
            this.referenceSeparatorToolStripMenuItem.Size = new System.Drawing.Size(213, 6);
            // 
            // referenceToolStripMenuItem
            // 
            this.referenceToolStripMenuItem.Name = "referenceToolStripMenuItem";
            this.referenceToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+K";
            this.referenceToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.referenceToolStripMenuItem.Text = "&Reference...";
            this.referenceToolStripMenuItem.Click += new System.EventHandler(this.referenceToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(213, 6);
            // 
            // applyHeader2ToolStripMenuItem
            // 
            this.applyHeader2ToolStripMenuItem.Name = "applyHeader2ToolStripMenuItem";
            this.applyHeader2ToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.applyHeader2ToolStripMenuItem.Text = "Apply Header 2 (##)";
            this.applyHeader2ToolStripMenuItem.Click += new System.EventHandler(this.applyHeader2ToolStripMenuItem_Click);
            // 
            // applyHeader3ToolStripMenuItem
            // 
            this.applyHeader3ToolStripMenuItem.Name = "applyHeader3ToolStripMenuItem";
            this.applyHeader3ToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.applyHeader3ToolStripMenuItem.Text = "Apply Header 3 (###)";
            this.applyHeader3ToolStripMenuItem.Click += new System.EventHandler(this.applyHeader3ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(213, 6);
            // 
            // toggleBlockquoteToolStripMenuItem
            // 
            this.toggleBlockquoteToolStripMenuItem.Name = "toggleBlockquoteToolStripMenuItem";
            this.toggleBlockquoteToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.toggleBlockquoteToolStripMenuItem.Text = "Toggle Blockquote (>)";
            this.toggleBlockquoteToolStripMenuItem.Click += new System.EventHandler(this.toggleBlockquoteToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(10, 302);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 49);
            this.panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(395, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(476, 14);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // AdditionalNotesEditorForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.rtxtNotes);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = true;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "AdditionalNotesEditorForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Additional Notes";
            this.Load += new System.EventHandler(this.AdditionalNotesEditorForm_Load);
            this.ctxMenuRichText.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private UndoRedoRichTextBox rtxtNotes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ContextMenuStrip ctxMenuRichText;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem boldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem italicToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem applyHeader2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applyHeader3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toggleBlockquoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator referenceSeparatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem referenceToolStripMenuItem;
    }
}