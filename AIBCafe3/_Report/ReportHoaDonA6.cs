using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace AIBCafe3._Report
{
    public partial class ReportHoaDon_A6 : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportHoaDon_A6(string TenBan, string NhanVien)
        {
            InitializeComponent();
            xrTenBan.Text = TenBan;
            xrNhanVien.Text = NhanVien;
        }

    }
}
