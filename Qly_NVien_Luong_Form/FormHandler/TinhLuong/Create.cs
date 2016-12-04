﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qly_NVien_Luong_Form.FormOnly;

namespace Qly_NVien_Luong_Form.FormHandler.TinhLuong
{
    class Create : FormOnly.TinhLuong.Criteria
    {
        public Create(Qly_Luong_NVien_Model.NhanVien nhanVien):base(nhanVien)
        {
            //Constructor này đã bị override
            this.Text = "Thêm";
        }

        /*Xóa trắng form*/
        private void clearForm()
        {
            cbxChucVu.SelectedIndex = 0;
            cbxDonVi.SelectedIndex = 0;
            cbxHeSoLuong.SelectedIndex = 0;
            dteTuNgay.Value = DateTime.Now;
            dteTuNgay.Value = DateTime.Now;
        }

        /*Override lại method cha*/
        private void onSubmit(object sender, EventArgs e)
        {
            base.onSubmit(sender, e);

            /*Thêm vào cơ sở dữ liệu*/
            if (base.tinhLuong != null)
            {
                base.dbContext.tinh_luong.Add(base.tinhLuong);
                base.dbContext.SaveChanges();
                clearForm();
                System.Windows.Forms.MessageBox.Show("Chuyển công tác thành công!");
            }
        }
    }
}
