using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using System.Collections;

namespace AIBCafe3
{
    public partial class Product_Form : DevExpress.XtraEditors.XtraForm
    {
        public Product_Form()
        {
            this.AllowFormSkin = false;
            InitializeComponent();
        }

        private void Product_Form_Load(object sender, EventArgs e)
        {
            
            this.Shown += new EventHandler(Product_Form_Shown); 
            
        }

        void Product_Form_Shown(object sender, EventArgs e)
        {
            if (Program.cafe.Units.ToList().Count <= 1 && Program.cafe.ProductGroups.ToList().Count <= 1)
            {
                MessageBox.Show("Chưa có nhóm thực đơn hoặc đơn vị tính, vui lòng thêm trước", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gridControl1.Enabled = false;
                groupControl1.Enabled = false;
                groupControl2.Enabled = false;
            }
            else
            {
                unitBindingSource.DataSource = Program.cafe.Units.Where(p => p.Id != ClassInfo.ThoiGianID);
                productGroupBindingSource.DataSource = Program.cafe.ProductGroups.OrderBy(p => p.DisplayOrder).Where(p => p.ProductGroupID != ClassInfo.ThoiGianID);
                productBindingSource.DataSource = Program.cafe.Products.OrderBy(p => p.DisplayOrder).Where(p => p.ProductID != ClassInfo.ThoiGianID);
                // Program.cafe.ObjectStateManager.ObjectStateManagerChanged += new CollectionChangeEventHandler(ObjectStateManager_ObjectStateManagerChanged);
                Program.cafe.SavingChanges += new EventHandler(cafe_SavingChanges);
                simpleButton3.Enabled = false;
            }
        }

        void cafe_SavingChanges(object sender, EventArgs e)
        {
            simpleButton3.Enabled = false;
        }

        void ObjectStateManager_ObjectStateManagerChanged(object sender, CollectionChangeEventArgs e)
        {
           
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();
            productBindingSource.EndEdit();

           var s = (IEnumerable<Product>)productBindingSource.DataSource;
            var n = s.Where(t => t.UnitID == null).ToList();
            if (n.Count>=1)
            {
                MessageBox.Show("Một số thực đơn chưa có đơn vị tính, Kiểm tra lại dữ liệu","Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Program.cafe.SaveChanges();
                Program.cafe.AcceptAllChanges();
            }
            
        }

        private void productBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new Product()
            {
                ProductID = Guid.NewGuid(),
                DisplayOrder =(short)( 1+ (Program.cafe.Products.Max(p=>p.DisplayOrder).Value)),
                Active = true,
                Price = 10000,
                Show = true,
                UnitID=Program.cafe.Units.Where(p => p.Id != ClassInfo.ThoiGianID).First().Id,
                ProductGroupID = Program.cafe.ProductGroups.Where(p => p.ProductGroupID != ClassInfo.ThoiGianID).First().ProductGroupID
            };
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (productBindingSource.Count>=1)
            {
                productBindingSource.RemoveCurrent();
                Program.cafe.SaveChanges();
            }
            
        }

        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
           // gridView1.EndDataUpdate();
            productBindingSource.EndEdit();
            simpleButton3.Enabled = true;
        }

        private void Product_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();
            productBindingSource.EndEdit();

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
                        Program.cafe.Refresh(System.Data.Objects.RefreshMode.StoreWins, Program.cafe.Products);
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
        }
    }
}