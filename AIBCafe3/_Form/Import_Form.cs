using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;

namespace AIBCafe3
{
    public partial class import_Form : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection cnn;
        SqlCommand mySqlCommand;

        void Nhap_Nhom_ThucDon()
        {
            cnn = new SqlConnection(buttonEdit1.Text);
            mySqlCommand = cnn.CreateCommand();

            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            mySqlCommand.CommandText = "SELECT Count(*) FROM dbo.ProductGroup";
            int a = (int)mySqlCommand.ExecuteScalar();
            mySqlCommand.CommandText = "SELECT Description ,GroupID ,GroupName FROM dbo.ProductGroup";
            SqlDataReader productsSqlDataReader = mySqlCommand.ExecuteReader();
            //  int a = productsSqlDataReader.FieldCount;
            int i = 0;
            while (productsSqlDataReader.Read())
            {
                i++;

                backgroundWorker1.ReportProgress((int)(((float)i / (float)a) * 100));
                ProductGroup nhom = new ProductGroup();
                Guid id = Guid.NewGuid();
                iniClass.IniWriteValue("NhomThucDon", productsSqlDataReader["GroupID"].ToString(), id.ToString());
                nhom.DisplayOrder = 1;
                nhom.ProductGroupID = id;
                nhom.Name = productsSqlDataReader["GroupName"].ToString();
                Program.cafe.ProductGroups.AddObject(nhom);

            }
            Program.cafe.SaveChanges();
            productsSqlDataReader.Close();
            cnn.Close();
            backgroundWorker1.ReportProgress(0);
        }
        void Nhap_ThucDon()
        {
            // cnn = new SqlConnection(buttonEdit1.Text);
            mySqlCommand = cnn.CreateCommand();

            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            mySqlCommand.CommandText = "SELECT Count(*) FROM dbo.Product";
            int a = (int)mySqlCommand.ExecuteScalar();
            mySqlCommand.CommandText = "SELECT Active ,Description , GroupID ,Price ,ProducID ,ProducName FROM dbo.Product";

            SqlDataReader productsSqlDataReader = mySqlCommand.ExecuteReader();
            Unit un;
            if (Program.cafe.Units.ToList().Count<=1)
            {
                un = new Unit { Id = Guid.NewGuid(), UnitName = "ly" };
                Program.cafe.Units.AddObject(un);
            }
            else
            {
                un = Program.cafe.Units.Where(p => p.Id != ClassInfo.ThoiGianID).First();
            }
            int i = 0;
            while (productsSqlDataReader.Read())
            {
                i++;

                backgroundWorker1.ReportProgress((int)(((float)i / (float)a) * 100));
                Product nhom = new Product();
                Guid id = Guid.NewGuid();
                iniClass.IniWriteValue("ThucDon", productsSqlDataReader["ProducID"].ToString(), id.ToString());

                nhom.ProductGroupID = Guid.Parse(iniClass.IniReadValue("NhomThucDon", productsSqlDataReader["GroupID"].ToString()));
                nhom.DisplayOrder = 1;
                nhom.ProductID = id;
                nhom.ProductName = productsSqlDataReader["ProducName"].ToString();
                nhom.Price = decimal.Parse(productsSqlDataReader["Price"].ToString());
                nhom.Active = true;
                nhom.Show = true;
                nhom.UnitID = un.Id;
                //nhom.Name = productsSqlDataReader["GroupName"].ToString();
                Program.cafe.Products.AddObject(nhom);

            }
            Program.cafe.SaveChanges();
            productsSqlDataReader.Close();
            cnn.Close();
            backgroundWorker1.ReportProgress(0);
        }
        void Nhap_NhomBan()
        {
            // cnn = new SqlConnection(buttonEdit1.Text);
            mySqlCommand = cnn.CreateCommand();
            mySqlCommand.CommandText = "SELECT Description ,GroupItemID ,GroupName FROM dbo.ItemGroup";
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            mySqlCommand.CommandText = "SELECT Count(*) FROM dbo.ItemGroup";
            int a = (int)mySqlCommand.ExecuteScalar();
            mySqlCommand.CommandText = "SELECT Description ,GroupItemID ,GroupName FROM dbo.ItemGroup";
            SqlDataReader productsSqlDataReader = mySqlCommand.ExecuteReader();
            int i = 0;
            while (productsSqlDataReader.Read())
            {
                i++;

                backgroundWorker1.ReportProgress((int)(((float)i / (float)a) * 100));
                ItemType nhom = new ItemType();
                Guid id = Guid.NewGuid();
                iniClass.IniWriteValue("NhomBan", productsSqlDataReader["GroupItemID"].ToString(), id.ToString());

                nhom.ItemTypeID = id;//Guid.Parse(iniClass.IniReadValue("NhomThucDon", productsSqlDataReader["GroupID"].ToString()));
                nhom.DisplayOrder = 1;
                nhom.Name = productsSqlDataReader["GroupName"].ToString();
                nhom.Timing = false;
                nhom.Price = 0;//decimal.Parse("0"+productsSqlDataReader["Price"].ToString());
                nhom.Active = true;
                Program.cafe.ItemTypes.AddObject(nhom);

            }
            Program.cafe.SaveChanges();
            productsSqlDataReader.Close();
            cnn.Close();
            backgroundWorker1.ReportProgress(0);
        }
        void Nhap_Ban()
        {
            // cnn = new SqlConnection(buttonEdit1.Text);
            mySqlCommand = cnn.CreateCommand();

            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            mySqlCommand.CommandText = "SELECT Count(*) FROM dbo.Items";
            int a = (int)mySqlCommand.ExecuteScalar();
            mySqlCommand.CommandText = "SELECT Active ,GroupItemID , Name ,Status ,TableID FROM dbo.Items";
            SqlDataReader productsSqlDataReader = mySqlCommand.ExecuteReader();

            int i = 0;
            while (productsSqlDataReader.Read())
            {
                i++;

                backgroundWorker1.ReportProgress((int)(((float)i / (float)a) * 100));
                Item nhom = new Item();
                Guid id = Guid.NewGuid();

                iniClass.IniWriteValue("Ban", productsSqlDataReader["TableID"].ToString(), id.ToString());

                nhom.ItemTypeID = Guid.Parse(iniClass.IniReadValue("NhomBan", productsSqlDataReader["GroupItemID"].ToString()));
                nhom.ItemID = id;
                nhom.DisplayOrder = 1;
                nhom.Name = productsSqlDataReader["Name"].ToString();
                nhom.Status = false;
                nhom.Active = true;

                Program.cafe.Items.AddObject(nhom);
                Program.cafe.SaveChanges();
            }
            
            productsSqlDataReader.Close();
            cnn.Close();
            backgroundWorker1.ReportProgress(0);
        }

