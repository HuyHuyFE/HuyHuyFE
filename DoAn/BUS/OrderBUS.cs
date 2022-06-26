using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using DoAn.DTO;

namespace DoAn.BUS
{
    class OrderBUS
    {
        private List<OrderDTO> dsOrder;

        public OrderBUS()
        {
            CTruycapDulieu data = CTruycapDulieu.khoitao();
            dsOrder = data.getDSOrder();
        }
        public List<OrderDTO>getDSOrder()
        {
            return dsOrder;
        }
        public OrderDTO timCff(string ma)
        {
            foreach(OrderDTO a in dsOrder)
            {
                if (a.CaFe == ma)
                    return a;
            }
            return null;
        }
        public bool them(OrderDTO cafe)
        {
            if (timCff(cafe.CaFe) == null)
            {
                dsOrder.Add(cafe);
                return true;
            }

            else
                MessageBox.Show("Mã đã có không thể thêm!!");
            dsOrder.Add(cafe);
            return false;
        }
        public bool xoa(string ma)
        {
            OrderDTO t = timCff(ma);
            if (t == null) return false;
            dsOrder.Remove(t);
            return true;
        }
        public bool sua(OrderDTO cafe)
        {
            OrderDTO t = timCff(cafe.CaFe);
            if (t == null) return false;
            t.CaFe = cafe.CaFe;            
            t.GiaTien = cafe.GiaTien;
            t.SoLuong = cafe.SoLuong;          
            return true;
        }
        public bool ghiFile(string TenFile)
        {
            try
            {
                FileStream f = new FileStream(TenFile, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(f, dsOrder);
                f.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool docFile(string TenFile)
        {
            try
            {
                FileStream f = new FileStream(TenFile, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                dsOrder = bf.Deserialize(f) as List<OrderDTO>;
                f.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public OrderDTO timHD(string sohd)
        {
            foreach (OrderDTO a in dsOrder)
            {
                if (a.sohd == sohd) return a;
            }
            return null;
        }
        public bool themHD(OrderDTO a)
        {
            OrderDTO t = timHD(a.sohd);
            if (t == null)
            {
                dsOrder.Add(a);
                return true;
            }
            return false;
        }
        public double tinhTongThanhTien()
        {
            double sum = 0;
            foreach (OrderDTO b in dsOrder)
            {
                sum = sum + b.thanhtien();
            }
            return sum;
        }

    }
}
