using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;

namespace AIBCafe3
{
    public partial class ProductGroup_Form : DevExpress.XtraEditors.XtraForm
    {
        public ProductGroup_Form()
        {
            this.AllowFormSkin = false;
            InitializeComponent();
        }
        private void ProductGroup_Form_Load(object sender, EventArgs e)
        {
            productGroupBindingSource.DataSource = Program.cafe.ProductGroups.OrderBy(p => p.DisplayOrder).Where(p => p.ProductGroupID != ClassInfo.ThoiGianID);
            Program.cafe.SavingChanges += new EventHandler(cafe_SavingChanges);
            simpleButton3.Enabled = false;
        }

        void cafe_SavingChanges(object sender, EventArgs e)
        {
            simpleButton3.Enabled = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Program.cafe.SaveChanges();
        }

        private void productGroupBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
           // var n =(IEnumerable<Product>) productGroupBindingSource.DataSource;
            e.NewObject = new ProductGroup()
            {
                ProductGroupID = Guid.NewGuid(),
                DisplayOrder =(short)(1+ Program.cafe.ProductGroups.Max(p=>p.DisplayOrder).Value),
                Report = false
            };
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (productGroupBindingSource.Position >= 0)
            {
                productGroupBindingSource.RemoveCurrent();
                Program.cafe.SaveChanges();
            }
        }

        private void ProductGroup_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();
            productGroupBindingSource.EndEdit();

            if (simpleButton3.Enabled)
            {
                var b = MessageBox.Show("Dữ liệu đã thay đổi bạn có muốn lưu không?", "Xác nhận?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (b == DialogResult.Yes)
                {
                    Program.cafe.SaveChanges();
                    Program.cafe.AcceptAllChanges();
                }
                else
                {
                    if (b == DialogResult.No)
                    {
                        Program.cafe.Refresh(System.Data.Objects.RefreshMode.StoreWins, Program.cafe.ProductGroups);
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }

            }
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            simpleButton3.Enabled = true;
        }
    }
}