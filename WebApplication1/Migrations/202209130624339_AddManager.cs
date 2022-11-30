namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManager : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "Manager", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "Manager");
        }
    }
}
