using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.DTO
{
    [Serializable]
    class MeNuDTO
    {
        private string ma;
        private string ten;
        private float gia;
        private string ban;
      
        public string MaMon
        { 
            get { return ma; }
            set { ma = value; }
        }
        public string TenMon
        {
            get { return ten; }
            set { ten = value; }
        }
        public float GiaTien { get => gia; set => gia = value; }
        public string Ban { get => ban; set => ban = value; }
      

        public MeNuDTO()
        {
            MaMon = " ";
            TenMon = " ";
            GiaTien = 0;         
            ban = "";
        
        }
        public MeNuDTO(string ma, string ten, float gia, int soluong,string ban)
        {
            MaMon = ma;
            TenMon = ten;
            GiaTien = gia;         
            Ban = ban;         
        }    
    }
}
