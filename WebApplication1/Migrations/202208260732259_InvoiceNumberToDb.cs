namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceNumberToDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Records", "InvoiceNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Records", "InvoiceNumber");
        }
    }
}
