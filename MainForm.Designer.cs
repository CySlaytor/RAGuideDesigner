namespace RaGuideDesigner
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newGuideToolStripMenuItem = new ToolStripMenuItem();
            loadProjectToolStripMenuItem = new ToolStripMenuItem();
            saveProjectToolStripMenuItem = new ToolStripMenuItem();
            saveProjectAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            importFromRAJSONToolStripMenuItem = new ToolStripMenuItem();
            importFromMarkdownToolStripMenuItem = new ToolStripMenuItem();
            generateMarkdownToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            spellCheckToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            tvGuideStructure = new RaGuideDesigner.Views.BufferedTreeView();
            cmTree = new ContextMenuStrip(components);
            expandAllToolStripMenuItem = new ToolStripMenuItem();
            collapseAllToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            addAchievementCategoryToolStripMenuItem = new ToolStripMenuItem();
            addAchievementToolStripMenuItem = new ToolStripMenuItem();
            addLeaderboardToolStripMenuItem = new ToolStripMenuItem();
            addCreditToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            duplicateToolStripMenuItem = new ToolStripMenuItem();
            moveUpToolStripMenuItem = new ToolStripMenuItem();
            moveDownToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            pnlEditor = new Panel();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            cmTree.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1264, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newGuideToolStripMenuItem, loadProjectToolStripMenuItem, saveProjectToolStripMenuItem, saveProjectAsToolStripMenuItem, toolStripSeparator1, importFromRAJSONToolStripMenuItem, importFromMarkdownToolStripMenuItem, generateMarkdownToolStripMenuItem, toolStripSeparator2, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // newGuideToolStripMenuItem
            // 
            newGuideToolStripMenuItem.Name = "newGuideToolStripMenuItem";
            newGuideToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newGuideToolStripMenuItem.Size = new Size(282, 22);
            newGuideToolStripMenuItem.Text = "&New Guide";
            newGuideToolStripMenuItem.Click += newGuideToolStripMenuItem_Click;
            // 
            // loadProjectToolStripMenuItem
            // 
            loadProjectToolStripMenuItem.Name = "loadProjectToolStripMenuItem";
            loadProjectToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            loadProjectToolStripMenuItem.Size = new Size(282, 22);
            loadProjectToolStripMenuItem.Text = "&Load Project...";
            loadProjectToolStripMenuItem.Click += loadProjectToolStripMenuItem_Click;
            // 
            // saveProjectToolStripMenuItem
            // 
            saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
            saveProjectToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveProjectToolStripMenuItem.Size = new Size(282, 22);
            saveProjectToolStripMenuItem.Text = "&Save Project";
            saveProjectToolStripMenuItem.Click += saveProjectToolStripMenuItem_Click;
            // 
            // saveProjectAsToolStripMenuItem
            // 
            saveProjectAsToolStripMenuItem.Name = "saveProjectAsToolStripMenuItem";
            saveProjectAsToolStripMenuItem.Size = new Size(282, 22);
            saveProjectAsToolStripMenuItem.Text = "Save Project &As...";
            saveProjectAsToolStripMenuItem.Click += saveProjectAsToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(279, 6);
            // 
            // importFromRAJSONToolStripMenuItem
            // 
            importFromRAJSONToolStripMenuItem.Name = "importFromRAJSONToolStripMenuItem";
            importFromRAJSONToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.I;
            importFromRAJSONToolStripMenuItem.Size = new Size(282, 22);
            importFromRAJSONToolStripMenuItem.Text = "&Import JSON File...";
            importFromRAJSONToolStripMenuItem.Click += importFromRAJSONToolStripMenuItem_Click;
            // 
            // importFromMarkdownToolStripMenuItem
            // 
            importFromMarkdownToolStripMenuItem.Name = "importFromMarkdownToolStripMenuItem";
            importFromMarkdownToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.I;
            importFromMarkdownToolStripMenuItem.Size = new Size(282, 22);
            importFromMarkdownToolStripMenuItem.Text = "Import Existing &Markdown...";
            importFromMarkdownToolStripMenuItem.Click += importFromMarkdownToolStripMenuItem_Click;
            // 
            // generateMarkdownToolStripMenuItem
            // 
            generateMarkdownToolStripMenuItem.Name = "generateMarkdownToolStripMenuItem";
            generateMarkdownToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            generateMarkdownToolStripMenuItem.Size = new Size(282, 22);
            generateMarkdownToolStripMenuItem.Text = "E&xport Markdown...";
            generateMarkdownToolStripMenuItem.Click += generateMarkdownToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(279, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(282, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem, toolStripSeparator6, spellCheckToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "&Edit";
            editToolStripMenuItem.DropDownOpening += editToolStripMenuItem_DropDownOpening;
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(174, 22);
            undoToolStripMenuItem.Text = "&Undo";
            undoToolStripMenuItem.Click += undoToolStripMenuItem_Click;
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.Z;
            redoToolStripMenuItem.Size = new Size(174, 22);
            redoToolStripMenuItem.Text = "&Redo";
            redoToolStripMenuItem.Click += redoToolStripMenuItem_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(171, 6);
            // 
            // spellCheckToolStripMenuItem
            // 
            spellCheckToolStripMenuItem.CheckOnClick = true;
            spellCheckToolStripMenuItem.Name = "spellCheckToolStripMenuItem";
            spellCheckToolStripMenuItem.Size = new Size(174, 22);
            spellCheckToolStripMenuItem.Text = "Enable Spell Check";
            spellCheckToolStripMenuItem.Click += spellCheckToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(116, 22);
            aboutToolStripMenuItem.Text = "&About...";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tvGuideStructure);
            splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pnlEditor);
            splitContainer1.Panel2MinSize = 500;
            splitContainer1.Size = new Size(1264, 657);
            splitContainer1.SplitterDistance = 350;
            splitContainer1.TabIndex = 1;
            // 
            // tvGuideStructure
            // 
            tvGuideStructure.AllowDrop = true;
            tvGuideStructure.ContextMenuStrip = cmTree;
            tvGuideStructure.Dock = DockStyle.Fill;
            tvGuideStructure.HideSelection = false;
            tvGuideStructure.Location = new Point(0, 0);
            tvGuideStructure.Name = "tvGuideStructure";
            tvGuideStructure.Size = new Size(350, 657);
            tvGuideStructure.TabIndex = 0;
            tvGuideStructure.AfterSelect += tvGuideStructure_AfterSelect;
            tvGuideStructure.NodeMouseClick += tvGuideStructure_NodeMouseClick;
            tvGuideStructure.DragDrop += tvGuideStructure_DragDrop;
            tvGuideStructure.DragEnter += tvGuideStructure_DragEnter;
            tvGuideStructure.DragOver += tvGuideStructure_DragOver;
            tvGuideStructure.KeyDown += tvGuideStructure_KeyDown;
            tvGuideStructure.MouseDown += tvGuideStructure_MouseDown;
            tvGuideStructure.MouseMove += tvGuideStructure_MouseMove;
            // 
            // cmTree
            // 
            cmTree.Items.AddRange(new ToolStripItem[] { expandAllToolStripMenuItem, collapseAllToolStripMenuItem, toolStripSeparator5, addAchievementCategoryToolStripMenuItem, addAchievementToolStripMenuItem, addLeaderboardToolStripMenuItem, addCreditToolStripMenuItem, toolStripSeparator4, duplicateToolStripMenuItem, moveUpToolStripMenuItem, moveDownToolStripMenuItem, toolStripSeparator3, deleteToolStripMenuItem });
            cmTree.Name = "cmTree";
            cmTree.Size = new Size(221, 242);
            cmTree.Opening += cmTree_Opening;
            // 
            // expandAllToolStripMenuItem
            // 
            expandAllToolStripMenuItem.Name = "expandAllToolStripMenuItem";
            expandAllToolStripMenuItem.Size = new Size(220, 22);
            expandAllToolStripMenuItem.Text = "Expand All";
            expandAllToolStripMenuItem.Click += expandAllToolStripMenuItem_Click;
            // 
            // collapseAllToolStripMenuItem
            // 
            collapseAllToolStripMenuItem.Name = "collapseAllToolStripMenuItem";
            collapseAllToolStripMenuItem.Size = new Size(220, 22);
            collapseAllToolStripMenuItem.Text = "Collapse All";
            collapseAllToolStripMenuItem.Click += collapseAllToolStripMenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(217, 6);
            // 
            // addAchievementCategoryToolStripMenuItem
            // 
            addAchievementCategoryToolStripMenuItem.Name = "addAchievementCategoryToolStripMenuItem";
            addAchievementCategoryToolStripMenuItem.Size = new Size(220, 22);
            addAchievementCategoryToolStripMenuItem.Text = "Add Achievement Category";
            addAchievementCategoryToolStripMenuItem.Click += addAchievementCategoryToolStripMenuItem_Click;
            // 
            // addAchievementToolStripMenuItem
            // 
            addAchievementToolStripMenuItem.Name = "addAchievementToolStripMenuItem";
            addAchievementToolStripMenuItem.Size = new Size(220, 22);
            addAchievementToolStripMenuItem.Text = "Add Achievement";
            addAchievementToolStripMenuItem.Click += addAchievementToolStripMenuItem_Click;
            // 
            // addLeaderboardToolStripMenuItem
            // 
            addLeaderboardToolStripMenuItem.Name = "addLeaderboardToolStripMenuItem";
            addLeaderboardToolStripMenuItem.Size = new Size(220, 22);
            addLeaderboardToolStripMenuItem.Text = "Add Leaderboard";
            addLeaderboardToolStripMenuItem.Click += addLeaderboardToolStripMenuItem_Click;
            // 
            // addCreditToolStripMenuItem
            // 
            addCreditToolStripMenuItem.Name = "addCreditToolStripMenuItem";
            addCreditToolStripMenuItem.Size = new Size(220, 22);
            addCreditToolStripMenuItem.Text = "Add Credit";
            addCreditToolStripMenuItem.Click += addCreditToolStripMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(217, 6);
            // 
            // duplicateToolStripMenuItem
            // 
            duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
            duplicateToolStripMenuItem.Size = new Size(220, 22);
            duplicateToolStripMenuItem.Text = "Duplicate";
            duplicateToolStripMenuItem.Click += duplicateToolStripMenuItem_Click;
            // 
            // moveUpToolStripMenuItem
            // 
            moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            moveUpToolStripMenuItem.ShortcutKeyDisplayString = "Alt+Up";
            moveUpToolStripMenuItem.Size = new Size(220, 22);
            moveUpToolStripMenuItem.Text = "Move Up";
            moveUpToolStripMenuItem.Click += moveUpToolStripMenuItem_Click;
            // 
            // moveDownToolStripMenuItem
            // 
            moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            moveDownToolStripMenuItem.ShortcutKeyDisplayString = "Alt+Down";
            moveDownToolStripMenuItem.Size = new Size(220, 22);
            moveDownToolStripMenuItem.Text = "Move Down";
            moveDownToolStripMenuItem.Click += moveDownToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(217, 6);
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.ShortcutKeys = Keys.Delete;
            deleteToolStripMenuItem.Size = new Size(220, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // pnlEditor
            // 
            pnlEditor.Dock = DockStyle.Fill;
            pnlEditor.Location = new Point(0, 0);
            pnlEditor.Name = "pnlEditor";
            pnlEditor.Size = new Size(910, 657);
            pnlEditor.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(1280, 720);
            Name = "MainForm";
            Text = "RA Wiki Guide Generator";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            cmTree.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Views.BufferedTreeView tvGuideStructure;
        private System.Windows.Forms.Panel pnlEditor;
        private System.Windows.Forms.ToolStripMenuItem newGuideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem importFromRAJSONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateMarkdownToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmTree;
        private System.Windows.Forms.ToolStripMenuItem addAchievementCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAchievementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addLeaderboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCreditToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromMarkdownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem expandAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collapseAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem spellCheckToolStripMenuItem;
    }
}