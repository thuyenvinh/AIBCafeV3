using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System.Collections;
using System.Data.Objects;

namespace AIBCafe3
{//Chưa cập nhật giá cho hóa đơn nhập từ hóa đơn ch tiết
    public partial class Inward_AddForm : DevExpress.XtraEditors.XtraForm
    {
        private Guid? _MaNhap = null;
        Guid a;
        public Inward_AddForm()
        {
            this.AllowFormSkin = false;
            InitializeComponent();
        }
        public Inward_AddForm(Guid? MaNhap)
        {
            this.AllowFormSkin = false;
            InitializeComponent();
            _MaNhap = MaNhap;
            a = (Guid)_MaNhap;

        }
        private void Inward_AddForm_Load(object sender, EventArgs e)
        {
            employeeBindingSource.DataSource = Program.cafe.Employees;
            unitBindingSource.DataSource = Program.cafe.Units.Where(p => p.Id != ClassInfo.ThoiGianID);
            productBindingSource.DataSource = Program.cafe.Products.OrderBy(p => p.DisplayOrder).Where(p => p.ProductID != ClassInfo.ThoiGianID);
            if (_MaNhap != null)
            {
                inwardBindingSource.DataSource = Program.cafe.Inwards.Where(p => p.InwardID == _MaNhap);
                inwardDetailsBindingSource.DataSource =
                    (
                        from p in Program.cafe.InwardDetails
                        where p.InwardID == _MaNhap
                        join t in Program.cafe.Products on p.ProductID equals t.ProductID
                        select new
                        {
                            ProductID = p.ProductID,
                            InwardID = p.InwardID,
                            InwardDetailID = p.InwardDetailID,
                            Price = p.Price,
                            Quantity = p.Quantity,
                            UnitID = t.UnitID
                        }
                    );
            }
            else
            {
                gridControl1.Enabled = false;
            }
        }

        void CapNhat()
        {
            //var t = inwardDetailsBindingSource.GetEnumerator();

            inwardBindingSource.EndEdit();
            inwardDetailsBindingSource.EndEdit();

            Program.cafe.SaveChanges();
            inwardBindingSource.DataSource = Program.cafe.Inwards.Where(p => p.InwardID == a);
            inwardDetailsBindingSource.DataSource = Program.cafe.InwardDetails.Where(p => p.InwardID == a);
        }
        private void simpleButton_ChapNhan_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            CapNhat();
            Cursor.Current = Cursors.Default;
            this.Close();
        }

        Inward nhap = new Inward();

        private void simpleButton_TaoPhieu_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            simpleButton_TaoPhieu.Enabled = false;
            employeeBindingSource.DataSource = Program.cafe.Employees;//.Where(p => p);
            a = Guid.NewGuid();
            gridControl1.Enabled = true;
            nhap.Amount = 0;
            nhap.Date = DateTime.Now;
            nhap.Description = "Nhập kho";
            nhap.EmployeesID = ClassInfo.NhanVien;
            nhap.InwardID = a;
            Program.cafe.AddToInwards(nhap);
            Program.cafe.SaveChanges();
            var load = Program.cafe.Inwards.Where(p => p.InwardID == a);
            Program.cafe.Refresh(System.Data.Objects.RefreshMode.ClientWins, load);
            inwardBindingSource.DataSource = load;
            Cursor.Current = Cursors.Default;
        }

        private void inwardBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            e.NewObject = new Inward { Amount = 0, Description = "Nhập kho", InwardID = a, Date = DateTime.Now, EmployeesID = ClassInfo.NhanVien };
            Cursor.Current = Cursors.Default;
        }

        private void inwardDetailsBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            e.NewObject = new InwardDetail { InwardDetailID = Guid.NewGuid(), InwardID = a, Quantity = 1, Price = 10000 };
            Cursor.Current = Cursors.Default;
        }
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                CapNhat();
                decimal tong = 0;
                var n = Program.cafe.BillDetails.Where(p => p.BillID == a);
                Program.cafe.Refresh(System.Data.Objects.RefreshMode.ClientWins, n);
                var t = (IEnumerable<InwardDetail>)inwardDetailsBindingSource.DataSource;
                foreach (var item in t)
                {
                    tong += (item.Price.Value) * (item.Quantity.Value);
                }
                spinEdit1.Value = tong;

            }
            catch (Exception)
            {
                Cursor.Current = Cursors.Default;
            }
            Cursor.Current = Cursors.Default;
        }

        private void inwardDetailsBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //var details = (List<Data.InvoiceDetail>)invoiceDetailBindingSource.DataSource;

            // MessageBox.Show(n.ToList().Count.ToString);
            //tTotalNoVAT.Value = details.Sum(p => p.Quantity * p.Price);
            //tVAT.Value = details.Sum(p => p.Quantity * p.Price * p.PercentVAT / 100);
            //tTotal.Value = tTotalNoVAT.Value + tVAT.Value;
        }

        private void inwardDetailsBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {

        }

        private void inwardDetailsBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            //var n = (System.Data.Objects.ObjectQuery<AIBCafe3.Inward>)inwardDetailsBindingSource.DataSource;
        }

        private void Inward_AddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //var a=  Program.cafe.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Added);
            var list = Program.cafe.InwardDetails.Where(p => p.InwardID == a).ToList();
            if (a != Guid.Empty)
            {
                if (list.Count <= 0)
                {
                    if (MessageBox.Show("Bạn đã tạo phiếu nhưng chưa nhập dữ liệu. Bạn có muốn xóa đi không?", "Xác nhận?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Program.cafe.DeleteObject(Program.cafe.Inwards.Where(p => p.InwardID == a).First());
                        Program.cafe.SaveChanges();
                    }
                }
            }

        }

        private void simpleButton_InPhieu_Click(object sender, EventArgs e)
        {
            new frmRptNhapkho(a).ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            if (inwardDetailsBindingSource.CurrencyManager.Position >= 0)
            {
                inwardDetailsBindingSource.RemoveCurrent();
                Program.cafe.SaveChanges();
            }
        }
    }
}