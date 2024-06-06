using DAL;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SchoolManagementSystem.Transport_Management
{
    public partial class RegisterTransport : MetroForm
    {
        string ids { get; set; }
        public RegisterTransport()
        {
            InitializeComponent();
            string[] VehicleType = new string[] { "Coach", "Bus", "Hi-ace", "Rikshaw" };
            comboBoxVehicleType.DataSource = VehicleType;
            bindDataGridView();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (txtVehicleNo.Text != string.Empty && txtNoOfSeats.Text != string.Empty && txtRoute.Text != string.Empty)
                {
                    VehicleEntity VE = new VehicleEntity();
                    VE.ID = int.Parse(lblID.Text);
                    VE.VehicleNo = txtVehicleNo.Text;
                    VE.VehicleType = comboBoxVehicleType.SelectedValue.ToString();
                    VE.NoOfSeats = int.Parse(txtNoOfSeats.Text);
                    VE.Route = txtRoute.Text;

                    if (new VehicleRepository().AddVehicle(VE) > 0)
                        Utility.showMessage("Success", "Your record has been successfully saved.Navigate to list to view record", "success");
                    else
                        Utility.showMessage("Error", "Oops ! unable to save record. Check logs for detail or contact service provider", "error");
                    lblID.Text = "0";
                    bindDataGridView();
                }
                else
                    Utility.showMessage("Warning", "Fill all fields", "warning");
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
            this.Cursor = Cursors.Default;
        }

        #region Grid Methods

        private void bindDataGridView()
        {
            try
            {
                List<VehicleEntity> vehicles = new VehicleRepository().GetALLVehicles(true);
                dataGridView.SetPagedDataSource(Utility.ToDataTable(vehicles), bindingNavigator);
                if (vehicles != null && vehicles.Count > 0)
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
                txtVehicleNo.Text = selectedRow.Cells["VehicleNo"].Value.ToString();
                comboBoxVehicleType.Text = selectedRow.Cells["VehicleType"].Value.ToString();
                txtNoOfSeats.Text = selectedRow.Cells["NoOfSeats"].Value.ToString();
                txtRoute.Text = selectedRow.Cells["Route"].Value.ToString();
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
                this.Cursor = Cursors.WaitCursor;
                if (ids.Length > 0)
                {
                    if (new Component.confirmationBox("Students and Employees availing this transport will be deallocated.Still want to proceed?").ShowDialog() == DialogResult.Yes)
                    {                        
                        string studentIDs = string.Empty;
                        System.Data.DataTable dt =  new StudentRepository().GetStudentsByVehicleID(ids);
                        if(dt != null && dt.Rows.Count > 0)
                        {
                            foreach (System.Data.DataRow row in dt.Rows)
                            studentIDs += row["ID"].ToString() + ",";
                        }

                        if (studentIDs != string.Empty)
                            studentIDs = studentIDs.Remove(studentIDs.Length - 1);

                        string EmpIDs = string.Empty;
                        
                        dt = new EmployeeRepository().GetEmployeeByVehicleID(ids);
                        if(dt != null && dt.Rows.Count > 0)
                        {
                            foreach (System.Data.DataRow row in dt.Rows)
                            EmpIDs += row["ID"].ToString() + ",";
                        }

                        if (EmpIDs != string.Empty)
                            EmpIDs = EmpIDs.Remove(EmpIDs.Length - 1);
                        bool result = false;
                        if (studentIDs != string.Empty || EmpIDs != string.Empty)
                            result = new VehicleRepository().DeleteVehicleAllocation(studentIDs, EmpIDs);
                        else
                            result = true;
                        if (result)
                        {
                            if (new VehicleRepository().DeleteVehicleByID(ids) > 0)
                            {
                                Utility.showMessage("Success", "Record deleted successfully", "success");
                                bindDataGridView();
                            }
                            else
                                Utility.showMessage("Warning", "Error occured while deleting record.Check logs for detail or contact service provider", "warning");
                            
                        }
                        else
                            Utility.showMessage("Warning", "Error occured while deleting record.Check logs for detail or contact service provider", "warning");
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
            this.Cursor = Cursors.Default;
        }

        #endregion
    }
}
