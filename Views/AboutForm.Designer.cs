namespace RaGuideDesigner.Views
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            btnOk = new Button();
            lblAppName = new Label();
            lblVersion = new Label();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblAuthor = new Label();
            linkCySlaytor = new LinkLabel();
            lblCySlaytorDesc = new Label();
            lblDesigner = new Label();
            linkASolidSnack = new LinkLabel();
            lblASolidSnackDesc = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(397, 226);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 0;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAppName.Location = new Point(82, 12);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(173, 25);
            lblAppName.TabIndex = 1;
            lblAppName.Text = "RA Guide Designer";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(84, 41);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(63, 15);
            lblVersion.TabIndex = 2;
            lblVersion.Text = "Version 1.0";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(btnOk);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 218);
            panel1.Name = "panel1";
            panel1.Size = new Size(484, 61);
            panel1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lblAuthor, 0, 0);
            tableLayoutPanel1.Controls.Add(linkCySlaytor, 1, 0);
            tableLayoutPanel1.Controls.Add(lblCySlaytorDesc, 1, 1);
            tableLayoutPanel1.Controls.Add(lblDesigner, 0, 2);
            tableLayoutPanel1.Controls.Add(linkASolidSnack, 1, 2);
            tableLayoutPanel1.Controls.Add(lblASolidSnackDesc, 1, 3);
            tableLayoutPanel1.Location = new Point(12, 81);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel1.Size = new Size(460, 186);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // lblAuthor
            // 
            lblAuthor.Anchor = AnchorStyles.Right;
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAuthor.Location = new Point(68, 5);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(49, 15);
            lblAuthor.TabIndex = 0;
            lblAuthor.Text = "Author:";
            // 
            // linkCySlaytor
            // 
            linkCySlaytor.Anchor = AnchorStyles.Left;
            linkCySlaytor.AutoSize = true;
            linkCySlaytor.LinkArea = new LinkArea(0, 9);
            linkCySlaytor.Location = new Point(123, 5);
            linkCySlaytor.Name = "linkCySlaytor";
            linkCySlaytor.Size = new Size(57, 15);
            linkCySlaytor.TabIndex = 1;
            linkCySlaytor.TabStop = true;
            linkCySlaytor.Text = "CySlaytor";
            linkCySlaytor.LinkClicked += linkLabel_LinkClicked;
            // 
            // lblCySlaytorDesc
            // 
            lblCySlaytorDesc.Dock = DockStyle.Fill;
            lblCySlaytorDesc.Location = new Point(123, 25);
            lblCySlaytorDesc.Name = "lblCySlaytorDesc";
            lblCySlaytorDesc.Size = new Size(334, 71);
            lblCySlaytorDesc.TabIndex = 2;
            lblCySlaytorDesc.Text = "Description for CySlaytor";
            // 
            // lblDesigner
            // 
            lblDesigner.Anchor = AnchorStyles.Right;
            lblDesigner.AutoSize = true;
            lblDesigner.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDesigner.Location = new Point(14, 101);
            lblDesigner.Name = "lblDesigner";
            lblDesigner.Size = new Size(103, 15);
            lblDesigner.TabIndex = 3;
            lblDesigner.Text = "Template Design:";
            // 
            // linkASolidSnack
            // 
            linkASolidSnack.Anchor = AnchorStyles.Left;
            linkASolidSnack.AutoSize = true;
            linkASolidSnack.LinkArea = new LinkArea(0, 11);
            linkASolidSnack.Location = new Point(123, 101);
            linkASolidSnack.Name = "linkASolidSnack";
            linkASolidSnack.Size = new Size(72, 15);
            linkASolidSnack.TabIndex = 4;
            linkASolidSnack.TabStop = true;
            linkASolidSnack.Text = "ASolidSnack";
            linkASolidSnack.LinkClicked += linkLabel_LinkClicked;
            // 
            // lblASolidSnackDesc
            // 
            lblASolidSnackDesc.Dock = DockStyle.Fill;
            lblASolidSnackDesc.Location = new Point(123, 121);
            lblASolidSnackDesc.Name = "lblASolidSnackDesc";
            lblASolidSnackDesc.Size = new Size(334, 65);
            lblASolidSnackDesc.TabIndex = 5;
            lblASolidSnackDesc.Text = "Description for ASolidSnack";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(64, 64);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // AboutForm
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(484, 279);
            Controls.Add(pictureBox1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(lblVersion);
            Controls.Add(lblAppName);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "About";
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.LinkLabel linkCySlaytor;
        private System.Windows.Forms.Label lblCySlaytorDesc;
        private System.Windows.Forms.Label lblDesigner;
        private System.Windows.Forms.LinkLabel linkASolidSnack;
        private System.Windows.Forms.Label lblASolidSnackDesc;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}