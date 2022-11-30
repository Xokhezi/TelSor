namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoomtoPrinterMaster : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PrinterMasters", "Room", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PrinterMasters", "Room");
        }
    }
}
