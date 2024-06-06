using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SchoolManagementSystem.Student_Management
{
    public partial class testForm : MetroForm
    {
        public testForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this,"This is Error Message","Error",MessageBoxButtons.OK,MessageBoxIcon.Error, 150);
            MetroFramework.MetroMessageBox.Show(this, "This is Warning Message", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, 200);
            MetroFramework.MetroMessageBox.Show(this, "This is Success Message", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, 300);
        }

        private void testForm_Load(object sender, EventArgs e)
        {

        }
    }
}
