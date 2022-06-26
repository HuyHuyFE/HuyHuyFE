using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn.DTO;
using DoAn.BUS;

namespace DoAn.GUI
{
    public partial class frmXemHoaDon : Form
    {
        private OrderBUS xlOrder;
        public object hoadon;
        public frmXemHoaDon()
        {
            InitializeComponent();
        }

        private void frmXemHoaDon_Load(object sender, EventArgs e)
        {
            OrderDTO hd = hoadon as OrderDTO; // ép kiểu
            hienthiHoaDon(hd);
            txtSoHD.Text = hd.sohd;
            txtSoBan.Text = hd.soban.ToString();
            dtpNgay.Value = hd.ngaylaphd;
            txtTenKH.Text = hd.tenkh;
        }
        private void hienthiHoaDon(OrderDTO a)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = OrderView.chuyendoi(a);
            dgvOrder.DataSource = bs;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            OrderDTO a = new OrderDTO();
            txtThanhTien.Text = xlOrder.tinhTongThanhTien().ToString();
            if (xlOrder.them(a) == false)
                MessageBox.Show("Đã tính tổng tiền!");
            else
                hienthiDSOrder(xlOrder.getDSOrder());

        }
        private void hienthiDSOrder(List<OrderDTO> capheList)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = capheList;
            dgvOrder.DataSource = bs;
        }
    }
}
