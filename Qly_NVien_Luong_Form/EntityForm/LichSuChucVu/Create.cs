using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qly_NVien_Luong_Form.EntityForm;
using Qly_Luong_NVien_Service;
using Qly_Luong_NVien_Model;

namespace Qly_NVien_Luong_Form.EntityForm.LichSuChucVu
{
    public partial class Create : EntityForm.LichSuChucVu.Criteria
    {
        public Create(Qly_Luong_NVien_Model.NhanVien nhanVien)
        {
            base.lichSuChucVu = new Qly_Luong_NVien_Model.LichSuChucVu();
            this.nhanVien = nhanVien;
            base.lichSuChucVu.nhan_vien = nhanVien;
            //Constructor này đã bị override
            this.Text = "Thêm";
        }

        /*Xóa trắng form*/
        private void clearForm()
        {
            cbxChucVu.SelectedIndex = 0;
            cbxDonVi.SelectedIndex = 0;
            dteTuNgay.Value = DateTime.Now;
            dteTuNgay.Value = DateTime.Now;
        }

        /*Override lại method cha*/
        public override void onSubmit(object sender, EventArgs e)
        {
            base.onSubmit(sender, e);

            /*Thêm vào cơ sở dữ liệu*/
            if (base.lichSuChucVu != null)
            {
                base.dbContext.nhan_vien.Attach(nhanVien);
                // Changed
                //base.dbContext.tinh_luong.Add(base.LichSuChucVu);
                base.dbContext.lich_su_chuc_vu.Add(base.lichSuChucVu);
                dbContext.SaveChanges();
                clearForm();
                System.Windows.Forms.MessageBox.Show("Thêm lịch sử chức vụ thành công!");
            }
        }
    }
}
