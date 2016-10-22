using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webapp.Models
{
    public class TinhLuong
    {
        public int id { get; set; }
        public virtual NhanVien nhan_vien { get; set; }
        public virtual DonVi don_vi { get; set; }
        public virtual ChucVu chuc_vu { get; set; }
        public virtual HeSoLuong he_so_luong { get; set; }
        public DateTime ngay_bat_dau { get; set; }
        public DateTime? ngay_ket_thuc { get; set; }
    }
}
