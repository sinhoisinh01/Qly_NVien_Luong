using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qly_NVien_Luong_Form.FormOnly.NhanVien;
using Qly_Luong_NVien_Service;

namespace Qly_NVien_Luong_Form.FormHandler.NhanVien
{
    public partial class Create : Criteria
    {
        private NhanVienService nhanVienService = new NhanVienService();

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
        private void onSubmit(object sender, EventArgs e)
        {
            base.onSubmit(sender, e); //Sau khi binding dữ liệu

            /*Thêm vào cơ sở dữ liệu*/
            if (base.nhanVien != null)
            {
                nhanVienService.add(base.nhanVien);            
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
            base.texHinhAnh.Text = "";
            base.texHo.Text = "";
            base.texMaSo.Text = "";
            base.texTen.Text = "";
            base.dteNgaySinh.Value = DateTime.Now;
            base.dteNgayLam.Value = DateTime.Now;
            base.dteNgayNghi.Value = DateTime.Now;
        }
    }
}
