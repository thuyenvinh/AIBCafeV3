using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AIBCafe3._Report;
namespace AIBCafe3
{
    public partial class frmRptNhapkho : DevExpress.XtraEditors.XtraForm
    {
        Guid _MaNhapkho = Guid.Empty;
        public frmRptNhapkho()
        {
            this.AllowFormSkin = false;
            InitializeComponent();
        }
        public frmRptNhapkho(Guid MaNhapkho)
        {
            this.AllowFormSkin = false;
            InitializeComponent();
            _MaNhapkho = MaNhapkho;
        }
        private void frmRptNhapkho_Load(object sender, EventArgs e)
        {
            if (_MaNhapkho != Guid.Empty)
            {
                rptNhapKho f = new rptNhapKho();
                //if (File.Exists(ClassInfo.reportpath + "PhieuNhapKho.repx"))
                //{
                //    f.LoadLayout(ClassInfo.reportpath + "PhieuNhapKho.repx");
                //}
                printControl1.PrintingSystem = f.PrintingSystem;
                printControl1.Zoom = 1F;
                var source = (
                    from p in Program.cafe.InwardDetails
                    join t in Program.cafe.Products on p.ProductID equals t.ProductID
                    join h in Program.cafe.Units on t.UnitID equals h.Id
                    where p.InwardID == _MaNhapkho
                    select new
                    {
                        TenThucDon = t.ProductName,
                        DonViTinh = h.UnitName,
                        SLuongNhap = p.Quantity,
                        DonGia = p.Price
                    }
                    );
                f.DataSource = source;
                f.CreateDocument();

            }
            else
            {
                MessageBox.Show("Không xác định được phiếu cần in, vui lòng thử lại");
            }
        }
    }
}