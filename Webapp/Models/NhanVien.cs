using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webapp.Models
{
    public class NhanVien
    {
        public int id { get; set; }
        public string ma_so { get; set; }
        public string ho { get; set; }
        public string ten { get; set; }
        public bool gioi_tinh { get; set; }
        public DateTime ngay_sinh { get; set; }
        public string dan_toc { get; set; }
        public string dia_chi { get; set; }
        public string cmnd { get; set; }
        public string hinh_anh { get; set; }
        public DateTime ngay_vao_lam { get; set; }
        public DateTime? ngay_nghi_lam { get; set; }
    }
}
