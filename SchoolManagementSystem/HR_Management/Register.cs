using DAL;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SchoolManagementSystem.HR_Management
{
    public partial class Register : MetroForm
    {
        public Register(int EmployeeID)
        {
            InitializeComponent();
            try
            {
                string[] Religions = new string[] { "Islam", "Hinduism", "Christianity" };
                string[] BloodGroups = new string[] { "A+", "O+", "B+", "AB+", "A-", "O-", "B-", "AB-" };
                string[] Genders = new string[] { "Male", "Female" };
                string[] Qualification = new string[] { "Matric", "FA", "ICS", "FSC", "FSC eqvivalent Diploma", "BA", "BCS", "BSC", "BSC eqvivalent Diploma", "MA", "MCS", "MSC", "MSC eqvivalent Diploma", "pHD" };
                int[] ExperianceYears = new int[51];
                int[] ExperiancMonths = new int[12];

                for (int i = 0; i <= 50; i++)
                    ExperianceYears[i] = i;

                for (int i = 0; i <= 11; i++)
                    ExperiancMonths[i] = i;

                comboBoxReligion.DataSource = Religions;
                comboBoxBloodGroup.DataSource = BloodGroups;
                comboBoxGender.DataSource = Genders;
                comboBoxQualification.DataSource = Qualification;
                comboBoxExperianceYears.DataSource = ExperianceYears;
                comboBoxExperianceMonths.DataSource = ExperiancMonths;

                comboBoxDepartment.DataSource = new DepartmentRepository().GetALLDepartments();
                comboBoxDepartment.DisplayMember = "DepartmentName";
                comboBoxDepartment.ValueMember = "ID";

                comboBoxEmployeeType.DataSource = new EmployeeTypeRepository().GetALLEmployeeTypes();
                comboBoxEmployeeType.DisplayMember = "EmployeeType";
                comboBoxEmployeeType.ValueMember = "ID";

                List<VehicleEntity> vehicles = new VehicleRepository().GetALLVehicles(true,true);
                comboBoxVehicle.DataSource = vehicles;
                comboBoxVehicle.DisplayMember = "VehicleNo";
                comboBoxVehicle.ValueMember = "ID";

                if (EmployeeID > 0)
                {
                    EmployeeEntity EE = new EmployeeRepository().GetEmployeeByID(EmployeeID);
                    lblID.Text = EE.ID.ToString();
                    txtFirstName.Text = EE.FirstName;
                    txtLastName.Text = EE.LastName;
                    txtDOB.Text = EE.DOB.ToString();
                    comboBoxGender.Text = EE.Gender;
                    comboBoxBloodGroup.Text = EE.BloodGroup;
                    comboBoxReligion.Text = EE.Religion;
                    txtAddress.Text = EE.Address;
                    txtContectNo.Text = EE.ContactNo;
                    txtEmergencyNo.Text = EE.EmergencyNo;

                    comboBoxQualification.Text = EE.Qualification;
                    comboBoxExperianceYears.Text = (EE.Experiance / 12).ToString();
                    comboBoxExperianceMonths.Text = (EE.Experiance % 12).ToString();
                    comboBoxDepartment.SelectedValue = EE.DepartmentID;
                    comboBoxEmployeeType.SelectedValue = EE.EmployeeTypeID;
                    txtSalary.Text = EE.Salary.ToString();
                    comboBoxVehicle.SelectedValue = EE.VehicleID;
                    numVehicleCharges.Value = EE.VehicleCharges;
                    if (EE.ImageName != null)
                        pictureBoxEmployeeImage.Image = Image.FromFile(Application.StartupPath + "\\Images\\Employee\\" + EE.ImageName + ".png");
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (ValidateResgisterForm())
                {
                    EmployeeEntity EE = new DAL.EmployeeEntity();
                    EE.ID = int.Parse(lblID.Text);
                    EE.FirstName = txtFirstName.Text;
                    EE.LastName = txtLastName.Text;
                    EE.DOB = DateTime.Parse(txtDOB.Text);
                    EE.Gender = comboBoxGender.Text;
                    EE.BloodGroup = comboBoxBloodGroup.Text;
                    EE.Religion = comboBoxReligion.Text;
                    EE.Address = txtAddress.Text;
                    EE.ContactNo = txtContectNo.Text;
                    EE.EmergencyNo = txtEmergencyNo.Text;
                    EE.Qualification = comboBoxQualification.SelectedValue.ToString();
                    EE.Experiance = (int.Parse(comboBoxExperianceYears.SelectedValue.ToString()) * 12) + int.Parse(comboBoxExperianceMonths.SelectedValue.ToString());
                    EE.DepartmentID = int.Parse(comboBoxDepartment.SelectedValue.ToString());
                    EE.EmployeeTypeID = int.Parse(comboBoxEmployeeType.SelectedValue.ToString());
                    EE.Salary = int.Parse(txtSalary.Text);
                    EE.VehicleID = int.Parse(comboBoxVehicle.SelectedValue.ToString());
                    EE.VehicleCharges = int.Parse(numVehicleCharges.Value.ToString());

                    if (pictureBoxEmployeeImage.Image != null)
                    {
                        string EmployeeImageName = Utility.GenerateUniqueNameForImage();
                        Image ThumbnailImg = pictureBoxEmployeeImage.Image.GetThumbnailImage(131, 105, null, new IntPtr());
                        ThumbnailImg.Save(Application.StartupPath + "\\Images\\Employee\\" + EmployeeImageName + ".png");
                        EE.ImageName = EmployeeImageName;
                    }

                    if (new VehicleRepository().GetVehicleCapacity(EE.VehicleID) <= new EmployeeRepository().GetNumOfEmployeeByVehiceID(EE.VehicleID))
                    {
                        if (new Component.confirmationBox("All seats are occupied in selected vehicle. Do you still want to proceed").ShowDialog() == DialogResult.Yes)
                            AddEmployee(EE);
                    }
                    else
                        AddEmployee(EE);
                    
                    if (lblID.Text != "0")
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    lblID.Text = "0";
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
            this.Cursor = Cursors.Default;
        }

        private void AddEmployee(EmployeeEntity EE)
        {
            int res = new EmployeeRepository().EnrollAndUpdateEmployee(EE);
            if (res > 0)
                Utility.showMessage("Success", "Your record has been successfully saved.Navigate to list to view record", "success");
            if(res == -2)
                Utility.showMessage("Duplication", "Oops ! Employee with same name,contact and employee type already exists in this department", "error");
            if(res == -1)
                Utility.showMessage("Error", "Oops ! unable to save record. Check logs for detail or contact service provider", "error");
        }
        private bool ValidateResgisterForm()
        {
            try
            {
                if (txtFirstName.Text == string.Empty || txtLastName.Text == string.Empty
                    || txtAddress.Text == string.Empty || txtContectNo.Text == string.Empty
                    || txtEmergencyNo.Text == string.Empty || txtSalary.Text == string.Empty)
                {
                    Utility.showMessage("Warning", "Fill all fields to proceed", "warning");
                    return false;
                }
                else
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(txtFirstName.Text, @"^[A-Za-z ]+$") || !System.Text.RegularExpressions.Regex.IsMatch(txtLastName.Text, @"^[A-Za-z ]+$"))
                    {
                        Utility.showMessage("Warning", "Name field must contain alphabets (Aa-Zz)", "warning");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
                return false;
            }
            return true;
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                if (fileDialogEmployeeImage.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxEmployeeImage.Image = Image.FromFile(fileDialogEmployeeImage.FileName);
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
