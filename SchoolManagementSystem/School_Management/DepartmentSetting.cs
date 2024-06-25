using DAL;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SchoolManagementSystem.School_Management
{
    public partial class DepartmentSetting : MetroForm
    {
        string ids { get; set; }
        public DepartmentSetting()
        {
            InitializeComponent();
            bindDataGridView();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDepartmentName.Text != "")
                {
                    if (new System.Text.RegularExpressions.Regex("^[0-9A-Za-z ]+$").IsMatch(txtDepartmentName.Text))//.All(char.IsLetter))
                    {
                        DepartmentEntity DE = new DepartmentEntity();
                        DE.ID = int.Parse(lblID.Text);
                        DE.DepartmentName = txtDepartmentName.Text;
                        if (new DepartmentRepository().AddDepartment(DE) > 0)
                            Utility.showMessage("Success", "Your record has been successfully saved.Navigate to list to view record", "success");
                        else
                            Utility.showMessage("Error", "Oops ! unable to save record. Check logs for detail or contact service provider", "error");
                        lblID.Text = "0";
                        bindDataGridView();
                    }
                    else
                        Utility.showMessage("Warning","Alphabets (Aa-Zz) and Numbers are allowed", "warning");
                }
                else
                    Utility.showMessage("Warning", "Enter department name", "warning");
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
            }
        }

        #region Grid Methods

        private void bindDataGridView()
        {
            try
            {
                List<DepartmentEntity> departments = new DepartmentRepository().GetALLDepartments(true);
                dataGridView.SetPagedDataSource(Utility.ToDataTable(departments), bindingNavigator);

                if (departments != null && departments.Count > 0)
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
                txtDepartmentName.Text = selectedRow.Cells["DepartmentName"].Value.ToString();
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
                    bool confirm = false;
                    List<EmployeeEntity> entities = new EmployeeRepository(new DBTransections()).GetEmployeeByDepartmentID(ids);
                    if (entities != null && entities.Count > 0)
                        if (new Component.confirmationBox("Employee registered in this department will also be deleted.Still want to proceed?").ShowDialog() == DialogResult.Yes)
                            confirm = true;
                    if (confirm)
                    {
                        foreach (EmployeeEntity entity in entities)
                        {
                            if (new EmployeeRepository(new DBTransections()).DeleteEmployee(entity) > 0)
                            {
                                if (System.IO.File.Exists(Application.StartupPath + "\\Images\\Employee\\" + entity.ImageName))
                                    System.IO.File.Delete(Application.StartupPath + "\\Images\\Employee\\" + entity.ImageName);
                            }
                        }
                        foreach (string id in ids.Split(','))
                        {
                            new DepartmentRepository().DeleteDepartmentByID(int.Parse(id));
                        }
                        bindDataGridView();
                        Utility.showMessage("Success", "Record deleted successfully", "success");
                    }
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
