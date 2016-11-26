namespace Qly_Luong_NVien_Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTableHangSo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HangSoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ten_hang_so = c.String(),
                        gia_tri = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HangSoes");
        }
    }
}
