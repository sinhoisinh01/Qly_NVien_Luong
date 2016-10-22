namespace Webapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
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
                        ngach_id = c.Int(nullable: false),
                        bac_luong = c.Int(nullable: false),
                        he_so = c.Single(nullable: false),
                        vuot_khung = c.Single(),
                        ngach_id1 = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Ngaches", t => t.ngach_id1)
                .Index(t => t.ngach_id1);
            
            CreateTable(
                "dbo.TinhLuongs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nhan_vien_id = c.Int(nullable: false),
                        don_vi_id = c.Int(nullable: false),
                        chuc_vu_id = c.Int(nullable: false),
                        he_so_luong_id = c.Int(nullable: false),
                        ngay_bat_dau = c.DateTime(nullable: false),
                        ngay_ket_thuc = c.DateTime(),
                        nhan_vien_id1 = c.Int(),
                        don_vi_id1 = c.Int(),
                        chuc_vu_id1 = c.Int(),
                        he_so_luong_id1 = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.NhanViens", t => t.nhan_vien_id1)
                .ForeignKey("dbo.DonVis", t => t.don_vi_id1)
                .ForeignKey("dbo.ChucVus", t => t.chuc_vu_id1)
                .ForeignKey("dbo.HeSoLuongs", t => t.he_so_luong_id1)
                .Index(t => t.nhan_vien_id1)
                .Index(t => t.don_vi_id1)
                .Index(t => t.chuc_vu_id1)
                .Index(t => t.he_so_luong_id1);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TinhLuongs", new[] { "he_so_luong_id1" });
            DropIndex("dbo.TinhLuongs", new[] { "chuc_vu_id1" });
            DropIndex("dbo.TinhLuongs", new[] { "don_vi_id1" });
            DropIndex("dbo.TinhLuongs", new[] { "nhan_vien_id1" });
            DropIndex("dbo.HeSoLuongs", new[] { "ngach_id1" });
            DropForeignKey("dbo.TinhLuongs", "he_so_luong_id1", "dbo.HeSoLuongs");
            DropForeignKey("dbo.TinhLuongs", "chuc_vu_id1", "dbo.ChucVus");
            DropForeignKey("dbo.TinhLuongs", "don_vi_id1", "dbo.DonVis");
            DropForeignKey("dbo.TinhLuongs", "nhan_vien_id1", "dbo.NhanViens");
            DropForeignKey("dbo.HeSoLuongs", "ngach_id1", "dbo.Ngaches");
            DropTable("dbo.TinhLuongs");
            DropTable("dbo.HeSoLuongs");
            DropTable("dbo.DonVis");
            DropTable("dbo.ChucVus");
            DropTable("dbo.Ngaches");
            DropTable("dbo.NhanViens");
        }
    }
}
