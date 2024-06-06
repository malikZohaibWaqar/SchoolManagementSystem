using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace SchoolManagementSystem.Component
{
    public partial class confirmationBox : MetroForm
    {
        public confirmationBox(string message)
        {
            InitializeComponent();
            lblMessage.Text = message;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
        }
    }
}
