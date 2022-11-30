namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePricesForNull1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Records", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Records", "PriceWithDph", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Records", "PriceWithDph", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Records", "Price", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
