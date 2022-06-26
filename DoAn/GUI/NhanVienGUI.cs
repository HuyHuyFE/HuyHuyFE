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
    public partial class NhanVienGUI : Form
    {
        MeNuBUS cfBUS = new MeNuBUS();
        private List<MeNuDTO> capheList;
       
        public NhanVienGUI()
        {
            InitializeComponent();
        }
        private void hienthi()
        {

        }
        private void NhanVienGUI_Load(object sender, EventArgs e)
        {
            capheList = new List<MeNuDTO>();
           
        }

        private void rbGoiMon_Click(object sender, EventArgs e)
        {
            frmOrder oder = new frmOrder();
            oder.Show();
        }

        private void rbDSMon_Click(object sender, EventArgs e)
        {
            frmCaFe cf = new frmCaFe();
            cf.Show();
        }
    }
}
