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

        public Edit(object id):base()
        {
            //Query dữ liệu lên
            base.tinhLuong = dbContext.tinh_luong.Find((int) id);

            //Đưa dữ liệu query vào form
            setDataToForm();

            //Constructor này đã được override
            this.Text = "Sửa";
            this.btnSubmit.Text = "Sửa";
        }

        private void setDataToForm()
        {
            this.cbxChucVu.SelectedValue = base.tinhLuong.chuc_vu.id;
            this.cbxDonVi.SelectedValue = base.tinhLuong.don_vi.id;
            this.cbxHeSoLuong.SelectedValue = base.tinhLuong.he_so_luong.id;
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
                try
                {
                    base.dbContext.Entry(base.tinhLuong).State = System.Data.Entity.EntityState.Modified;
                    base.dbContext.SaveChanges();
                } catch(Exception ex)
                {
                    Console.WriteLine("this block");
                }
                System.Windows.Forms.MessageBox.Show("Sửa công tác thành công!");
                this.Close();
            }
        }
    }
}
