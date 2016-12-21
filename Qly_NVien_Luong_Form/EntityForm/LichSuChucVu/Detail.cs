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

namespace Qly_NVien_Luong_Form.EntityForm.LichSuChucVu
{
    public partial class Detail : Form
    {
        private Qly_Luong_NVien_Model.NhanVienLuongDBContext dbContext = new NhanVienLuongDBContext();
        private Qly_Luong_NVien_Model.LichSuChucVu tinhLuong = null;

        public Detail(object id)
        {
            tinhLuong = dbContext.lich_su_chuc_vu.Find((int) id);
            InitializeComponent();
            loadDataToForm();
        }

        private void loadDataToForm()
        {
            if (tinhLuong == null)
                this.Close();

            lblChucVu.Text = tinhLuong.chuc_vu != null? tinhLuong.chuc_vu.ten_chuc_vu: "Không có";
            lblDonVi.Text = tinhLuong.don_vi != null? tinhLuong.don_vi.ten_goi: "Không có";
            // Changed
            //if (tinhLuong.he_so_luong != null)
            //    lblHeSoLuong.Text = tinhLuong.he_so_luong.he_so + " / " + tinhLuong.he_so_luong.ngach.ten_ngach;
            //else
            lblNgayBatDau.Text = tinhLuong.ngay_bat_dau.ToShortDateString();
            lblNgayKetThuc.Text = tinhLuong.ngay_ket_thuc != null ? tinhLuong.ngay_ket_thuc.Value.ToShortDateString() : "Không có";
        }
    }
}
