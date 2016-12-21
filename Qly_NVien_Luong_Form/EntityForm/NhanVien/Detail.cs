using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Qly_NVien_Luong_Form.EntityForm.LichSuChucVu;
using Qly_Luong_NVien_Service;
using Qly_Luong_NVien_Model;
using Macchiator;
using System.Data.Entity;

namespace Qly_NVien_Luong_Form.EntityForm.NhanVien
{
    public partial class Detail : Form
    {
        private Qly_Luong_NVien_Model.NhanVien nhanVien = null;
        private NhanVienService nhanVienService = new NhanVienService();
        private TinhLuongService tinhLuongService = new TinhLuongService();
        private NhanVienLuongDBContext dbContext = new NhanVienLuongDBContext();

        private bool isLSChucVuSearched = false;
        private bool isLSNgachSearched = false;

        public Detail(object id)
        {
            InitializeComponent();
            loadData(id);
            setDataToDetail();
            loadLichSuChucVu();
            loadLichSuNgach();
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

        //Tải lịch sử chức vụ
        private void loadLichSuChucVu()
        {
            // Changed
            IList<Qly_Luong_NVien_Model.LichSuChucVu> congTac = dbContext.lich_su_chuc_vu.Where(tl => tl.nhan_vien.id == this.nhanVien.id).ToList();
            foreach(var e in congTac)
                dbContext.Entry(e).Reload();
            var bindingList = new SortableBindingList<Qly_Luong_NVien_Model.LichSuChucVu>(congTac);
            var source = new BindingSource(bindingList, null);
            this.tblLuong.DataSource = source;
        }

        //Tải lịch sử ngạch
        private void loadLichSuNgach()
        {
            // Changed
            IList<Qly_Luong_NVien_Model.LichSuNgach> ngachs = dbContext.lich_su_ngach.Where(tl => tl.nhan_vien.id == this.nhanVien.id).ToList();
            foreach (var e in ngachs)
                dbContext.Entry(e).Reload();
            var bindingList = new SortableBindingList<Qly_Luong_NVien_Model.LichSuNgach>(ngachs);
            var source = new BindingSource(bindingList, null);
            this.tblLichSuNgach.DataSource = source;
        }

        //Tải lịch sử chức vụ theo thời gian
        private void loadLichSuChucVuThoiGian()
        {
            var fromDate = dteTuNgay.Value;
            var toDate = dteDenNgay.Value;
            // Changed
            IList<Qly_Luong_NVien_Model.LichSuChucVu> congTac = dbContext.lich_su_chuc_vu.Where(
            tl =>
            tl.nhan_vien.id == this.nhanVien.id &&
                DbFunctions.TruncateTime(tl.ngay_bat_dau) >= DbFunctions.TruncateTime(fromDate) &&
                DbFunctions.TruncateTime(tl.ngay_bat_dau) <= DbFunctions.TruncateTime(toDate)
            ).ToList();
            foreach(var e in congTac)
                dbContext.Entry(e).Reload(); 
            var bindingList = new SortableBindingList<Qly_Luong_NVien_Model.LichSuChucVu>(congTac);
            var source = new BindingSource(bindingList, null);
            this.tblLuong.DataSource = source;
        }

        //Tải lịch sử ngạch theo thời gian
        private void loadLichSuNgachThoiGian()
        {
            var fromDate = dteLichSuNgachNgayBatDau.Value;
            var toDate = dteLichSuNgachNgayKetThuc.Value;
            // Changed
            IList<Qly_Luong_NVien_Model.LichSuNgach> ngachs = dbContext.lich_su_ngach.Where(
            tl =>
            tl.nhan_vien.id == this.nhanVien.id &&
                DbFunctions.TruncateTime(tl.ngay_bat_dau) >= DbFunctions.TruncateTime(fromDate) &&
                DbFunctions.TruncateTime(tl.ngay_bat_dau) <= DbFunctions.TruncateTime(toDate)
            ).ToList();
            foreach (var e in ngachs)
                dbContext.Entry(e).Reload();
            var bindingList = new SortableBindingList<Qly_Luong_NVien_Model.LichSuNgach>(ngachs);
            var source = new BindingSource(bindingList, null);
            this.tblLichSuNgach.DataSource = source;
        }

        //load chung chung theo thời gian
        private void loadTheoThoiGian()
        {
            var selectedTab = tabCongTac.SelectedTab.Name;

            if (selectedTab == "tpaChucVu")
            {
                loadLichSuChucVuThoiGian();
            } else if(selectedTab == "tpaNgach")
            {
                loadLichSuNgachThoiGian();
            }
        }

        //Load lịch sử chung chung
        private void loadCongTac()
        {
            var selectedTab = tabCongTac.SelectedTab.Name;

            if (selectedTab == "tpaChucVu")
            {
                loadLichSuChucVu();
            }
            else if (selectedTab == "tpaNgach")
            {
                loadLichSuNgach();
            }
        }

        //Chung chung
        private void loadDuLieu()
        {
            var selectedTab = tabCongTac.SelectedTab.Name;

            if (selectedTab == "tpaChucVu")
            {
                if (isLSChucVuSearched == true)
                    loadTheoThoiGian();
                else
                    loadCongTac();
            }
            else
            {
                if (isLSNgachSearched == true)
                    loadTheoThoiGian();
                else
                    loadCongTac();
            }
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
            int selectedIndex = -1;
            try
            {
                selectedIndex = tblLuong.CurrentCell.RowIndex;
            } catch(NullReferenceException ex) { }
            Qly_NVien_Luong_Form.EntityForm.LichSuChucVu.Criteria criteria = new Qly_NVien_Luong_Form.EntityForm.LichSuChucVu.Create(this.nhanVien);
            criteria.ShowDialog();
            loadDuLieu();
            if (selectedIndex != - 1) tblLuong.Rows[selectedIndex].Selected = true;
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
                Qly_NVien_Luong_Form.EntityForm.LichSuChucVu.Criteria form = new Qly_NVien_Luong_Form.EntityForm.LichSuChucVu.Edit(id);
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
            else if (this.tblLuong.Columns[e.ColumnIndex].Name == "clmNgayKetThuc")
                e.Value = e.Value == null ? "Hiện tại" : (e.Value as DateTime?).Value.ToString("dd/MM/yyyy");
            else if (this.tblLuong.Columns[e.ColumnIndex].Name == "clmNgayBatDau")
                e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
        }

        //Nhấn nút lọc trên giao diện
        private void onFilterSubmited(object sender, EventArgs e)
        {
            isLSChucVuSearched = true;
            loadDuLieu();

            //Hiển thị nút reset
            btnMacDinh.Visible = true;
        }

        //Nút mặc định được nhấn
        private void btnMacDinhSubmited(object sender, EventArgs e)
        {
            isLSChucVuSearched = false;
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
                Qly_NVien_Luong_Form.EntityForm.LichSuChucVu.Detail detail = new Qly_NVien_Luong_Form.EntityForm.LichSuChucVu.Detail(id);
                detail.ShowDialog();
            }
        }

