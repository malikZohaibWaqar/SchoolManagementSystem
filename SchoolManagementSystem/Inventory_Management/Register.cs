using DAL;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SchoolManagementSystem.Inventory_Management
{
    public partial class Register : MetroForm
    {
        string ids { get; set; }
        public Register()
        {
            InitializeComponent();
            bindDataGridView_CM();
            comboBoxProductCategoryGrid.SelectedIndexChanged -= comboBoxProductCategoryGrid_SelectedIndexChanged;
            initializeCatComboboxes();
            comboBoxProductCategoryGrid.SelectedIndexChanged += comboBoxProductCategoryGrid_SelectedIndexChanged;
        }

        private void metroTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroTabControl.SelectedIndex == 0)
                bindDataGridView_CM();
            else
                bindDataGridView_PM();
        }

        #region Category Management Methods
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCategoryName.Text != string.Empty)
                {
                    ProductCategoryEntity PC = new ProductCategoryEntity();
                    PC.ID = int.Parse(lblIDCat.Text);
                    PC.ProductCategory = txtCategoryName.Text;
                    if (new ProductCategoryRepository().AddProductCategory(PC) > 0)
                        Utility.showMessage("Success", "Your record has been successfully saved.Navigate to list to view record", "success");
                    else
                        Utility.showMessage("Error", "Oops ! unable to save record. Check logs for detail or contact service provider", "error");
                    lblIDCat.Text = "0";
                    bindDataGridView_CM();
                    initializeCatComboboxes();
                }
                else
                    Utility.showMessage("Warning", "Enter category name", "warning"); 
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }

        #region Grid Methods

        private void bindDataGridView_CM()
        {
            try
            {
                List<ProductCategoryEntity> productCategories = new ProductCategoryRepository().GetALLProductCategories(true);
                toolStripLabel1.Text = "Total Record(s) : " + productCategories.Count;
                dataGridView.SetPagedDataSource(Utility.ToDataTable(productCategories), bindingNavigatorCM);
                if (productCategories != null && productCategories.Count > 0)
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
                        contextMenugridCM.Items[0].Enabled = false;
                    else
                        contextMenugridCM.Items[0].Enabled = true;

                    ids = string.Empty;
                    foreach (DataGridViewRow row in dataGridView.SelectedRows)
                        ids += row.Cells["ID"].Value.ToString() + ",";
                    if (ids.Length > 0)
                    {
                        ids = ids.Remove(ids.Length - 1);
                        contextMenugridCM.Show(Cursor.Position);
                    }
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private void contextMenugridCM_edit_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                lblIDCat.Text = selectedRow.Cells["ID"].Value.ToString();
                txtCategoryName.Text = selectedRow.Cells["ProductCategory"].Value.ToString();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private void contextMenugridCM_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ids.Length > 0)
                {
                    foreach (string id in ids.Split(','))
                    {
                        new ProductCategoryRepository().DeleteProductCategoryByID(int.Parse(id));
                    }
                    bindDataGridView_CM();
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

        #endregion

        #region Product Management Methods

        private void comboBoxProductCategoryGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindDataGridView_PM();
        }
        private void initializeCatComboboxes()
        {
            comboBoxProductCategory.DataSource = new ProductCategoryRepository().GetALLProductCategories();
            comboBoxProductCategory.DisplayMember = "ProductCategory";
            comboBoxProductCategory.ValueMember = "ID";

            comboBoxProductCategoryGrid.DataSource = new ProductCategoryRepository().GetALLProductCategories();
            comboBoxProductCategoryGrid.DisplayMember = "ProductCategory";
            comboBoxProductCategoryGrid.ValueMember = "ID";
        }
        private void BtnSave_PM_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (txtProductName.Text != string.Empty || txtQuantity.Text != string.Empty || txtUnitPrice.Text != string.Empty)
                {
                    ProductEntity P = new ProductEntity();
                    P.ID = int.Parse(lblIDPM.Text);
                    P.ProductCategory = int.Parse(comboBoxProductCategory.SelectedValue.ToString());
                    P.ProductName = txtProductName.Text;
                    P.Quantity = int.Parse(txtQuantity.Text);
                    P.UnitPrice = int.Parse(txtUnitPrice.Text);
                    if (new ProductRepository().AddProduct(P) > 0)
                        Utility.showMessage("Success", "Your record has been successfully saved.Navigate to list to view record", "success");
                    else
                        Utility.showMessage("Error", "Oops ! unable to save record. Check logs for detail or contact service provider", "error");
                    lblIDPM.Text = "0";
                    bindDataGridView_PM();
                }
                else
                    Utility.showMessage("Warning", "Fill all fields", "warning"); 
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
            this.Cursor = Cursors.Default;
        }

        #region Grid Methods

        private void bindDataGridView_PM()
        {
            try
            {
                List<ProductEntity> products = new ProductRepository().GetALLProducts(int.Parse(comboBoxProductCategoryGrid.SelectedValue.ToString()));
                dataGridViewPM.SetPagedDataSource(Utility.ToDataTable(products), bindingNavigatorPM);
                if (products != null && products.Count > 0)
                {
                    dataGridViewPM.Columns["ID"].Visible = false;
                    dataGridViewPM.Columns["ProductCategory"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private void dataGridViewPM_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right && e.RowIndex > -1)
                {
                    if (dataGridViewPM.SelectedRows.Count > 1)
                        contextMenugridPM.Items[0].Enabled = false;
                    else
                        contextMenugridPM.Items[0].Enabled = true;

                    ids = string.Empty;
                    foreach (DataGridViewRow row in dataGridViewPM.SelectedRows)
                        ids += row.Cells["ID"].Value.ToString() + ",";
                    if (ids.Length > 0)
                    {
                        ids = ids.Remove(ids.Length - 1);
                        contextMenugridPM.Show(Cursor.Position);
                    }
                }
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private void contextMenugridPM_edit_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow selectedRow = dataGridViewPM.SelectedRows[0];
                lblIDPM.Text = selectedRow.Cells["ID"].Value.ToString();
                comboBoxProductCategory.SelectedValue = int.Parse(selectedRow.Cells["ProductCategory"].Value.ToString());
                txtProductName.Text = selectedRow.Cells["ProductName"].Value.ToString();
                txtQuantity.Text = selectedRow.Cells["Quantity"].Value.ToString();
                txtUnitPrice.Text = selectedRow.Cells["UnitPrice"].Value.ToString();
            }
            catch (Exception ex)
            {
                new ErrrorLoggerRepository().WriteToErrorLogger(ex);
                Utility.showMessage("Exception", ex.Message, "error");
            }
        }
        private void contextMenugridPM_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ids.Length > 0)
                {
                    foreach (string id in ids.Split(','))
                    {
                        new ProductRepository().DeleteProductByID(int.Parse(id));
                    }
                    bindDataGridView_CM();
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

        #endregion

    }
}
