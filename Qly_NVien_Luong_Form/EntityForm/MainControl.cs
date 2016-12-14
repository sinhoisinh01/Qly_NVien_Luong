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

namespace Qly_NVien_Luong_Form.EntityForm
{
    public partial class MainControl : Form
    {
        private Qly_Luong_NVien_Model.NhanVienLuongDBContext dbContext = new NhanVienLuongDBContext();        

        public MainControl()
        {
            InitializeComponent();
            loadDataToTable();
        }

        private void loadDataToTable()
        {
            IList<Qly_Luong_NVien_Model.NhanVien> nhanVienList = dbContext.nhan_vien.ToList().ToArray();
            var bindingList = new BindingList<Qly_Luong_NVien_Model.NhanVien>(nhanVienList);
            var source = new BindingSource(bindingList, null);
            this.tblData.DataSource = source;
        }

        /*Thêm dữ liệu*/
        private void onBtnAdd_Submit(object sender, EventArgs e)
        {
            Create form = new Create();
            form.ShowDialog();
            loadDataToTable();
        }

        /*Xem chi tiết dữ liệu*/
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

        /*Sửa dòng dữ liệu*/
        private void editThisRow(object sender, EventArgs e)
        {
            try
            {
                var selectedRow = tblData.SelectedRows[0];
                var id = selectedRow.Cells[0].Value;
                Edit form = new Edit(id);
                form.ShowDialog();
                loadDataToTable();
            } catch(Exception ex)
            {
                return;
            }
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
    }
}
