namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewPc : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.NumberMasterDatas", "Option");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NumberMasterDatas", "Option", c => c.String(nullable: false));
        }
    }
}
