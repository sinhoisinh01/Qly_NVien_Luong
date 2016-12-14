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

namespace Qly_NVien_Luong_Form.EntityForm.TinhLuong
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
            loadData();
        }

        /*Tải dữ liệu*/
        private void loadData()
        {
            IList<ChucVu> chucVus = dbContext.chuc_vu.ToList();
            cbxChucVu.DataSource = chucVus;
            cbxChucVu.ValueMember = "id";
            cbxChucVu.DisplayMember = "ten_chuc_vu";
            if (tinhLuong != null)
                if(tinhLuong.chuc_vu != null)
                    cbxChucVu.SelectedItem = tinhLuong.chuc_vu;
            else
                cbxChucVu.SelectedIndex = 0;

            IList<HeSoLuong> heSoLuongs = dbContext.he_so_luong.ToList();
            cbxHeSoLuong.DataSource = heSoLuongs;
            cbxHeSoLuong.ValueMember = "id";
            cbxHeSoLuong.DisplayMember = "he_so";
            if (tinhLuong != null)
                if (tinhLuong.he_so_luong != null)
                    cbxHeSoLuong.SelectedItem = tinhLuong.he_so_luong;
                else
                    cbxHeSoLuong.SelectedIndex = 0;

            IList<DonVi> donVis = dbContext.don_vi.ToList();
            cbxDonVi.DataSource = donVis;
            cbxDonVi.ValueMember = "id";
            cbxDonVi.DisplayMember = "ten_goi";
            if (tinhLuong != null)
                if (tinhLuong.don_vi != null)
                    cbxDonVi.SelectedItem = tinhLuong.don_vi;
                else
                    cbxDonVi.SelectedIndex = 0;
        }

        //Binding dữ liệu vào đối tượng
        private void bindingData()
        {            
            this.tinhLuong.chuc_vu = (ChucVu)this.cbxChucVu.SelectedItem;
            this.tinhLuong.don_vi = (DonVi)this.cbxDonVi.SelectedItem;
            this.tinhLuong.he_so_luong = (HeSoLuong)this.cbxHeSoLuong.SelectedItem;
            this.tinhLuong.he_so_luong.ngach = (this.cbxHeSoLuong.SelectedItem as HeSoLuong).ngach;
            this.tinhLuong.ngay_bat_dau = this.dteTuNgay.Value.Date;
            this.tinhLuong.ngay_bat_dau = this.dteDenNgay.Value.Date;
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
        public virtual void onSubmit(object sender, EventArgs e)
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
