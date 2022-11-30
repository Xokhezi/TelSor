namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMasterDataDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NumberMasterDatas", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.NumberMasterDatas", "Number", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NumberMasterDatas", "Number", c => c.String());
            AlterColumn("dbo.NumberMasterDatas", "Name", c => c.String());
        }
    }
}
