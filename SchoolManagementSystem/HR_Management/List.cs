using DAL;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SchoolManagementSystem.HR_Management
{
    public partial class List : MetroForm
    {
        string ids { get; set; }
        public List()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                InitializeComponent();

                comboBoxDepartmentGrid.DataSource = new DepartmentRepository().GetALLDepartments();
                comboBoxDepartmentGrid.DisplayMember = "DepartmentName";
                comboBoxDepartmentGrid.ValueMember = "ID";
                comboBoxDepartmentGrid.SelectedIndexChanged += ApplyFilterOnRecord;

                comboBoxEmployeeTypeGrid.DataSource = new EmployeeTypeRepository().GetALLEmployeeTypes();
                comboBoxEmployeeTypeGrid.DisplayMember = "EmployeeType";
                comboBoxEmployeeTypeGrid.ValueMember = "ID";
                comboBoxEmployeeTypeGrid.SelectedIndexChanged += ApplyFilterOnRecord;


                string[] Qualification = new string[] { "", "Matric", "FA", "ICS", "FSC", "FSC eqvivalent Diploma", "BA", "BCS", "BSC", "BSC eqvivalent Diploma", "MA", "MCS", "MSC", "MSC eqvivalent Diploma", "pHD" };
                int[] ExperianceYears = new int[51];
                for (int i = 0; i <= 50; i++)
                    ExperianceYears[i] = i;

                comboBoxQualificationGrid.DataSource = Qualification;
                comboBoxMinExperianceGrid.DataSource = ExperianceYears;

                comboBoxQualificationGrid.SelectedIndexChanged += ApplyFilterOnRecord;
                comboBoxMinExperianceGrid.SelectedIndexChanged += ApplyFilterOnRecord;

                ApplyFilterOnRecord(null,new EventArgs());
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
            this.Cursor = Cursors.Default;
        }
        private void ApplyFilterOnRecord(object sender, EventArgs e)
        {
            bindDataGridView();
        }

        #region Grid Methods

        private void bindDataGridView()
        {
            try
            {
                int Exp = 0;
                if (comboBoxMinExperianceGrid.Text != "")
                    Exp = int.Parse(comboBoxMinExperianceGrid.SelectedValue.ToString());

                DataTable employees = GridRepository.GetData_Employee(int.Parse(comboBoxDepartmentGrid.SelectedValue.ToString()), int.Parse(comboBoxEmployeeTypeGrid.SelectedValue.ToString()), comboBoxQualificationGrid.Text, Exp);
                dataGridView.SetPagedDataSource(employees, bindingNavigator);
                if (employees != null && employees.Rows.Count > 0)
                {
                    dataGridView.Columns["ID"].Visible = false; dataGridView.Columns["FirstName"].Visible = false;
                    dataGridView.Columns["LastName"].Visible = false; dataGridView.Columns["DOB"].Visible = false;
                    dataGridView.Columns["BloodGroup"].Visible = false; dataGridView.Columns["Religion"].Visible = false;
                    dataGridView.Columns["Address"].Visible = false; dataGridView.Columns["EmergencyNo"].Visible = false;
                    dataGridView.Columns["Qualification"].Visible = false; dataGridView.Columns["Experiance"].Visible = false;
                    dataGridView.Columns["DepartmentID"].Visible = false; dataGridView.Columns["EmployeeTypeID"].Visible = false;
                    dataGridView.Columns["ImageName"].Visible = false; dataGridView.Columns["VehicleID"].Visible = false;

                    dataGridView.Columns["VehicleCharges"].Visible = false; dataGridView.Columns["ID1"].Visible = false;
                    dataGridView.Columns["DepartmentName"].Visible = false; dataGridView.Columns["ID2"].Visible = false;
                    dataGridView.Columns["EmployeeType"].Visible = false; dataGridView.Columns["ID3"].Visible = false;
                    dataGridView.Columns["VehicleType"].Visible = false; dataGridView.Columns["NoOfSeats"].Visible = false;
                    dataGridView.Columns["Route"].Visible = false; dataGridView.Columns["Gender"].Visible = false;
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
                if (new Register(int.Parse(selectedRow.Cells["ID"].Value.ToString())).ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    bindDataGridView();

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
                        new EmployeeRepository(new DBTransections()).DeleteEmployee(int.Parse(id));
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

        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroTabControl1.SelectedIndex != 0)
            {
                if (dataGridView != null && dataGridView.SelectedRows.Count == 1)
                {
                    try
                    {
                        DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                        txtFirstName.Text = selectedRow.Cells["FirstName"].Value.ToString();
                        txtLastName.Text = selectedRow.Cells["LastName"].Value.ToString();
                        txtDOB.Text = selectedRow.Cells["DOB"].Value.ToString();
                        txtGender.Text = selectedRow.Cells["Gender"].Value.ToString();
                        txtBloodGroup.Text = selectedRow.Cells["BloodGroup"].Value.ToString();
                        txtReligion.Text = selectedRow.Cells["Religion"].Value.ToString();
                        txtAddress.Text = selectedRow.Cells["Address"].Value.ToString();
                        txtContectNo.Text = selectedRow.Cells["ContactNo"].Value.ToString();
                        txtEmergencyNo.Text = selectedRow.Cells["EmergencyNo"].Value.ToString();

                        txtQualification.Text = selectedRow.Cells["Qualification"].Value.ToString();
                        txtExperianceYear.Text = (int.Parse(selectedRow.Cells["Experiance"].Value.ToString()) / 12).ToString();
                        txtExperianceMonth.Text = (int.Parse(selectedRow.Cells["Experiance"].Value.ToString()) % 12).ToString();
                        txtDepartment.Text = selectedRow.Cells["DepartmentName"].Value.ToString();
                        txtEmployeeType.Text = selectedRow.Cells["EmployeeType"].Value.ToString();
                        txtSalary.Text = selectedRow.Cells["Salary"].Value.ToString();

                        if (selectedRow.Cells["ImageName"].Value.ToString() != "")
                            pictureBoxEmployeeImage.Image = Image.FromFile(Application.StartupPath + "\\Images\\Employee\\" + selectedRow.Cells["ImageName"].Value.ToString() + ".png");

                        txtVehicleNo.Text = selectedRow.Cells["VehicleNo"].Value.ToString();
                        txtVehicletype.Text = selectedRow.Cells["VehicleType"].Value.ToString();
                        txtCharges.Text = "Rs " + selectedRow.Cells["VehicleCharges"].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                        Utility.showMessage("Exception", ex.Message, "error");
                    }
                }
                else
                {
                    Utility.showMessage("Warning", "Oops ! Can't nevigate to detail.Either list is empty or record is not selected.", "warning");
                    metroTabControl1.SelectedIndex = 0;
                }
            }
        }
    }
}
