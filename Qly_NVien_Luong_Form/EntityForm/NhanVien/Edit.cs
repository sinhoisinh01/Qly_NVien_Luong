using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qly_NVien_Luong_Form.FormOnly.NhanVien;
using System.Data.Entity;
using Qly_Luong_NVien_Service;

namespace Qly_NVien_Luong_Form.FormHandler.NhanVien
{
    public partial class Edit : Criteria
    {
        private NhanVienService nhanVienService = new NhanVienService();

        public Edit(object id):base()
        {
            //Query dữ liệu lên            
            if(id != null)
                base.nhanVien = base.dbContext.nhan_vien.Find(id);
            else throw new ArgumentNullException();

            //Set dữ liệu vào form
            setDataToForm();
        }

        /*Set dữ liệu vào form sau khi truy vấn*/
        private void setDataToForm()
        {
            base.texMaSo.Text = base.nhanVien.ma_so;
            base.texDanToc.Text = base.nhanVien.dan_toc;
            base.texCMND.Text = base.nhanVien.cmnd;
            base.texDiaChi.Text = base.nhanVien.dia_chi;
            base.texHinhAnh.Text = base.nhanVien.hinh_anh;
            base.texTen.Text = base.nhanVien.ten;
            base.texHo.Text = base.nhanVien.ho;
            base.dteNgaySinh.Value = base.nhanVien.ngay_sinh;
            base.dteNgayNghi.Value = base.nhanVien.ngay_nghi_lam != null? base.nhanVien.ngay_nghi_lam.Value: DateTime.Now;
            base.dteNgayLam.Value = base.nhanVien.ngay_vao_lam;
        }

        private void overrideInitComp()
        {
            base.btnSubmit.Text = "Cập nhập";
            base.Text = "Sửa thông tin nhân viên";
        }

        private void onSubmit(object sender, EventArgs e)
        {
            base.onSubmit(sender, e);

            /*Cập nhập database*/
            if(base.nhanVien != null)
            {
                nhanVienService.update(base.nhanVien);
                base.Close(); //Đóng form
            }
        }
    }
}
