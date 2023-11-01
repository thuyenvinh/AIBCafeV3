using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AIBCafe3._Report;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
namespace AIBCafe3
{
    //static class Ext
    //{
    //    public static IQueryable<TSource> Between<TSource, TKey>(this IQueryable<TSource> source,
    //          Expression<Func<TSource, TKey>> keySelector, TKey Tu, TKey Den) where TKey : IComparable<TKey>
    //    {
    //        Expression key = Expression.Invoke(keySelector, keySelector.Parameters.ToArray());
    //        Expression lowerBound = Expression.LessThanOrEqual(Expression.Constant(Tu), key);
    //        Expression upperBound = Expression.LessThanOrEqual(key, Expression.Constant(Den));
    //        Expression and = Expression.AndAlso(lowerBound, upperBound);
    //        Expression<Func<TSource, bool>> lambda = Expression.Lambda<Func<TSource, bool>>(and, keySelector.Parameters);
    //        return source.Where(lambda);
    //    }

    //    public static int ThuyenTon<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate, object[] prameter)
    //    {
    //        var a = prameter[0].ToString();
    //        return 1;
    //    }

    //}
    public partial class frmInventory : DevExpress.XtraEditors.XtraForm
    {

        /// <summary>
        /// Tính giá trị số lượng sản phẩm bán
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        int TinhBan(DateTime TuNgay, DateTime DenNgay, Guid? ProductID)
        {
            var cafe = Program.cafe;
            var SLuongBan = 1;
            var DSThucDon_tatCa =
                (from billdetails in cafe.BillDetails
                 join bills in cafe.Bills on billdetails.BillID equals bills.BillID
                 where
                   billdetails.ProductID == ProductID
                   && bills.Date >= TuNgay && bills.Date < DenNgay
                 select new
                 {
                     billdetails.Quantity
                 }
                 ).ToList();
            if (DSThucDon_tatCa.Count >= 1)
            {
                var m = DSThucDon_tatCa.Sum(p => p.Quantity);
                SLuongBan = (int)m;
            }
            else
            {
                SLuongBan = 0;
            }
            return SLuongBan;
        }

        /// <summary>
        /// Tính giá trị sản phẩm nhập
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        int TinhNhap(DateTime TuNgay, DateTime DenNgay, Guid? ProductID)
        {
            var cafe = Program.cafe;
            var SLuongBan = 1;
            var DSThucDon_tatCa =
                (from billdetails in cafe.InwardDetails
                 join bills in cafe.Inwards on billdetails.InwardID equals bills.InwardID
                 where
                   billdetails.ProductID == ProductID
                   && bills.Date >= TuNgay && bills.Date < DenNgay
                 select new
                 {
                     billdetails.Quantity
                 }
                 ).ToList();
            if (DSThucDon_tatCa.Count >= 1)
            {
                var m = DSThucDon_tatCa.Sum(p => p.Quantity);
                SLuongBan = (int)m;
            }
            else
            {
                SLuongBan = 0;
            }
            return SLuongBan;
        }

        /// <summary>
        /// Tính giá trị sản phẩm tồn
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        int TinhTon(DateTime DenNgay, Guid? ProductID)
        {
            var cafe = Program.cafe;

            //Tính tổng số lượng xuất
            var SLuongBan = 0;
            var DSThucDon_tatCa =
                (from billdetails in cafe.BillDetails
                 join bills in cafe.Bills on billdetails.BillID equals bills.BillID
                 where
                   billdetails.ProductID == ProductID &&
                   bills.Date < DenNgay
                 select new
                 {
                     billdetails.Quantity
                 }
                 ).ToList();

            if (DSThucDon_tatCa.Count >= 1)
            {
                var m = DSThucDon_tatCa.Sum(p => p.Quantity);
                SLuongBan = (int)m;
            }
            else
            {
                SLuongBan = 0;
            }
            //Tính tổng số lượng nhập
            int SLNhap = 0;
            var TongNhap_ = (
                from p in cafe.InwardDetails
                join inw in cafe.Inwards on p.InwardID equals inw.InwardID
                where
                p.ProductID == ProductID &&
                 inw.Date < DenNgay
                select new
                {
                    p.Quantity
                }
                ).ToList();
            if (TongNhap_.Count <= 0)
            {
                SLNhap = 0;
            }
            else
            {
                var t = TongNhap_.Sum(p => p.Quantity);
                SLNhap = (int)t;
            }

            return SLNhap - SLuongBan;
        }


