using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing.Printing;
using System.Linq;

namespace AIBCafe3
{
    public partial class Option_form : DevExpress.XtraEditors.XtraForm
    {
        public Option_form()
        {
            this.AllowFormSkin = false;
            InitializeComponent();
            AllowFormSkin = false;
        }

        private void Option_form_Load(object sender, EventArgs e)
        {
            //PrintDocument prtdoc = new PrintDocument();
            //var strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;
            //foreach (var item in PrinterSettings.InstalledPrinters)
            //{
            //    //comboBoxEdit1.so = PrinterSettings.InstalledPrinters;

            //}
        }
    }
}