using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SchoolManagementSystem.Component
{
    public partial class messageBox : MetroForm
    {
        public messageBox(string headerText,string message,string type)
        {
            InitializeComponent();
            if (type == "error")
            {               
                pbMessage.Image = SchoolManagementSystem.Properties.Resources.error_32x32;
                panelHeader.BackColor = Color.Maroon;
            }
            if (type == "warning")
            {
                pbMessage.Image = SchoolManagementSystem.Properties.Resources.warning_32x32;
                panelHeader.BackColor = Color.Orange;
            }
            if (type == "success")
            {
                pbMessage.Image = SchoolManagementSystem.Properties.Resources.success_32x32;
                panelHeader.BackColor = Color.DarkGreen;
            }
            lblHeader.ForeColor = Color.White;
            lblHeader.Text = headerText;
            lblMessage.Text = message;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
