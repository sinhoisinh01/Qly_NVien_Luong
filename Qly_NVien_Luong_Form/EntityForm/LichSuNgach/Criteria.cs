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
using System.Data.Entity;

namespace Qly_NVien_Luong_Form.EntityForm.LichSuNgach
{
    public partial class Criteria : Form
    {
        protected NhanVienLuongDBContext dbContext = new NhanVienLuongDBContext();

        protected Qly_Luong_NVien_Model.LichSuNgach lichSuNgach = null;
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
            IList<Ngach> chucVus = dbContext.ngach.ToList();
            cbxNgach.DataSource = chucVus;
            cbxNgach.ValueMember = "id";
            cbxNgach.DisplayMember = "ten_ngach";
        }

        //Binding dữ liệu vào đối tượng
        private void bindingData()
        {
            if (lichSuNgach == null)
                lichSuNgach = new Qly_Luong_NVien_Model.LichSuNgach();
            this.lichSuNgach.he_so_luong = (Qly_Luong_NVien_Model.HeSoLuong)cbxBac.SelectedItem;
            // Changed
            //this.LichSuChucVu.he_so_luong = (HeSoLuong)this.cbxHeSoLuong.SelectedItem;            
            this.lichSuNgach.ngay_bat_dau = this.dteNgayBatDau.Value.Date;
            if (chbLamHienTai.Checked)
                this.lichSuNgach.ngay_ket_thuc = null;
            else
            {
                this.lichSuNgach.ngay_ket_thuc = this.dteNgayKetThuc.Value.Date;
                if (this.lichSuNgach.ngay_ket_thuc.Value == DateTime.Now.Date)
                    this.lichSuNgach.ngay_ket_thuc = null;
            }
            this.lichSuNgach.nhan_vien = this.nhanVien;
        }

        /*Validate dữ liệu*/
        private void validateData()
        {
            //Nếu như dữ liệu thì set thuộc tính nhanVien về null để không thêm vào database
            if (this.lichSuNgach.he_so_luong == null) {
                this.lichSuNgach = null;
                return;
            }

            if (this.lichSuNgach.ngay_bat_dau.Date >= DateTime.Now.Date)
            {
                this.lichSuNgach = null;
                return;
            }

            if (this.lichSuNgach.ngay_ket_thuc != null)
            {
                if (this.lichSuNgach.ngay_ket_thuc.Value.Date > DateTime.Now.Date)
                {
                    this.lichSuNgach = null;
                    return;
                }
            }

            if (this.lichSuNgach.ngay_bat_dau >= (this.lichSuNgach.ngay_ket_thuc == null ? DateTime.Now.Date : this.lichSuNgach.ngay_ket_thuc.Value.Date))
            {
                this.lichSuNgach = null;
                return;
            }

            var isListExist = dbContext.lich_su_ngach.Where(
                lsn =>
                (   DbFunctions.TruncateTime(lichSuNgach.ngay_bat_dau) >= DbFunctions.TruncateTime(lsn.ngay_bat_dau) &&
                    DbFunctions.TruncateTime(lichSuNgach.ngay_bat_dau) <= DbFunctions.TruncateTime(lsn.ngay_ket_thuc)) 
                    ||
                (   DbFunctions.TruncateTime(lichSuNgach.ngay_ket_thuc == null? DateTime.Now: lichSuNgach.ngay_ket_thuc.Value) >= DbFunctions.TruncateTime(lsn.ngay_bat_dau) &&
                    DbFunctions.TruncateTime(lichSuNgach.ngay_ket_thuc == null ? DateTime.Now : lichSuNgach.ngay_ket_thuc.Value) <= DbFunctions.TruncateTime(lsn.ngay_ket_thuc))
            ).ToList().Count != 0;
            if (isListExist)
            {
                this.lichSuNgach = null;
                System.Windows.Forms.MessageBox.Show("Lịch sử ngạch được thêm / sửa đã bị trùng.");
                return;
            }
        }

        //Nhấn nút submit cập nhập dữ liệu
        public virtual void onSubmit(object sender, EventArgs e)
        {
            /*Binding dữ liệu*/
            bindingData();

            /*Validate dữ liệu*/
            validateData();
        }

        //Nhấn nút thoát
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Check vào vẫn làm đến hiện tại
        private void chbLamHienTai_CheckedChanged(object sender, EventArgs e)
        {
            if (chbLamHienTai.Checked)
                dteNgayKetThuc.Enabled = false;
            else
                dteNgayKetThuc.Enabled = true;
        }

        //Chọn ngạch khác
        private void cbxNgach_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ngach = (cbxNgach.SelectedItem as Ngach);
            if (ngach != null) {
                var idNgach = ngach.id;
                var bacList = dbContext.he_so_luong.Where(hsl => hsl.ngach.id == idNgach).ToList();
                cbxBac.DataSource = bacList;
            }
        }

        //Format cbx
        private void cbxBac_Format(object sender, ListControlConvertEventArgs e)
        {
            if(e.ListItem is HeSoLuong)
            {
                var val = (HeSoLuong)e.Value;
                /*
                var vuotKhungStr = "";
                if (val.vuot_khung == null)
                    vuotKhungStr = " / 0.0";
                else
                    vuotKhungStr = " / " + val.vuot_khung.Value;*/
                e.Value = "Bậc " + val.bac_luong /*+ " / Hệ số " + val.he_so + vuotKhungStr*/;     
            }
        }
    }
}
