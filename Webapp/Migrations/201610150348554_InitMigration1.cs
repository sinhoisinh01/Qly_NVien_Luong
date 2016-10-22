namespace Webapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.HeSoLuongs", name: "ngach_id1", newName: "ngach_id");
            RenameColumn(table: "dbo.TinhLuongs", name: "nhan_vien_id1", newName: "nhan_vien_id");
            RenameColumn(table: "dbo.TinhLuongs", name: "don_vi_id1", newName: "don_vi_id");
            RenameColumn(table: "dbo.TinhLuongs", name: "chuc_vu_id1", newName: "chuc_vu_id");
            RenameColumn(table: "dbo.TinhLuongs", name: "he_so_luong_id1", newName: "he_so_luong_id");
            AlterColumn("dbo.HeSoLuongs", "ngach_id", c => c.Int());
            AlterColumn("dbo.TinhLuongs", "nhan_vien_id", c => c.Int());
            AlterColumn("dbo.TinhLuongs", "don_vi_id", c => c.Int());
            AlterColumn("dbo.TinhLuongs", "chuc_vu_id", c => c.Int());
            AlterColumn("dbo.TinhLuongs", "he_so_luong_id", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TinhLuongs", "he_so_luong_id", c => c.Int(nullable: false));
            AlterColumn("dbo.TinhLuongs", "chuc_vu_id", c => c.Int(nullable: false));
            AlterColumn("dbo.TinhLuongs", "don_vi_id", c => c.Int(nullable: false));
            AlterColumn("dbo.TinhLuongs", "nhan_vien_id", c => c.Int(nullable: false));
            AlterColumn("dbo.HeSoLuongs", "ngach_id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.TinhLuongs", name: "he_so_luong_id", newName: "he_so_luong_id1");
            RenameColumn(table: "dbo.TinhLuongs", name: "chuc_vu_id", newName: "chuc_vu_id1");
            RenameColumn(table: "dbo.TinhLuongs", name: "don_vi_id", newName: "don_vi_id1");
            RenameColumn(table: "dbo.TinhLuongs", name: "nhan_vien_id", newName: "nhan_vien_id1");
            RenameColumn(table: "dbo.HeSoLuongs", name: "ngach_id", newName: "ngach_id1");
        }
    }
}
