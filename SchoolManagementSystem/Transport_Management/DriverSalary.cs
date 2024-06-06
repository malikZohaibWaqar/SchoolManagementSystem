using DAL;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SchoolManagementSystem.Transport_Management
{
    public partial class DriverSalary : MetroForm
    {
        string ids { get; set; }
        public DriverSalary()
        {
            InitializeComponent();

            List<DriverEntity> drivers = new DriverRepository().GetALLDrivers();
            if (drivers != null && drivers.Count > 0)
            {
                comboBoxDriverName.DataSource = drivers;
                comboBoxDriverName.DisplayMember = "DriverName";
                comboBoxDriverName.ValueMember = "ID";

                comboBoxDriverName.SelectedIndexChanged += comboBoxDriverName_SelectedIndexChanged;
                txtSalary.Text = new DriverRepository().GetDriverByID(int.Parse(comboBoxDriverName.SelectedValue.ToString())).Salary.ToString();
            }
            else
            {
                Utility.showMessage("Warning", "Oops ! You don't have any driver in your school to pay salary", "warning");
                btnSave.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DriverSalaryEntity DSE = new DriverSalaryEntity();
                DSE.ID = int.Parse(lblID.Text);
                DSE.DriverID = int.Parse(comboBoxDriverName.SelectedValue.ToString());
                DSE.SalaryMonth = DateTime.Parse(txtDate.Text);

                if (txtDeduction.Text != "")
                    DSE.Deduction = int.Parse(txtDeduction.Text);

                DSE.salary = int.Parse(txtSalary.Text);
                DSE.NetPayable = DSE.salary - DSE.Deduction;

                if (new DriverSalaryRepository().AddDriverSalary(DSE) > 0)
                    Utility.showMessage("Success", "Salary has been paid to driver successfully.Navigate to list to view record", "success");
                else
                    Utility.showMessage("Error", "Oops ! unable to save record. Check logs for detail or contact service provider", "error");
                
                lblID.Text = "0";
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
            this.Cursor = Cursors.Default;
        }
        private void comboBoxDriverName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtSalary.Text = new DriverRepository().GetDriverByID(int.Parse(comboBoxDriverName.SelectedValue.ToString())).Salary.ToString();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroTabControl1.SelectedIndex == 1)
                bindDataGridView();
        }

        #region Grid Methods

        private void bindDataGridView()
        {
            try
            {
                DataTable salaries = GridRepository.GetData_DriverSalary(DateTime.Parse(txtDateGrid.Text));
                dataGridView.SetPagedDataSource(salaries, bindingNavigator);
                if (salaries != null && salaries.Rows.Count > 0)
                {
                    dataGridView.Columns["ID"].Visible = false;
                    dataGridView.Columns["DriverID"].Visible = false;
                    dataGridView.Columns["SalaryMonth"].Visible = false;
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
                comboBoxDriverName.SelectedValue = int.Parse(selectedRow.Cells["DriverID"].Value.ToString());
                txtDate.Text = selectedRow.Cells["SalaryMonth"].Value.ToString();
                txtDeduction.Text = selectedRow.Cells["Deduction"].Value.ToString();
                txtSalary.Text = selectedRow.Cells["salary"].Value.ToString();
                metroTabControl1.SelectedIndex = 0;
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
                        new DriverSalaryRepository().DeleteDriverSalaryByID(int.Parse(id));
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
