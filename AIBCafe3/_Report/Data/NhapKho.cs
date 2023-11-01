using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AIBCafe3._Report.Data
{
    class NhapKho:DataTable
    {
        public NhapKho()
        {

            var n = new
            {
                TenThucDon = "",
                DonViTinh = "",
                SLuongNhap = 0,
                DonGia = 0
            };
            foreach (var item in n.GetType().GetProperties())
            {
                this.Columns.Add(item.Name);
            }
        }
    }
    class DSachNhapKho : DataTable
    {
        public DSachNhapKho()
        {

            var n = new
            {
                NgayNhap = "",
                NhanVien = "",
                NoiDung = 0,
                TongTien = 0,
                GhiChu = ""
            };
            foreach (var item in n.GetType().GetProperties())
            {
                this.Columns.Add(item.Name);
            }
        }
    }
}
