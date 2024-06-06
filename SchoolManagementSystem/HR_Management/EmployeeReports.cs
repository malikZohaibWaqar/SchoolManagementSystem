using DAL;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Windows.Forms;

namespace SchoolManagementSystem.HR_Management
{
    public partial class EmployeeReports : MetroForm
    {
        private Reports.rptEmployee rptEmployee { get; set; }
        public EmployeeReports()
        {
            InitializeComponent();
            comboBoxDepartmentGrid.DataSource = new DepartmentRepository().GetALLDepartments();
            comboBoxDepartmentGrid.DisplayMember = "DepartmentName";
            comboBoxDepartmentGrid.ValueMember = "ID";
            
            comboBoxEmployeeTypeGrid.DataSource = new EmployeeTypeRepository().GetALLEmployeeTypes();
            comboBoxEmployeeTypeGrid.DisplayMember = "EmployeeType";
            comboBoxEmployeeTypeGrid.ValueMember = "ID";
            
            string[] Qualification = new string[] { "", "Matric", "FA", "ICS", "FSC", "FSC eqvivalent Diploma", "BA", "BCS", "BSC", "BSC eqvivalent Diploma", "MA", "MCS", "MSC", "MSC eqvivalent Diploma", "pHD" };
            int[] ExperianceYears = new int[51];
            for (int i = 0; i <= 50; i++)
                ExperianceYears[i] = i;

            comboBoxQualificationGrid.DataSource = Qualification;
            comboBoxMinExperianceGrid.DataSource = ExperianceYears;
        }
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                int Exp = 0;
                if (comboBoxMinExperianceGrid.Text != "")
                    Exp = int.Parse(comboBoxMinExperianceGrid.SelectedValue.ToString());

                DataSet rptDS = new DataSet();
                DataTable dt = ReportRepository.GetSchoolInfo();
                dt.TableName = "SchoolInfo";
                rptDS.Tables.Add(dt);

                dt = new DataTable();
                dt = ReportRepository.GetEmployeeReportData(int.Parse(comboBoxDepartmentGrid.SelectedValue.ToString()), comboBoxQualificationGrid.Text, int.Parse(comboBoxEmployeeTypeGrid.SelectedValue.ToString()), int.Parse(comboBoxMinExperianceGrid.Text));
                dt.TableName = "dtEmployee";
                rptDS.Tables.Add(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if(rptEmployee == null)
                        rptEmployee = new Reports.rptEmployee();

                    rptEmployee.SetDataSource(rptDS);
                    crystalReportViewer.ReportSource = rptEmployee;
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
        private void EmployeeReports_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rptEmployee != null)
            {
                rptEmployee.Close();
                rptEmployee.Dispose();
            }
            crystalReportViewer.Dispose();
        }
    }
}
