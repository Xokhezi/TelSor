namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ROlesToDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ManagersMasterDatas", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ManagersMasterDatas", "Role");
        }
    }
}
