namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMasterDataTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NumberMasterDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Number = c.String(),
                        DepartmentId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NumberMasterDatas", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.NumberMasterDatas", new[] { "DepartmentId" });
            DropTable("dbo.NumberMasterDatas");
        }
    }
}
