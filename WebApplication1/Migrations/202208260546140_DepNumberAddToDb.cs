namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepNumberAddToDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "DepNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "DepNumber");
        }
    }
}
