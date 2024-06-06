using DAL;
using MetroFramework.Forms;
using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SchoolManagementSystem.Student_Management
{
    public partial class PromoteStudent : MetroForm
    {
        public PromoteStudent()
        {
            try
            {
                InitializeComponent();

                List<ClassEntity> CurrentClasse = new ClassRepository().GetALLClasses();
                comboBoxCurrentClass.DataSource = CurrentClasse;
                comboBoxCurrentClass.DisplayMember = "ClassName";
                comboBoxCurrentClass.ValueMember = "ClassName";
                comboBoxCurrentClass.SelectedIndexChanged += new EventHandler(LoadStudents);

                List<ClassEntity> PromotedClasse = new ClassRepository().GetALLClasses(true);
                comboBoxPromoteClass.DataSource = PromotedClasse;
                comboBoxPromoteClass.DisplayMember = "ClassName";
                comboBoxPromoteClass.ValueMember = "ClassName";

                LoadGrid();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private void LoadStudents(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            List<StudentEntity> SE = new StudentRepository().GetALLStudents(int.Parse(comboBoxCurrentClass.SelectedValue.ToString()));
            if (SE.Count > 0)
            {
                panelStudentList.Controls.Clear();
                int xsize = 208; int ysize = 23; int xgap = 6;
                int initialgap = 44;
                int xcount = 1; int ycount = 1;
                for (int i = 0; i < SE.Count; i++)
                {
                    //CheckBox cb = new CheckBox();
                    MetroFramework.Controls.MetroCheckBox cb = new MetroFramework.Controls.MetroCheckBox();
                    cb.FontWeight = MetroFramework.MetroCheckBoxWeight.Regular;
                    cb.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
                    cb.Cursor = Cursors.Hand;
                    if (xcount == 1)
                        cb.Location = new Point(44, ysize * ycount);
                    else
                        cb.Location = new Point(xsize * (xcount - 1) + xgap * (xcount - 1) + initialgap, ysize * ycount);

                    xcount++;
                    cb.Size = new Size(208, 23);
                    cb.Text = SE[i].FirstName + " " + SE[i].LastName;
                    cb.Name = SE[i].ID.ToString();
                    panelStudentList.Controls.Add(cb);
                    if (cb.Location.X == 472)
                    {
                        xcount = 1; ycount++;
                    }
                }
            }
            else
            {
                panelStudentList.Controls.Clear();
                Label lbl = new Label();
                lbl.Font = new Font("Candara", 12);
                lbl.ForeColor = Color.Red;
                lbl.Text = "No student exists in selected class";
                lbl.Size = new Size(400, 30);
                lbl.Location = new Point(44, 23);
                panelStudentList.Controls.Add(lbl);
            }

        }
        private void btnPromoteAll_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (new StudentRepository().PromoteStudentByClass(comboBoxCurrentClass.SelectedValue.ToString(), comboBoxPromoteClass.SelectedValue.ToString()) > 0)
                    Utility.showMessage("Success", "Students have been promoted successfully", "success");
                else
                    Utility.showMessage("Error", "Oops ! unable to save record. Check logs for detail or contact service provider", "error");
                LoadGrid();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private void btnPromoteSelected_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                var checkedCheckBox = panelStudentList.Controls.OfType<CheckBox>().Where(c => c.Checked).OrderBy(c => c.Text).Select(c => c.Name);
                var JoinedStudentIDs = String.Join(",", checkedCheckBox);
                if (JoinedStudentIDs != "")
                {
                    if (new StudentRepository().PromoteStudentByID(JoinedStudentIDs, comboBoxPromoteClass.SelectedValue.ToString()) > 0)
                        Utility.showMessage("Success", "Students have been promoted successfully", "success");
                    else
                        Utility.showMessage("Error", "Oops ! unable to save record. Check logs for detail or contact service provider", "error");
                    LoadGrid();
                }
                else
                    Utility.showMessage("Warning", "Select student to promote", "warning");
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
            this.Cursor = Cursors.Default;
        }

        private void btnPassout_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                var checkedCheckBox = panelStudentList.Controls.OfType<CheckBox>().Where(c => c.Checked).OrderBy(c => c.Text).Select(c => c.Name);
                var JoinedStudentIDs = String.Join(",", checkedCheckBox);
                if (JoinedStudentIDs != "")
                {
                    if (new StudentRepository().PassOutStudentByID(JoinedStudentIDs) > 0)
                        Utility.showMessage("Success", "Students have been passes out successfully", "success");
                    else
                        Utility.showMessage("Error", "Oops ! unable to save record. Check logs for detail or contact service provider", "error");
                    LoadGrid();
                }
                else
                    Utility.showMessage("Warning", "Select student to promote", "warning");
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
            this.Cursor = Cursors.Default;
        }
    }
}
