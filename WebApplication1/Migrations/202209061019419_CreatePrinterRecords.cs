namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePrinterRecords : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PrinterRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ResponsiblePerson = c.String(),
                        Factory = c.String(),
                        Room = c.String(),
                        SerialNr = c.String(),
                        RentalPrize = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DepartmentId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrinterRecords", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.PrinterRecords", new[] { "DepartmentId" });
            DropTable("dbo.PrinterRecords");
        }
    }
}
