using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAn.BUS;
using DoAn.DTO;

namespace DoAn.GUI
{

    public partial class frmOrder : Form
    {
        private MeNuBUS xlMenu;
        private OrderBUS xlOrder;
        private OrderDTO oode;
        

        public frmOrder()
        {
            InitializeComponent();
        }
        private void hienthiDSOrder(List<OrderDTO> capheList)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = capheList;
            dgvOrder.DataSource = bs;
        }
        private void CNhanVien_Load(object sender, EventArgs e)
        {
            oode = new OrderDTO();
            xlOrder = new OrderBUS();
            xlMenu = new MeNuBUS();            
            hienthiDSOrder(xlOrder.getDSOrder());
            hienThiDSMon(xlMenu.getDSCaFe());
        }
        private void hienThiDSMon(List<MeNuDTO> meNuDTOs)
        {
            //BindingSource bs = new BindingSource();
            //bs.DataSource = xlMenu.getDSCaFe();
            cbCaFe.DisplayMember = "TenMon"; // hiển thị lên giao diện
            cbCaFe.ValueMember = "TenMon"; // tính toán
            cbCaFe.DataSource = meNuDTOs;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            if (cbCaFe.Text == "")
            {
                MessageBox.Show("Bạn phải nhập Mã Món Ăn, Thức Uống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string tenMon = cbCaFe.SelectedValue.ToString();
            CChitiet ct = new CChitiet();
            ct.menu = xlMenu.timCf(tenMon);
            ct.soluong = int.Parse(txtSoLuong.Text);
            ct.dongia = int.Parse(txtGia.Text);
            
            oode.chitiet.Add(ct);
            hienthi(oode);
        }
        private void hienthi(OrderDTO a)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = OrderView.chuyendoi(a);
            dgvOrder.DataSource = bs;
        }

        private void cbCaFe_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tenMon = cbCaFe.SelectedValue.ToString();
            MeNuDTO a = xlMenu.timMon(tenMon);
            txtGia.Text = a.GiaTien.ToString();
            txtSoBan.Text = a.Ban.ToString();
            txtSoLuong.Text = "1";
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            OrderBUS sv = new OrderBUS();
            bool flag = false;
            foreach (MeNuDTO a in xlMenu.getDSCaFe())
            {
                if (a.TenMon == txtTim.Text)
                {
                    MessageBox.Show("Tìm thấy Món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flag = true;
                    return;
                }
            }
            if (flag == false)
            {
                MessageBox.Show("Không tìm thấy ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn thoát chương trình?",
              "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            oode.sohd = txtSoHD.Text;
            oode.soban = int.Parse(txtSoBan.Text);
            oode.ngaylaphd = dtpNgay.Value;
            oode.tenkh = txtTenKH.Text;
            if (xlOrder.themHD(oode) == true)
            {
                hienthiDSHoadon(xlOrder.getDSOrder());
                oode = new OrderDTO();// lập hóa đơn tiếp theo
                hienthi(oode);
            }
            else
            {
                MessageBox.Show(" Hóa Đơn Đã Tồn Tại!!!");
            }
        }
        private void hienthiDSHoadon(List<OrderDTO> ds)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = ds;
            dgvHoaDon.DataSource = bs;
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            CTruycapDulieu data = CTruycapDulieu.khoitao();
            if (data.ghiDuLieu("hoadon.dat") == true)
                MessageBox.Show("Ghi dữ liệu thành công!");
            else MessageBox.Show("Không ghi được dữ liệu lên file!");

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvHoaDon.SelectedRows)
            {
                string sohd = r.Cells[0].Value.ToString();
                frmXemHoaDon f = new frmXemHoaDon();
                OrderDTO x = xlOrder.timHD(sohd);
                f.hoadon = x;
                f.ShowDialog();
                break;
            }
        }
    }
}
