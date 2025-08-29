namespace RaGuideDesigner.Views
{
    partial class CollectibleEditor
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbAchPoints = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAchId = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAchTitle = new RaGuideDesigner.Views.UndoRedoRichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pbAchBadge = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvCollectibles = new System.Windows.Forms.TreeView();
            this.ctxMenuTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addCollectibleGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCollectibleItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grpItemEditor = new System.Windows.Forms.GroupBox();
            this.rtxtItemDescription = new RaGuideDesigner.Views.UndoRedoRichTextBox();
            this.txtItemUrl = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtItemUrlText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grpGroupEditor = new System.Windows.Forms.GroupBox();
            this.txtGroupTitle = new System.Windows.Forms.TextBox();
            this.ctxMenuTextBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtxtIntro = new RaGuideDesigner.Views.UndoRedoRichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOutro = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAchBadge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ctxMenuTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.grpItemEditor.SuspendLayout();
            this.grpGroupEditor.SuspendLayout();
            this.ctxMenuTextBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.panel1.TabIndex = 4;
            // 
            // cmbAchPoints
            // 
            this.cmbAchPoints.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAchPoints.FormattingEnabled = true;
            this.cmbAchPoints.Location = new System.Drawing.Point(459, 8);
            this.cmbAchPoints.Name = "cmbAchPoints";
            this.cmbAchPoints.Size = new System.Drawing.Size(71, 23);
            this.cmbAchPoints.TabIndex = 6;
            this.cmbAchPoints.SelectedIndexChanged += new System.EventHandler(this.cmbAchPoints_SelectedIndexChanged);
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(10, 99);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvCollectibles);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2MinSize = 350;
            this.splitContainer1.Size = new System.Drawing.Size(638, 463);
            this.splitContainer1.SplitterDistance = 260;
            this.splitContainer1.TabIndex = 5;
            // 
            // tvCollectibles
            // 
            this.tvCollectibles.AllowDrop = true;
            this.tvCollectibles.ContextMenuStrip = this.ctxMenuTree;
            this.tvCollectibles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCollectibles.HideSelection = false;
            this.tvCollectibles.Location = new System.Drawing.Point(0, 0);
            this.tvCollectibles.Name = "tvCollectibles";
            this.tvCollectibles.ShowNodeToolTips = false;
            this.tvCollectibles.Size = new System.Drawing.Size(260, 463);
            this.tvCollectibles.TabIndex = 1;
            this.tvCollectibles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvCollectibles_AfterSelect);
            this.tvCollectibles.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvCollectibles_NodeMouseClick);
            this.tvCollectibles.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvCollectibles_DragDrop);
            this.tvCollectibles.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvCollectibles_DragEnter);
            this.tvCollectibles.DragOver += new System.Windows.Forms.DragEventHandler(this.tvCollectibles_DragOver);
            this.tvCollectibles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvCollectibles_KeyDown);
            this.tvCollectibles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvCollectibles_MouseDown);
            this.tvCollectibles.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tvCollectibles_MouseMove);
            // 
            // ctxMenuTree
            // 
            this.ctxMenuTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCollectibleGroupToolStripMenuItem,
            this.addCollectibleItemToolStripMenuItem,
            this.toolStripSeparator3,
            this.duplicateToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator2,
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem});
            this.ctxMenuTree.Name = "ctxMenuTree";
            this.ctxMenuTree.Size = new System.Drawing.Size(193, 148);
            this.ctxMenuTree.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMenuTree_Opening);
            // 
            // addCollectibleGroupToolStripMenuItem
            // 
            this.addCollectibleGroupToolStripMenuItem.Name = "addCollectibleGroupToolStripMenuItem";
            this.addCollectibleGroupToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.addCollectibleGroupToolStripMenuItem.Text = "Add Collectible Group";
            this.addCollectibleGroupToolStripMenuItem.Click += new System.EventHandler(this.addCollectibleGroupToolStripMenuItem_Click);
            // 
            // addCollectibleItemToolStripMenuItem
            // 
            this.addCollectibleItemToolStripMenuItem.Name = "addCollectibleItemToolStripMenuItem";
            this.addCollectibleItemToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.addCollectibleItemToolStripMenuItem.Text = "Add Collectible Item";
            this.addCollectibleItemToolStripMenuItem.Click += new System.EventHandler(this.addCollectibleItemToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(189, 6);
            // 
            // duplicateToolStripMenuItem
            // 
            this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.duplicateToolStripMenuItem.Text = "Duplicate";
            this.duplicateToolStripMenuItem.Click += new System.EventHandler(this.duplicateToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(189, 6);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.ShortcutKeyDisplayString = "Alt+Up";
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.moveUpToolStripMenuItem.Text = "Move Up";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.ShortcutKeyDisplayString = "Alt+Down";
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.moveDownToolStripMenuItem.Text = "Move Down";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.grpItemEditor);
            this.splitContainer2.Panel1.Controls.Add(this.grpGroupEditor);
            this.splitContainer2.Panel1MinSize = 200;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel2MinSize = 200;
            this.splitContainer2.Size = new System.Drawing.Size(374, 463);
            this.splitContainer2.SplitterDistance = 260;
            this.splitContainer2.TabIndex = 2;
            // 
            // grpItemEditor
            // 
            this.grpItemEditor.Controls.Add(this.rtxtItemDescription);
            this.grpItemEditor.Controls.Add(this.txtItemUrl);
            this.grpItemEditor.Controls.Add(this.label5);
            this.grpItemEditor.Controls.Add(this.txtItemUrlText);
            this.grpItemEditor.Controls.Add(this.label3);
            this.grpItemEditor.Controls.Add(this.label7);
            this.grpItemEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpItemEditor.Location = new System.Drawing.Point(0, 70);
            this.grpItemEditor.Name = "grpItemEditor";
            this.grpItemEditor.Size = new System.Drawing.Size(374, 190);
            this.grpItemEditor.TabIndex = 1;
            this.grpItemEditor.TabStop = false;
            this.grpItemEditor.Text = "Item Editor";
            // 
            // rtxtItemDescription
            // 
            this.rtxtItemDescription.AcceptsTab = true;
            this.rtxtItemDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtItemDescription.ContextMenuStrip = this.ctxMenuRichText;
            this.rtxtItemDescription.Location = new System.Drawing.Point(6, 40);
            this.rtxtItemDescription.Name = "rtxtItemDescription";
            this.rtxtItemDescription.Size = new System.Drawing.Size(362, 58);
            this.rtxtItemDescription.TabIndex = 6;
            this.rtxtItemDescription.Text = "";
            // 
            // txtItemUrl
            // 
            this.txtItemUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemUrl.Location = new System.Drawing.Point(6, 161);
            this.txtItemUrl.Name = "txtItemUrl";
            this.txtItemUrl.Size = new System.Drawing.Size(362, 23);
            this.txtItemUrl.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "URL:";
            // 
            // txtItemUrlText
            // 
            this.txtItemUrlText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemUrlText.Location = new System.Drawing.Point(6, 117);
            this.txtItemUrlText.Name = "txtItemUrlText";
            this.txtItemUrlText.Size = new System.Drawing.Size(362, 23);
            this.txtItemUrlText.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "URL Text:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Description:";
            // 
            // grpGroupEditor
            // 
            this.grpGroupEditor.Controls.Add(this.txtGroupTitle);
            this.grpGroupEditor.Controls.Add(this.label2);
            this.grpGroupEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpGroupEditor.Location = new System.Drawing.Point(0, 0);
            this.grpGroupEditor.Name = "grpGroupEditor";
            this.grpGroupEditor.Size = new System.Drawing.Size(374, 70);
            this.grpGroupEditor.TabIndex = 0;
            this.grpGroupEditor.TabStop = false;
            this.grpGroupEditor.Text = "Group Editor";
            // 
            // txtGroupTitle
            // 
            this.txtGroupTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGroupTitle.ContextMenuStrip = this.ctxMenuTextBox;
            this.txtGroupTitle.Location = new System.Drawing.Point(62, 22);
            this.txtGroupTitle.Multiline = true;
            this.txtGroupTitle.Name = "txtGroupTitle";
            this.txtGroupTitle.Size = new System.Drawing.Size(306, 37);
            this.txtGroupTitle.TabIndex = 1;
            // 
            // ctxMenuTextBox
            // 
            this.ctxMenuTextBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem1,
            this.copyToolStripMenuItem1,
            this.pasteToolStripMenuItem1});
            this.ctxMenuTextBox.Name = "ctxMenuTextBox";
            this.ctxMenuTextBox.Size = new System.Drawing.Size(103, 70);
            // 
            // cutToolStripMenuItem1
            // 
            this.cutToolStripMenuItem1.Name = "cutToolStripMenuItem1";
            this.cutToolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.cutToolStripMenuItem1.Text = "Cut";
            this.cutToolStripMenuItem1.Click += new System.EventHandler(this.cutToolStripMenuItem1_Click);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem1.Text = "Copy";
            this.copyToolStripMenuItem1.Click += new System.EventHandler(this.copyToolStripMenuItem1_Click);
            // 
            // pasteToolStripMenuItem1
            // 
            this.pasteToolStripMenuItem1.Name = "pasteToolStripMenuItem1";
            this.pasteToolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.pasteToolStripMenuItem1.Text = "Paste";
            this.pasteToolStripMenuItem1.Click += new System.EventHandler(this.pasteToolStripMenuItem1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Title:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtxtIntro);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Introduction";
            // 
            // rtxtIntro
            // 
            this.rtxtIntro.AcceptsTab = true;
            this.rtxtIntro.ContextMenuStrip = this.ctxMenuRichText;
            this.rtxtIntro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtIntro.Location = new System.Drawing.Point(3, 19);
            this.rtxtIntro.Name = "rtxtIntro";
            this.rtxtIntro.Size = new System.Drawing.Size(368, 69);
            this.rtxtIntro.TabIndex = 0;
            this.rtxtIntro.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtOutro);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(374, 108);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Measured Indicator";
            // 
            // txtOutro
            // 
            this.txtOutro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutro.Location = new System.Drawing.Point(3, 19);
            this.txtOutro.Multiline = true;
            this.txtOutro.Name = "txtOutro";
            this.txtOutro.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutro.Size = new System.Drawing.Size(368, 86);
            this.txtOutro.TabIndex = 0;
            // 
            // CollectibleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "CollectibleEditor";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(658, 572);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAchBadge)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ctxMenuTree.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.grpItemEditor.ResumeLayout(false);
            this.grpItemEditor.PerformLayout();
            this.grpGroupEditor.ResumeLayout(false);
            this.grpGroupEditor.PerformLayout();
            this.ctxMenuTextBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbAchPoints;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAchId;
        private System.Windows.Forms.Label label6;
        private UndoRedoRichTextBox txtAchTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbAchBadge;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvCollectibles;
        private System.Windows.Forms.GroupBox grpGroupEditor;
        private System.Windows.Forms.TextBox txtGroupTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpItemEditor;
        private System.Windows.Forms.TextBox txtItemUrl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtItemUrlText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private UndoRedoRichTextBox rtxtIntro;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtOutro;
        private System.Windows.Forms.ContextMenuStrip ctxMenuTree;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private UndoRedoRichTextBox rtxtItemDescription;
        private System.Windows.Forms.ContextMenuStrip ctxMenuTextBox;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addCollectibleGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCollectibleItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
    }
}