namespace Qly_Nhan_Vien_Luong_Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowFK : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChucVus",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ten_chuc_vu = c.String(),
                        he_so_chuc_vu = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.DonVis",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ten_goi = c.String(),
                        dia_chi = c.String(),
                        dien_thoai = c.String(),
                        ngay_thanh_lap = c.DateTime(nullable: false),
                        mo_ta = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.HeSoLuongs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        bac_luong = c.Int(nullable: false),
                        he_so = c.Single(nullable: false),
                        vuot_khung = c.Single(),
                        ngach_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Ngaches", t => t.ngach_id)
                .Index(t => t.ngach_id);
            
            CreateTable(
                "dbo.Ngaches",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ma_so = c.String(),
                        ten_ngach = c.String(),
                        mo_ta = c.String(),
                        nien_han = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.NhanViens",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ma_so = c.String(),
                        ho = c.String(),
                        ten = c.String(),
                        gioi_tinh = c.Boolean(nullable: false),
                        ngay_sinh = c.DateTime(nullable: false),
                        dan_toc = c.String(),
                        dia_chi = c.String(),
                        cmnd = c.String(),
                        hinh_anh = c.String(),
                        ngay_vao_lam = c.DateTime(nullable: false),
                        ngay_nghi_lam = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.TinhLuongs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ngay_bat_dau = c.DateTime(nullable: false),
                        ngay_ket_thuc = c.DateTime(),
                        chuc_vu_id = c.Int(),
                        don_vi_id = c.Int(),
                        he_so_luong_id = c.Int(),
                        nhan_vien_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ChucVus", t => t.chuc_vu_id)
                .ForeignKey("dbo.DonVis", t => t.don_vi_id)
                .ForeignKey("dbo.HeSoLuongs", t => t.he_so_luong_id)
                .ForeignKey("dbo.NhanViens", t => t.nhan_vien_id)
                .Index(t => t.chuc_vu_id)
                .Index(t => t.don_vi_id)
                .Index(t => t.he_so_luong_id)
                .Index(t => t.nhan_vien_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TinhLuongs", "nhan_vien_id", "dbo.NhanViens");
            DropForeignKey("dbo.TinhLuongs", "he_so_luong_id", "dbo.HeSoLuongs");
            DropForeignKey("dbo.TinhLuongs", "don_vi_id", "dbo.DonVis");
            DropForeignKey("dbo.TinhLuongs", "chuc_vu_id", "dbo.ChucVus");
            DropForeignKey("dbo.HeSoLuongs", "ngach_id", "dbo.Ngaches");
            DropIndex("dbo.TinhLuongs", new[] { "nhan_vien_id" });
            DropIndex("dbo.TinhLuongs", new[] { "he_so_luong_id" });
            DropIndex("dbo.TinhLuongs", new[] { "don_vi_id" });
            DropIndex("dbo.TinhLuongs", new[] { "chuc_vu_id" });
            DropIndex("dbo.HeSoLuongs", new[] { "ngach_id" });
            DropTable("dbo.TinhLuongs");
            DropTable("dbo.NhanViens");
            DropTable("dbo.Ngaches");
            DropTable("dbo.HeSoLuongs");
            DropTable("dbo.DonVis");
            DropTable("dbo.ChucVus");
        }
    }
}
