using DAL;
using MetroFramework.Forms;
using System;
using System.Windows.Forms;

namespace SchoolManagementSystem.Account_Management
{
    public partial class Signin : MetroForm
    {
        public Signin()
        {
            InitializeComponent();
            lblDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
        }

        private void btnQuitApp_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Abort;
        }
        private void btnSignin_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (txtUserName.Text != string.Empty || txtPassword.Text != string.Empty)
                {
                    SignInEntity entity = new SignInRepository().ValidateSignIn(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                    if (entity != null)
                    {
                        Properties.Settings.Default.UserName = entity.userName;
                        Properties.Settings.Default.UserID = entity.ID;
                        if (Utility.initializeModules())
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        else
                        {
                            Utility.showMessage("Access Denied", "Unable to login with '" + entity.userName + "'.Access control not defined for this user. Please contact system administrator", "error");
                        }
                    }
                    else
                        Utility.showMessage("Invalid Credentials", "User name and password are invalid", "error");
                }
                else
                    Utility.showMessage("Credential Required", "Enter user name and password to proceed", "warning");
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
            this.Cursor = Cursors.Default;
        }
        private void btnGuestLogin_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.UserName = "Guest";
            Properties.Settings.Default.UserID = -1;
            if(Utility.initializeModules(true))
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
        }

        private void textboxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtPassword.Focus())
                {
                    if (e.KeyCode == Keys.CapsLock)
                    {
                        if (Control.IsKeyLocked(Keys.CapsLock))
                            lblCapslock.Text = "Caps lock is on";
                        else
                            lblCapslock.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
    }
}
