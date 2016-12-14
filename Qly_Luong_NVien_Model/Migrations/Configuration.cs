namespace Qly_Luong_NVien_Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Qly_Luong_NVien_Model.NhanVienLuongDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Qly_Luong_NVien_Model.NhanVienLuongDBContext context)
        {
            //  This method will be called after migrating to the latest version.
            /* Add Rows for DonVi Table */
            DonVi dvi = new DonVi()
            {
                id = 1,
                ten_goi = "Khoa Công nghệ thông tin",
                dia_chi = "273 An Dương Vương",
                dien_thoai = "19001516",
                ngay_thanh_lap = new DateTime(2000, 10, 12),
                mo_ta = "Khoa chuyên dạy về Công nghệ thông tin"
            };
            context.don_vi.AddOrUpdate(dvi);
            dvi = new DonVi()
            {
                id = 2,
                ten_goi = "Trung tâm tin học",
                dia_chi = "273 An Dương Vương",
                dien_thoai = "19001516",
                ngay_thanh_lap = new DateTime(2010, 10, 12),
                mo_ta = "Trung tâm tin học Đại học Sài Gòn"
            };
            context.don_vi.AddOrUpdate(dvi);
            dvi = new DonVi()
            {
                id = 3,
                ten_goi = "Trung tâm ngoại ngữ",
                dia_chi = "273 An Dương Vương",
                dien_thoai = "19001516",
                ngay_thanh_lap = new DateTime(2005, 10, 12),
                mo_ta = "Trung tâm ngoại ngữ Đại học Sài Gòn"
            };
            context.don_vi.AddOrUpdate(dvi);
            /* Hết DonVi Table */

            // Add Rows for NhanVien Table
            NhanVien nv = new NhanVien()
            {
                id = 1,
                ma_so = "3113410100",
                ho = "Đoàn",
                ten = "Phúc Sinh",
                gioi_tinh = false,
                ngay_sinh = new DateTime(1995, 4, 1),
                dan_toc = "Kinh",
                dia_chi = "262 Lê Văn Sỹ, P14, Q3",
                cmnd = "025316441",
                hinh_anh = null,
                ngay_vao_lam = new DateTime(2013, 9, 5),
                ngay_nghi_lam = null
            };
            context.nhan_vien.AddOrUpdate(nv);
            nv = new NhanVien()
            {
                id = 2,
                ma_so = "3113410024",
                ho = "Hồng",
                ten = "Phúc Thạnh Đông",
                gioi_tinh = false,
                ngay_sinh = new DateTime(1995, 4, 1),
                dan_toc = "Kinh",
                dia_chi = "262 Lê Văn Sỹ, P14, Q3",
                cmnd = "025316441",
                hinh_anh = null,
                ngay_vao_lam = new DateTime(2013, 9, 5),
                ngay_nghi_lam = null
            };
            context.nhan_vien.AddOrUpdate(nv);

            // Add Rows for Ngach Table
            Ngach ngach = new Ngach()
            {
                id = 1,
                ma_so = "01.001",
                ten_ngach = "Chuyên Viên Cao Cấp",
                nien_han = 3,
                mo_ta = "Nhân viên làm việc ở các đơn vị chức năng, có trình độ Tiến sĩ trở lên."
            };
            context.ngach.AddOrUpdate(ngach);
            ngach = new Ngach()
            {
                id = 2,
                ma_so = "01.003",
                ten_ngach = "Chuyên Viên",
                nien_han = 3,
                mo_ta = "Nhân viên làm việc ở các đơn vị chức năng, có trình độ Đại học trở lên."
            };
            context.ngach.AddOrUpdate(ngach);
            ngach = new Ngach()
            {
                id = 3,
                ma_so = "15.110",
                ten_ngach = "Giảng Viên Chính",
                nien_han = 3,
                mo_ta = "Nhân viên trực tiếp giảng dạy thuộc các khoa có trình độ Thạc sĩ trở lên."
            };
            context.ngach.AddOrUpdate(ngach);
            ngach = new Ngach()
            {
                id = 4,
                ma_so = "15.111",
                ten_ngach = "Giảng Viên",
                nien_han = 3,
                mo_ta = "Nhân viên trực tiếp giảng dạy thuộc các khoa có trình độ Đại học trở lên."
            };
            context.ngach.AddOrUpdate(ngach);
            ngach = new Ngach()
            {
                id = 5,
                ma_so = "01.004",
                ten_ngach = "Cán Sự",
                nien_han = 2,
                mo_ta = "Nhân viên làm việc hành chánh văn phòng ở các đơn vị chức năng, có trình độ THPT trở lên."
            };
            context.ngach.AddOrUpdate(ngach);
            ngach = new Ngach()
            {
                id = 6,
                ma_so = "01.007",
                ten_ngach = "Nhân Viên Kỹ Thuật",
                nien_han = 2,
                mo_ta = "Nhân viên làm việc kĩ thuật ở các đơn vị. Vd: KTV phòng máy vi tính, KTV thư viện…"
            };
            context.ngach.AddOrUpdate(ngach);
            ngach = new Ngach()
            {
                id = 7,
                ma_so = "01.11",
                ten_ngach = "Nhân Viên Bảo Vệ",
                nien_han = 2,
                mo_ta = "Nhân viên bảo vệ thuộc phòng Hành chánh."
            };
            context.ngach.AddOrUpdate(ngach);

            // Add Rows for Ngach Table
            ChucVu chucVu = new ChucVu()
            {
                id = 1,
                ten_chuc_vu = "Hiệu trưởng",
                he_so_chuc_vu = 0.8f
            };
            context.chuc_vu.AddOrUpdate(chucVu);
            chucVu = new ChucVu()
            {
                id = 2,
                ten_chuc_vu = "Hiệu phó",
                he_so_chuc_vu = 0.7f
            };
            context.chuc_vu.AddOrUpdate(chucVu);
            chucVu = new ChucVu()
            {
                id = 3,
                ten_chuc_vu = "Trưởng phòng",
                he_so_chuc_vu = 0.5f
            };
            context.chuc_vu.AddOrUpdate(chucVu);
            chucVu = new ChucVu()
            {
                id = 4,
                ten_chuc_vu = "Trưởng Khoa",
                he_so_chuc_vu = 0.5f
            };
            context.chuc_vu.AddOrUpdate(chucVu);
            chucVu = new ChucVu()
            {
                id = 5,
                ten_chuc_vu = "Giám đốc trung tâm",
                he_so_chuc_vu = 0.5f
            };
            context.chuc_vu.AddOrUpdate(chucVu);
            chucVu = new ChucVu()
            {
                id = 6,
                ten_chuc_vu = "Phó phòng",
                he_so_chuc_vu = 0.4f
            };
            context.chuc_vu.AddOrUpdate(chucVu);
            chucVu = new ChucVu()
            {
                id = 7,
                ten_chuc_vu = "Phó Khoa",
                he_so_chuc_vu = 0.4f
            };
            context.chuc_vu.AddOrUpdate(chucVu);
            chucVu = new ChucVu()
            {
                id = 8,
                ten_chuc_vu = "Phó Giám đốc trung tâm",
                he_so_chuc_vu = 0.4f
            };
            context.chuc_vu.AddOrUpdate(chucVu);
            chucVu = new ChucVu()
            {
                id = 9,
                ten_chuc_vu = "Trưởng bộ môn trực thuộc Khoa",
                he_so_chuc_vu = 0.4f
            };
            context.chuc_vu.AddOrUpdate(chucVu);
            chucVu = new ChucVu()
            {
                id = 10,
                ten_chuc_vu = "Phó bộ môn trực thuộc Khoa",
                he_so_chuc_vu = 0.3f
            };
            context.chuc_vu.AddOrUpdate(chucVu);
            context.chuc_vu.AddOrUpdate(chucVu);
            chucVu = new ChucVu()
            {
                id = 11,
                ten_chuc_vu = "Không có",
                he_so_chuc_vu = 0
            };
            context.chuc_vu.AddOrUpdate(chucVu);

            // Add Rows for HeSoLuong Table
            /* Phần dữ liệu Chuyên viên cao cấp */
            HeSoLuong heSoLuong = new HeSoLuong()
            {
                id = 1,
                ngach = context.ngach.Find(1),
                bac_luong = 1,
                he_so = 6.20f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 2,
                ngach = context.ngach.Find(1),
                bac_luong = 2,
                he_so = 6.56f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 3,
                ngach = context.ngach.Find(1),
                bac_luong = 3,
                he_so = 6.92f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 4,
                ngach = context.ngach.Find(1),
                bac_luong = 4,
                he_so = 7.28f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 5,
                ngach = context.ngach.Find(1),
                bac_luong = 5,
                he_so = 7.64f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 6,
                ngach = context.ngach.Find(1),
                bac_luong = 6,
                he_so = 8.00f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 7,
                ngach = context.ngach.Find(1),
                bac_luong = 7,
                he_so = 8.36f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 8,
                ngach = context.ngach.Find(1),
                bac_luong = 8,
                he_so = 8.36f,
                vuot_khung = 1.05f
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            /*------Hết phần dữ liệu chuyên viên cao cấp*/

            /* Phần dữ liệu Chuyên viên */
            heSoLuong = new HeSoLuong()
            {
                id = 9,
                ngach = context.ngach.Find(2),
                bac_luong = 1,
                he_so = 2.34f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 10,
                ngach = context.ngach.Find(2),
                bac_luong = 2,
                he_so = 2.67f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 11,
                ngach = context.ngach.Find(2),
                bac_luong = 3,
                he_so = 3.00f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 12,
                ngach = context.ngach.Find(2),
                bac_luong = 4,
                he_so = 3.33f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 13,
                ngach = context.ngach.Find(2),
                bac_luong = 5,
                he_so = 3.66f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 14,
                ngach = context.ngach.Find(2),
                bac_luong = 6,
                he_so = 3.99f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 15,
                ngach = context.ngach.Find(2),
                bac_luong = 7,
                he_so = 4.32f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 16,
                ngach = context.ngach.Find(2),
                bac_luong = 8,
                he_so = 4.32f,
                vuot_khung = 1.05f
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            /*------Hết phần dữ liệu Chuyên viên*/

            /* Phần dữ liệu Giảng viên chính */
            heSoLuong = new HeSoLuong()
            {
                id = 17,
                ngach = context.ngach.Find(3),
                bac_luong = 1,
                he_so = 4.40f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 18,
                ngach = context.ngach.Find(3),
                bac_luong = 2,
                he_so = 4.74f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 19,
                ngach = context.ngach.Find(3),
                bac_luong = 3,
                he_so = 5.08f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 20,
                ngach = context.ngach.Find(3),
                bac_luong = 4,
                he_so = 5.42f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 21,
                ngach = context.ngach.Find(3),
                bac_luong = 5,
                he_so = 5.76f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 22,
                ngach = context.ngach.Find(3),
                bac_luong = 6,
                he_so = 6.10f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 23,
                ngach = context.ngach.Find(3),
                bac_luong = 7,
                he_so = 6.44f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 24,
                ngach = context.ngach.Find(3),
                bac_luong = 8,
                he_so = 6.44f,
                vuot_khung = 1.05f
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            /*------Hết phần dữ liệu Giảng viên chính */

            /* Phần dữ liệu Giảng viên */
            heSoLuong = new HeSoLuong()
            {
                id = 25,
                ngach = context.ngach.Find(4),
                bac_luong = 1,
                he_so = 2.34f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 26,
                ngach = context.ngach.Find(4),
                bac_luong = 2,
                he_so = 2.67f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 27,
                ngach = context.ngach.Find(4),
                bac_luong = 3,
                he_so = 3.00f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 28,
                ngach = context.ngach.Find(4),
                bac_luong = 4,
                he_so = 3.33f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 29,
                ngach = context.ngach.Find(4),
                bac_luong = 5,
                he_so = 3.66f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 30,
                ngach = context.ngach.Find(4),
                bac_luong = 6,
                he_so = 3.99f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 31,
                ngach = context.ngach.Find(4),
                bac_luong = 7,
                he_so = 4.32f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 32,
                ngach = context.ngach.Find(4),
                bac_luong = 8,
                he_so = 4.32f,
                vuot_khung = 1.05f
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            /*------Hết phần dữ liệu Giảng viên*/

            /* Phần dữ liệu Cán sự */
            heSoLuong = new HeSoLuong()
            {
                id = 33,
                ngach = context.ngach.Find(5),
                bac_luong = 1,
                he_so = 1.86f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 34,
                ngach = context.ngach.Find(5),
                bac_luong = 2,
                he_so = 2.06f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 35,
                ngach = context.ngach.Find(5),
                bac_luong = 3,
                he_so = 2.26f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 36,
                ngach = context.ngach.Find(5),
                bac_luong = 4,
                he_so = 2.46f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 37,
                ngach = context.ngach.Find(5),
                bac_luong = 5,
                he_so = 2.66f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 38,
                ngach = context.ngach.Find(5),
                bac_luong = 6,
                he_so = 2.66f,
                vuot_khung = 1.07f
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 39,
                ngach = context.ngach.Find(5),
                bac_luong = 7,
                he_so = 2.66f,
                vuot_khung = 1.16f
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 40,
                ngach = context.ngach.Find(5),
                bac_luong = 8,
                he_so = 2.66f,
                vuot_khung = 1.27f
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            /*------Hết phần dữ liệu Cán sự */

            /* Phần dữ liệu Nhân viên kĩ thuật */
            heSoLuong = new HeSoLuong()
            {
                id = 41,
                ngach = context.ngach.Find(6),
                bac_luong = 1,
                he_so = 1.65f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 42,
                ngach = context.ngach.Find(6),
                bac_luong = 2,
                he_so = 1.83f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 43,
                ngach = context.ngach.Find(6),
                bac_luong = 3,
                he_so = 2.01f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 44,
                ngach = context.ngach.Find(6),
                bac_luong = 4,
                he_so = 2.19f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 45,
                ngach = context.ngach.Find(6),
                bac_luong = 5,
                he_so = 2.37f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 46,
                ngach = context.ngach.Find(6),
                bac_luong = 6,
                he_so = 2.37f,
                vuot_khung = 1.07f
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 47,
                ngach = context.ngach.Find(6),
                bac_luong = 7,
                he_so = 2.37f,
                vuot_khung = 1.16f
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 48,
                ngach = context.ngach.Find(6),
                bac_luong = 8,
                he_so = 2.37f,
                vuot_khung = 1.27f
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            /*------Hết phần dữ liệu Nhân viên kĩ thuật */

            /* Phần dữ liệu Nhân Viên Bảo Vệ */
            heSoLuong = new HeSoLuong()
            {
                id = 49,
                ngach = context.ngach.Find(7),
                bac_luong = 1,
                he_so = 1.50f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 50,
                ngach = context.ngach.Find(7),
                bac_luong = 2,
                he_so = 1.68f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 51,
                ngach = context.ngach.Find(7),
                bac_luong = 3,
                he_so = 1.86f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 52,
                ngach = context.ngach.Find(7),
                bac_luong = 4,
                he_so = 2.04f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 53,
                ngach = context.ngach.Find(7),
                bac_luong = 5,
                he_so = 2.22f,
                vuot_khung = null
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 54,
                ngach = context.ngach.Find(7),
                bac_luong = 6,
                he_so = 2.22f,
                vuot_khung = 1.07f
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 55,
                ngach = context.ngach.Find(7),
                bac_luong = 7,
                he_so = 2.22f,
                vuot_khung = 1.16f
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            heSoLuong = new HeSoLuong()
            {
                id = 56,
                ngach = context.ngach.Find(7),
                bac_luong = 8,
                he_so = 2.22f,
                vuot_khung = 1.27f
            };
            context.he_so_luong.AddOrUpdate(heSoLuong);
            /*------Hết phần dữ liệu Nhân Viên Bảo Vệ */

            /* Phần dữ liệu tính lương */
            // Khoa CNTT - Chức vụ: Không - Ngạch: NV Kĩ thuật bậc 7 - Hệ số lương: 2.37 VK 1.16
            TinhLuong tinhLuong = new TinhLuong()
            {
                id = 1,
                nhan_vien = context.nhan_vien.Find(1),
                don_vi = context.don_vi.Find(1),
                chuc_vu = context.chuc_vu.Find(21),
                he_so_luong = context.he_so_luong.Find(47),
                ngay_bat_dau = new DateTime(2013, 4, 1),
                ngay_ket_thuc = new DateTime(2015, 9, 2)

            };
            context.tinh_luong.AddOrUpdate(tinhLuong);
            
            // Khoa CNTT - Chức vụ: Không - Ngạch: NV Kĩ thuật bậc 8 - Hệ số lương: 2.37 VK 1.27
            tinhLuong = new TinhLuong()
            {
                id = 2,
                nhan_vien = context.nhan_vien.Find(1),
                don_vi = context.don_vi.Find(1),
                chuc_vu = context.chuc_vu.Find(21),
                he_so_luong = context.he_so_luong.Find(48),
                ngay_bat_dau = new DateTime(2015, 9, 3),
                ngay_ket_thuc = new DateTime(2016, 2, 1)

            };
            context.tinh_luong.AddOrUpdate(tinhLuong);
            
            // Khoa CNTT - Chức vụ: Không - Ngạch: Giảng viên bậc 1 - Hệ số lương: 2.34 VK 1.00
            tinhLuong = new TinhLuong()
            {
                id = 3,
                nhan_vien = context.nhan_vien.Find(1),
                don_vi = context.don_vi.Find(1),
                chuc_vu = context.chuc_vu.Find(21),
                he_so_luong = context.he_so_luong.Find(25),
                ngay_bat_dau = new DateTime(2016, 2, 2),
                ngay_ket_thuc = new DateTime(2016, 4, 1)

            };
            context.tinh_luong.AddOrUpdate(tinhLuong);

            // Khoa CNTT - Chức vụ: Phó bộ môn trực thuộc khoa - Ngạch: Giảng viên bậc 1 - Hệ số lương: 2.34 VK 1.00
            tinhLuong = new TinhLuong()
            {
                id = 4,
                nhan_vien = context.nhan_vien.Find(1),
                don_vi = context.don_vi.Find(1),
                chuc_vu = context.chuc_vu.Find(20),
                he_so_luong = context.he_so_luong.Find(25),
                ngay_bat_dau = new DateTime(2016, 4, 2),
                ngay_ket_thuc = null

            };
            context.tinh_luong.AddOrUpdate(tinhLuong);

            // TTTH - Chức vụ: Không - Ngạch: Giảng viên bậc 1 - Hệ số lương: 2.34 VK 1.00
            tinhLuong = new TinhLuong()
            {
                id = 5,
                nhan_vien = context.nhan_vien.Find(1),
                don_vi = context.don_vi.Find(6),
                chuc_vu = context.chuc_vu.Find(21),
                he_so_luong = context.he_so_luong.Find(25),
                ngay_bat_dau = new DateTime(2016, 5, 1),
                ngay_ket_thuc = new DateTime(2016, 6, 1)

            };
            context.tinh_luong.AddOrUpdate(tinhLuong);

            // TTTH - Chức vụ: Phó giám đốc trung tâm - Ngạch: Giảng viên bậc 1 - Hệ số lương: 2.34 VK 1.00
            tinhLuong = new TinhLuong()
            {
                id = 6,
                nhan_vien = context.nhan_vien.Find(1),
                don_vi = context.don_vi.Find(6),
                chuc_vu = context.chuc_vu.Find(18),
                he_so_luong = context.he_so_luong.Find(25),
                ngay_bat_dau = new DateTime(2016, 6, 2),
                ngay_ket_thuc = null

            };
            context.tinh_luong.AddOrUpdate(tinhLuong);
            /* Hết phần dữ liệu tính lương */

            /* Phần dữ liệu lương cơ bản */
            HangSo hang_so = new HangSo()
            {
                id = 1,
                ten_hang_so = "LUONG_CO_BAN",
                gia_tri = "720000"

            };
            context.hang_so.AddOrUpdate(hang_so);
            /* Hết phần dữ liệu tính lương */

            tinhLuong = new TinhLuong()
            {
                id = 2,
                nhan_vien = context.nhan_vien.Find(1),
                don_vi = context.don_vi.Find(1),
                chuc_vu = context.chuc_vu.Find(21),
                he_so_luong = context.he_so_luong.Find(37),
                ngay_bat_dau = new DateTime(2013, 4, 1),
                ngay_ket_thuc = new DateTime(2014, 9, 2)

            };
            context.tinh_luong.AddOrUpdate(tinhLuong);
            tinhLuong = new TinhLuong()
            {
                id = 2,
                nhan_vien = context.nhan_vien.Find(1),
                don_vi = context.don_vi.Find(1),
                chuc_vu = context.chuc_vu.Find(20),
                he_so_luong = context.he_so_luong.Find(37),
                ngay_bat_dau = new DateTime(2014, 9, 3),
                ngay_ket_thuc = new DateTime(2015, 10, 7)

            };
            context.tinh_luong.AddOrUpdate(tinhLuong);
            tinhLuong = new TinhLuong()
            {
                id = 2,
                nhan_vien = context.nhan_vien.Find(1),
                don_vi = context.don_vi.Find(1),
                chuc_vu = context.chuc_vu.Find(19),
                he_so_luong = context.he_so_luong.Find(25),
                ngay_bat_dau = new DateTime(2015, 10, 8),
                ngay_ket_thuc = null

            };
            context.tinh_luong.AddOrUpdate(tinhLuong);

            base.Seed(context);
        }
    }
}
