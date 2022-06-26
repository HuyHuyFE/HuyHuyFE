using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
    class OrderView
    {
        public string mamon { get; set; }
        public string tenmon { get; set; }
        public string soluong { get; set; }       
        public string gia { get; set; }
        public string thanhtien { get; set; }
        public string sohd { get; set; }
        public string soban { get; set; }
        public string ngaylaphd { get; set; }
        public string tenkh { get; set; }
     


        public static List<OrderView> chuyendoi(OrderDTO x)
        {
            List<OrderView> ds = new List<OrderView>();
            foreach(CChitiet a in x.chitiet)
            {
                OrderView b = new OrderView();
                b.mamon = a.menu.MaMon;
                b.tenmon = a.menu.TenMon;                
                b.soluong = a.soluong.ToString();              
                b.gia = a.dongia.ToString();
                b.thanhtien = a.thanhtien().ToString();
                
                b.sohd = x.sohd;               
                b.soban = x.soban.ToString();
                b.ngaylaphd = x.ngaylaphd.ToString();
                b.tenkh = x.tenkh;
                ds.Add(b);
            }
            return ds;
        }


    }
}
