namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepProdDataPopulate : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (1, 'Neurèeno', 'Neurèeno')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (2, '191000', 'Vedení Vrbno')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (3, '191001', 'Manažer závodu Vrbno')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (4, '191010', 'Manažer závodu Bruntál')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (5, '192110', 'Lidské zdroje Vrbno')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (6, '192320', 'Energetika Vrbno')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (7, '192330', 'Ekologie')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (8, '192400', 'Plánování a investic')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (9, '193100', 'Projekty')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (10, '193110', 'Logistika Vrbno')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (11, '193120', 'Expedice, skladování')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (12, '193130', 'Sklad HV Vrbno')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (13, '193200', 'IT')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (14, '193310', 'Zásobování Vrbno')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (15, '193317', 'Zásobování Robotics')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (16, '193320', 'Sklad materiálu Vr')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (17, '195100', 'Vedení plast výroby')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (18, '195101', 'Pøíprava výroby Vr')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (19, '195102', 'Údržba Vrbno')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (20, '195105', 'Sklad forem')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (21, '195110', 'Mistøi TP1 Plasty I')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (22, '195120', 'Mistøi TP2  PlastyII')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (23, '195144', 'Regenerace')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (24, '195147', 'Montáž Robotics')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (25, '196000', 'Vedení stroj. výroby')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (26, '196400', 'Konstrukce')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (27, '196800', 'Nástrojárna')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (28, '196801', 'Øezárna, ostøírna')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (29, '196895', 'Mechanici - nové for')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (30, '197012', 'Výrobní kontrola Vr')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (31, '197013', 'Výr kontr nástroje')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (32, '197017', 'Kontrola Robotics Vr')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (33, '197110', 'Kvalita Vrbno')");
            Sql("INSERT INTO Departments (Id, DepNumber, Name) VALUES (34, '198100', 'Servis opravy')");
        }

        public override void Down()
        {
        }
    }
}
