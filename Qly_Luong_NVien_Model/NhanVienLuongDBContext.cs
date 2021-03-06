﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qly_Luong_NVien_Model
{
    public class NhanVienLuongDBContext : DbContext
    {
        public DbSet<NhanVien> nhan_vien { get; set; }
        public DbSet<Ngach> ngach { get; set; }
        public DbSet<ChucVu> chuc_vu { get; set; }
        public DbSet<DonVi> don_vi { get; set; }
        public DbSet<HeSoLuong> he_so_luong { get; set; }
        public DbSet<LichSuChucVu> lich_su_chuc_vu { get; set; }
        public DbSet<LichSuNgach> lich_su_ngach { get; set; }
        public DbSet<HangSo> hang_so { get; set; }
    }
}
