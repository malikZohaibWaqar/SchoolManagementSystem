using DAL;
using MetroFramework.Forms;
using System;
using System.Data;
using System.Windows.Forms;

namespace SchoolManagementSystem.Student_Management
{
    public partial class FeesCollection : MetroForm
    {
        string ids { get; set; }
        public FeesCollection()
        {
            InitializeComponent();
            try
            {
                comboBoxClass.DataSource = new ClassRepository().GetALLClasses(true);
                comboBoxClass.DisplayMember = "ClassName";
                comboBoxClass.ValueMember = "ID";

                comboBoxFeesCatagory.DataSource = new FeesCatagoryRepository().GetALLFeesCatagories();
                comboBoxFeesCatagory.DisplayMember = "FeeCatagory";
                comboBoxFeesCatagory.ValueMember = "Fees";

                comboBoxClassGrid.DataSource = new ClassRepository().GetALLClasses();
                comboBoxClassGrid.DisplayMember = "ClassName";
                comboBoxClassGrid.ValueMember = "ID";

                comboBoxClass.SelectedIndexChanged += comboBoxClass_SelectedIndexChanged;
            }
            catch(Exception ex)
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
                if (comboBoxStudent.Text == string.Empty)
                {
                    Utility.showMessage("Warning", "No student exist to collect fees", "warning");
                }
                else
                {
                    FeesCollectionEntity FCE = new FeesCollectionEntity();
                    FCE.ClassID = int.Parse(comboBoxClass.SelectedValue.ToString());
                    FCE.StudentID = int.Parse(comboBoxStudent.SelectedValue.ToString());
                    FCE.Fees = int.Parse(comboBoxFeesCatagory.SelectedValue.ToString());
                    FCE.Fine = (txtFine.Text == string.Empty ? 0 : int.Parse(txtFine.Text));
                    FCE.Date = DateTime.Parse(txtMonth.Text);
                    FCE.ID = int.Parse(lblID.Text);
                    if (new FeesCollectionRepository().AddFeesCollection(FCE) > 0)
                        Utility.showMessage("Success", "Student fees has been collected successfully.Navigate to list to view record", "success");
                    else
                        Utility.showMessage("Error", "Oops ! unable to save record. Check logs for detail or contact service provider", "error");
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

        #region Grid Methods

        private void bindDataGridView()
        {
            try
            {
                DataTable feesCollection = GridRepository.GetData_FeesCollection(int.Parse(comboBoxClassGrid.SelectedValue.ToString()),DateTime.Parse(txtMonthGrid.Value.ToString()));
                dataGridView.SetPagedDataSource(feesCollection, bindingNavigator);
                if (feesCollection != null && feesCollection.Rows.Count > 0)
                {
                    dataGridView.Columns["ID"].Visible = false;
                    dataGridView.Columns["StudentID"].Visible = false;
                    dataGridView.Columns["ClassID"].Visible = false;
                }
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
                comboBoxClass.SelectedValue = int.Parse(selectedRow.Cells["ClassID"].Value.ToString());
                comboBoxStudent.SelectedValue = int.Parse(selectedRow.Cells["StudentID"].Value.ToString());
                comboBoxFeesCatagory.SelectedValue = int.Parse(selectedRow.Cells["Fees"].Value.ToString());
                txtFine.Text = selectedRow.Cells["Fine"].Value.ToString();
                txtMonth.Text = txtMonthGrid.Text;
                metroTabControl.SelectedIndex = 0;
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
                        new FeesCollectionRepository().DeleteFeesCollectionByID(int.Parse(id));
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
            if(metroTabControl.SelectedIndex == 1)
                bindDataGridView();
        }
        private void comboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxStudent.DataSource = new StudentRepository().GetALLStudents(int.Parse(comboBoxClass.SelectedValue.ToString()));
            comboBoxStudent.DisplayMember = "FirstName";
            comboBoxStudent.ValueMember = "ID";
        }
        private void ParamGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindDataGridView();
        }
    }
}
