using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace AIBCafe3._Report
{
    class rptInventory : DataTable
    {
        public rptInventory()
        {

            var n = new
            {
                TenThucDon = "",
                DonViTinh = "",
                TonDau = 0,
                SLuongNhap = 0,
                SLuongBan = 0,
                SLuongTon = 0,
                GiaTriTon = 0
            };
            foreach (var item in n.GetType().GetProperties())
            {
                this.Columns.Add(item.Name);
            }
        }
        public static IEnumerable GetBillLists()
        {
            return null;
        }
    }
}