namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationsTORole : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ManagersMasterDatas", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ManagersMasterDatas", "Department", c => c.String(nullable: false));
            AlterColumn("dbo.ManagersMasterDatas", "Role", c => c.String(nullable: false));
            AlterColumn("dbo.PrinterMasters", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.PrinterMasters", "ResponsiblePerson", c => c.String(nullable: false));
            AlterColumn("dbo.PrinterMasters", "Factory", c => c.String(nullable: false));
            AlterColumn("dbo.PrinterMasters", "SerialNr", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PrinterMasters", "SerialNr", c => c.String());
            AlterColumn("dbo.PrinterMasters", "Factory", c => c.String());
            AlterColumn("dbo.PrinterMasters", "ResponsiblePerson", c => c.String());
            AlterColumn("dbo.PrinterMasters", "Name", c => c.String());
            AlterColumn("dbo.ManagersMasterDatas", "Role", c => c.String());
            AlterColumn("dbo.ManagersMasterDatas", "Department", c => c.String());
            AlterColumn("dbo.ManagersMasterDatas", "Name", c => c.String());
        }
    }
}
