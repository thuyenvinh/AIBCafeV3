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
    public partial class frmBground : DevExpress.XtraEditors.XtraForm
    {
        void ThongBao()
        {
            MessageBox.Show("Bạn không có quyền thực hiện chức năng này, xin vui lòng liên hệ với quản trị viên để dược cấp thêm quyền!\r Hoặc xin liên hệ nhà cung cấp để được trợ giúp!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        void OpenForm(Type typeForm, bool Dialog)
        {
            Cursor.Current = Cursors.WaitCursor;
            foreach (Form fm in MdiChildren)
            {
                if (fm.GetType() == typeForm)
                {
                    fm.Activate();
                    return;
                }
                else
                {
                    fm.Close();
                }
            }
            Form f = (Form)Activator.CreateInstance(typeForm);
            if (Dialog)
            {
                f.ShowDialog();
            }
            else
            {
                f.MdiParent = this.MdiParent;
                f.WindowState = FormWindowState.Maximized;
                f.Show();
            }

        }
        public frmBground()
        {
            InitializeComponent();
        }

        private void picQLKhach_DoubleClick(object sender, EventArgs e)
        {
            
            if (ClassInfo.QLBanHang)
            {
                OpenForm(typeof(Bill_AddForm), false);
            }
            else
            {
                ThongBao();
            }
        }

        private void picQLNhapKho_DoubleClick(object sender, EventArgs e)
        {
            if (ClassInfo.QLKho)
            {
                OpenForm(typeof(Inward_AddForm), false);
            }
            else
            {
                ThongBao();
            }
        }

        private void picThietKe_DoubleClick(object sender, EventArgs e)
        {

               // OpenForm(typeof(ReportDesigner.MainForm), true);

        }

        private void picQLNguoiDung_DoubleClick(object sender, EventArgs e)
        {
            if (ClassInfo.QLNhanVien)
            {
                OpenForm(typeof(Employee_Form), false);
            }
            else
            {
                ThongBao();
            }
        }

        private void picQLThucDon_DoubleClick(object sender, EventArgs e)
        {
            if (ClassInfo.QLThucDon)
            {
                OpenForm(typeof(Product_Form), false);
            }
            else
            {
                ThongBao();
            }
        }

        private void picThongKe_DoubleClick(object sender, EventArgs e)
        {
            if (ClassInfo.QlBaoCao)
            {
                OpenForm(typeof(frmInventory), false);
            }
            else
            {
                ThongBao();
            }
        }

    }
}