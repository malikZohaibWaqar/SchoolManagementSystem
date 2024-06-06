using DAL;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SchoolManagementSystem.Student_Management
{
    public partial class List : MetroForm
    {
        string ids { get; set; }
        public List()
        {
            try
            {
                InitializeComponent();

                comboBoxClassGrid.DataSource = new ClassRepository().GetALLClasses();
                comboBoxClassGrid.DisplayMember = "ClassName";
                comboBoxClassGrid.ValueMember = "ID";
                comboBoxClassGrid.SelectedIndexChanged += ApplyFilterOnRecord;

                comboBoxFeesCatagoryGrid.DataSource = new FeesCatagoryRepository().GetALLFeesCatagories();
                comboBoxFeesCatagoryGrid.DisplayMember = "FeeCatagory";
                comboBoxFeesCatagoryGrid.ValueMember = "ID";
                comboBoxFeesCatagoryGrid.SelectedIndexChanged += ApplyFilterOnRecord;

                comboBoxGenderGrid.Items.Add("");
                comboBoxGenderGrid.Items.Add("Male");
                comboBoxGenderGrid.Items.Add("Female");
                comboBoxGenderGrid.SelectedIndexChanged += ApplyFilterOnRecord;

                bindDataGridView();

                if (!(Utility.verifyAccess("btnStudentRegistration", false) && Utility.verifyAccess("MIStudentRegistration", false)))
                    dataGridView.CellMouseClick -= dataGridView_CellMouseClick;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private void ApplyFilterOnRecord(object sender, EventArgs e)
        {
            bindDataGridView();
        }

        #region Grid Methods

        private void bindDataGridView()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataTable dtStudents = GridRepository.GetData_Student(int.Parse(comboBoxClassGrid.SelectedValue.ToString()), comboBoxGenderGrid.Text, int.Parse(comboBoxFeesCatagoryGrid.SelectedValue.ToString()));
                dataGridView.SetPagedDataSource(dtStudents, bindingNavigator);
                if (dtStudents != null && dtStudents.Rows.Count > 0)
                {
                    dataGridView.Columns["FirstName"].Visible = false; dataGridView.Columns["LastName"].Visible = false;
                    dataGridView.Columns["ID"].Visible = false; dataGridView.Columns["RollNo"].Visible = false;
                    dataGridView.Columns["DOB"].Visible = false; dataGridView.Columns["Gender"].Visible = false;
                    dataGridView.Columns["BloodGroup"].Visible = false; dataGridView.Columns["Religion"].Visible = false;
                    dataGridView.Columns["Address"].Visible = false; dataGridView.Columns["EmergencyNo"].Visible = false;
                    dataGridView.Columns["FatherName"].Visible = false; dataGridView.Columns["FatherContact"].Visible = false;
                    dataGridView.Columns["MotherName"].Visible = false; dataGridView.Columns["GuardianName"].Visible = false;
                    dataGridView.Columns["RelationWithGuardian"].Visible = false; dataGridView.Columns["Class"].Visible = false;
                    dataGridView.Columns["FeesCatagory"].Visible = false; dataGridView.Columns["ImageName"].Visible = false;
                    dataGridView.Columns["VehicleID"].Visible = false; dataGridView.Columns["VehicleCharges"].Visible = false;
                    dataGridView.Columns["ID1"].Visible = false; dataGridView.Columns["ClassName"].Visible = false;
                    dataGridView.Columns["ID2"].Visible = false; dataGridView.Columns["Fees"].Visible = false;
                    dataGridView.Columns["ID3"].Visible = false; dataGridView.Columns["VehicleType"].Visible = false;
                    dataGridView.Columns["NoOfSeats"].Visible = false; dataGridView.Columns["Route"].Visible = false;
                    dataGridView.Columns["FeeCatagory"].Visible = false; dataGridView.Columns["isPassOut"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
            this.Cursor = Cursors.Default;
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
                        new StudentRepository().DeleteStudent(int.Parse(id));
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

        private void metroTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroTabControl.SelectedIndex != 0)
            {
                if (dataGridView != null && dataGridView.SelectedRows.Count == 1)
                {
                    try
                    {
                        DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                        lblID.Text = selectedRow.Cells["ID"].Value.ToString();

                        txtRollNo.Text = selectedRow.Cells["RollNo"].Value.ToString();
                        txtFirstName.Text = selectedRow.Cells["FirstName"].Value.ToString();
                        txtLastName.Text = selectedRow.Cells["LastName"].Value.ToString();
                        txtDOB.Text = DateTime.Parse(selectedRow.Cells["DOB"].Value.ToString()).ToString("dd MMMM yyyy");
                        txtGender.Text = selectedRow.Cells["Gender"].Value.ToString();
                        txtBloodGroup.Text = selectedRow.Cells["BloodGroup"].Value.ToString();
                        txtReligion.Text = selectedRow.Cells["Religion"].Value.ToString();
                        txtAddress.Text = selectedRow.Cells["Address"].Value.ToString();
                        txtContectNo.Text = selectedRow.Cells["ContactNo"].Value.ToString();
                        txtEmergencyNo.Text = selectedRow.Cells["EmergencyNo"].Value.ToString();

                        txtFatherName.Text = selectedRow.Cells["FatherName"].Value.ToString();
                        txtFatherContact.Text = selectedRow.Cells["FatherContact"].Value.ToString();
                        txtMotherName.Text = selectedRow.Cells["MotherName"].Value.ToString();
                        txtGuardianName.Text = selectedRow.Cells["GuardianName"].Value.ToString();
                        txtRelationWithGuardian.Text = selectedRow.Cells["RelationWithGuardian"].Value.ToString();

                        if (selectedRow.Cells["GuardianName"].Value.ToString() != null && selectedRow.Cells["GuardianName"].Value.ToString() != "")
                            checkBoxParentsDeseased.Checked = true;

                        txtClass.Text = selectedRow.Cells["ClassName"].Value.ToString();
                        txtFees.Text = selectedRow.Cells["FeeCatagory"].Value.ToString();
                        if (selectedRow.Cells["ImageName"].Value.ToString() != "" && selectedRow.Cells["ImageName"].Value.ToString() != string.Empty)
                            pictureBoxStudentImage.Image = Image.FromFile(Application.StartupPath + "\\Images\\Student\\" + selectedRow.Cells["ImageName"].Value.ToString() + ".png");

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
                    metroTabControl.SelectedIndex = 0;
                }
            }
        }
    }
}
