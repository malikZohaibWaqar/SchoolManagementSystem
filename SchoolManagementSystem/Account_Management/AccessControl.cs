using DAL;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SchoolManagementSystem.Account_Management
{
    public partial class AccessControl : MetroForm
    {
        public AccessControl(int ID = 0)
        {
            try
            {
                InitializeComponent();
                comboBoxUser.DataSource = new SignInRepository().GetALLSignIn();
                comboBoxUser.DisplayMember = "UserName";
                comboBoxUser.ValueMember = "ID";

                comboBoxUser.SelectedIndexChanged += comboBoxUser_SelectedIndexChanged;
                if (ID != 0)
                    comboBoxUser.SelectedValue = ID;
                GetAccessControlList();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private void comboBoxUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAccessControlList();
        }
        private void GetAccessControlList()
        {
            try
            {
                AccessControlEntity ACE = new AccessControlRepository().GetAccessControlByID(int.Parse(comboBoxUser.SelectedValue.ToString()));
                List<MetroFramework.Controls.MetroCheckBox> mcb = gbModules.Controls.OfType<MetroFramework.Controls.MetroCheckBox>().ToList();
                foreach (MetroFramework.Controls.MetroCheckBox cb in mcb)
                {
                    if (ACE != null && ACE.modules.Contains(cb.Name))
                        cb.Checked = true;
                    else
                        cb.Checked = false;
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }

        }
        private void btnUpdateAccessControl_Click(object sender, EventArgs e)
        {
            try
            {
                string modules = string.Join(",", gbModules.Controls.OfType<MetroFramework.Controls.MetroCheckBox>().Where(m => m.Checked).Select(m => m.Name));

                AccessControlEntity ace = new AccessControlEntity();
                ace.userID = int.Parse(comboBoxUser.SelectedValue.ToString());
                ace.modules = modules;
                if (new AccessControlRepository().AddUpdateAccessControl(ace) < 0)
                    Utility.showMessage("Access Control", "Oops ! can't grant access to modules.Check logs for detail or contact service provider", "warning");
                else
                    Utility.showMessage("Access Control", "User has been successfully granted access to modules", "success");
                    
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
    }
}
