using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qly_NVien_Luong_Form.EntityForm.LichSuNgach
{
    public partial class Create : Criteria
    {
        public Create(Qly_Luong_NVien_Model.NhanVien nhanVien)
        {
            base.lichSuNgach = new Qly_Luong_NVien_Model.LichSuNgach();
            this.nhanVien = nhanVien;
            base.lichSuNgach.nhan_vien = nhanVien;
            //Constructor này đã bị override
            this.Text = "Thêm";
        }

        /*Xóa trắng form*/
        private void clearForm()
        {
            cbxNgach.SelectedIndex = 0;
            cbxBac.SelectedIndex = 0;
            dteNgayBatDau.Value = DateTime.Now;
            dteNgayKetThuc.Value = DateTime.Now;
        }

        /*Override lại method cha*/
        public override void onSubmit(object sender, EventArgs e)
        {
            base.onSubmit(sender, e);

            /*Thêm vào cơ sở dữ liệu*/
            if (base.lichSuNgach != null)
            {
                base.dbContext.nhan_vien.Attach(nhanVien);
                // Changed
                //base.dbContext.tinh_luong.Add(base.LichSuChucVu);
                base.dbContext.lich_su_ngach.Add(lichSuNgach);
                dbContext.SaveChanges();
                clearForm();
                System.Windows.Forms.MessageBox.Show("Thêm lịch sử ngạch thành công!");
            }
        }
    }
}
