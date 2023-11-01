using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.Data;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace AIBCafe3
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public LoginForm()
        {
            this.AllowFormSkin = false;
            InitializeComponent();
        }
        
        AIBCafe3.IniWorker ini = new IniWorker(Application.StartupPath +@"\Setting.ini",true);

        private void LoginForm_Load(object sender, EventArgs e)
        {
            var a=ini.IniReadValue("Login","Check");
            buttonEdit1.EditValue = ini.IniReadValue("Config", "Path");
            if (a!="")
            {
                if (bool.Parse(a))
                {
                    usertext.Text = ini.IniReadValue("Login", "User");
                    checkEdit1.Checked = bool.Parse(a);
                    
                }
            }
        }
        void Open()
        {
            string providerName = "System.Data.SqlClient";
            string serverName = ".";
            string databaseName = "AdventureWorks";

            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();

            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            sqlBuilder.IntegratedSecurity = true;

            string providerString = sqlBuilder.ToString();

            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();

            entityBuilder.Provider = providerName;
            entityBuilder.ProviderConnectionString = providerString;
            entityBuilder.Metadata = @"res://*/AdventureWorksModel.csdl|
                            res://*/AdventureWorksModel.ssdl|
                            res://*/AdventureWorksModel.msl";
            Console.WriteLine(entityBuilder.ToString());

            using (EntityConnection conn = new EntityConnection(entityBuilder.ToString()))
            {
                conn.Open();
                Console.WriteLine("Just testing the connection.");
                conn.Close();
            }

        }

        private void dangNhap_Button_Click(object sender, EventArgs e)
        {
            if (buttonEdit1.EditValue.ToString()=="")
            {
                MessageBox.Show("Nhấn vào nút [+] để tạo mới cơ sở dữ liệu cho chương trình!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Program.cafe = new AIBCafe3Entities();
            
            Cursor.Current = Cursors.WaitCursor;
            
            
            //var HD = Program.cafe.Bills.ToList();
            //if (HD.Count >= 1000)
            //{
            //    var HD1 = (Program.cafe.Bills.Max(p=>p.Date));
            //    var HD2 = (Program.cafe.Bills.Min(p=>p.Date));
                
            //    var n = ini.IniReadValue("APP", "HH");
            //    if (((DateTime)HD1 - (DateTime)HD2).TotalDays >= 16 || n == "112")
            //    {
            //        ini.IniWriteValue("APP", "HH", "112");
            //        MessageBox.Show("Phần mềm đã hết hạn sử dụng, vui lòng liên hệ với AIBSoft - Viet Nam để được hổ trợ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        Process.Start("http://aibip.com");
            //        Environment.Exit(-1);
            //    }
            //}
            if (Program.cafe.Employees.ToList().Count<=0)
            {
                //Thêm mới người dùng
                Employee em = new Employee { 
                    EmployeesID = Guid.NewGuid(), 
                    LoginName="Admin", 
                    Name="Người quản trị", 
                    Password="123456",
                    Empl =true, 
                    Report=true, 
                    Item=true,
                    InWard=true, 
                    Sell=true,
                Product =true};
                Program.cafe.Employees.AddObject(em);
                
                //Thêm mới đơn vị tính
                Unit prdG = new Unit();
                prdG.Id = ClassInfo.ThoiGianID;
                prdG.UnitName = "Giờ";
                Program.cafe.Units.AddObject(prdG);

                //Thêm mới nhóm thực đơn
                ProductGroup prdG1 = new ProductGroup();
                prdG1.ProductGroupID = ClassInfo.ThoiGianID;
                prdG1.Name = "Thời gian";
                prdG1.Report = false;
                prdG1.DisplayOrder = 0;
                Program.cafe.ProductGroups.AddObject(prdG1);

                //Thêm mới thực đơn
                Product prd = new Product();
                prd.ProductID = ClassInfo.ThoiGianID;
                prd.ProductName = "Thời gian(giờ)";
                prd.Show = false;
                prd.Active = true;
                prd.DisplayOrder = 0;
                prd.Price = 0;
                prd.UnitID = ClassInfo.ThoiGianID;
                prd.ProductGroupID = ClassInfo.ThoiGianID;
                Program.cafe.Products.AddObject(prd);

                Program.cafe.SaveChanges();
            }

            var a = (from p in Program.cafe.Employees
                     where p.LoginName == usertext.Text.Trim() && p.Password == passwordEdit.Text.Trim()
                     select p
                   );
            if (a!=null)
            {
                var b = a.ToList();
                if (b.Count != 1)
                {
                    MessageBox.Show("User hoặc Password không đúng, xin vui lòng thử lại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ini.IniWriteValue("Login", "User",usertext.Text);
                    ini.IniWriteValue("Login", "Check", (checkEdit1.Checked ? "True" : "False"));

                    var c = b.First();
                    ClassInfo.NhanVien = c.EmployeesID;
                    ClassInfo.QLBanHang = (c.Sell.Value);
                    ClassInfo.QlBaoCao = (c.Report.Value);
                    ClassInfo.QLKho = (c.Item.Value);
                    ClassInfo.QLNhanVien = (c.Empl.Value);
                    ClassInfo.QLThucDon = (c.Product.Value);

                    paReport.DiaChi = "TT Phước An -Krông Pắc - Đaklak";
                    paReport.DienThoai = "";
                    paReport.TenQuan = "NGÀN LỘC GARDEN";
                    this.Hide();
                    Main frm = new Main();
                    frm.Show();
                } 
            }
            
        }

        private void huy_Button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát chương trình?", "Xác nhận?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
            
        }

        private void textEdit2_Enter(object sender, EventArgs e)
        {
            usertext.SelectAll();
        }

        private void textEdit2_Click(object sender, EventArgs e)
        {
            usertext.SelectAll();
        }

        private void textEdit1_Enter(object sender, EventArgs e)
        {
            passwordEdit.SelectAll();
        }

        private void textEdit1_Click(object sender, EventArgs e)
        {
            passwordEdit.SelectAll();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + @"\_Data\AIBCafe.sdf"))
            {
                SaveFileDialog dl = new SaveFileDialog();
                dl.Title = "Lưu file cơ sở dữ liệu";
                dl.FileName = "AIBCafe";
                dl.Filter = "AIBCafe Document| *.AIBC|All Files (*.*)|*.*";
                if (dl.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(Application.StartupPath + @"\_Data\AIBCafe.sdf", dl.FileName,true);
                    buttonEdit1.EditValue = dl.FileName;
                    
                    ini.IniWriteValue("Config", "Path", dl.FileName);
                    string cnn = "metadata=res://*/AIBCafe3Model.csdl|res://*/AIBCafe3Model.ssdl|res://*/AIBCafe3Model.msl;provider=System.Data.SqlServerCe.3.5;provider connection string=\"Data Source={0};Password=567leduan\";";
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                    config.ConnectionStrings.ConnectionStrings["AIBCafe3Entities"].ConnectionString = string.Format(cnn, dl.FileName);
                    config.ConnectionStrings.ConnectionStrings["AIBCafe3Entities"].ProviderName = "System.Data.EntityClient";
                   // config.ConnectionStrings.ConnectionStrings[0].ConnectionString = string.Format(cnn, dl.FileName);
                   // config.ConnectionStrings.ConnectionStrings[0].ProviderName = "System.Data.EntityClient";
                    config.Save();
                    // = string.Format(cnn, dl.FileName);
                    ConfigurationManager.RefreshSection("connectionStrings");
                }
            }
            else
            {
                MessageBox.Show("Chương trình không thể chạy được vào lúc này, vui lòng download data","Thông báo!",MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.Start("http://aibip.com/app/");
            }
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog dl = new OpenFileDialog();
            dl.Title = "Lưu file cơ sở dữ liệu";
            dl.FileName = "AIBCafe";
            dl.Filter = "AIBCafe Document| *.AIBC|All Files (*.*)|*.*";
            if (dl.ShowDialog() == DialogResult.OK)
            {
              //  File.Copy(Application.StartupPath + @"\_Data\AIBCafe.sdf", dl.FileName, true);
                buttonEdit1.EditValue = dl.FileName;

                ini.IniWriteValue("Config", "Path", dl.FileName);
                string cnn = "metadata=res://*/AIBCafe3Model.csdl|res://*/AIBCafe3Model.ssdl|res://*/AIBCafe3Model.msl;provider=System.Data.SqlServerCe.3.5;provider connection string=\"Data Source={0};Password=567leduan\";";
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.ConnectionStrings.ConnectionStrings["AIBCafe3Entities"].ConnectionString = string.Format(cnn, dl.FileName);
                config.ConnectionStrings.ConnectionStrings["AIBCafe3Entities"].ProviderName = "System.Data.EntityClient";
                config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");
            }
        }

        private void LoginForm_Shown(object sender, EventArgs e)
        {

        }
    }
}