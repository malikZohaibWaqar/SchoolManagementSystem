using DAL;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SchoolManagementSystem.School_Management
{
    public partial class FeesSetting : MetroForm
    {
        string ids { get; set; }
        public FeesSetting()
        {
            InitializeComponent();
            bindDataGridView();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCatagoryName.Text != string.Empty && txtFees.Text != string.Empty)
                {
                    if (new System.Text.RegularExpressions.Regex("^[0-9A-Za-z ]+$").IsMatch(txtCatagoryName.Text))//.All(char.IsLetter))
                    {
                        FeesCatagoryEntity FCE = new FeesCatagoryEntity();
                        FCE.ID = int.Parse(lblID.Text);
                        FCE.FeeCatagory = txtCatagoryName.Text;
                        FCE.Fees = int.Parse(txtFees.Text);
                        if (new FeesCatagoryRepository().AddFeesCatagory(FCE) > 0)
                            Utility.showMessage("Success", "Your record has been successfully saved.Navigate to list to view record", "success");
                        else
                            Utility.showMessage("Error", "Oops ! unable to save record. Check logs for detail or contact service provider", "error");
                        lblID.Text = "0";
                        bindDataGridView();
                    }
                    else
                        Utility.showMessage("Warning", "Alphabets (Aa-Zz) and Numbers are allowed", "warning");

                }
                else
                    Utility.showMessage("Warning", "Enter category name & fees", "warning");
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }

        #region Grid Methods

        private void bindDataGridView()
        {
            try
            {
                List<FeesCatagoryEntity> feescategory = new FeesCatagoryRepository().GetALLFeesCatagories(true);
                dataGridView.SetPagedDataSource(Utility.ToDataTable(feescategory), bindingNavigator);

                if (feescategory != null && feescategory.Count > 0)
                    dataGridView.Columns["ID"].Visible = false;
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
                lblID.Text = selectedRow.Cells["ID"].Value.ToString();
                txtCatagoryName.Text = selectedRow.Cells["FeeCatagory"].Value.ToString();
                txtFees.Text = selectedRow.Cells["Fees"].Value.ToString();
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
                    bool confirm = false;
                    List<StudentEntity> entities = new StudentRepository().GetStudentsByFeesCategoryID(ids);
                    if (entities != null && entities.Count > 0)
                        if (new Component.confirmationBox("Student registered with this fees category will also be deleted.Still want to proceed?").ShowDialog() == DialogResult.Yes)
                            confirm = true;
                    if (confirm)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        foreach (StudentEntity entity in entities)
                        {
                            if (new StudentRepository().DeleteStudent(entity) > 0)
                            {
                                if (System.IO.File.Exists(Application.StartupPath + "\\Images\\Student\\" + entity.ImageName))
                                    System.IO.File.Delete(Application.StartupPath + "\\Images\\Student\\" + entity.ImageName);
                            }
                        }
                        foreach (string id in ids.Split(','))
                        {
                            new FeesCatagoryRepository().DeleteFeesCatagoryByID(int.Parse(id));
                        }
                        bindDataGridView();
                        this.Cursor = Cursors.Default;
                        Utility.showMessage("Success", "Record deleted successfully", "success");
                    }
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

    }
}
