namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateToPrintersRecs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PrinterRecordPrints", "Month", c => c.Int(nullable: false));
            AddColumn("dbo.PrinterRecordPrints", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.PrinterRecords", "Month", c => c.Int(nullable: false));
            AddColumn("dbo.PrinterRecords", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PrinterRecords", "Year");
            DropColumn("dbo.PrinterRecords", "Month");
            DropColumn("dbo.PrinterRecordPrints", "Year");
            DropColumn("dbo.PrinterRecordPrints", "Month");
        }
    }
}
