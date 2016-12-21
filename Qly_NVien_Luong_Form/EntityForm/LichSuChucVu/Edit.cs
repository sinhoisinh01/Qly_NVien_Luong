using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qly_NVien_Luong_Form.EntityForm;
using Qly_Luong_NVien_Service;

namespace Qly_NVien_Luong_Form.EntityForm.LichSuChucVu
{
    public partial class Edit : EntityForm.LichSuChucVu.Criteria
    {

        public Edit(object id):base()
        {
            //Query dữ liệu lên
            base.lichSuChucVu = dbContext.lich_su_chuc_vu.Find((int) id);

            //Đưa dữ liệu query vào form
            setDataToForm();

            //Constructor này đã được override
            this.Text = "Sửa";
            this.btnSubmit.Text = "Sửa";
        }

        private void setDataToForm()
        {
            this.cbxChucVu.SelectedValue = base.lichSuChucVu.chuc_vu.id;
            // Changed
            //this.cbxNgach.SelectedValue = base.tinhLuong.he_so_luong.ngach.id;
            this.cbxDonVi.SelectedValue = base.lichSuChucVu.don_vi.id;
            // Changed
            //this.cbxHeSoLuong.SelectedValue = base.tinhLuong.he_so_luong.id;
            if (base.lichSuChucVu.ngay_ket_thuc != null)
                this.dteDenNgay.Value = base.lichSuChucVu.ngay_ket_thuc.Value;
            else chbLamHienTai.Checked = true;
            this.dteTuNgay.Value = base.lichSuChucVu.ngay_bat_dau;
        }

        /*Override lại method cha*/
        public override void onSubmit(object sender, EventArgs e)
        {
            base.onSubmit(sender, e);

            /*Thêm vào cơ sở dữ liệu*/
            if (base.lichSuChucVu != null)
            {
                try
                {
                    base.dbContext.Entry(base.lichSuChucVu).State = System.Data.Entity.EntityState.Modified;
                    base.dbContext.SaveChanges();
                } catch(Exception ex)
                {
                    Console.WriteLine("this block");
                }
                System.Windows.Forms.MessageBox.Show("Sửa lịch sử chức vụ thành công!");
                this.Close();
            }
        }
    }
}