        //TAB LỊCH SỬ NGẠCH//

        //Format dữ liệu đầu vào
        private void tblLichSuNgach_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is HeSoLuong && this.tblLichSuNgach.Columns[e.ColumnIndex].Name == "clmLichSuNgachNgach")
                e.Value = (e.Value as HeSoLuong).ngach.ten_ngach;
            else if (e.Value is HeSoLuong && this.tblLichSuNgach.Columns[e.ColumnIndex].Name == "clmLichSuNgachBac")
                e.Value = (e.Value as HeSoLuong).bac_luong;
            else if (e.Value is HeSoLuong && this.tblLichSuNgach.Columns[e.ColumnIndex].Name == "clmLichSuNgachHeSoLuong")
                e.Value = (e.Value as HeSoLuong).he_so;
            else if (e.Value is HeSoLuong && this.tblLichSuNgach.Columns[e.ColumnIndex].Name == "clmLichSuNgachVuotKhung")
            {
                var temp = (e.Value as HeSoLuong).vuot_khung;
                if (temp == null)
                    e.Value = "Không có";
                else e.Value = temp.Value;
            }
            else if (this.tblLichSuNgach.Columns[e.ColumnIndex].Name == "clmLichSuNgachNgayKetThuc")
                e.Value = e.Value == null ? "Hiện tại" : (e.Value as DateTime?).Value.ToString("dd/MM/yyyy");
            else if (this.tblLichSuNgach.Columns[e.ColumnIndex].Name == "clmLichSuNgachNgayBatDau")
                e.Value = ((DateTime)e.Value).ToString("dd/MM/yyyy");
        }

        //Sửa lịch sử ngạch
        private void btnLichSuNgachSua_Click(object sender, EventArgs e)
        {
            //Dòng dưới chỉ set tạm thời
            try
            {
                var selectedIndex = tblLichSuNgach.CurrentCell.RowIndex;
                var selectedRow = tblLichSuNgach.SelectedRows[0];
                var id = selectedRow.Cells[0].Value;
                Qly_NVien_Luong_Form.EntityForm.LichSuNgach.Criteria form = new Qly_NVien_Luong_Form.EntityForm.LichSuNgach.Edit(id);
                form.ShowDialog();
                loadDuLieu();
                tblLuong.Rows[selectedIndex].Selected = true;
            }
            catch (Exception ex)
            {
                return;
            }
        }

        //THêm lịch sử ngạch
        private void btnLichSuNgachThem_Click(object sender, EventArgs e)
        {
            Qly_NVien_Luong_Form.EntityForm.LichSuNgach.Create form = new Qly_NVien_Luong_Form.EntityForm.LichSuNgach.Create(this.nhanVien);
            form.ShowDialog();
            loadDuLieu();
        }

        //TÌm kiếm lịch sử ngạch
        private void btnLichSuNgachLoc_Click(object sender, EventArgs e)
        {
            isLSNgachSearched = true;
            loadDuLieu();
            btnLichSuNgachMacDinh.Visible = true;
        }

        //Set về mặc định sau khi tìm kiếm
        private void btnLichSuNgachMacDinh_Click(object sender, EventArgs e)
        {
            isLSNgachSearched = false;
            loadDuLieu();
            btnLichSuNgachMacDinh.Visible = false;
        }
    }
}
