using DAL;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Windows.Forms;

namespace SchoolManagementSystem.HR_Management
{
    public partial class EmployeeSalary : MetroForm
    {
        string ids { get; set; }
        public EmployeeSalary()
        {
            try
            {
                InitializeComponent();
                comboBoxDepartmentName.DataSource = new DepartmentRepository().GetALLDepartments(true);
                comboBoxDepartmentName.DisplayMember = "DepartmentName";
                comboBoxDepartmentName.ValueMember = "ID";
                comboBoxDepartmentName.SelectedIndexChanged += new EventHandler(comboBoxDepartmentName_SelectedIndexChanged);

                comboBoxEmployeeName.DataSource = new EmployeeRepository(new DBTransections()).GetALLEmployees(int.Parse(comboBoxDepartmentName.SelectedValue.ToString()));
                comboBoxEmployeeName.DisplayMember = "FirstName";
                comboBoxEmployeeName.ValueMember = "ID";
                comboBoxEmployeeName.SelectedIndexChanged += new EventHandler(comboBoxEmployeeName_SelectedIndexChanged);

                txtSalary.Text = new EmployeeRepository(new DBTransections()).GetEmployeeByID(int.Parse(comboBoxEmployeeName.SelectedValue.ToString())).Salary.ToString();

                txtDateGrid.TextChanged += bindDataGridView_filterChanged;

                comboBoxDepartmentGrid.DataSource = new DepartmentRepository().GetALLDepartments();
                comboBoxDepartmentGrid.DisplayMember = "DepartmentName";
                comboBoxDepartmentGrid.ValueMember = "ID";
                comboBoxDepartmentGrid.SelectedIndexChanged += bindDataGridView_filterChanged;

            }
            catch(Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSalary.Text != string.Empty)
                {
                    SalaryEntity SE = new SalaryEntity();
                    SE.ID = int.Parse(lblID.Text);
                    SE.EmployeeID = int.Parse(comboBoxEmployeeName.SelectedValue.ToString());
                    SE.DepartmentID = int.Parse(comboBoxDepartmentName.SelectedValue.ToString());
                    SE.date = DateTime.Parse(txtDate.Text);
                    if (txtDeduction.Text != string.Empty)
                        SE.Deduction = int.Parse(txtDeduction.Text);
                    SE.salary = int.Parse(txtSalary.Text);
                    if (txtDeduction.Text != string.Empty)
                        SE.NetPayable = SE.salary - SE.Deduction;

                    if (new SalaryRepository().AddSalary(SE) > 0)
                        Utility.showMessage("Success", "Your record has been successfully saved.Navigate to list to view record", "success");
                    else
                        Utility.showMessage("Error", "Oops ! unable to save record. Check logs for detail or contact service provider", "error");

                    lblID.Text = "0";
                }
                else
                    Utility.showMessage("Warning", "You are forgetting to pay salary. Please enter salary", "error");
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private void metroTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroTabControl.SelectedIndex == 1)
            {
                if (txtDateGrid.Text != string.Empty && comboBoxDepartmentGrid.SelectedValue != null)
                        bindDataGridView(DateTime.Parse(txtDateGrid.Text), int.Parse(comboBoxDepartmentGrid.SelectedValue.ToString()));
            }
        }
        private void comboBoxDepartmentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBoxEmployeeName.DataSource = new EmployeeRepository(new DBTransections()).GetALLEmployees(int.Parse(comboBoxDepartmentName.SelectedValue.ToString()));
                comboBoxEmployeeName.DisplayMember = "FirstName";
                comboBoxEmployeeName.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private void comboBoxEmployeeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSalary.Text = new EmployeeRepository(new DBTransections()).GetEmployeeByID(int.Parse(comboBoxEmployeeName.SelectedValue.ToString())).Salary.ToString();
        }

        #region Grid Methods

        private void bindDataGridView_filterChanged(object sender, EventArgs e)
        {
            if (comboBoxDepartmentGrid.SelectedValue != null )
                bindDataGridView(DateTime.Parse(txtDateGrid.Text), int.Parse(comboBoxDepartmentGrid.SelectedValue.ToString()));
        }
        private void bindDataGridView(DateTime date, int DeptID)
        {
            try
            {
                DataTable salaries = GridRepository.GetData_Salary(date, DeptID);
                dataGridView.SetPagedDataSource(salaries, bindingNavigator);

                if (salaries != null && salaries.Rows.Count > 0)
                {
                    dataGridView.Columns["ID"].Visible = false;
                    dataGridView.Columns["DepartmentID"].Visible = false;
                    dataGridView.Columns["EmployeeID"].Visible = false;
                    dataGridView.Columns["date"].Visible = false;
                }
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
                comboBoxDepartmentName.SelectedValue = int.Parse(selectedRow.Cells["DepartmentID"].Value.ToString());
                comboBoxEmployeeName.SelectedValue = int.Parse(selectedRow.Cells["EmployeeID"].Value.ToString());
                txtDate.Text = selectedRow.Cells["date"].Value.ToString();
                txtDeduction.Text = selectedRow.Cells["Deduction"].Value.ToString();
                txtSalary.Text = selectedRow.Cells["salary"].Value.ToString();
                metroTabControl.SelectedIndex = 0;
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
                        new SalaryRepository().DeleteSalaryByID(int.Parse(id));
                    }
                    bindDataGridView(DateTime.Parse(txtDateGrid.Text), int.Parse(comboBoxDepartmentGrid.SelectedValue.ToString()));
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
