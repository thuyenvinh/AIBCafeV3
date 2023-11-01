using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;
using System.IO;
using AIBCafe3;

namespace AIBCafe3
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            this.AllowFormSkin = false;
            InitializeComponent();

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Product_Form frm = new Product_Form();

            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ProductGroup_Form frm = new ProductGroup_Form();
            frm.ShowDialog();
        }

        private void barStaticItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Process.Start("http://aibip.com");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            new LoginForm().ShowDialog();
            Cursor.Current = Cursors.Default;
            ribbonControl1.Minimized = true;
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoginForm frm = new LoginForm();
            frm.ShowDialog();
        }

        private void ButtonTinhTien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Bill_AddForm frm = new Bill_AddForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ButtonDanhSachHoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Bill_Form frm = new Bill_Form();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Item_Form frm = new Item_Form();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Bill_Form frm = new Bill_Form();
            frm.MdiParent = this;
            frm.Show();
        }

        private void Nhap_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Inward_AddForm frm = new Inward_AddForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void DSNhap_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Inward_Form frm = new Inward_Form();
            frm.MdiParent = this;
            frm.Show();
        }

        private void NguoiDung_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Employee_Form frm = new Employee_Form();
            frm.MdiParent = this;
            frm.Show();
        }

        private void QLKhach_barButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Bill_AddForm frm = new Bill_AddForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            //XtraForm1 frm = new XtraForm1();
            //frm.ShowDialog();
            import_Form frm = new import_Form();
            frm.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}