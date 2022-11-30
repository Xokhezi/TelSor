namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatetimeRecors : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Records", "DateOf", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Records", "DateOf", c => c.DateTime(nullable: false));
        }
    }
}
