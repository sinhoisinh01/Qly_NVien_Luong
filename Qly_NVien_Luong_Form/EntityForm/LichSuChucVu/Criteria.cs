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

namespace Qly_NVien_Luong_Form.EntityForm.LichSuChucVu
{
    public partial class Criteria : Form
    {
        protected NhanVienLuongDBContext dbContext = new NhanVienLuongDBContext();

        protected Qly_Luong_NVien_Model.LichSuChucVu lichSuChucVu = null;
        protected Qly_Luong_NVien_Model.NhanVien nhanVien = null;

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

            IList<DonVi> donVis = dbContext.don_vi.ToList();
            cbxDonVi.DataSource = donVis;
            cbxDonVi.ValueMember = "id";
            cbxDonVi.DisplayMember = "ten_goi";
        }

        //Binding dữ liệu vào đối tượng
        private void bindingData()
        {
            if (lichSuChucVu == null)
                lichSuChucVu = new Qly_Luong_NVien_Model.LichSuChucVu();
            this.lichSuChucVu.chuc_vu = (ChucVu)this.cbxChucVu.SelectedItem;
            this.lichSuChucVu.don_vi = (DonVi)this.cbxDonVi.SelectedItem;
            // Changed
            //this.LichSuChucVu.he_so_luong = (HeSoLuong)this.cbxHeSoLuong.SelectedItem;            
            this.lichSuChucVu.ngay_bat_dau = this.dteTuNgay.Value.Date;
            if (chbLamHienTai.Checked)
                this.lichSuChucVu.ngay_ket_thuc = null;
            else
            {                
                this.lichSuChucVu.ngay_ket_thuc = this.dteDenNgay.Value.Date;
                if (this.lichSuChucVu.ngay_ket_thuc.Value.Date == DateTime.Now.Date)
                    this.lichSuChucVu.ngay_ket_thuc = null;
            }
            this.lichSuChucVu.nhan_vien = this.nhanVien;
        }

        /*Validate dữ liệu*/
        private void validateData()
        {
            //Nếu như dữ liệu thì set thuộc tính nhanVien về null để không thêm vào database
            if (this.lichSuChucVu.don_vi == null) {
                this.lichSuChucVu = null;
                return;
            } else if (this.lichSuChucVu.chuc_vu == null) {
                this.lichSuChucVu = null;
                return;
            }

            if(this.lichSuChucVu.ngay_bat_dau.Date >= DateTime.Now.Date)
            {
                this.lichSuChucVu = null;
                return;
            }

            if(this.lichSuChucVu.ngay_ket_thuc != null)
            {
                if (this.lichSuChucVu.ngay_ket_thuc.Value.Date > DateTime.Now.Date)
                {
                    this.lichSuChucVu = null;
                    return;
                }
            }

            if(this.lichSuChucVu.ngay_bat_dau.Date >= (this.lichSuChucVu.ngay_ket_thuc == null? DateTime.Now.Date: this.lichSuChucVu.ngay_ket_thuc.Value.Date))
            {
                this.lichSuChucVu = null;
                return;
            }
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

        //Bấm vào nút check
        private void chbLamHienTai_CheckedChanged(object sender, EventArgs e)
        {
            if (chbLamHienTai.Checked)
                dteDenNgay.Enabled = false;
            else
                dteDenNgay.Enabled = true;
        }
    }
}
