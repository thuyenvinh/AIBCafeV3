using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace AIBCafe3._Report
{
    public partial class rptNhapKho : DevExpress.XtraReports.UI.XtraReport
    {
        public rptNhapKho()
        {
            InitializeComponent();
            xrLabel8.Text = DateTime.Now.ToString("........,\\N\\gà\\y dd \\t\\há\\n\\g MM \\nă\\m yyyy");
        }

    }
}
