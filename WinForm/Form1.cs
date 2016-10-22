using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Webapp.Models;
using System.Data.Entity;

namespace WinForm
{
    public partial class Form1 : Form
    {
        NhanVienLuongDBContext _context;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _context = new NhanVienLuongDBContext();
            _context.nhan_vien.Load();
            this.nhanVienBindingSource.DataSource = this._context.nhan_vien.Local.ToBindingList();
        }
    }
}
