namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrintsReords : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PrinterRecordPrints",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ResponsiblePerson = c.String(),
                        Factory = c.String(),
                        Room = c.String(),
                        SerialNr = c.String(),
                        PrizeBw = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrizeColor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CountBw = c.Int(nullable: false),
                        CountColor = c.Int(nullable: false),
                        DepartmentId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrinterRecordPrints", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.PrinterRecordPrints", new[] { "DepartmentId" });
            DropTable("dbo.PrinterRecordPrints");
        }
    }
}
