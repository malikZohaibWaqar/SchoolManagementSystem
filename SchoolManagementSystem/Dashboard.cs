using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class Dashboard : MetroForm
    {
        private string[] modules { get; set; }

        #region Form methods
        
        public Dashboard()
        {
            InitializeComponent();
            timer.Start();
            lblDateTime.Text = String.Format("{0:F}", DateTime.Now);
            lblUserName.Text = Properties.Settings.Default.UserName;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = String.Format("{0:F}", DateTime.Now);
        }
        private void loginUserMenu_Clicked(object sender, EventArgs e)
        {
            contextMenuUser.Show(lblUserName, (new Point(lblUserName.Width - contextMenuUser.Width, lblUserName.Bottom)));
        }
        private void btnSignOut_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.UserID = 0;
            Properties.Settings.Default.UserName = string.Empty;
            Application.Restart();
        }
        private void btnExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
        #endregion

        #region School Management Methods

        private void MIClassSetting_Click(object sender, EventArgs e)
        {
            string controlName = "";
            if (sender is ToolStripMenuItem)
                controlName = ((ToolStripMenuItem)sender).Name;
            else
                controlName = ((Button)sender).Name;
            if (Utility.verifyAccess(controlName))
                new School_Management.ClassSetting().Show(this);
        }

        private void MIDepartmentSetting_Click(object sender, EventArgs e)
        {
            string controlName = "";
            if (sender is ToolStripMenuItem)
                controlName = ((ToolStripMenuItem)sender).Name;
            else
                controlName = ((Button)sender).Name;
            if (Utility.verifyAccess(controlName))
                new School_Management.DepartmentSetting().Show(this);
        }

        private void MIFeesSetting_Click(object sender, EventArgs e)
        {
            string controlName = ((ToolStripMenuItem)sender).Name;
            if (Utility.verifyAccess(controlName))
                new School_Management.FeesSetting().Show(this);
        }

        private void MIGenerateTimeTable_Click(object sender, EventArgs e)
        {
            string controlName = ((ToolStripMenuItem)sender).Name;
            if (Utility.verifyAccess(controlName))
                new School_Management.GenerateTimeTable().Show(this);
        }

        private void MILoadTimeTable_Click(object sender, EventArgs e)
        {
            string controlName = ((ToolStripMenuItem)sender).Name;
            if (Utility.verifyAccess(controlName))
                new School_Management.LoadTimeTable().Show(this);
        }

        private void MIInstituteExpense_Click(object sender, EventArgs e)
        {
            string controlName = ((ToolStripMenuItem)sender).Name;
            if (Utility.verifyAccess(controlName))
                new School_Management.InstituteExpense().Show(this);
        }
        
        private void MILicenseSetting_Click(object sender, EventArgs e)
        {
            string controlName = ((ToolStripMenuItem)sender).Name;
            if (Utility.verifyAccess(controlName))
                new School_Management.LicenseSetting().Show(this);
        }
        #endregion

        #region Student Management Methods

        private void MIStudentRegistration_Click(object sender, EventArgs e)
        {
            string controlName = "";
            if (sender is ToolStripMenuItem)
                controlName = ((ToolStripMenuItem)sender).Name;
            else
                controlName = ((Button)sender).Name;
            if (Utility.verifyAccess(controlName))
                new Student_Management.Register(0).Show(this);
        }

        private void MIFeesCollection_Click(object sender, EventArgs e)
        {
            string controlName = ((ToolStripMenuItem)sender).Name;
            if (Utility.verifyAccess(controlName))
                new Student_Management.FeesCollection().Show(this);
        }

        private void MIStudentPromotion_Click(object sender, EventArgs e)
        {
            string controlName = ((ToolStripMenuItem)sender).Name;
            if (Utility.verifyAccess(controlName))
                new Student_Management.PromoteStudent().Show(this);
        }

        private void MIStudentlist_Click(object sender, EventArgs e)
        {
            string controlName = ((ToolStripMenuItem)sender).Name;
            if (Utility.verifyAccess(controlName))
                new Student_Management.List().Show(this);
        }

        #endregion

        #region Employee Management Methods

        private void MIEmployeeRegistration_Click(object sender, EventArgs e)
        {
            string controlName = "";
            if (sender is ToolStripMenuItem)
                controlName = ((ToolStripMenuItem)sender).Name;
            else
                controlName = ((Button)sender).Name;
            if (Utility.verifyAccess(controlName))
                new HR_Management.Register(0).Show(this);
        }

        private void MIEmployeeSalary_Click(object sender, EventArgs e)
        {
            string controlName = ((ToolStripMenuItem)sender).Name;
            if (Utility.verifyAccess(controlName))
                new HR_Management.EmployeeSalary().Show(this);
        }

        private void MIEmployeeTypeSetting_Click(object sender, EventArgs e)
        {
            string controlName = ((ToolStripMenuItem)sender).Name;
            if (Utility.verifyAccess(controlName))
                new HR_Management.EmployeeType().Show(this);
        }

        private void MIEmployeeList_Click(object sender, EventArgs e)
        {
            string controlName = ((ToolStripMenuItem)sender).Name;
            if (Utility.verifyAccess(controlName)) new HR_Management.List().Show(this);
        }

        #endregion

        #region Transport Management Methods

        private void MIRegisterTransport_Click(object sender, EventArgs e)
        {
            string controlName = ((ToolStripMenuItem)sender).Name;
            if (Utility.verifyAccess(controlName))
                new Transport_Management.RegisterTransport().Show(this);
        }

        private void MIRegisterDriver_Click(object sender, EventArgs e)
        {
            string controlName = ((ToolStripMenuItem)sender).Name;
            if (Utility.verifyAccess(controlName)) new Transport_Management.RegisterDriver().Show(this);
        }
        private void MIDriverSalary_Click(object sender, EventArgs e)
        {
            string controlName = ((ToolStripMenuItem)sender).Name;
            if (Utility.verifyAccess(controlName)) new Transport_Management.DriverSalary().Show(this);
        }

        #endregion

        #region Inventory Management Methods
        private void MIRegisterInventory_Click(object sender, EventArgs e)
        {
            string controlName = ((ToolStripMenuItem)sender).Name;
            if (Utility.verifyAccess(controlName)) new Inventory_Management.Register().Show(this);
        }

        #endregion

        #region Report Methods

        private void btnStudentReport_Click(object sender, EventArgs e)
        {
            new Student_Management.StudentReports().Show(this);
        }

        private void btnEmployeeReport_Click(object sender, EventArgs e)
        {
            new HR_Management.EmployeeReports().Show(this);
        }

        private void btnTransportReport_Click(object sender, EventArgs e)
        {
            new Transport_Management.TransportReports().Show(this);
        }

        private void btnInventoryReport_Click(object sender, EventArgs e)
        {
            new Inventory_Management.InventoryReports().Show(this);
        }
        private void btnProfitLoss_Click(object sender, EventArgs e)
        {
            new School_Management.PLSReports().Show(this);
        }
        #endregion

        #region Other Methods
        private void TSMIaccountSetting_Click(object sender, EventArgs e)
        {
            string controlName = "";
            if (sender is ToolStripMenuItem)
                controlName = ((ToolStripMenuItem)sender).Name;
            else
                controlName = ((Button)sender).Name;
            if (Utility.verifyAccess(controlName)) new Account_Management.AccountSetting().Show(this);
        }
        private void TSMIaccessControl_Click(object sender, EventArgs e)
        {
            string controlName = ((ToolStripMenuItem)sender).Name;
            if (Utility.verifyAccess(controlName)) new Account_Management.AccessControl().Show(this);
        }
        #endregion

    }
}