namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountingPrntersAndRental : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountingPrinterPrints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Byte(nullable: false),
                        Month = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        PriceBw = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceColor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CountBw = c.Int(nullable: false),
                        CountColor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountingPrinterPrints", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.AccountingPrinterPrints", new[] { "DepartmentId" });
            DropTable("dbo.AccountingPrinterPrints");
        }
    }
}
