using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qly_NVien_Luong_Form.EntityForm.NhanVien;
using Qly_Luong_NVien_Service;
using Qly_Luong_NVien_Model;

namespace Qly_NVien_Luong_Form.EntityForm.NhanVien
{
    public partial class Create : Criteria
    {
        public Create()
        {
            //Override lại form
            overrideInitComp();
        }

        private void overrideInitComp()
        {
            base.btnSubmit.Text = "Thêm";
            base.Text = "Thêm nhân viên";
        }

        /*Nhấn nút submit*/
        public override void onSubmit(object sender, EventArgs e)
        {
            base.onSubmit(sender, e); //Sau khi binding dữ liệu

            /*Thêm vào cơ sở dữ liệu*/
            if (base.nhanVien != null)
            {
                dbContext.nhan_vien.Add(base.nhanVien);
                dbContext.SaveChanges();
                clearForm();
                System.Windows.Forms.MessageBox.Show("Thêm nhân viên thành công!");
            }
        }

        /*Xóa trắng form*/
        private void clearForm()
        {
            base.rdoNam.Checked = true;
            base.texCMND.Text = "";
            base.texDanToc.Text = "";
            base.texDiaChi.Text = "";
            //base.texHinhAnh.Text = "";
            base.texHo.Text = "";
            base.texMaSo.Text = "";
            base.texTen.Text = "";
            base.dteNgaySinh.Value = DateTime.Now;
            base.dteNgayLam.Value = DateTime.Now;
            //base.dteNgayNghi.Value = DateTime.Now;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Create
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(284, 362);
            this.Name = "Create";
            this.ResumeLayout(false);

        }
    }
}
