using DAL;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Windows.Forms;

namespace SchoolManagementSystem.Transport_Management
{
    public partial class TransportReports : MetroForm
    {
        private Reports.rptTransport rptTransport { get; set; }
        public TransportReports()
        {
            InitializeComponent();
            comboBoxVehicleType.DataSource = new VehicleRepository().GetALLVehicles();
            comboBoxVehicleType.DisplayMember = "VehicleNo";
            comboBoxVehicleType.ValueMember = "ID";
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
                dt = ReportRepository.GetTransportReportData(int.Parse(comboBoxVehicleType.SelectedValue.ToString()));
                dt.TableName = "dtTransport";
                rptDS.Tables.Add(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (rptTransport == null)
                        rptTransport = new Reports.rptTransport();

                    rptTransport.SetDataSource(rptDS);
                    crystalReportViewer.ReportSource = rptTransport;
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
        private void TransportReports_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rptTransport != null)
            {
                rptTransport.Close();
                rptTransport.Dispose();
            }
            crystalReportViewer.Dispose();
        }
    }
}
