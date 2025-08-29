using System;
using System.Reflection;
using System.Windows.Forms;

namespace RaGuideDesigner.Views
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            this.Text = "About RA Guide Designer";
            lblAppName.Text = "RA Guide Designer";

            // Get version from assembly
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            if (version != null)
            {
                lblVersion.Text = $"Version {version.Major}.{version.Minor}.{version.Build}";
            }

            lblCySlaytorDesc.Text = "This tool was developed to streamline the creation of high-quality, standardized wiki guides for the RetroAchievements community.";
            lblASolidSnackDesc.Text = "Provided the comprehensive guide template, design specifications, and feature requirements that form the foundation of this application.";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Safely check if the LinkData is a valid string URL
                if (e.Link?.LinkData is string url && !string.IsNullOrEmpty(url))
                {
                    var ps = new System.Diagnostics.ProcessStartInfo(url)
                    {
                        UseShellExecute = true,
                        Verb = "open"
                    };
                    System.Diagnostics.Process.Start(ps);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Could not open the link.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}