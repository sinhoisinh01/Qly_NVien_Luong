using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qly_NVien_Luong_Form.EntityForm.LichSuNgach
{
    public partial class Edit : Criteria
    {

        public Edit(object id) : base()
        {
            //Query dữ liệu lên
            base.lichSuNgach = dbContext.lich_su_ngach.Find((int)id);

            //Đưa dữ liệu query vào form
            setDataToForm();

            //Constructor này đã được override
            this.Text = "Sửa";
            this.btnSubmit.Text = "Sửa";
        }

        private void setDataToForm()
        {
            this.cbxNgach.SelectedValue = base.lichSuNgach.he_so_luong.ngach.id;
            // Changed
            //this.cbxNgach.SelectedValue = base.tinhLuong.he_so_luong.ngach.id;
            //this.cbxBac.DataSource = dbContext.he_so_luong.Where(hsl => hsl.ngach.id == lichSuNgach.he_so_luong.ngach.id).ToList();
            this.cbxBac.SelectedIndex = base.cbxBac.FindString("Bậc " + base.lichSuNgach.he_so_luong.bac_luong);
            // Changed
            //this.cbxHeSoLuong.SelectedValue = base.tinhLuong.he_so_luong.id;
            if (base.lichSuNgach.ngay_ket_thuc != null)
                this.dteNgayKetThuc.Value = base.lichSuNgach.ngay_ket_thuc.Value;
            else chbLamHienTai.Checked = true;
            this.dteNgayBatDau.Value = base.lichSuNgach.ngay_bat_dau;
        }

        /*Override lại method cha*/
        public override void onSubmit(object sender, EventArgs e)
        {
            base.onSubmit(sender, e);

            /*Thêm vào cơ sở dữ liệu*/
            if (base.lichSuNgach != null)
            {
                try
                {
                    base.dbContext.Entry(base.lichSuNgach).State = System.Data.Entity.EntityState.Modified;
                    base.dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("this block");
                }
                System.Windows.Forms.MessageBox.Show("Sửa lịch sử ngạch thành công!");
                this.Close();
            }
        }
    }
}
