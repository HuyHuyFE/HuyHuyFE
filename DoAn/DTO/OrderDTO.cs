using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
    [Serializable]
    class OrderDTO
    {
        private string m_sohd;
        private int m_soban;
        private DateTime m_ngaylaphd;
        private string m_tenkh;
        private string caFe;
        private int soLuong;
        private float giaTien;
       
        private List<CChitiet> m_chitiet;

        public OrderDTO(string sohd, int soban, DateTime ngaylaphd, string tenkh, string caFe, int soLuong, float giaTien, string banAn, DateTime dateTime)
            
        {
            m_sohd = sohd;
            m_soban = soban;
            m_ngaylaphd = ngaylaphd;
            m_tenkh = tenkh;
            this.caFe = caFe;
            this.soLuong = soLuong;
            this.giaTien = giaTien;
            
           m_chitiet = new List<CChitiet>();
        }
        public OrderDTO()
        {
            m_sohd = "";
            m_soban = 0;
            m_ngaylaphd = DateTime.Now;
            m_tenkh = "";
            caFe = "";
            soLuong = 0;
            giaTien = 0;
            
            m_chitiet = new List<CChitiet>();
        }
        public List<CChitiet> chitiet
        {
            get { return m_chitiet; }
        }
        public double thanhtien()
        {
            double total = 0;
            foreach (CChitiet cthd in m_chitiet)
            {
                total += cthd.thanhtien();
            }
            return total;
        }

        public string sohd
        {
            get { return m_sohd; }
            set { m_sohd = value; }
        }
        public int soban
        {
            get { return m_soban; }
            set { m_soban = value; }
        }
        public DateTime ngaylaphd
        {
            get { return m_ngaylaphd; }
            set { m_ngaylaphd = value; }
        }
        public string tenkh
        {
            get { return m_tenkh; }
            set { m_tenkh = value; }
        }
        public string CaFe { get => caFe; set => caFe = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public float GiaTien { get => giaTien; set => giaTien = value; }
       
    }
}
