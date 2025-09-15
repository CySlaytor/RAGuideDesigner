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
            btnOk = new System.Windows.Forms.Button();
            lblAppName = new System.Windows.Forms.Label();
            lblVersion = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            lblAuthor = new System.Windows.Forms.Label();
            linkCySlaytor = new System.Windows.Forms.LinkLabel();
            lblCySlaytorDesc = new System.Windows.Forms.Label();
            lblDesigner = new System.Windows.Forms.Label();
            linkASolidSnack = new System.Windows.Forms.LinkLabel();
            lblASolidSnackDesc = new System.Windows.Forms.Label();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOk.Location = new System.Drawing.Point(397, 226);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(75, 23);
            btnOk.TabIndex = 0;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblAppName.Location = new System.Drawing.Point(82, 12);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new System.Drawing.Size(173, 25);
            lblAppName.TabIndex = 1;
            lblAppName.Text = "RA Guide Designer";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new System.Drawing.Point(84, 41);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new System.Drawing.Size(63, 15);
            lblVersion.TabIndex = 2;
            lblVersion.Text = "Version 1.0";
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.Control;
            panel1.Controls.Add(btnOk);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(0, 218);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(484, 61);
            panel1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(lblAuthor, 0, 0);
            tableLayoutPanel1.Controls.Add(linkCySlaytor, 1, 0);
            tableLayoutPanel1.Controls.Add(lblCySlaytorDesc, 1, 1);
            tableLayoutPanel1.Controls.Add(lblDesigner, 0, 2);
            tableLayoutPanel1.Controls.Add(linkASolidSnack, 1, 2);
            tableLayoutPanel1.Controls.Add(lblASolidSnackDesc, 1, 3);
            tableLayoutPanel1.Location = new System.Drawing.Point(12, 81);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            tableLayoutPanel1.Size = new System.Drawing.Size(460, 186);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // lblAuthor
            // 
            lblAuthor.Anchor = System.Windows.Forms.AnchorStyles.Right;
            lblAuthor.AutoSize = true;
            lblAuthor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblAuthor.Location = new System.Drawing.Point(68, 5);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new System.Drawing.Size(49, 15);
            lblAuthor.TabIndex = 0;
            lblAuthor.Text = "Author:";
            // 
            // linkCySlaytor
            // 
            linkCySlaytor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            linkCySlaytor.AutoSize = true;
            linkCySlaytor.LinkArea = new System.Windows.Forms.LinkArea(0, 9);
            linkCySlaytor.Location = new System.Drawing.Point(123, 5);
            linkCySlaytor.Name = "linkCySlaytor";
            linkCySlaytor.Size = new System.Drawing.Size(57, 15);
            linkCySlaytor.TabIndex = 1;
            linkCySlaytor.TabStop = true;
            linkCySlaytor.Text = "CySlaytor";
            linkCySlaytor.LinkClicked += linkLabel_LinkClicked;
            // 
            // lblCySlaytorDesc
            // 
            lblCySlaytorDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            lblCySlaytorDesc.Location = new System.Drawing.Point(123, 25);
            lblCySlaytorDesc.Name = "lblCySlaytorDesc";
            lblCySlaytorDesc.Size = new System.Drawing.Size(334, 71);
            lblCySlaytorDesc.TabIndex = 2;
            lblCySlaytorDesc.Text = "Description for CySlaytor";
            // 
            // lblDesigner
            // 
            lblDesigner.Anchor = System.Windows.Forms.AnchorStyles.Right;
            lblDesigner.AutoSize = true;
            lblDesigner.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblDesigner.Location = new System.Drawing.Point(14, 101);
            lblDesigner.Name = "lblDesigner";
            lblDesigner.Size = new System.Drawing.Size(103, 15);
            lblDesigner.TabIndex = 3;
            lblDesigner.Text = "Template Design:";
            // 
            // linkASolidSnack
            // 
            linkASolidSnack.Anchor = System.Windows.Forms.AnchorStyles.Left;
            linkASolidSnack.AutoSize = true;
            linkASolidSnack.LinkArea = new System.Windows.Forms.LinkArea(0, 11);
            linkASolidSnack.Location = new System.Drawing.Point(123, 101);
            linkASolidSnack.Name = "linkASolidSnack";
            linkASolidSnack.Size = new System.Drawing.Size(72, 15);
            linkASolidSnack.TabIndex = 4;
            linkASolidSnack.TabStop = true;
            linkASolidSnack.Text = "ASolidSnack";
            linkASolidSnack.LinkClicked += linkLabel_LinkClicked;
            // 
            // lblASolidSnackDesc
            // 
            lblASolidSnackDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            lblASolidSnackDesc.Location = new System.Drawing.Point(123, 121);
            lblASolidSnackDesc.Name = "lblASolidSnackDesc";
            lblASolidSnackDesc.Size = new System.Drawing.Size(334, 65);
            lblASolidSnackDesc.TabIndex = 5;
            lblASolidSnackDesc.Text = "Description for ASolidSnack";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new System.Drawing.Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(64, 64);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // AboutForm
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Window;
            ClientSize = new System.Drawing.Size(484, 279);
            Controls.Add(pictureBox1);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(lblVersion);
            Controls.Add(lblAppName);
            Controls.Add(panel1);
            Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutForm";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "About";
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
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