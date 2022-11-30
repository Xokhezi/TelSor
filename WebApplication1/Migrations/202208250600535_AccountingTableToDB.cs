namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountingTableToDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountingRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Byte(nullable: false),
                        DateOf = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceWithDph = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountingRecords", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.AccountingRecords", new[] { "DepartmentId" });
            DropTable("dbo.AccountingRecords");
        }
    }
}
