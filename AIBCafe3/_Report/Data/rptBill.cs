using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace AIBCafe3._Report
{
    class rptBill : DataTable
    {
        public int MyProperty { get; set; }
        public rptBill()
        {
            
            var n = new
            {
                ThucDon = "",
                SoLuong = 0,
                DonGia = 0,
                DvTinh = ""
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
