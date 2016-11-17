using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qly_NVien_Luong_Form.FormOnly.NhanVien
{
    public partial class Detail : Form
    {
        private Qly_Luong_NVien_Model.NhanVien nhanVien = null;
        private Qly_Luong_NVien_Model.NhanVienLuongDBContext dbContext = new Qly_Luong_NVien_Model.NhanVienLuongDBContext();

        public Detail(object id)
        {
            InitializeComponent();
            loadData(id);
            setDataToDetail();
        }


        /*Lấy dữ liệu từ database*/
        private void loadData(object id)
        {
            this.nhanVien = dbContext.nhan_vien.Find(id);
            if (nhanVien == null)
                throw new KeyNotFoundException();
        }

        /*Đưa dữ liệu lấy từ database vào form*/
        private void setDataToDetail()
        {
            this.lblMaSo.Text = nhanVien.ma_so;
            this.lblHo.Text = nhanVien.ho;
            this.lblTen.Text = nhanVien.ten;
            this.lblNgaySinh.Text = nhanVien.ngay_sinh.ToShortDateString();
            this.lblGioiTinh.Text = nhanVien.gioi_tinh == true? "Nam": "Nữ";
            this.lblHinhAnh.Text = nhanVien.hinh_anh;
            this.lblDanToc.Text = nhanVien.dan_toc;
            this.lblDiaChi.Text = nhanVien.dia_chi;
            this.lblNgayLam.Text = nhanVien.ngay_vao_lam.ToShortDateString();
            this.lblNgayNghi.Text = nhanVien.ngay_nghi_lam.Value.ToShortDateString();
        }
    }
}
