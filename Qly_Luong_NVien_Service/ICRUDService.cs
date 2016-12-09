using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qly_Luong_NVien_Service
{
    /**
     * T kiểu dữ liệu muốn tương tác
     * ID kiểu để truy vấn dữ liệu
     * */
    interface ICRUDService<ENTITY, ID> where ENTITY: class
    {
        void add(ENTITY entity); //Thêm
        void remove(ENTITY entity); //Xóa theo entity
        void remove(IEnumerable<ENTITY> entities); //Xóa theo danh sách
        IEnumerable<ENTITY> findAll(); //Truy vấn tất cả
        ENTITY find(ID id); //Truy vấn theo id
        void update(ENTITY entity); //Cập nhập
    }
}
