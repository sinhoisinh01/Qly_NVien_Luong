﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Qly_Luong_NVien_Model;

namespace Qly_NVien_Luong_Form.EntityForm.NhanVien
{
    public partial class Criteria : Form
    {
        protected Qly_Luong_NVien_Model.NhanVien nhanVien = null;
        protected NhanVienLuongDBContext dbContext = new NhanVienLuongDBContext();

        public Criteria()
        {
            InitializeComponent();
        }

        /*Binding dữ liệu*/
        private void bindingData()
        {
            nhanVien = new Qly_Luong_NVien_Model.NhanVien();
            nhanVien.ma_so = texMaSo.Text;
            nhanVien.ho = texHo.Text;
            nhanVien.ten = texTen.Text;
            nhanVien.ngay_sinh = dteNgaySinh.Value;
            nhanVien.dan_toc = texDanToc.Text;
            nhanVien.dia_chi = texDiaChi.Text;
            nhanVien.cmnd = texCMND.Text;
            nhanVien.hinh_anh = texHinhAnh.Text;
            nhanVien.ngay_vao_lam = dteNgayLam.Value;
            nhanVien.ngay_nghi_lam = dteNgayNghi.Value;
            nhanVien.gioi_tinh = rdoNam.Checked;
        }

        /*Validate dữ liệu*/
        private void validateData()
        {
            //Nếu như dữ liệu thì set thuộc tính nhanVien về null để không thêm vào database
        }

        public virtual void onSubmit(object sender, EventArgs e)
        {
            /*Binding dữ liệu vào thuộc tính data*/
            bindingData();

            /*Validate dữ liệu*/
            validateData();
        }

        private void onCancel(object sender, EventArgs e)
        {
            base.Close();
        }        

        private void rdoNam_onChange(object sender, EventArgs e)
        {
            if(rdoNam.Checked == true)
                rdoNu.Checked = false;
        }

        private void rdoNu_onChange(object sender, EventArgs e)
        {
            if(rdoNu.Checked == true)
                rdoNam.Checked = false;
        }
    }
}
