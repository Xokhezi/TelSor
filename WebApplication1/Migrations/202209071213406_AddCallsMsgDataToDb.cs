namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCallsMsgDataToDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Records", "Calls", c => c.Int(nullable: false));
            AddColumn("dbo.Records", "Msgs", c => c.Int(nullable: false));
            AddColumn("dbo.Records", "Data", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Records", "Data");
            DropColumn("dbo.Records", "Msgs");
            DropColumn("dbo.Records", "Calls");
        }
    }
}
