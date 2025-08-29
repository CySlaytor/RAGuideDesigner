namespace RaGuideDesigner.Views
{
    partial class LeaderboardRootEditor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtxtIntro = new RaGuideDesigner.Views.UndoRedoRichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtxtIntro);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(638, 454);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Leaderboard Guide Introduction";
            // 
            // rtxtIntro
            // 
            this.rtxtIntro.AcceptsTab = true;
            this.rtxtIntro.ContextMenuStrip = this.ctxMenuRichText;
            this.rtxtIntro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtIntro.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rtxtIntro.Location = new System.Drawing.Point(10, 26);
            this.rtxtIntro.Name = "rtxtIntro";
            this.rtxtIntro.Size = new System.Drawing.Size(618, 418);
            this.rtxtIntro.TabIndex = 0;
            this.rtxtIntro.Text = "";
            this.rtxtIntro.Leave += new System.EventHandler(this.rtxtIntro_Leave);
            // 
            // LeaderboardRootEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "LeaderboardRootEditor";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(658, 474);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private UndoRedoRichTextBox rtxtIntro;
    }
}