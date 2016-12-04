using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Qly_NVien_Luong_Form.FormHandler.TinhLuong;
using Qly_Luong_NVien_Service;
using Qly_Luong_NVien_Model;
using Qly_NVien_Luong_Form.Utils;

namespace Qly_NVien_Luong_Form.FormOnly.NhanVien
{
    public partial class Detail : Form
    {
        private Qly_Luong_NVien_Model.NhanVien nhanVien = null;
        private Qly_Luong_NVien_Model.NhanVienLuongDBContext dbContext = new Qly_Luong_NVien_Model.NhanVienLuongDBContext();
        private NhanVienService nhanVienService = new NhanVienService();
        private TinhLuongService tinhLuongService = new TinhLuongService();

        public Detail(object id)
        {
            InitializeComponent();
            loadData(id);
            setDataToDetail();
        }


        /*Lấy dữ liệu từ database*/
        private void loadData(object id)
        {
            //Tải thông tin nhân viên
            this.nhanVien = nhanVienService.find((int)id);
            if (nhanVien == null)
                throw new KeyNotFoundException();

            //Tải bảng công tác của nhân viên đó
            ISet<Qly_Luong_NVien_Model.TinhLuong> congTac = tinhLuongService.findByNhanVien(this.nhanVien);
            var bindingList = new BindingList<Qly_Luong_NVien_Model.TinhLuong>(congTac.ToArray());
            var source = new BindingSource(bindingList, null);
            this.tblLuong.DataSource = source;
        }

        /*Đưa dữ liệu lấy từ database vào form*/
        private void setDataToDetail()
        {
            this.lblMaSo.Text = nhanVien.ma_so;
            this.lblHo.Text = nhanVien.ho;
            this.lblTen.Text = nhanVien.ten;
            this.lblNgaySinh.Text = nhanVien.ngay_sinh.ToShortDateString();
            this.lblGioiTinh.Text = nhanVien.gioi_tinh == true? "Nam": "Nữ";            
            this.lblDanToc.Text = nhanVien.dan_toc;
            this.lblDiaChi.Text = nhanVien.dia_chi;
            this.lblCMND.Text = nhanVien.cmnd;
            this.lblHinhAnh.Text = nhanVien.hinh_anh;
            this.lblNgayLam.Text = nhanVien.ngay_vao_lam.ToShortDateString();
            DateTime? ngayNghi = nhanVien.ngay_nghi_lam;
            this.lblNgayNghi.Text = ngayNghi != null? ngayNghi.Value.ToShortDateString(): "Không có";
        }

        //Nhấn vào nút thêm chuyển công tác
        private void onAdd(object sender, EventArgs e)
        {
            Qly_NVien_Luong_Form.FormOnly.TinhLuong.Criteria criteria = new Create(nhanVien);
            criteria.ShowDialog();
        }

        //Nhấn vào nút sửa công tác
        private void onEdit(object sender, EventArgs e)
        {
            //Dòng dưới chỉ set tạm thời
            Qly_NVien_Luong_Form.FormOnly.TinhLuong.Criteria criteria = new Edit(0);
            criteria.ShowDialog();
        }

        //Format cell
        private void propCellFormating(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((tblLuong.Rows[e.RowIndex].DataBoundItem != null) &&
                (tblLuong.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = PropertyUtils.bindProperty(
                              tblLuong.Rows[e.RowIndex].DataBoundItem,
                              tblLuong.Columns[e.ColumnIndex].DataPropertyName
                            );
            }
        }

        private void tblLuong_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DonVi)
                e.Value = (e.Value as DonVi).ten_goi;
            else if (e.Value is ChucVu)
                e.Value = (e.Value as ChucVu).ten_chuc_vu;            
            else if(e.Value is HeSoLuong)
                e.Value = (e.Value as HeSoLuong).he_so + " / " + (e.Value as HeSoLuong).ngach.ten_ngach;
        }
    }
}
