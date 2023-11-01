using System;
using System.Windows.Forms;

namespace AIBCafe3
{
    public static class ClassInfo
    {
        public static Guid? NhanVien;

        public static bool QLBanHang = false;
        public static bool QLNhanVien = false;
        public static bool QLThucDon = false;
        public static bool QlBaoCao = false;
        public static bool QLKho = false;

        public static Guid ThoiGianID = Guid.Parse("6712cc2f-1114-48fa-a024-f37b105c022b");
        public static Guid ThoiGianNhomID = Guid.Parse("dc724b2a-b67c-48f8-9e38-aac341df3437");

        public static string reportpath = Application.StartupPath + @"\BaoCao\";
    }
    public static class paReport
    {
        public static string TenQuan;
        public static string DiaChi;
        public static string DienThoai;
        public static string Sologan;
    }
}