        void Nhap_HoaDon()
        {
            // cnn = new SqlConnection(buttonEdit1.Text);
            mySqlCommand = cnn.CreateCommand();

            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            mySqlCommand.CommandText = "SELECT Count(*) FROM dbo.Billing";
            int a = (int)mySqlCommand.ExecuteScalar();
            mySqlCommand.CommandText = "SELECT BillID ,TableID ,UserName ,Date ,Total , Sale ,DateEnd ,Payment ,Active FROM dbo.Billing	WHERE TableID IS NOT NULL";
            SqlDataReader productsSqlDataReader = mySqlCommand.ExecuteReader();
            int i = 0;
            while (productsSqlDataReader.Read())
            {
                i++;

                backgroundWorker1.ReportProgress((int)(((float)i / (float)a) * 100));
                Bill nhom = new Bill();
                Guid id = Guid.NewGuid();

                iniClass.IniWriteValue("HoaDon", productsSqlDataReader["BillID"].ToString(), id.ToString());

                // nhom. = Guid.Parse(iniClass.IniReadValue("NhomBan", productsSqlDataReader["GroupItemID"].ToString()));
                nhom.BillID = id;
                nhom.ItemID = Guid.Parse(iniClass.IniReadValue("Ban", productsSqlDataReader["TableID"].ToString()));
                nhom.EmployeesID = ClassInfo.NhanVien;
                nhom.Amount = decimal.Parse(productsSqlDataReader["Total"].ToString());
                nhom.Date = DateTime.Parse(productsSqlDataReader["Date"].ToString());
                nhom.DateEnd = DateTime.Parse(productsSqlDataReader["DateEnd"].ToString());
                Program.cafe.Bills.AddObject(nhom);
                Program.cafe.SaveChanges();
            }
            
            productsSqlDataReader.Close();
            cnn.Close();
            backgroundWorker1.ReportProgress(0);
        }


        void Nhap_HoaDonChiTiet()
        {
            // cnn = new SqlConnection(buttonEdit1.Text);
            mySqlCommand = cnn.CreateCommand();

            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            mySqlCommand.CommandText = "SELECT Count(*) FROM dbo.BillDetails";
            int a = (int)mySqlCommand.ExecuteScalar();
            mySqlCommand.CommandText = "SELECT  BillDetailID ,BillID ,Price ,ProducID ,Quantity FROM    dbo.BillDetails WHERE   ( BillID IS NOT NULL ) AND ProducID IS NOT NULL	";
            SqlDataReader productsSqlDataReader = mySqlCommand.ExecuteReader();
            int i = 0;
            while (productsSqlDataReader.Read())
            {
                i++;

                backgroundWorker1.ReportProgress((int)(((float)i / (float)a) * 100));
                BillDetail nhom = new BillDetail();
                Guid id = Guid.NewGuid();

                nhom.BillDetailID = id;

                nhom.BillID = Guid.Parse(iniClass.IniReadValue("HoaDon", productsSqlDataReader["BillID"].ToString()));

                nhom.Price = decimal.Parse(productsSqlDataReader["Price"].ToString());

                nhom.ProductID = Guid.Parse(iniClass.IniReadValue("ThucDon", productsSqlDataReader["ProducID"].ToString()));

                nhom.Quantity = int.Parse(productsSqlDataReader["Quantity"].ToString());
                Program.cafe.BillDetails.AddObject(nhom);

            }
            Program.cafe.SaveChanges();
            productsSqlDataReader.Close();
            cnn.Close();
            backgroundWorker1.ReportProgress(0);
        }

