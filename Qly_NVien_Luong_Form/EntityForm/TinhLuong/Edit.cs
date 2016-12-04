using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qly_NVien_Luong_Form.FormOnly;
using Qly_Luong_NVien_Service;

namespace Qly_NVien_Luong_Form.FormHandler.TinhLuong
{
    public partial class Edit : FormOnly.TinhLuong.Criteria
    {
        private TinhLuongService tinhLuongService = new TinhLuongService();

        public Edit(object id):base()
        {
            //Query dữ liệu lên
            base.tinhLuong = tinhLuongService.find((int) id);

            //Đưa dữ liệu query vào form
            setDataToForm();

            //Constructor này đã được override
            this.Text = "Sửa";
        }

        private void setDataToForm()
        {
            this.cbxChucVu.SelectedItem = base.tinhLuong.chuc_vu;
            this.cbxDonVi.SelectedItem = base.tinhLuong.don_vi;
            this.cbxHeSoLuong.SelectedItem = base.tinhLuong.he_so_luong;
            this.dteDenNgay.Value = base.tinhLuong.ngay_ket_thuc != null? base.tinhLuong.ngay_ket_thuc.Value: DateTime.Now;
            this.dteTuNgay.Value = base.tinhLuong.ngay_bat_dau;
        }
    }
}
