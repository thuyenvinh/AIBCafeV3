using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AIBCafe3._Report;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Reflection;

namespace AIBCafe3._Report
{
    public partial class frmNhapKhos : DevExpress.XtraEditors.XtraForm
    {
        public frmNhapKhos()
        {
            InitializeComponent();
        }

        private void frmNhapKhos_Load(object sender, EventArgs e)
        {
            tuNgaydt.EditValue = DateTime.Now;
            denNgaydt.EditValue = DateTime.Now;
        }
        DateTime TuNgay;
        DateTime DenNgay;
        void Thongke()
        {
            rptNhapKhos f = new rptNhapKhos(TuNgay,DenNgay);

            //if (File.Exists(ClassInfo.reportpath + "DSNhapKho.repx"))
            //{
            //    f.LoadLayout(ClassInfo.reportpath + "DSNhapKho.repx");
            //}
            printControl1.PrintingSystem = f.PrintingSystem;
            printControl1.Zoom = 1F;
            var source = (
                from p in Program.cafe.Inwards
                join empl in Program.cafe.Employees on p.EmployeesID equals empl.EmployeesID
                where p.Date>=TuNgay && p.Date <DenNgay
                orderby p.Date
                select new
                {

                    NgayNhap = p.Date,
                    NhanVien = empl.Name,
                    NoiDung = p.Description,
                    TongTien = p.Amount,
                    GhiChu = ""
                }
                );
            f.DataSource = source;
            f.CreateDocument();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            TuNgay = (DateTime)tuNgaydt.EditValue;
            DenNgay = (DateTime)denNgaydt.EditValue;

            Thongke();
            Cursor.Current = Cursors.Default;
        }
    }
}