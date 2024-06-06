using DAL;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Windows.Forms;

namespace SchoolManagementSystem.Transport_Management
{
    public partial class RegisterDriver : MetroForm
    {
        string ids { get; set; }
        public RegisterDriver()
        {
            InitializeComponent();
            string[] Qualification = new string[] { "illiterate", "Junior-School (1-5)", "Middle-School (6-8)", "Matric", "FA", "FSC", "BA", "BSC" };
            comboBoxQualification.DataSource = Qualification;

            comboBoxVehicle.DataSource = new VehicleRepository().GetALLVehicles(true);
            comboBoxVehicle.DisplayMember = "VehicleNo";
            comboBoxVehicle.ValueMember = "ID";
            bindDataGridView();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (txtDriverName.Text != string.Empty)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(txtDriverName.Text, @"^[A-Za-z ]+$"))//.All(char.IsLetter))
                    {
                        DriverEntity DE = new DriverEntity();
                        DE.ID = int.Parse(lblID.Text);
                        DE.VehicleID = int.Parse(comboBoxVehicle.SelectedValue.ToString());
                        DE.Qualification = comboBoxQualification.SelectedValue.ToString();
                        DE.Salary = (txtSalary.Text == "" ? 0 : int.Parse(txtSalary.Text));
                        DE.DriverName = txtDriverName.Text;
                        if (new DriverRepository().GetDriverByVehicleID(DE.VehicleID) == null)
                            AddDriver(DE);
                        else if (new Component.confirmationBox("Driver already assigned on this vehicle. Do you still want to proceed").ShowDialog() == DialogResult.Yes)
                                AddDriver(DE);
                    }
                    else
                        Utility.showMessage("Warning", "Alphabets (Aa-Zz) are allowed", "warning");
                }
                else
                    Utility.showMessage("Warning", "Enter driver name", "warning");
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
            this.Cursor = Cursors.Default;
        }
        private void AddDriver(DriverEntity DE)
        {
            if (new DriverRepository().AddDriver(DE) > 0)
                Utility.showMessage("Success", "Your record has been successfully saved.Navigate to list to view record", "success");
            else
                Utility.showMessage("Error", "Oops ! unable to save record. Check logs for detail or contact service provider", "error");
            lblID.Text = "0";
            bindDataGridView();
        }
        #region Grid Methods

        private void bindDataGridView()
        {
            try
            {
                DataTable drivers = GridRepository.GetData_Driver();
                dataGridView.SetPagedDataSource(drivers, bindingNavigator);
                if (drivers != null && drivers.Rows.Count > 0)
                {
                    dataGridView.Columns["ID"].Visible = false;
                    dataGridView.Columns["VehicleID"].Visible = false;
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
                txtDriverName.Text = selectedRow.Cells["DriverName"].Value.ToString();
                comboBoxVehicle.SelectedValue = int.Parse(selectedRow.Cells["VehicleID"].Value.ToString());
                comboBoxQualification.Text = selectedRow.Cells["Qualification"].Value.ToString();
                txtSalary.Text = selectedRow.Cells["Salary"].Value.ToString();
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
                        new DriverRepository().DeleteDriverByID(int.Parse(id));
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
