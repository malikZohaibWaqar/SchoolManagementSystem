using DAL;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SchoolManagementSystem.School_Management
{
    public partial class InstituteExpense : MetroForm
    {
        string ids { get; set; }
        public InstituteExpense()
        {
            InitializeComponent();

            comboBoxVehicle.DataSource = new VehicleRepository().GetALLVehicles(true);
            comboBoxVehicle.DisplayMember = "VehicleNo";
            comboBoxVehicle.ValueMember = "ID";
            bindDataGridView();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDescription.Text == string.Empty)
                    Utility.showMessage("Warning","Write description about expense to proceed", "warning");
                else
                {
                    ExpensesEntity ee = new ExpensesEntity();
                    ee.ID = int.Parse(lblID.Text);
                    ee.BillingMonth = DateTime.Parse(txtDate.Value.ToString());
                    ee.BuildingRent = double.Parse(numBuildingRent.Value.ToString());
                    ee.ElectricityBill = double.Parse(numElectricityBill.Value.ToString());
                    ee.GasBill = double.Parse(numGasBill.Value.ToString());
                    ee.Misc = double.Parse(numMisc.Value.ToString());
                    ee.Vehicle = int.Parse(comboBoxVehicle.SelectedValue.ToString());
                    ee.VehicleExpense = double.Parse(numVehicleExpense.Value.ToString());
                    ee.Description = txtDescription.Text;

                    if (new ExpensesRepository().AddExpenses(ee) > 0)
                        Utility.showMessage("Success", "Your institute expenses has been successfully saved", "success");
                    else
                        Utility.showMessage("Error", "Oops ! unable to save record. Check logs for detail or contact service provider", "error");
                    lblID.Text = "0";
                    bindDataGridView();
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }

        #region Grid Methods

        private void bindDataGridView()
        {
            try
            {
                List<ExpensesEntity> ee = new ExpensesRepository().GetALLExpenses(DateTime.Parse(txtDateGrid.Value.ToString()));
                dataGridView.SetPagedDataSource(Utility.ToDataTable(ee), bindingNavigator);

                if (ee != null && ee.Count > 0)
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
                txtDateGrid.Text = selectedRow.Cells["BillingMonth"].Value.ToString();
                numBuildingRent.Value = decimal.Parse(selectedRow.Cells["BuildingRent"].Value.ToString());
                numElectricityBill.Value = decimal.Parse(selectedRow.Cells["ElectricityBill"].Value.ToString());
                numGasBill.Value = decimal.Parse(selectedRow.Cells["GasBill"].Value.ToString());
                numMisc.Value = decimal.Parse(selectedRow.Cells["Misc"].Value.ToString());
                comboBoxVehicle.SelectedText = selectedRow.Cells["Vehicle"].Value.ToString();
                numVehicleExpense.Value = decimal.Parse(selectedRow.Cells["VehicleExpense"].Value.ToString());
                txtDescription.Text = selectedRow.Cells["Description"].Value.ToString();
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
                        new ExpensesRepository().DeleteExpensesByID(int.Parse(id));
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
