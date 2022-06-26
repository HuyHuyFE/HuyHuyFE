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
    public partial class frmCaFe : Form
    {

        private MeNuBUS capheList;
        private string TenFile = "LUUDL.txt";
        public frmCaFe()
        {
            InitializeComponent();
        }
        private void hienthi(List<MeNuDTO> capheList)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = capheList;
            dgvCaPhe.DataSource = bs;
        }
        private void frmQuayOder_Load(object sender, EventArgs e)
        {          
            CTruycapDulieu.docFile(TenFile);          
            capheList = new MeNuBUS();
            hienthi(capheList.getDSCaFe());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            MeNuDTO cfDTO = new MeNuDTO();
            if (txtMaMon.Text == "")
            {
                MessageBox.Show("Bạn phải nhập Mã Món Ăn, Thức Uống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            cfDTO.MaMon = txtMaMon.Text;
            cfDTO.TenMon = txtTenMon.Text;
            cfDTO.GiaTien = int.Parse(txtGia.Text);
            capheList.themcf(cfDTO);
                hienthi(capheList.getDSCaFe());
        }

        private void dgvCaPhe_RowEnter(object sender, DataGridViewCellEventArgs e)
        {


            txtMaMon.Text = dgvCaPhe.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenMon.Text = dgvCaPhe.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtGia.Text = dgvCaPhe.Rows[e.RowIndex].Cells[2].Value.ToString();
            //foreach (DataGridViewRow r in dgvCaPhe.SelectedRows)
            //{
            //    string mamon = r.Cells[0].Value.ToString();
            //    MeNuDTO cfDTO = capheList.timCf(mamon);
            //    if (cfDTO != null)
            //    {
            //        txtMaMon.Text = cfDTO.MaMon;
            //        txtTenMon.Text = cfDTO.TenMon;
            //        txtGia.Text = cfDTO.GiaTien.ToString();
            //        break;
            //    }
            //}
         }

        private void dgvCaPhe_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvCaPhe.SelectedRows)
            {
                string mamon = r.Cells[0].Value.ToString();
                foreach (MeNuDTO a in capheList.getDSCaFe())
                {
                    if (a.MaMon == mamon)
                    {
                        txtMaMon.Text = a.MaMon;
                        txtTenMon.Text = a.TenMon;
                        txtGia.Text = a.GiaTien.ToString();
                        return;

                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            MeNuDTO cfDTO = new MeNuDTO();
            cfDTO.MaMon = txtMaMon.Text;
            cfDTO.TenMon = txtTenMon.Text;
            cfDTO.GiaTien = float.Parse(txtGia.Text);
            capheList.sua(cfDTO);
            hienthi(capheList.getDSCaFe());
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

        

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            MeNuDTO cfDTO = new MeNuDTO();
            cfDTO.MaMon = txtMaMon.Text;
            cfDTO.TenMon = txtTenMon.Text;
            cfDTO.GiaTien = float.Parse(txtGia.Text);
            capheList.sua(cfDTO);
            hienthi(capheList.getDSCaFe());
        }

            private void btnThoat_Click_1(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn muốn thoát?",
             "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.Yes)
            {
                Close();
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow r in dgvCaPhe.SelectedRows)
            //{
            //    //if (r.Cells[0].Value == null)
            //    //    break;
            //    string mamon = r.Cells[0]Value.ToString();
            //    capheList.xoa(mamon);
            //}
            //hienthi(capheList.getDSCaFe());
            capheList.xoa(txtMaMon.Text);
            hienthi(capheList.getDSCaFe());
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (CTruycapDulieu.ghiFile(TenFile))
            {
                MessageBox.Show(" Ghi Dữ Liệu Thành Công!!");
            }
            else
                MessageBox.Show(" Không Ghi Được Dữ Liệu!!!!");
        }
    }
}
