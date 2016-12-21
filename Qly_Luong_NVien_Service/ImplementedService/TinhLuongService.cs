using Qly_Luong_NVien_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qly_Luong_NVien_Service
{
    public class TinhLuongService : CommonCRUDService<LichSuChucVu, int>
    {
        protected override Type assignedClass()
        {
            return typeof(LichSuChucVu);
        }

        //Tìm theo nhân viên
        public ISet<LichSuChucVu> findByNhanVien(NhanVien nhanVien)
        {
            ISet<LichSuChucVu> ketQua = new HashSet<LichSuChucVu>();
            IList<LichSuChucVu> duLieu = new List<LichSuChucVu>(base.findAll().ToArray());
            foreach (var d in duLieu)
                if (nhanVien.id == d.id)
                    ketQua.Add(d);
            return ketQua;
        }

        //Tìm theo nhân viên và khoảng thời gian
        public ISet<LichSuChucVu> findByDateRange(NhanVien nhanVien, DateTime from, DateTime to)
        {
            ISet<LichSuChucVu> ketQua = new HashSet<LichSuChucVu>();
            IList<LichSuChucVu> duLieu = new List<LichSuChucVu>(base.findAll().ToArray());
            foreach (var d in duLieu)
            {
                if (nhanVien.id == d.id && d.ngay_bat_dau >= from && d.ngay_bat_dau <= to)
                    ketQua.Add(d);
            }
            return ketQua;
        }
    }
}
