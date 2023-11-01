using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using System.Linq;
using AIBCafe3;
using System.IO;
using AIBCafe3._Report;

namespace AIBCafe3
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
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
                f.MdiParent = this;
                f.WindowState = FormWindowState.Maximized;
                f.Show();
            }

        }
        public Main()
        {
            this.AllowFormSkin = false;
            InitializeComponent();
            
        }

        private void navBarControl1_GroupExpanded(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {
            NavBarGroup a = e.Group;
            foreach (NavBarGroup item in navBarControl1.Groups)
            {
                if (item != a)
                {
                    item.Expanded = false;
                }
            }
        }

        private void navQuanLyKhach_LinkClicked(object sender, NavBarLinkEventArgs e)
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

        private void navDSHoaDon_LinkClicked(object sender, NavBarLinkEventArgs e)
        {

            if (ClassInfo.QlBaoCao)
            {
                OpenForm(typeof(Bill_Form), false);
            }
            else
            {
                ThongBao();
            }
        }

        private void navSuaPhieu_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (ClassInfo.QLBanHang)
            {
               // OpenForm(typeof(ReportDesigner.MainForm), true);
            }
            else
            {
                ThongBao();
            }
        }

        private void navNhapKho_LinkClicked(object sender, NavBarLinkEventArgs e)
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

        private void navDsNhapKho_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (ClassInfo.QLKho)
            {
                OpenForm(typeof(Inward_Form), false);
            }
            else
            {
                ThongBao();
            }
        }

        private void navPhanLoai_ThucDon_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (ClassInfo.QLThucDon)
            {
                OpenForm(typeof(ProductGroup_Form), false);
            }
            else
            {
                ThongBao();
            }
        }

        private void navDsThucDon_LinkClicked(object sender, NavBarLinkEventArgs e)
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

        private void navDVTinh_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
           // MessageBox.Show("Chưa sử dụng được!");

            if (ClassInfo.QLThucDon)
            {
                OpenForm(typeof(Unit_Form), true);
            }
            else
            {
                ThongBao();
            }
        }

        private void navCongThuc_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            MessageBox.Show("Chưa sử dụng được!");
            if (ClassInfo.QLThucDon)
            {
                OpenForm(typeof(Assembly_form), false);
            }
            else
            {
                ThongBao();
            }
        }

        private void navKhuVuc_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (ClassInfo.QLThucDon)
            {
                OpenForm(typeof(Item_Form), false);
            }
            else
            {
                ThongBao();
            }
        }

        private void navPhongBan_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (ClassInfo.QLThucDon)
            {
                OpenForm(typeof(Item_Form), false);
            }
            else
            {
                ThongBao();
            }
        }

        private void navBC_NhapKho_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (ClassInfo.QlBaoCao)
            {
                OpenForm(typeof(frmNhapKhos), false);
            }
            else
            {
                ThongBao();
            }
        }

        private void navBC_BanHang_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (ClassInfo.QlBaoCao)
            {
                OpenForm(typeof(frmRptBill), false);
            }
            else
            {
                ThongBao();
            }
        }

        private void navBC_TonKho_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            //new frmInventory().Show();
            //return;
            if (ClassInfo.QlBaoCao)
            {
                OpenForm(typeof(frmInventory), false);
            }
            else
            {
                ThongBao();
            }
        }

        private void navTuyChon_LinkClicked(object sender, NavBarLinkEventArgs e)
        {

        }

        private void navNguoiDung_LinkClicked(object sender, NavBarLinkEventArgs e)
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

        private void xtraTabbedMdiManager1_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            if (this.MdiChildren.Length == 0)
            {
                frmBground frm = new frmBground();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void navNangCap_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            MessageBox.Show("Cảnh báo:\r -Chức năng này chỉ dành cho những khách hàng đang sử dụng phiên bản 2.5 muốn nâng cấp lên 3.0\r -Dữ liệu sẽ nâng cấp đè lên phiên bản mới nên phải cẩn thận","Thông báo!",MessageBoxButtons.OK, MessageBoxIcon.Information);
            OpenForm(typeof(import_Form), true);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            //IniWorker ini = new IniWorker(Application.StartupPath + "/Option.ini", true);
            //var path = ini.IniReadValue("App", "Backup_path");
            //if (path.ToString() != "")
            //{
            //    if (System.IO.Directory.Exists(path))
            //    {
            //        File.Copy(ini.IniReadValue("App", "Datapath"), path + "/" + (DateTime.Now.ToString("dd/MM/yyyy/HH/mm/ss").Replace("/", ".")) + ".sdf");
                    
            //    }
            //    else
            //    {
            //        System.IO.Directory.CreateDirectory(path);
            //        File.Copy(ini.IniReadValue("App", "Datapath"), path + "/" + (DateTime.Now.ToString("dd/MM/yyyy/HH/mm/ss").Replace("/", ".")) + ".sdf");
            //    }
            //}
            //else
            //{
            //    if (MessageBox.Show("Bạn chưa tạo đường dẫn backup cho chương trình, xin vui lòng chọn trước khi thoát!", "Cảnh báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        e.Cancel = true;
            //        new Option_form().ShowDialog();
            //    }
            //    else
            //    {

            //    }
            //}
            //Cursor.Current = Cursors.Default;
        }
    
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void Main_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (ClassInfo.QLBanHang)
            {
                OpenForm(typeof(Bill_AddForm), false);
            }
            Cursor.Current = Cursors.Default;
        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmAbout().ShowDialog();
        }
    }
}