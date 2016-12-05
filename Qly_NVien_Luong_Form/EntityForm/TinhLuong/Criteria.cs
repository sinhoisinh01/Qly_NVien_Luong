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
using Qly_Luong_NVien_Service;

namespace Qly_NVien_Luong_Form.FormOnly.TinhLuong
{
    public partial class Criteria : Form
    {
        protected Qly_Luong_NVien_Model.TinhLuong tinhLuong = null;
        protected Qly_Luong_NVien_Model.NhanVien nhanVien = null;

        protected ChucVuService chucVuService = new ChucVuService();
        protected HeSoLuongService heSoLuongService = new HeSoLuongService();
        protected DonViService donViService = new DonViService();

        public Criteria(Qly_Luong_NVien_Model.NhanVien nhanVien)
        {
            InitializeComponent();
            this.nhanVien = nhanVien;
        }

        protected Criteria()
        {
            InitializeComponent();
            loadData();
        }

        /*Tải dữ liệu*/
        private void loadData()
        {
            IList<ChucVu> chucVus = chucVuService.findAll().ToList();
            cbxChucVu.DataSource = chucVus;
            cbxChucVu.ValueMember = "id";
            cbxChucVu.DisplayMember = "ten_chuc_vu";

            IList<HeSoLuong> heSoLuongs = heSoLuongService.findAll().ToList();
            cbxHeSoLuong.DataSource = heSoLuongs;
            cbxHeSoLuong.ValueMember = "id";
            cbxHeSoLuong.DisplayMember = "he_so";

            IList<DonVi> donVis = donViService.findAll().ToList();
            cbxDonVi.DataSource = donVis;
            cbxDonVi.ValueMember = "id";
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

        //Cách hiển thị
        private void cbxHeSoLuong_Format(object sender, ListControlConvertEventArgs e)
        {
            var heSo = ((HeSoLuong)e.ListItem).he_so;
            var ngach = ((HeSoLuong)e.ListItem).ngach.ten_ngach;
            e.Value = heSo + " / " + ngach;
        }
    }
}
