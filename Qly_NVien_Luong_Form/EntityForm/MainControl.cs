using Qly_Luong_NVien_Service;
using Qly_NVien_Luong_Form.EntityForm.NhanVien;
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
using Macchiator;

namespace Qly_NVien_Luong_Form.EntityForm
{
    public partial class MainControl : Form
    {
        private IList<Qly_Luong_NVien_Model.NhanVien> nhanVienList;

        private Qly_Luong_NVien_Model.NhanVienLuongDBContext dbContext = new NhanVienLuongDBContext();

        public MainControl()
        {
            
            InitializeComponent();
            loadDataToTable();
        }

        private void loadDataToTable()
        {
            this.nhanVienList = dbContext.Set<Qly_Luong_NVien_Model.NhanVien>().ToArray();
            foreach(var e in nhanVienList)
                dbContext.Entry<Qly_Luong_NVien_Model.NhanVien>(e).Reload();
            //var bindingList = new BindingList<Qly_Luong_NVien_Model.NhanVien>(this.nhanVienList);
            SortableBindingList<Qly_Luong_NVien_Model.NhanVien> bindingList;
            bindingList = new SortableBindingList<Qly_Luong_NVien_Model.NhanVien>(this.nhanVienList.ToList());
            var source = new BindingSource(bindingList, null);
            this.tblData.AutoGenerateColumns = false;
            this.tblData.DataSource = source;
            //DataCounter.autoIncrementTable(this.tblData);
        }
        
        /*Thêm dữ liệu*/
        private void onBtnAdd_Submit(object sender, EventArgs e)
        {
            var selectedIndex = tblData.CurrentCell.RowIndex;
            Create form = new Create();
            form.ShowDialog();
            loadDataToTable();
            tblData.Rows[selectedIndex].Selected = true;
        }

        /*Xem chi tiết dữ liệu*/
        /*
        private void viewThisRow(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = tblData.Rows[e.RowIndex];
                var id = selectedRow.Cells[0].Value;                
                Detail detail = new Detail(id);
                detail.ShowDialog();             
            }
        }
        */

        /*Sửa dòng dữ liệu*/
        private void editThisRow(object sender, EventArgs e)
        {
            var selectedIndex = tblData.CurrentCell.RowIndex;
            var selectedRow = tblData.SelectedRows[0];
            var id = selectedRow.Cells["id"].Value;
            Edit form = new Edit(id);
            form.ShowDialog();
            loadDataToTable();
            tblData.Rows[selectedIndex].Selected = true;
        }

        /*Xóa dòng dữ liệu*/
        private void removeThisRow(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa nhân viên này không?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                var id = tblData.SelectedRows[0].Cells[0].Value;
                var nhanVien = dbContext.nhan_vien.Find((int)id);
                if (nhanVien != null)
                {
                    
                    dbContext.nhan_vien.Remove(nhanVien);
                    dbContext.SaveChanges();
                    loadDataToTable();
                }
            }
        }


        //Format table
        private void tblData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(this.tblData.Columns[e.ColumnIndex].Name == "gioiTinh")
            {
                if(e.Value != null)
                {
                    var temp = (bool)e.Value;
                    if (temp == false)
                        e.Value = "Nam";
                    else
                        e.Value = "Nữ";
                }
            }
        }

        //Click lên nút trên dòng dữ liệu
        private void tblData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != tblData.Columns["btnViewDetail"].Index) return;

            var selectedRow = tblData.Rows[e.RowIndex];
            var id = selectedRow.Cells["id"].Value;
            Detail detail = new Detail(id);
            detail.ShowDialog();
        }

        //Nhấn nút tìm kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            Search searchDialog = new Search();
            searchDialog.ShowDialog();
            List<Qly_Luong_NVien_Model.NhanVien> data = searchDialog.SearchResult;
            if (data != null)
            {
                SortableBindingList<Qly_Luong_NVien_Model.NhanVien> bindingList;
                bindingList = new SortableBindingList<Qly_Luong_NVien_Model.NhanVien>(data);
                var source = new BindingSource(bindingList, null);
                tblData.DataSource = source;
                btnDefault.Visible = true;
            }
        }

        //Khôi phục
        private void btnDefault_Click(object sender, EventArgs e)
        {
            SortableBindingList<Qly_Luong_NVien_Model.NhanVien> bindingList;
            bindingList = new SortableBindingList<Qly_Luong_NVien_Model.NhanVien>(dbContext.nhan_vien.ToList());
            var source = new BindingSource(bindingList, null);
            tblData.DataSource = source;
            btnDefault.Visible = false;
        }
    }
}
