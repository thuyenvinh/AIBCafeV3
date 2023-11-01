using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AIBCafe3
{
    public partial class Bill_Form : DevExpress.XtraEditors.XtraForm
    {
        public Bill_Form()
        {
            this.AllowFormSkin = false;
            InitializeComponent();
        }
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DateTime dt1 = (DateTime)dateEdit1.DateTime;
            DateTime dt2 = (DateTime)dateEdit2.DateTime;
            billBindingSource.DataSource = (from p in Program.cafe.Bills
                                           where ((p.Date >= dt1)&& (p.DateEnd<=dt2))
                                            select p);
        }

        private void Bill_Form_Load(object sender, EventArgs e)
        {
            employeeBindingSource.DataSource = Program.cafe.Employees;
            dateEdit1.DateTime = DateTime.Now;
            dateEdit2.DateTime = DateTime.Now;
            itemBindingSource.DataSource = Program.cafe.Items;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (e.Clicks == 2)
            {
                if (e.RowHandle >= 0)
                {
                    var p = billBindingSource.Current as Bill;
                    Rpt_BillForm frm = new Rpt_BillForm(p.BillID, null); 
                    frm.ShowDialog();
                }
            }
        }
    }
}