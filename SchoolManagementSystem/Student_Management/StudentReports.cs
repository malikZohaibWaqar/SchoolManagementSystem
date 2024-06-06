using DAL;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Windows.Forms;

namespace SchoolManagementSystem.Student_Management
{
    public partial class StudentReports : MetroForm
    {
        private Reports.rptStudent rptStudent { get; set; }
        private Reports.rptStudentDetail rptStudentDetail { get; set; }
        public StudentReports()
        {
            InitializeComponent();
            comboBoxClassGrid.DataSource = new ClassRepository().GetALLClasses();
            comboBoxClassGrid.DisplayMember = "ClassName";
            comboBoxClassGrid.ValueMember = "ID";

            comboBoxFeesCatagoryGrid.DataSource = new FeesCatagoryRepository().GetALLFeesCatagories();
            comboBoxFeesCatagoryGrid.DisplayMember = "FeeCatagory";
            comboBoxFeesCatagoryGrid.ValueMember = "ID";

            comboBoxGenderGrid.Items.Add("");
            comboBoxGenderGrid.Items.Add("Male");
            comboBoxGenderGrid.Items.Add("Female");
        }
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet rptDS = new DataSet();
                DataTable dt = ReportRepository.GetSchoolInfo();
                dt.TableName = "SchoolInfo";
                rptDS.Tables.Add(dt);

                dt = new DataTable();
                dt = ReportRepository.GetStudentReportData(int.Parse(comboBoxClassGrid.SelectedValue.ToString()), comboBoxGenderGrid.Text, int.Parse(comboBoxFeesCatagoryGrid.SelectedValue.ToString()));
                dt.TableName = "dtStudent";
                rptDS.Tables.Add(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (((Button)sender).Name == "btnGenerateReport")
                    {
                        if (rptStudent == null)
                            rptStudent = new Reports.rptStudent();

                        rptStudent.SetDataSource(rptDS);
                        crystalReportViewer.ReportSource = rptStudent;
                    }
                    else
                    {
                        if (rptStudentDetail == null)
                            rptStudentDetail = new Reports.rptStudentDetail();

                        rptStudentDetail.SetDataSource(rptDS);
                        crystalReportViewer.ReportSource = rptStudentDetail;
                    }
                }
                else
                    Utility.showMessage("Record not found", "Oops ! No record found related to provided parameters", "warning");
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private void StudentReports_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rptStudent != null)
            {
                rptStudent.Close();
                rptStudent.Dispose();
            }
            if (rptStudentDetail != null)
            {
                rptStudentDetail.Close();
                rptStudentDetail.Dispose();
            }
            crystalReportViewer.Dispose();
        }
    }
}
