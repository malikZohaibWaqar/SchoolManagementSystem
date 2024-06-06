using DAL;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Windows.Forms;

namespace SchoolManagementSystem.School_Management
{
    public partial class PLSReports : MetroForm
    {
        private Reports.rptPLS rptPLS { get; set; }
        public PLSReports()
        {
            InitializeComponent();
        }
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet rptDS = new DataSet();
                DataTable dt = ReportRepository.GetSchoolInfo();
                dt.TableName = "SchoolInfo";
                rptDS.Tables.Add(dt);

                DataSet plsDS = ReportRepository.GetPLSReportData(DateTime.Parse(txtDate.Text));
                if (plsDS != null && plsDS.Tables.Count > 0)
                {
                    DataTable plsDT = new DataTable("dtPL");
                    plsDT.Columns.Add("Fees", typeof(Int32));
                    plsDT.Columns.Add("Fine", typeof(Int32));
                    plsDT.Columns.Add("EmployeeSalary", typeof(Int32));
                    plsDT.Columns.Add("DriverSalary", typeof(Int32));
                    plsDT.Columns.Add("BuildingRent", typeof(Int32));
                    plsDT.Columns.Add("ElectricityBill", typeof(Int32));
                    plsDT.Columns.Add("GasBill", typeof(Int32));
                    plsDT.Columns.Add("Misc", typeof(Int32));
                    plsDT.Columns.Add("BillingMonth", typeof(DateTime));
                    plsDT.Columns.Add("TotalExpenseVehicle", typeof(Int32));

                    DataRow dr = plsDT.NewRow();
                    if (plsDS.Tables["PL1"] != null && plsDS.Tables["PL1"].Rows.Count > 0)
                    {
                        dr["Fees"] = (plsDS.Tables["PL1"].Rows[0]["Fees"].ToString() == string.Empty ? 0 : int.Parse(plsDS.Tables["PL1"].Rows[0]["Fees"].ToString()));
                        dr["Fine"] = (plsDS.Tables["PL1"].Rows[0]["Fine"].ToString() == string.Empty ? 0 : int.Parse(plsDS.Tables["PL1"].Rows[0]["Fine"].ToString()));
                    }
                    
                    if (plsDS.Tables["PL2"] != null && plsDS.Tables["PL2"].Rows.Count > 0)
                        dr["EmployeeSalary"] = (plsDS.Tables["PL2"].Rows[0]["EmployeeSalary"].ToString() == string.Empty ? 0 : int.Parse(plsDS.Tables["PL2"].Rows[0]["EmployeeSalary"].ToString()));
                    
                    if (plsDS.Tables["PL3"] != null && plsDS.Tables["PL3"].Rows.Count > 0)
                        dr["DriverSalary"] = (plsDS.Tables["PL3"].Rows[0]["DriverSalary"].ToString() == string.Empty ? 0 : int.Parse(plsDS.Tables["PL3"].Rows[0]["DriverSalary"].ToString()));

                    if (plsDS.Tables["PL4"] != null && plsDS.Tables["PL4"].Rows.Count > 0)
                    {
                        dr["BuildingRent"] = (plsDS.Tables["PL4"].Rows[0]["BuildingRent"].ToString() == string.Empty ? 0 : int.Parse(plsDS.Tables["PL4"].Rows[0]["BuildingRent"].ToString()));
                        dr["ElectricityBill"] = (plsDS.Tables["PL4"].Rows[0]["ElectricityBill"].ToString() == string.Empty ? 0 : int.Parse(plsDS.Tables["PL4"].Rows[0]["ElectricityBill"].ToString()));
                        dr["GasBill"] = (plsDS.Tables["PL4"].Rows[0]["GasBill"].ToString() == string.Empty ? 0 : int.Parse(plsDS.Tables["PL4"].Rows[0]["GasBill"].ToString()));
                        dr["Misc"] = (plsDS.Tables["PL4"].Rows[0]["Misc"].ToString() == string.Empty ? 0 : int.Parse(plsDS.Tables["PL4"].Rows[0]["Misc"].ToString()));
                        dr["BillingMonth"] = DateTime.Parse(txtDate.Text);
                    }
                    dr["TotalExpenseVehicle"] = (plsDS.Tables["dtExpenseVehicle"].Compute("Sum(VehicleExpense)", string.Empty).ToString() == string.Empty ? 0 : int.Parse(plsDS.Tables["dtExpenseVehicle"].Compute("Sum(VehicleExpense)", string.Empty).ToString()));
                    plsDT.Rows.Add(dr);
                    rptDS.Tables.Add(plsDT);

                    if (rptPLS == null)
                        rptPLS = new Reports.rptPLS();

                    rptPLS.SetDataSource(rptDS);
                    rptPLS.Subreports["rptVehicleExpense.rpt"].SetDataSource(plsDS.Tables["dtExpenseVehicle"].Copy());
                    crystalReportViewer.ReportSource = rptPLS;
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
        private void PLSReports_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rptPLS != null)
            {
                rptPLS.Close();
                rptPLS.Dispose();
            }
            crystalReportViewer.Dispose();
        }
    }
}
