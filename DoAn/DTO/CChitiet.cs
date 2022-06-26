using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
    [Serializable]
    class CChitiet
    {
        private int m_soluong;
        private double m_dongia;
        private MeNuDTO m_menu;
        private OrderDTO m_order;
        public int soluong
        {
            get { return m_soluong; }
            set { m_soluong = value; }
        }
        public double dongia
        {
            get { return m_dongia; }
            set { m_dongia = value; }
        }
        public MeNuDTO menu
        {
            get { return m_menu; }
            set { m_menu = value; }
        }
        public OrderDTO order
        {
            get { return m_order; }
            set { m_order = value; }
        }
        public CChitiet()
        {
            m_order = null;
            m_menu = null;
            m_soluong = 0;
            m_dongia = 0;
        }
        public CChitiet(MeNuDTO menu, OrderDTO order,int soluong, double dongia)
        {
            m_order = order;
            m_menu = menu;
            m_soluong = soluong;
            m_dongia = dongia;
        }
        public double thanhtien()
        {
            return m_soluong * m_dongia;
        }
    }
}
