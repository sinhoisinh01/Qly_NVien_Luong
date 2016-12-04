using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Qly_Luong_NVien_Model;

namespace Qly_NVien_Luong_Form.FormOnly.TinhLuong
{
    public partial class Criteria : Form
    {
        protected Qly_Luong_NVien_Model.TinhLuong tinhLuong = null;
        protected Qly_Luong_NVien_Model.NhanVien nhanVien = null;
        protected NhanVienLuongDBContext dbContext = new NhanVienLuongDBContext();

        public Criteria(Qly_Luong_NVien_Model.NhanVien nhanVien)
        {
            InitializeComponent();
            this.nhanVien = nhanVien;
        }

        protected Criteria()
        {
            InitializeComponent();
        }


        //Binding dữ liệu vào đối tượng
        private void bindingData()
        {
            this.tinhLuong.chuc_vu = (ChucVu)this.cbxChucVu.SelectedItem;
            this.tinhLuong.don_vi = (DonVi)this.cbxDonVi.SelectedItem;
            this.tinhLuong.he_so_luong = (HeSoLuong)this.cbxHeSoLuong.SelectedItem;
            this.tinhLuong.ngay_bat_dau = this.dteTuNgay.Value;
            this.tinhLuong.ngay_bat_dau = this.dteDenNgay.Value;
            this.tinhLuong.nhan_vien = this.nhanVien;
        }

        /*Validate dữ liệu*/
        private void validateData()
        {
            //Nếu như dữ liệu thì set thuộc tính nhanVien về null để không thêm vào database
        }

        //Đóng form
        private void onClose(object sender, EventArgs e)
        {
            this.Close();
        }
        
        //Nhấn nút submit form
        protected void onSubmit(object sender, EventArgs e)
        {
            /*Binding dữ liệu*/
            bindingData();

            /*Validate dữ liệu*/
            validateData();
        }
        
    }
}
