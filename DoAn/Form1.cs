using DoAn.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void dangnhap()
        {
            //if (txtTaiKhoan.Text.Length == 0 && txtMatKhau.Text.Length == 0)
            //    MessageBox.Show("Bạn chưa nhập tài khoản hoặc mật khẩu !!!");
            //else if (this.txtTaiKhoan.Text == "Admin" && this.txtMatKhau.Text == "Admin")
            //    return;
            //else if (this.txtTaiKhoan.Text == "NhanVien1" && this.txtMatKhau.Text == "NV1")
            //    return;
            //else if (this.txtTaiKhoan.Text == "NhanVien2" && this.txtMatKhau.Text == "NV2")
            //    return;
            //else MessageBox.Show(" Tài Khoản hoặc Mật Khẩu không đúng !!!");
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            frmCaFe order = new frmCaFe();
            QuanLyGUI cfGUI = new QuanLyGUI();
            //NhanVienGUI nvGUI = new NhanVienGUI();
            //if (this.txtTaiKhoan.Text == "Admin" && this.txtMatKhau.Text == "Admin")
            //{
               cfGUI.Show();

            //}
            //else if (this.txtTaiKhoan.Text == "NhanVien1" && this.txtMatKhau.Text == "NV1")
            //{

            //    nvGUI.Show();

            //}
            //dangnhap();

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

        private void anMK_Click(object sender, EventArgs e)
        {

            if (txtMatKhau.PasswordChar == '\0')
            {
                hienMK.BringToFront();
                txtMatKhau.PasswordChar = '*';
            }
        }

        private void hienMK_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '*')
            {
                anMK.BringToFront();
                txtMatKhau.PasswordChar = '\0';
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
