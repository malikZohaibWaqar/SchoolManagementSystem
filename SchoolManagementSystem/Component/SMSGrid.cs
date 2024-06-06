using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    class SMSGrid : MetroFramework.Controls.MetroGrid
    {
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }
        public int _pageSize = 6;
        BindingSource bs;
        BindingList<DataTable> tables;
        public void SetPagedDataSource(DataTable dataTable, BindingNavigator bnav)
        {
            bs = new BindingSource();
            tables = new BindingList<DataTable>();
            DataTable dt = null;
            int counter = 1;
            foreach (DataRow dr in dataTable.Rows)
            {
                if (counter == 1)
                {
                    dt = dataTable.Clone();
                    tables.Add(dt);
                }
                dt.Rows.Add(dr.ItemArray);
                if (PageSize < ++counter)
                {
                    counter = 1;
                }
            }
            bnav.BindingSource = bs;
            bs.DataSource = tables;
            bs.PositionChanged += bs_PositionChanged;
            bs_PositionChanged(bs, EventArgs.Empty);
        }
        void bs_PositionChanged(object sender, EventArgs e)
        {
            this.DataSource = tables.Count > 0 ? tables[bs.Position] : null ;
        }
    }
}
