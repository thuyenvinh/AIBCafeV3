using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AIBCafe3
{
    public partial class frmAbout : DevExpress.XtraEditors.XtraForm
    {
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams param = base.CreateParams;
                param.ClassStyle += CS_DROPSHADOW;
                return param;
            }
        }
        public frmAbout()
        {
            this.AllowFormSkin = false;
            InitializeComponent();
        }

        private void frmAbout_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupControl1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}