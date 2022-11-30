namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LogsToDb1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Logs");
            AlterColumn("dbo.Logs", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Logs", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Logs");
            AlterColumn("dbo.Logs", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Logs", "Id");
        }
    }
}
