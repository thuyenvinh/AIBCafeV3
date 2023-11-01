using System;
using System.Windows.Forms;
using AIBCafe3._Report;
using System.Linq;
using System.IO;

namespace AIBCafe3
{
    public partial class Rpt_BillForm : DevExpress.XtraEditors.XtraForm
    {
        private Guid? _IDHoaDon = null;
        private Guid? _Ban = null;
        private bool _DaIn = false;

        public Rpt_BillForm()
        {
            this.AllowFormSkin = false;
            
            
        }
        public Rpt_BillForm(Guid IDHoaDon, Guid? Ban)
        {
            
            this.AllowFormSkin = false;
            try
            {
                InitializeComponent();
            }
            catch (Exception)
            {

            }
            _IDHoaDon = IDHoaDon;
            _Ban = Ban;
        }
        public Rpt_BillForm(Guid IDHoaDon, Guid? Ban, bool DaIn)
        {
            this.AllowFormSkin = false;
            try
            {
                InitializeComponent();
            }
            catch (Exception)
            {

            }
            _IDHoaDon = IDHoaDon;
            _Ban = Ban;
        }
       
        private void XtraForm1_Load(object sender, EventArgs e)
        {
            if (_IDHoaDon != null)
            {
               // IniWorker iniwker = new IniWorker(Application.StartupPath + "/Report.ini", true);
               
                var mm = _Ban;
                string TenBan = Program.cafe.Bills.Where(p => p.BillID == _IDHoaDon).FirstOrDefault().Item.Name;
                string NhanVien = Program.cafe.Employees.First().Name;

                ReportHoaDon_A6 f_report = new ReportHoaDon_A6(TenBan,NhanVien);

                //if (File.Exists(ClassInfo.reportpath + "HoaDon.repx"))
                //{
                //    f_report.LoadLayout(ClassInfo.reportpath + "HoaDon.repx");
                //}
                printControl1.PrintingSystem = f_report.PrintingSystem;
                printControl1.Zoom = 1F;


                ////////////////////////////
                var bill = Program.cafe.Bills.Where(p => p.BillID == _IDHoaDon).First();
                f_report.xrNgaybatDau.Text = "Vào lúc " + ((DateTime)bill.Date).ToString("dd/MM/yyyy - HH:mm");
                f_report.xrNgayKetThuc.Text = "Ra lúc " + ((DateTime)bill.DateEnd).ToString("dd/MM/yyyy - HH:mm");

                //f_report.xrDiaChi.Text = paReport.DiaChi;
                //f_report.xrDienThoai.Text = paReport.DienThoai;
                //f_report.xrTenQuan.Text = paReport.TenQuan;
                //f_report.xrSologan.Text = a.IniReadValue("HoaDon", "Sologan");
                
                f_report.xrThanhToan.Text = (bill.Amount - bill.Discount).ToString();
                ///////////////////////////////
                //var _IDban = Program.cafe.Bills.Where(p => p.BillID == _IDHoaDon).ToList().First().ItemID;
                //var _IDKhuVuc = Program.cafe.Items.Where(p => p.ItemID == _IDban).First().ItemTypeID;
                //var _1KhuVuc = Program.cafe.ItemTypes.Where(p => p.ItemTypeID == _IDKhuVuc).First();


                var HoaDon_Time = (from billdetails in Program.cafe.BillDetails
                                   join products in Program.cafe.Products on billdetails.ProductID equals products.ProductID
                                   join un in Program.cafe.Units on products.UnitID equals un.Id
                                   where
                                     billdetails.BillID == _IDHoaDon
                                   select new
                                   {
                                       ThucDon = products.ProductName,
                                       DvTinh = un.UnitName,
                                       SoLuong = billdetails.Quantity,
                                       DonGia = billdetails.Price
                                   }
                            ).ToList();
                f_report.DataSource = HoaDon_Time;

                f_report.CreateDocument();
              

            }
            else
            {
                MessageBox.Show("Không xác định được bàn cần tính tiền!\rVui lòng kiểm tra lại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                this.Close();
            }

        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (_Ban != null)
            {
                iniClass.IniWriteValue("Ban", _Ban.ToString(), "0");
                printPreviewBarItem9.PerformClick();
                this.Close();
            }
            else
            {
                printPreviewBarItem9.PerformClick();
                this.Close();
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {


        }
    }
}