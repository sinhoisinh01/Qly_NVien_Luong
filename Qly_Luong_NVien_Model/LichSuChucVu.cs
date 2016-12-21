using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qly_Luong_NVien_Model
{
    public class LichSuChucVu
    {
        public int id { get; set; }
        public virtual NhanVien nhan_vien { get; set; }
        public virtual DonVi don_vi { get; set; }
        public virtual ChucVu chuc_vu { get; set; }
        public DateTime ngay_bat_dau { get; set; }
        public DateTime? ngay_ket_thuc { get; set; }
    }
}
