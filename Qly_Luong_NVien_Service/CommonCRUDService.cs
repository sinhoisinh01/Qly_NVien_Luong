using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qly_Luong_NVien_Model;
using System.Data.Entity;

namespace Qly_Luong_NVien_Service
{
    public abstract class CommonCRUDService<ENTITY, ID> : ICRUDService<ENTITY, ID>
        where ENTITY: class
    {
        private Qly_Luong_NVien_Model.NhanVienLuongDBContext dbContext;
        protected DbSet dbSet = null;

        public CommonCRUDService()
        {
            dbContext = new NhanVienLuongDBContext();
            dbSet = detectedClassDbSet();
        }
        
        //Lấy dbSet phụ thuộc theo class
        private DbSet detectedClassDbSet()
        {
            var className = assignedClass().Name;
            switch(className)
            {
                case "ChucVu":
                    return dbContext.chuc_vu;
                    break;
                case "DonVi":
                    return dbContext.don_vi;
                    break;
                case "HangSo":
                    return dbContext.hang_so;
                    break;
                case "HeSoLuong":
                    return dbContext.he_so_luong;
                    break;
                case "Ngach":
                    return dbContext.ngach;
                    break;
                case "NhanVien":
                    return dbContext.nhan_vien;
                    break;
                case "TinhLuong":
                    return dbContext.tinh_luong;
                    break;
                default:
                    throw new FormatException("CommonCRUDService không hỗ trợ! Hãy cài đặt thêm ở method detectClass()");
                    break;
            }
        }

        //Yêu cầu cài đặt class trả về
        protected abstract Type assignedClass();

        public void add(ENTITY entity)
        {
            dbSet.Add(entity);
            dbContext.SaveChanges();
        }

        public void remove(ENTITY entity)
        {
            dbSet.Remove(entity);
        }

        public void remove(IEnumerable<ENTITY> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public IEnumerable<ENTITY> findAll()
        {
            return dbContext.Set<ENTITY>();
        }

        public ENTITY find(ID id)
        {
            return (ENTITY)dbSet.Find(id);
        }

        public void update(ENTITY entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
