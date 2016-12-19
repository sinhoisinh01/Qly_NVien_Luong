using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qly_NVien_Luong_Form
{
    public partial class Search : Form
    {
        private Qly_Luong_NVien_Model.NhanVienLuongDBContext dbContext = new Qly_Luong_NVien_Model.NhanVienLuongDBContext();
        private List<Qly_Luong_NVien_Model.NhanVien> searchResult;

        public List<Qly_Luong_NVien_Model.NhanVien> SearchResult
        {
            get { return this.searchResult; }
        }
        
        public Search()
        {
            InitializeComponent();
            cbxSearchBy.SelectedIndex = 0;
        }

        //Thực hiện tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txfKeyword.Text.ToLower();
            string searchBy = (string)cbxSearchBy.SelectedItem;
            DateTime fromDate = dteFromDate.Value;
            DateTime toDate = dteToDate.Value;

            var criteria = dbContext.nhan_vien;
            var query = criteria.Where(t => 1 > 0); ;
            if (searchBy == "Họ")
                query = criteria.Where(nv => nv.ho.ToLower().Contains(keyword));
            else if (searchBy == "Tên")
                query = criteria.Where(nv => nv.ten.ToLower().Contains(keyword));
            else if (searchBy == "Họ và Tên")
                query = criteria.Where(
                    nv => ((nv.ho.ToLower() + " " + nv.ten.ToLower()) as string).Contains(keyword)
                );
            else if (searchBy == "Địa chỉ")
                query = criteria.Where(nv => nv.dia_chi.ToLower().Contains(keyword));
            else if (searchBy == "Dân tộc")
                query = criteria.Where(nv => nv.dan_toc.ToLower().Contains(keyword));

            if(chxBirthdaySearch.Checked == false)
                if (fromDate.Date < toDate.Date)
                    query = criteria.Where(
                        nv =>
                        DbFunctions.TruncateTime(nv.ngay_sinh) >= DbFunctions.TruncateTime(fromDate) &&
                        DbFunctions.TruncateTime(nv.ngay_sinh) <= DbFunctions.TruncateTime(toDate)
                    );

            this.searchResult = query.ToList();
            this.Close();
        }

        //Thoát
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Checked
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chxBirthdaySearch.Checked == true)
            {
                dteFromDate.Enabled = false;
                dteToDate.Enabled = false;
            } else
            {
                dteFromDate.Enabled = true;
                dteToDate.Enabled = true;
            }
        }
    }
}
