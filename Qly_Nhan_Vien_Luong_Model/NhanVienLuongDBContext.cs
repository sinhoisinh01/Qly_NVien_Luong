using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qly_Nhan_Vien_Luong_Model
{
    public class NhanVienLuongDBContext : DbContext
    {
        public DbSet<NhanVien> nhan_vien { get; set; }
        public DbSet<Ngach> ngach { get; set; }
        public DbSet<ChucVu> chuc_vu { get; set; }
        public DbSet<DonVi> don_vi { get; set; }
        public DbSet<HeSoLuong> he_so_luong { get; set; }
        public DbSet<TinhLuong> tinh_luong { get; set; }
    }
}