        void Nhap_NhapKho()
        {
            // cnn = new SqlConnection(buttonEdit1.Text);
            mySqlCommand = cnn.CreateCommand();

            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            mySqlCommand.CommandText = "SELECT Count(*) FROM dbo.Inward";
            int a = (int)mySqlCommand.ExecuteScalar();
            mySqlCommand.CommandText = "SELECT Active ,Date ,Description ,InwardID ,UserName FROM dbo.Inward";
            SqlDataReader productsSqlDataReader = mySqlCommand.ExecuteReader();
            int i = 0;
            while (productsSqlDataReader.Read())
            {
                i++;

                backgroundWorker1.ReportProgress((int)(((float)i / (float)a) * 100));
                Inward nhom = new Inward();
                Guid id = Guid.NewGuid();

                nhom.InwardID = id;
                iniClass.IniWriteValue("NhapKho", productsSqlDataReader["InwardID"].ToString(),id.ToString());

                nhom.Amount = 0;
                nhom.Date = DateTime.Parse(productsSqlDataReader["Date"].ToString());
                nhom.Description = productsSqlDataReader["Description"].ToString();
                nhom.EmployeesID = ClassInfo.NhanVien;

                Program.cafe.Inwards.AddObject(nhom);

            }
            Program.cafe.SaveChanges();
            productsSqlDataReader.Close();
            cnn.Close();
            backgroundWorker1.ReportProgress(0);
        }

        void Nhap_NhapKhoChiTiet()
        {
            // cnn = new SqlConnection(buttonEdit1.Text);
            mySqlCommand = cnn.CreateCommand();

            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            mySqlCommand.CommandText = "SELECT Count(*) FROM dbo.InWardDetails";
            int a = (int)mySqlCommand.ExecuteScalar();
            mySqlCommand.CommandText = "SELECT InWardDetailID ,InwardID ,Price ,ProducID ,Quantity FROM dbo.InWardDetails";
            SqlDataReader productsSqlDataReader = mySqlCommand.ExecuteReader();
            int i = 0;
            while (productsSqlDataReader.Read())
            {
                i++;
                backgroundWorker1.ReportProgress((int)(((float)i / (float)a) * 100));
                InwardDetail nhom = new InwardDetail();
                Guid id = Guid.NewGuid();

                nhom.InwardDetailID = id;

                nhom.InwardID = Guid.Parse(iniClass.IniReadValue("NhapKho", productsSqlDataReader["InwardID"].ToString()));

                nhom.Price = decimal.Parse(productsSqlDataReader["Price"].ToString());

                nhom.ProductID = Guid.Parse(iniClass.IniReadValue("ThucDon", productsSqlDataReader["ProducID"].ToString()));

                nhom.Quantity = int.Parse(productsSqlDataReader["Quantity"].ToString());

                Program.cafe.InwardDetails.AddObject(nhom);

            }
            Program.cafe.SaveChanges();
            productsSqlDataReader.Close();
            cnn.Close();
            backgroundWorker1.ReportProgress(0);
        }

        public import_Form()
        {
            this.AllowFormSkin = false;
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Nhap_Nhom_ThucDon();
            Nhap_ThucDon();

            Nhap_NhomBan();
            Nhap_Ban();

            Nhap_HoaDon();
            Nhap_HoaDonChiTiet();

            Nhap_NhapKho();
            Nhap_NhapKhoChiTiet();


        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarControl1.Position = e.ProgressPercentage;
            this.Text ="Nâng cấp dữ liệu "+ e.ProgressPercentage.ToString();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Đã cập nhật dữ liệu thành công! Vui lòng khởi động lại chương trình để xác nhận sự thay đổi!","Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Restart();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Chắc chắn bạn muốn nâng cấp dữ liệu từ phần mềm phiên bản củ không?\r-Lưu ý: Chương trình sẽ khởi động lại khi thực hiện xong!", "Xác nhận?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                backgroundWorker1.RunWorkerAsync();
            } 

            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void import_Form_Load(object sender, EventArgs e)
        {
        }
    }
}