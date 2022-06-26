using DoAn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DoAn.BUS
{
     class NhanVienBUS
    {
        private List<NhanVienDTO> nhanvienList;

        public NhanVienBUS()
        {
            nhanvienList = new List<NhanVienDTO>();
        }
        public List<NhanVienDTO>getDSNhanVien()
        {
            return nhanvienList;
        }
        public NhanVienDTO timNV(string ma)
        {
            foreach (NhanVienDTO a in nhanvienList)
            {
                if (a.MaNV == ma)
                    return a;
            }
            return null;
        }
        public bool themNV(NhanVienDTO nv)
        {
            NhanVienDTO t = timNV(nv.MaNV);
            if (t == null) 
            {
                nhanvienList.Add(nv);
                return true; 
            }
           
            return false;
        }
        public bool xoaNV(string ma)
        {
            NhanVienDTO t = timNV(ma);
            if (t == null) return false;
            else nhanvienList.Remove(t);
            return true;
        }
        public bool suaNV(NhanVienDTO nv)
        {
            NhanVienDTO t = timNV(nv.MaNV);
            if (t == null) return false;
            t.MaNV = nv.MaNV; ;
            t.TenNV=nv.TenNV;
            t.NgaySinh=nv.NgaySinh;
            t.Phai=nv.Phai;
            t.DiaChi = nv.DiaChi;
            t.SoDienThoai = nv.SoDienThoai;
            t.LuongCa = nv.LuongCa;
            t.Khuvuc = nv.Khuvuc;
            return true;
        }
        public bool ghiFile(string TenFile)
        {
            try
            {
                FileStream f = new FileStream(TenFile, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(f, nhanvienList);
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
                nhanvienList = bf.Deserialize(f) as List<NhanVienDTO>;
                f.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
