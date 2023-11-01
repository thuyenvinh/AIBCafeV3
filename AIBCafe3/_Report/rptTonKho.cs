using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace AIBCafe3._Report
{
    public partial class rptTonKho : DevExpress.XtraReports.UI.XtraReport
    {
        public rptTonKho(DateTime TuNgay, DateTime DenNgay)
        {
            InitializeComponent();
            xrLabel7.Text = string.Format("Từ ngày {0} đến ngày {1}",TuNgay.ToString("dd/MM/yyyy HH:mm"),DenNgay.ToString("dd/MM/yyyy HH:mm"));
            xrLabel8.Text = DateTime.Now.ToString("........,\\N\\gà\\y dd \\t\\há\\n\\g MM \\nă\\m yyyy");
        }

    }
}
