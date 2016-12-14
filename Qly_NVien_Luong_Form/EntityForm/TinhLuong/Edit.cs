using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qly_NVien_Luong_Form.EntityForm;
using Qly_Luong_NVien_Service;

namespace Qly_NVien_Luong_Form.EntityForm.TinhLuong
{
    public partial class Edit : EntityForm.TinhLuong.Criteria
    {
        private TinhLuongService tinhLuongService = new TinhLuongService();

        public Edit(object id):base()
        {
            //Query dữ liệu lên
            base.tinhLuong = tinhLuongService.find((int) id);

            //Đưa dữ liệu query vào form
            setDataToForm();

            //Constructor này đã được override
            this.Text = "Sửa";
            this.btnSubmit.Text = "Sửa";
        }

        private void setDataToForm()
        {
            this.cbxChucVu.SelectedItem = base.tinhLuong.chuc_vu;
            this.cbxDonVi.SelectedItem = base.tinhLuong.don_vi;
            this.cbxHeSoLuong.SelectedItem = base.tinhLuong.he_so_luong;
            this.dteDenNgay.Value = base.tinhLuong.ngay_ket_thuc != null? base.tinhLuong.ngay_ket_thuc.Value: DateTime.Now;
            this.dteTuNgay.Value = base.tinhLuong.ngay_bat_dau;
        }

        /*Override lại method cha*/
        public override void onSubmit(object sender, EventArgs e)
        {
            base.onSubmit(sender, e);

            /*Thêm vào cơ sở dữ liệu*/
            if (base.tinhLuong != null)
            {
                dbContext.Entry(base.tinhLuong).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                System.Windows.Forms.MessageBox.Show("Sửa công tác thành công!");
                this.Close();
            }
        }
    }
}
