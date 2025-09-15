using System;
using System.Windows.Forms;

namespace RaGuideDesigner.Views
{
    public partial class InputBoxForm : Form
    {
        public string InputText { get; private set; } = "";

        public InputBoxForm(string title, string prompt, string defaultValue = "")
        {
            InitializeComponent();
            this.Text = title;
            this.lblPrompt.Text = prompt;
            this.txtInput.Text = defaultValue;
            this.InputText = defaultValue;
            this.txtInput.Select();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.InputText = this.txtInput.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Static helper method to make it easy to call, like the original InputBox
        public static DialogResult Show(string title, string prompt, ref string value)
        {
            using (var form = new InputBoxForm(title, prompt, value))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    value = form.InputText;
                }
                return result;
            }
        }
    }
}