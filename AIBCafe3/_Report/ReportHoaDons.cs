using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace AIBCafe3._Report
{
    public partial class ReportHoaDons : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportHoaDons(DateTime TuNgay, DateTime DenNgay)
        {
            InitializeComponent();
            this.xrTuNgay.Text = TuNgay.ToString("Từ dd/MM/yyyy HH:mm");
            this.xrLDenNgay.Text=DenNgay.ToString("- Đến dd/MM/yyyy HH:mm");
            this.xrLNgayIn.Text= DateTime.Now.ToString("........,\\N\\gà\\y dd \\t\\há\\n\\g MM \\nă\\m yyyy");
        }

    }
}
