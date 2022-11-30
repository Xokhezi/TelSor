namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountingPrnters : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountingPrinterRentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Byte(nullable: false),
                        Month = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountingPrinterRentals", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.AccountingPrinterRentals", new[] { "DepartmentId" });
            DropTable("dbo.AccountingPrinterRentals");
        }
    }
}
