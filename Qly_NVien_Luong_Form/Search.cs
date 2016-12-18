using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qly_NVien_Luong_Form
{
    public partial class Search : Form
    {
        private List<Qly_Luong_NVien_Model.NhanVien> searchResult;

        public List<Qly_Luong_NVien_Model.NhanVien> SearchResult
        {
            get { return this.searchResult; }
        }
        
        public Search()
        {
            InitializeComponent();
        }

        //Thực hiện tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        //Thoát
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
