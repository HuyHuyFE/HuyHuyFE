using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{


    [Serializable]
    public class NhanVienDTO
    {
        private string m_manv;
        private string m_tennv;
        private string m_diachi;
        private DateTime m_ngaysinh;
        private bool m_phai;
        private string m_sodienthoai;
        private string m_luongca;
        private string m_khuvuc;


        public NhanVienDTO(string manv, string tennv, string diachi, DateTime ngaysinh, bool phai, string sodienthoai, string luongca,string khuvuc)
        {
            m_manv = manv;
            m_tennv = tennv;
            m_diachi = diachi;
            m_ngaysinh = ngaysinh;
            m_phai = phai;
            m_sodienthoai = sodienthoai;
            m_luongca = luongca;
            m_khuvuc = khuvuc;
        }
        public NhanVienDTO()
        {
            m_manv = "";
            m_tennv = "";
            m_ngaysinh = DateTime.Now;
            m_phai = false;
            m_diachi = "";
            m_sodienthoai = "";
            m_luongca = "";
            m_khuvuc = "";
        }
        public string MaNV { get => m_manv; set => m_manv = value; }
        public string TenNV { get => m_tennv; set => m_tennv = value; }
        public string DiaChi { get => m_diachi; set => m_diachi = value; }
        public DateTime NgaySinh { get => m_ngaysinh; set => m_ngaysinh = value; }
        public bool Phai { get => m_phai; set => m_phai = value; }
        public string SoDienThoai { get => m_sodienthoai; set => m_sodienthoai = value; }
        public string LuongCa { get => m_luongca; set => m_luongca = value; }
        public string Khuvuc { get => m_khuvuc; set => m_khuvuc = value; }
    }
}



