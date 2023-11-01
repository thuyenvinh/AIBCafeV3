using System;
using System.IO;
using System.Linq;
using AIBCafe3._Report;
namespace AIBCafe3
{
    public partial class frmRptBill : DevExpress.XtraEditors.XtraForm
    {
        public frmRptBill()
        {
            InitializeComponent();
        }
        DateTime TuNgay = DateTime.Now;
        DateTime DenNgay = DateTime.Now;

        private void frmRptBill_Load(object sender, EventArgs e)
        {
            tuNgaydt.EditValue = DateTime.Now;
            denNgaydt.EditValue = DateTime.Now;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DateTime TuNgay = (DateTime)tuNgaydt.EditValue;
            DateTime DenNgay = (DateTime)denNgaydt.EditValue;

            ReportHoaDons f = new ReportHoaDons(TuNgay, DenNgay);

            //if (File.Exists(ClassInfo.reportpath + "DanhSachHoaDon.repx"))
            //{
            //    f.LoadLayout(ClassInfo.reportpath + "DanhSachHoaDon.repx");
            //}
            printControl1.PrintingSystem = f.PrintingSystem;
            printControl1.Zoom = 1F;

            var ListHoaDon = (
                from p in Program.cafe.Bills
                // join itm in Program.cafe.Items on itm.ItemID equals p.ItemID
                join t in Program.cafe.Items on p.ItemID equals t.ItemID
                join ep in Program.cafe.Employees on p.EmployeesID equals ep.EmployeesID
                where (p.Date >= TuNgay) && (p.Date < DenNgay)
                select new
                {
                    GioVao = p.Date,
                    GioRa = p.DateEnd,
                    TenBan = t.Name,
                    NhanVien = ep.Name,
                    TongTien = p.Amount,
                    GiamGia = p.Discount,
                    GhiChu = p.Description
                }
                );
            f.DataSource = ListHoaDon;
            f.CreateDocument();
        }
    }
}