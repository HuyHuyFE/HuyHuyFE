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
    public partial class frmNhanVien : Form
    {
        private NhanVienBUS nhanvienList;
        public frmNhanVien()
        {
            InitializeComponent();
        }
        private void hienthi(List<NhanVienDTO> nhanvienList)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = nhanvienList;
            dgvNhanVien.DataSource = bs;
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            nhanvienList = new NhanVienBUS();
            if (nhanvienList.docFile("nhanvien.dat") == false)
                MessageBox.Show(" Không Đọc Được!!");
            hienthi(nhanvienList.getDSNhanVien());
        }       

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO();
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Bạn phải nhập Mã Nhân Viên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            nv.MaNV = txtMaNV.Text;
            nv.TenNV = txtTenNV.Text;
            nv.NgaySinh = dtpNgaySinh.Value;
            nv.DiaChi = txtDiaChi.Text;
            nv.Phai = radNam.Checked;
            nv.SoDienThoai = txtSoDienThoai.Text;
            nv.LuongCa = txtLuongCa.Text;
            nv.Khuvuc = cbKhuVuc.Text;
            if (nhanvienList.themNV(nv) == true)
                hienthi(nhanvienList.getDSNhanVien());
            else
                MessageBox.Show("Mã đã có! Không thể thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvNhanVien.SelectedRows)
            {
                if (r.Cells[0].Value == null)
                    break;
                string MaNV =r.Cells[0].Value.ToString();
                nhanvienList.xoaNV(MaNV);
            }
            hienthi(nhanvienList.getDSNhanVien());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            NhanVienDTO nv = new NhanVienDTO();
            nv.MaNV = txtMaNV.Text;
            nv.TenNV = txtTenNV.Text;
            nv.NgaySinh = dtpNgaySinh.Value;
            nv.DiaChi = txtDiaChi.Text;
            nv.Phai = radNam.Checked;
            nv.SoDienThoai = txtSoDienThoai.Text;
            nv.LuongCa = txtLuongCa.Text;
            nv.Khuvuc = cbKhuVuc.Text;
            nhanvienList.suaNV(nv);
            hienthi(nhanvienList.getDSNhanVien());
        }

        private void btnLuuFile_Click(object sender, EventArgs e)
        {

            if (nhanvienList.ghiFile("nhanvien.dat") == true)
            {
                MessageBox.Show(" Ghi Dữ Liệu Thành Công!!");
            }
            else
                MessageBox.Show(" Không Ghi Được Dữ Liệu!!!!");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn thoát?",
              "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                Close();
            }       
        }

        private void dgvNhanVien_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.Text = dgvNhanVien.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenNV.Text = dgvNhanVien.Rows[e.RowIndex].Cells[1].Value.ToString();
           // dtpNgaySinh.Value = Convert.ToDateTime(dgvNhanVien.Rows[e.RowIndex].Cells[2].Value);
            if (dgvNhanVien.Rows[e.RowIndex].Cells[3].Value.ToString() == "True")
                radNam.Checked = true;
            else
                radNu.Checked = true;
            txtDiaChi.Text = dgvNhanVien.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSoDienThoai.Text = dgvNhanVien.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtLuongCa.Text = dgvNhanVien.Rows[e.RowIndex].Cells[6].Value.ToString();
            cbKhuVuc.Text= dgvNhanVien.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void dgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvNhanVien.SelectedRows)
            {
                string ma = r.Cells[0].Value.ToString();
                foreach (NhanVienDTO a in nhanvienList.getDSNhanVien())
                {
                    if (a.MaNV == ma)
                    {
                        txtMaNV.Text = a.MaNV;
                        txtTenNV.Text = a.TenNV;
                        dtpNgaySinh.Value = a.NgaySinh;
                        txtDiaChi.Text = a.DiaChi;
                        txtSoDienThoai.Text = a.SoDienThoai;
                        cbKhuVuc.Text = a.Khuvuc;
                        radNam.Checked = a.Phai;
                        return;

                    }
                }
            }
        }
    }
}
