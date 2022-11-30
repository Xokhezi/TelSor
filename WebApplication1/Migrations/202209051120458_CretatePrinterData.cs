namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CretatePrinterData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PrinterMasters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DepartmentId = c.Byte(nullable: false),
                        ResponsiblePerson = c.String(),
                        Factory = c.String(),
                        SerialNr = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrinterMasters", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.PrinterMasters", new[] { "DepartmentId" });
            DropTable("dbo.PrinterMasters");
        }
    }
}
