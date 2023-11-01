using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace AIBCafe3._Report
{
    public class rptBills : DataTable
    {
        public rptBills()
        {

            var n = new
            {
                GioVao = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                GioRa = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                TenBan = "",
                NhanVien = "",
                TongTien = 0,
                GiamGia = 0,
                GhiChu = ""
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
