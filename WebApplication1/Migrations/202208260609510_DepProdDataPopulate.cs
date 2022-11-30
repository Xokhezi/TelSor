namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepProdDataPopulate : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (1, 'Neur�eno', 'Neur�eno')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (2, '191000', 'Veden� Vrbno')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (3, '191001', 'Mana�er z�vodu Vrbno')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (4, '191010', 'Mana�er z�vodu Brunt�l')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (5, '192110', 'Lidsk� zdroje Vrbno')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (6, '192320', 'Energetika Vrbno')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (7, '192330', 'Ekologie')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (8, '192400', 'Pl�nov�n� a investic')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (9, '193100', 'Projekty')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (10, '193110', 'Logistika Vrbno')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (11, '193120', 'Expedice, skladov�n�')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (12, '193130', 'Sklad HV Vrbno')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (13, '193200', 'IT')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (14, '193310', 'Z�sobov�n� Vrbno')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (15, '193317', 'Z�sobov�n� Robotics')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (16, '193320', 'Sklad materi�lu Vr')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (17, '195100', 'Veden� plast v�roby')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (18, '195101', 'P��prava v�roby Vr')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (19, '195102', '�dr�ba Vrbno')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (20, '195105', 'Sklad forem')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (21, '195110', 'Mist�i TP1 Plasty I')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (22, '195120', 'Mist�i TP2  PlastyII')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (23, '195144', 'Regenerace')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (24, '195147', 'Mont� Robotics')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (25, '196000', 'Veden� stroj. v�roby')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (26, '196400', 'Konstrukce')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (27, '196800', 'N�stroj�rna')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (28, '196801', '�ez�rna, ost��rna')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (29, '196895', 'Mechanici - nov� for')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (30, '197012', 'V�robn� kontrola Vr')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (31, '197013', 'V�r kontr n�stroje')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (32, '197017', 'Kontrola Robotics Vr')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (33, '197110', 'Kvalita Vrbno')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (34, '198100', 'Servis opravy')");
        }

        public override void Down()
        {
        }
    }
}