        /// <summary>
        /// Tính giá trị sản phẩm tồn
        /// </summary>
        /// <param name="TuNgay"></param>
        /// <param name="DenNgay"></param>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        decimal TinhGiaTriTon(DateTime TuNgay, DateTime DenNgay, Guid? ProductID)
        {
            var cafe = Program.cafe;
            decimal giaTriTon = 0;
            var n = TinhTon(DenNgay, ProductID);
            var DSThucDon_tatCa =
                    (from p in cafe.InwardDetails
                     join iw in cafe.Inwards on p.InwardID equals iw.InwardID
                     where
                       p.ProductID == ProductID
                       && iw.Date < DenNgay
                     orderby iw.Date
                     select p
                 ).ToList();
            
            foreach (var item in DSThucDon_tatCa)
            {
                giaTriTon += (decimal)item.Price.Value * (decimal)item.Quantity.Value;
                n -= item.Quantity.Value;
                if (n<=0)
                {
                    giaTriTon += (decimal)n * item.Price.Value;
                    break;
                }
            }
            return giaTriTon;
        }

        public frmInventory()
        {
            this.AllowFormSkin = false;
            InitializeComponent();
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            this.barEditItem1.EditValue = DateTime.Now;
            this.barEditItem2.EditValue = DateTime.Now;

        }
        decimal ChuyenDoiDonVi(Guid ProductID, int Quan)
        {
            if (true)
            {
                
            }
            return (decimal)0;
        }
        //private static Expression<Func<BillDetail, bool>> createCloseEnoughFunc(double coolLat, double coolLong, double maxDist)
        //{
        //    return null;
        //    Program.cafe.BillDetails.Where(p => p.Price == Between1(p.Price));
        //}


        private DataTable ObtainDataTableFromIEnumerable(IEnumerable DuLieuNguon)
        {
            DataTable dt = new DataTable();
            foreach (object obj in DuLieuNguon)
            {
                Type t = obj.GetType();
                PropertyInfo[] pis = t.GetProperties();
                if (dt.Columns.Count == 0)
                {
                    foreach (PropertyInfo pi in pis)
                    {
                        dt.Columns.Add(pi.Name, pi.PropertyType);
                    }
                }
                DataRow dr = dt.NewRow();
                foreach (PropertyInfo pi in pis)
                {
                    object value = pi.GetValue(obj, null);
                    dr[pi.Name] = value;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            var tu = (DateTime)this.barEditItem1.EditValue;
            var den = (DateTime)this.barEditItem2.EditValue;

            rptInventory dt = new rptInventory();

            var ar = (from p in Program.cafe.Products
                      join unit in Program.cafe.Units on p.UnitID equals unit.Id
                      join prType in Program.cafe.ProductGroups on p.ProductGroupID equals prType.ProductGroupID
                      where prType.Report.Value==true
                      select new
                      {
                          ProductID = p.ProductID,
                          TenThucDon = p.ProductName,
                          DonViTinh = unit.UnitName,
                          TonDau=0,
                          SLuongNhap = 0,
                          SLuongBan = 0,
                          SLuongTon = 0,
                          GiaTriTon = 0
                      }
                );
            rptTonKho f = new rptTonKho(tu, den);
            rptInventory d = new rptInventory();
            //if (File.Exists(ClassInfo.reportpath + "TonKho.repx"))
            //{
            //    f.LoadLayout(ClassInfo.reportpath + "TonKho.repx");
            //}
            var source = ObtainDataTableFromIEnumerable(ar);

            foreach (System.Data.DataRow item in source.Rows)
            //Thay đổi từng giá trị trong khung
            {
                item[3] = TinhTon(tu, (Guid)item[0]);//Tồn đầu
                item[4] = TinhNhap(tu, den, (Guid)item[0]);//Nhập
                item[5] = TinhBan(tu, den, (Guid)item[0]);//Bán
                item[6] = TinhTon(den, (Guid)item[0]);//Tồn cuối
                item[7] = TinhGiaTriTon(tu, den, (Guid)item[0]);//Giá trị tồn cuối
            }

            f.DataSource = source;
            IniWorker a = new IniWorker(Application.StartupPath + "/Report.ini", true);

            if (File.Exists(ClassInfo.reportpath + "BaoCaoTonKho.arcx"))
            {
                f.LoadLayout(ClassInfo.reportpath + "BaoCaoTonKho.arcx");
            }
            printControl1.PrintingSystem = f.PrintingSystem;
            printControl1.Zoom = 1F;

            f.CreateDocument();
            
        }
        public void AssignmentAction(string x, string vlue)
        {
            x = vlue;//new Random().NextDouble().ToString();
        }

    }
}