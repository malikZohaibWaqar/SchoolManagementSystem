using DAL;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Windows.Forms;

namespace SchoolManagementSystem.Inventory_Management
{
    public partial class InventoryReports : MetroForm
    {
        private Reports.rptInventry rptInventory { get; set; }
        public InventoryReports()
        {
            InitializeComponent();
            comboBoxProductCategory.DataSource = new ProductCategoryRepository().GetALLProductCategories();
            comboBoxProductCategory.DisplayMember = "ProductCategory";
            comboBoxProductCategory.ValueMember = "ID";
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
                dt = ReportRepository.GetInventoryReportData(int.Parse(comboBoxProductCategory.SelectedValue.ToString()));
                dt.TableName = "dtInventry";
                rptDS.Tables.Add(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (rptInventory == null)
                        rptInventory = new Reports.rptInventry();

                    rptInventory.SetDataSource(rptDS);
                    crystalReportViewer.ReportSource = rptInventory;
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
        private void InventoryReports_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rptInventory != null)
            {
                rptInventory.Close();
                rptInventory.Dispose();
            }
            crystalReportViewer.Dispose();
        }
    }
}
