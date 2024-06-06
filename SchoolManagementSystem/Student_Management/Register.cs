using DAL;
using MetroFramework.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SchoolManagementSystem.Student_Management
{
    public partial class Register : MetroForm
    {
        private string rollNo { get; set; }
        private bool flag { get; set; }
        public Register(int StudentID)
        {
            try
            {
                InitializeComponent();

                string[] Religions = new string[] { "Islam", "Hinduism", "Christianity" };
                string[] BloodGroups = new string[] { "A+", "O+", "B+", "AB+", "A-", "O-", "B-", "AB-" };
                string[] Genders = new string[] { "Male", "Female" };
                string[] Relations = new string[] { "Brother", "Sister", "Uncle", "Cousin" };

                comboBoxReligion.DataSource = Religions;
                comboBoxBloodGroup.DataSource = BloodGroups;
                comboBoxGender.DataSource = Genders;
                comboBoxRelation.DataSource = Relations;

                comboBoxClass.DataSource = new ClassRepository().GetALLClasses(true);
                comboBoxClass.DisplayMember = "ClassName";
                comboBoxClass.ValueMember = "ID";

                comboBoxFeesCatagory.DataSource = new FeesCatagoryRepository().GetALLFeesCatagories(true);
                comboBoxFeesCatagory.DisplayMember = "FeeCatagory";
                comboBoxFeesCatagory.ValueMember = "ID";

                List<VehicleEntity> vehicles = new VehicleRepository().GetALLVehicles(true,true);
                comboBoxVehicle.DataSource = vehicles;
                comboBoxVehicle.DisplayMember = "VehicleNo";
                comboBoxVehicle.ValueMember = "ID";

                if (StudentID == 0)
                {
                    rollNo = (new StudentRepository().GetMaxIDOfStudent() + 1) + "-" + (DateTime.Now.Month < 6 ? "s" : "f") + "-" + DateTime.Now.Year;
                    txtRollNo.Text = rollNo;
                }
                else
                {
                    StudentEntity SE = new StudentRepository().GetStudentByID(StudentID);
                    lblID.Text = SE.ID.ToString();
                    txtRollNo.Text = SE.RollNo;
                    txtFirstName.Text = SE.FirstName;
                    txtLastName.Text = SE.LastName;
                    txtDOB.Text = SE.DOB.ToString();
                    comboBoxGender.Text = SE.Gender;
                    comboBoxBloodGroup.Text = SE.BloodGroup;
                    comboBoxReligion.Text = SE.Religion;
                    txtAddress.Text = SE.Address;
                    txtContectNo.Text = SE.ContactNo;
                    txtEmergencyNo.Text = SE.EmergencyNo;

                    txtFatherName.Text = SE.FatherName;
                    txtFatherContact.Text = SE.FatherContact;
                    txtMotherName.Text = SE.MotherName;

                    if (SE.GuardianName != null)
                    {
                        checkBoxParentsDeseased.Checked = true;
                        txtGuardianName.Text = SE.GuardianName;
                        comboBoxRelation.Text = SE.RelationWithGuardian;
                    }
                    if (SE.ImageName != null)
                        pictureBoxStudentImage.Image = Image.FromFile(Application.StartupPath + "\\Images\\Student\\" + SE.ImageName + ".png");

                    comboBoxClass.SelectedValue = SE.Class;
                    comboBoxFeesCatagory.SelectedValue = SE.FeesCatagory;
                    comboBoxVehicle.SelectedValue = SE.VehicleID;
                    numVehicleCharges.Value = SE.VehicleCharges;
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private void Register_Shown(object sender, EventArgs e)
        {
            if (comboBoxClass.Items.Count == 0 || comboBoxFeesCatagory.Items.Count == 0)
            {
                Utility.showMessage("Data Check", "Student can't be registered. Verify class and fees category is added in system before registering student", "warning");
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (ValidateForm())
                {
                    StudentEntity student = new DAL.StudentEntity();
                    student.ID = int.Parse(lblID.Text);
                    student.FirstName = txtFirstName.Text;
                    student.LastName = txtLastName.Text;
                    student.DOB = DateTime.Parse(txtDOB.Text);
                    student.Gender = comboBoxGender.Text;
                    student.BloodGroup = comboBoxBloodGroup.Text;
                    student.Religion = comboBoxReligion.Text;
                    student.Address = txtAddress.Text;
                    student.ContactNo = txtContectNo.Text;
                    student.EmergencyNo = txtEmergencyNo.Text;
                    student.FatherName = txtFatherName.Text;
                    student.FatherContact = txtFatherContact.Text;
                    student.MotherName = txtMotherName.Text;
                    if (checkBoxParentsDeseased.Checked)
                    {
                        student.GuardianName = txtGuardianName.Text;
                        student.RelationWithGuardian = comboBoxRelation.Text;
                    }
                    student.Class = int.Parse(comboBoxClass.SelectedValue.ToString());
                    student.FeesCatagory = int.Parse(comboBoxFeesCatagory.SelectedValue.ToString());
                    student.RollNo = txtRollNo.Text;
                    student.VehicleID = (comboBoxVehicle.SelectedValue == null ? 0 : int.Parse(comboBoxVehicle.SelectedValue.ToString()));
                    student.VehicleCharges = int.Parse(numVehicleCharges.Value.ToString());
                    student.isPassOut = false;
                    if (pictureBoxStudentImage.Image != null)
                    {
                        string StudentImageName = Utility.GenerateUniqueNameForImage();
                        Image ThumbnailImg = pictureBoxStudentImage.Image.GetThumbnailImage(131, 105, null, new IntPtr());
                        ThumbnailImg.Save(Application.StartupPath + "\\Images\\Student\\" + StudentImageName + ".png");
                        student.ImageName = StudentImageName;
                    }

                    if (new VehicleRepository().GetVehicleCapacity(student.VehicleID) <= new StudentRepository().GetNumOfStudentByVehiceID(student.VehicleID) && student.VehicleID != 0)
                    {
                        if (new Component.confirmationBox("All seats are occupied in selected vehicle. Do you still want to proceed").ShowDialog() == DialogResult.Yes)
                            AddStudent(student);
                    }
                    else
                        AddStudent(student);
                    
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
        private void AddStudent(StudentEntity student)
        {
            int res = new StudentRepository().EnrollAndUpdateStudent(student);
            if (res > 0)
                Utility.showMessage("Success", "Your record has been successfully saved.Navigate to list to view record", "success");
            if(res == -2)
                Utility.showMessage("Duplication", "Oops ! Student with same name,father name and mother name already enrolled in this class", "error");
            if(res == -1)
                Utility.showMessage("Error", "Oops ! unable to save record. Check logs for detail or contact service provider", "error");
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtContectNo.Text = string.Empty;
                txtEmergencyNo.Text = string.Empty;
                txtFatherName.Text = string.Empty;
                txtFatherContact.Text = string.Empty;
                txtMotherName.Text = string.Empty;

                comboBoxGender.SelectedIndex = 0;
                comboBoxBloodGroup.SelectedIndex = 0;
                comboBoxReligion.SelectedIndex = 0;
                comboBoxClass.SelectedIndex = 0;
                comboBoxFeesCatagory.SelectedIndex = 0;

                checkBoxParentsDeseased.Checked = false;
                txtGuardianName.Text = string.Empty;
                comboBoxRelation.SelectedIndex = 0;

                txtRollNo.Text = rollNo;
                txtRollNo.ReadOnly = true;

                if (lblID.Text != "0")
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
                if (txtFirstName.Text == string.Empty || txtLastName.Text == string.Empty
                    || txtAddress.Text == string.Empty || txtContectNo.Text == string.Empty
                    || txtEmergencyNo.Text == string.Empty || txtFatherName.Text == string.Empty
                    || txtFatherContact.Text == string.Empty || txtMotherName.Text == string.Empty)
                {
                    Utility.showMessage("Warning", "Fill all fields", "warning");
                    return false;
                }
                else
                {
                    if (checkBoxParentsDeseased.Checked && txtGuardianName.Text == string.Empty)
                    {
                        Utility.showMessage("Warning", "If parents deseased then guardian name is required", "warning");
                        return false;
                    }
                    else
                    {
                        if (!txtContectNo.Text.All(char.IsNumber) || !txtEmergencyNo.Text.All(char.IsNumber)
                            || !txtFatherContact.Text.All(char.IsNumber))
                        {
                            Utility.showMessage("Warning", "Number fields must contain only digits", "warning");
                            return false;
                        }
                        else
                        {
                            if (!Regex.IsMatch(txtFirstName.Text, @"^[A-Za-z ]+$") || !Regex.IsMatch(txtLastName.Text, @"^[A-Za-z ]+$")
                                || !Regex.IsMatch(txtFatherName.Text, @"^[A-Za-z ]+$") || !Regex.IsMatch(txtMotherName.Text, @"^[A-Za-z ]+$")
                                || (checkBoxParentsDeseased.Checked && !Regex.IsMatch(txtGuardianName.Text, @"^[A-Za-z ]+$")))
                            {
                                Utility.showMessage("Warning", "Name fields must contain only alphabets", "warning");
                                return false;
                            }
                        }
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
                if (fileDialogStudentImage.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxStudentImage.Image = Image.FromFile(fileDialogStudentImage.FileName);
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
