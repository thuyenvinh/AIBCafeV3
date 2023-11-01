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
    public partial class Assembly_form : DevExpress.XtraEditors.XtraForm
    {
        public Assembly_form()
        {
            InitializeComponent();
        }

        private void quantitativeBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new Quantitative { Id=Guid.NewGuid(), Quantity = 2, UnitID=Guid.NewGuid(), UnitID_Parent=Guid.NewGuid() };
        }

        private void Assembly_form_Load(object sender, EventArgs e)
        {
            simpleButtonChapNhan.Enabled = false;
            unitBindingSource.DataSource = Program.cafe.Units.Where(p=>p.Id != ClassInfo.ThoiGianID);
            unitBindingSource1.DataSource = Program.cafe.Units.Where(p => p.Id != ClassInfo.ThoiGianID);
            quantitativeBindingSource.DataSource = Program.cafe.Quantitatives;

            productBindingSource.DataSource = Program.cafe.Products.Where(p => p.ProductID != ClassInfo.ThoiGianID);
            productBindingSource1.DataSource = Program.cafe.Products.Where(p => p.ProductID != ClassInfo.ThoiGianID);
            assemblyBindingSource.DataSource = Program.cafe.Assemblies;
            Program.cafe.SavingChanges += new EventHandler(cafe_SavingChanges);
        }

        void cafe_SavingChanges(object sender, EventArgs e)
        {
            simpleButtonChapNhan.Enabled = false;
        }

        private void simpleButtonChapNhan_Click(object sender, EventArgs e)
        {
            Program.cafe.SaveChanges();
        }

        private void simpleButtonDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void assemblyBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new AIBCafe3.Assembly { Id = Guid.NewGuid(), Quantity = 1, Description = "" };
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage1")
            {
                if (quantitativeBindingSource.CurrencyManager.Position>=0)
                {
                    quantitativeBindingSource.RemoveCurrent();
                    Program.cafe.SaveChanges();
                }
            }
            else
            {
                if (assemblyBindingSource.CurrencyManager.Position >= 0)
                {
                    assemblyBindingSource.RemoveCurrent();
                    Program.cafe.SaveChanges();
                }
            }
        }

        private void Assembly_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            gridView2.CloseEditor();
            gridView2.UpdateCurrentRow();
            
            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();
            assemblyBindingSource.EndEdit();
            quantitativeBindingSource.EndEdit();

            if (simpleButtonChapNhan.Enabled)
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
                        Program.cafe.Refresh(System.Data.Objects.RefreshMode.StoreWins, Program.cafe.Assemblies);
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
            simpleButtonChapNhan.Enabled = true;
        }
    }
}