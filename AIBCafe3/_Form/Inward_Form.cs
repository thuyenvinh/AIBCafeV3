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
    public partial class Inward_Form : DevExpress.XtraEditors.XtraForm
    {
        public Inward_Form()
        {
            this.AllowFormSkin = false;
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Tim();
        }
        void Tim()
        {
            if (dateEdit1.Text.Trim() != "" || dateEdit1.Text.Trim() != "")
            {
                DateTime dt1 = (DateTime)dateEdit1.DateTime;
                DateTime dt2 = (DateTime)dateEdit2.DateTime;
                
                    var b=(
                    from p in Program.cafe.Inwards
                    where ((p.Date <= dt2) & (p.Date > dt1))
                    select p);
               // Program.cafe.Refresh(System.Data.Objects.RefreshMode.ClientWins, b);
                inwardBindingSource.DataSource = b;
            }
        }
        private void Inward_Form_Load(object sender, EventArgs e)
        {
            employeeBindingSource.DataSource = Program.cafe.Employees;
            dateEdit1.DateTime = DateTime.Now;
            dateEdit2.DateTime = DateTime.Now;
        }

        private void simpleButton_Xoa_Click(object sender, EventArgs e)
        {
            if (inwardBindingSource.Position >= 0)
            {
                if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Xác nhận?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    var a = inwardBindingSource.Current as Inward;
                    var b = Program.cafe.InwardDetails.Where(p => p.InwardID == a.InwardID);
                    if (b != null)
                    {
                        foreach (var item in b.ToList())
                        {
                            Program.cafe.InwardDetails.DeleteObject(item);
                        }
                        Program.cafe.SaveChanges();
                    }
                    inwardBindingSource.RemoveCurrent();
                    Program.cafe.SaveChanges();
                    Tim();
                }
            }
        }

        private void simpleButton_Dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (e.Clicks == 2)
            {
                if (e.RowHandle >= 0)
                {
                    var p = inwardBindingSource.Current as Inward;
                    Inward_AddForm frm = new Inward_AddForm(p.InwardID);
                    frm.ShowDialog();
                }
            }
        }
    }
}