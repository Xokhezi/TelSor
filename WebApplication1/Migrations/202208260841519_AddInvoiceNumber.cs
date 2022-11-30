namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInvoiceNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountingRecords", "InvoiceNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccountingRecords", "InvoiceNumber");
        }
    }
}
