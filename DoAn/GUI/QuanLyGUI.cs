using DoAn.BUS;
using DoAn.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn.GUI
{
    public partial class QuanLyGUI : Form
    {
        MeNuBUS cfBUS = new MeNuBUS();
        private List<MeNuDTO>capheList;
        NhanVienBUS nvBUS = new NhanVienBUS();
        private List<NhanVienDTO>nhanvienList;
       
        public QuanLyGUI()
        {
            InitializeComponent();
        }
        private void hienthi()
        {
           
        }

        private void CaFeGUI_Load(object sender, EventArgs e)
        {
            capheList = new List<MeNuDTO>();
            nhanvienList = new List<NhanVienDTO>();
          
        }

        private void btnThemRib_Click(object sender, EventArgs e)
        {
            frmCaFe oder = new frmCaFe();
            oder.Show();
           
        }

        //private void btnSuaRib_Click(object sender, EventArgs e)
        //{
        //    frmQuayOder oder = new frmQuayOder();
        //    oder.Show();
        //}

        //private void btnXoaRib_Click(object sender, EventArgs e)
        //{
        //    frmQuayOder oder = new frmQuayOder();
        //    oder.Show();
        //}

        private void rbQuanLyNV_Click(object sender, EventArgs e)
        {
            frmNhanVien nv = new frmNhanVien();
            nv.Show();
        }

        private void rbQuanLyKho_Click(object sender, EventArgs e)
        {

        }

        private void rbQuanLyBan_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ribbonButton8_Click(object sender, EventArgs e)
        {
            frmDoanhThu doanhthu = new frmDoanhThu();
            doanhthu.Show();
        }

        private void rbNuocNgot_Click(object sender, EventArgs e)
        {
           
        }

        private void rbNuocPhaChe_Click(object sender, EventArgs e)
        {
           
        }

        private void rbKem_Click(object sender, EventArgs e)
        {
           
        }

        private void ribbonPanel9_Click(object sender, EventArgs e)
        {
            frmOrder oder = new frmOrder();
            oder.Show();
        }

        private void btnDSNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien nv = new frmNhanVien();
            nv.Show();
        }
    }
}
