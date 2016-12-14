using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Qly_NVien_Luong_Form.EntityForm.TinhLuong;
using Qly_Luong_NVien_Service;
using Qly_Luong_NVien_Model;

namespace Qly_NVien_Luong_Form.EntityForm.NhanVien
{
    public partial class Detail : Form
    {
        private Qly_Luong_NVien_Model.NhanVien nhanVien = null;
        private NhanVienService nhanVienService = new NhanVienService();
        private TinhLuongService tinhLuongService = new TinhLuongService();
        private NhanVienLuongDBContext dbContext = new NhanVienLuongDBContext();

        private bool isSearched = false;

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
            this.nhanVien = dbContext.nhan_vien.Find((int)id);
            if (nhanVien == null)
                throw new KeyNotFoundException();

            //Tải bảng công tác của nhân viên đó
            loadCongTac();
        }

        private void loadCongTac()
        {
            IList<Qly_Luong_NVien_Model.TinhLuong> congTac = dbContext.tinh_luong.ToList();
            IList<Qly_Luong_NVien_Model.TinhLuong> result = new List<Qly_Luong_NVien_Model.TinhLuong>();
            foreach(var e in congTac) {
                if (e.nhan_vien == null)
                    continue;
                if (e.nhan_vien.id == this.nhanVien.id)
                {
                    result.Add(e);
                    dbContext.Entry(e).Reload();
                }
            }
            var bindingList = new BindingList<Qly_Luong_NVien_Model.TinhLuong>(result.ToArray());
            var source = new BindingSource(bindingList, null);
            this.tblLuong.DataSource = source;
        }

        private void loadCongTacTheoThoiGian()
        {
            var fromDate = dteTuNgay.Value;
            var toDate = dteDenNgay.Value;
            IList<Qly_Luong_NVien_Model.TinhLuong> congTac = dbContext.tinh_luong.ToList();
            IList<Qly_Luong_NVien_Model.TinhLuong> result = new List<Qly_Luong_NVien_Model.TinhLuong>();
            foreach (var e in congTac)
            {
                if (e.nhan_vien == null)
                    continue;
                if (e.nhan_vien.id == this.nhanVien.id && e.ngay_bat_dau >= fromDate.Date && e.ngay_ket_thuc <= toDate.Date)
                {
                    result.Add(e);
                    dbContext.Entry(e).Reload();
                }
            }
            var bindingList = new BindingList<Qly_Luong_NVien_Model.TinhLuong>(result.ToArray());
            var source = new BindingSource(bindingList, null);
            this.tblLuong.DataSource = source;
        }
        
        private void loadDuLieu()
        {
            if (isSearched == true)
                loadCongTacTheoThoiGian();
            else
                loadCongTac();
        }

        /*Đưa dữ liệu lấy từ database vào form*/
        private void setDataToDetail()
        {
            this.lblMaSo.Text = nhanVien.ma_so;
            this.lblHo.Text = nhanVien.ho + " " + nhanVien.ten;
            this.lblNgaySinh.Text = nhanVien.ngay_sinh.ToShortDateString();
            this.lblGioiTinh.Text = nhanVien.gioi_tinh == true? "Nữ": "Nam";            
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
            var selectedIndex = tblLuong.CurrentCell.RowIndex;
            Qly_NVien_Luong_Form.EntityForm.TinhLuong.Criteria criteria = new Qly_NVien_Luong_Form.EntityForm.TinhLuong.Create(this.nhanVien);
            criteria.ShowDialog();
            loadDuLieu();
            tblLuong.Rows[selectedIndex].Selected = true;
        }

        //Nhấn vào nút sửa công tác
        private void onEdit(object sender, EventArgs e)
        {            
            //Dòng dưới chỉ set tạm thời
            try
            {
                var selectedIndex = tblLuong.CurrentCell.RowIndex;
                var selectedRow = tblLuong.SelectedRows[0];
                var id = selectedRow.Cells[0].Value;
                Qly_NVien_Luong_Form.EntityForm.TinhLuong.Criteria form = new Qly_NVien_Luong_Form.EntityForm.TinhLuong.Edit(id);
                form.ShowDialog();
                loadDuLieu();
                tblLuong.Rows[selectedIndex].Selected = true;
            }
            catch (Exception ex)
            {
                return;
            }
        }
        
        private void tblLuong_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is DonVi && this.tblLuong.Columns[e.ColumnIndex].Name == "clmDonVi")
                e.Value = (e.Value as DonVi).ten_goi;
            else if (e.Value is ChucVu && this.tblLuong.Columns[e.ColumnIndex].Name == "clmChucVu")
                e.Value = (e.Value as ChucVu).ten_chuc_vu;
            else if (e.Value is HeSoLuong && this.tblLuong.Columns[e.ColumnIndex].Name == "clmHeSoLuong")
                e.Value = (e.Value as HeSoLuong).he_so;
            else if (e.Value is HeSoLuong && this.tblLuong.Columns[e.ColumnIndex].Name == "clmNgach")
                e.Value = (e.Value as HeSoLuong).ngach.ten_ngach + " / Bậc " + (e.Value as HeSoLuong).bac_luong;
        }

        //Nhấn nút lọc trên giao diện
        private void onFilterSubmited(object sender, EventArgs e)
        {
            isSearched = true;
            loadDuLieu();

            //Hiển thị nút reset
            btnMacDinh.Visible = true;
        }

        //Nút mặc định được nhấn
        private void btnMacDinhSubmited(object sender, EventArgs e)
        {
            isSearched = false;
            loadDuLieu();

            //Tắt hiển thị
            btnMacDinh.Visible = false;
        }

        //Xem chi tiết tính lương
        private void viewDetail(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = tblLuong.Rows[e.RowIndex];
                var id = selectedRow.Cells[0].Value;
                Qly_NVien_Luong_Form.EntityForm.TinhLuong.Detail detail = new Qly_NVien_Luong_Form.EntityForm.TinhLuong.Detail(id);
                detail.ShowDialog();
            }
        }
    }
}
