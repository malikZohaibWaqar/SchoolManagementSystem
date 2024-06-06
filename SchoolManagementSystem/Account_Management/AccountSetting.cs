using DAL;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SchoolManagementSystem.Account_Management
{
    public partial class AccountSetting : MetroForm
    {
        string ids { get; set; }
        public AccountSetting()
        {
            try
            {
                InitializeComponent();

                SignInEntity entity = new SignInRepository().GetSignInByID(Properties.Settings.Default.UserID);
                txtUserName.Text = entity.userName;
                txtPassword.Text = entity.password;

                bindDataGridView();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm())
                {
                    SignInEntity entity = new SignInEntity();
                    entity.ID = int.Parse(lblID.Text);
                    entity.userName = txtCUUserName.Text.Trim();
                    entity.password = txtCUPassword.Text.Trim();

                    if (new SignInRepository().AddUpdateSignIn(entity) > 0)
                    {
                        Utility.showMessage("Success", "User created successfully. Manage access control for '" + entity.userName + "'", "success");
                        new AccessControl(entity.ID).Show();
                    }
                    bindDataGridView();
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private bool ValidateForm()
        {
            try
            {
                if (txtCUUserName.Text == string.Empty)
                {
                    Utility.showMessage("Warning", "User Name is required", "warning");
                    return false;
                }
                if (txtCUPassword.Text == string.Empty)
                {
                    Utility.showMessage("Warning", "Password is required", "warning");
                    return false;
                }
                if (txtCUPassword.Text != txtCUConfirmPassword.Text)
                {
                    Utility.showMessage("Warning", "Password doesn't match", "warning");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
                return false;
            }
        }

        #region Grid Methods

        private void bindDataGridView()
        {
            try
            {
                List<SignInEntity> SignIn = new SignInRepository().GetALLSignIn();
                dataGridView.SetPagedDataSource(Utility.ToDataTable(SignIn), bindingNavigator);
                if (SignIn != null && SignIn.Count > 0)
                    dataGridView.Columns["ID"].Visible = false;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right && e.RowIndex > -1)
                {
                    if (dataGridView.SelectedRows.Count > 1)
                        contextMenugrid.Items[0].Enabled = false;
                    else
                        contextMenugrid.Items[0].Enabled = true;

                    ids = string.Empty;
                    foreach (DataGridViewRow row in dataGridView.SelectedRows)
                        ids += row.Cells["ID"].Value.ToString() + ",";
                    if (ids.Length > 0)
                    {
                        ids = ids.Remove(ids.Length - 1);
                        contextMenugrid.Show(Cursor.Position);
                    }
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private void contextMenugrid_edit_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                lblID.Text = selectedRow.Cells["ID"].Value.ToString();
                txtCUUserName.Text = selectedRow.Cells["userName"].Value.ToString();
                txtCUPassword.Text = selectedRow.Cells["password"].Value.ToString();
                txtCUConfirmPassword.Text = selectedRow.Cells["password"].Value.ToString();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private void contextMenugrid_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ids.Length > 0)
                {
                    foreach (string id in ids.Split(','))
                    {
                        new AccessControlRepository().DeleteAccessControl(int.Parse(id));
                        new SignInRepository().DeleteSignInByID(int.Parse(id));
                    }
                    bindDataGridView();
                    Utility.showMessage("Success", "Record deleted successfully", "success");
                }
                else
                    Utility.showMessage("Warning", "Select record to delete", "warning");
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }

        #endregion
    }
}
