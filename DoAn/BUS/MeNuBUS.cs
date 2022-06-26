using DoAn.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace DoAn.BUS
{
    
    class MeNuBUS
    {
        private  List<MeNuDTO> capheList;     
        public MeNuBUS()
        {
            CTruycapDulieu data = CTruycapDulieu.khoitao();
            capheList = data.getDSCaFe();         
        }
        public List<MeNuDTO> getDSCaFe()
        {
            return capheList;     
        }
        public void setDSMenu(List<MeNuDTO> ds)
        {
            this.capheList = ds;
        }
        public MeNuDTO timCf(string ten)
        {
            foreach( MeNuDTO a in capheList)
            {
                 if (a.TenMon == ten)
                    return a;
            }
            return null;
        }
        public MeNuDTO timMon(string tenMon)
        {
            foreach (MeNuDTO a in capheList)
            {
                if (a.TenMon == tenMon)
                    return a;
            }
            return null;
        }
        public void themcf(MeNuDTO cafe)
        {
            if (timCf(cafe.TenMon) == null)
                capheList.Add(cafe);
            else
                MessageBox.Show("Mã đã có không thể thêm!!");
        }
        public bool xoa(string ma)
        {
            MeNuDTO t = timCf(ma);
            if (t == null) return false;
            capheList.Remove(t);
            return true;    
        }
        public bool sua(MeNuDTO cafe)
        {
            MeNuDTO t = timCf(cafe.TenMon);
            if (t == null) return false;
            t.MaMon = cafe.MaMon;
            t.TenMon = cafe.TenMon;
            t.GiaTien = cafe.GiaTien;
            return true;
        }
        public bool ghiFile(string TenFile)
        {
            try
            {
                FileStream f = new FileStream(TenFile, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(f, capheList);
                f.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool docFile(string TenFile)
        {
            try
            {
                FileStream f = new FileStream(TenFile, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                capheList = bf.Deserialize(f) as List<MeNuDTO>;
                f.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
