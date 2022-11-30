using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PrinterRecordPrint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ResponsiblePerson { get; set; }
        public string Factory { get; set; }
        public string Room { get; set; }
        public string SerialNr { get; set; }
        public decimal PrizeBw { get; set; }
        public decimal PrizeColor { get; set; }
        public int CountBw { get; set; }
        public int CountColor { get; set; }
        public byte DepartmentId { get; set; }
        public Department Department { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public PrinterRecordPrint()
        {

        }
        public PrinterRecordPrint(string name, string responsiblePerson, string factory, string room, string serialNr, decimal prizeBw, decimal prizeColor,int countBw,int countColor, byte departmentId,int month, int year)
        {
            this.Name = name;
            this.ResponsiblePerson = responsiblePerson;
            this.Factory = factory;
            this.Room = room;
            this.SerialNr = serialNr;
            this.CountBw = countBw;
            this.CountColor = countColor;
            this.PrizeBw = prizeBw;
            this.PrizeColor = prizeColor;
            this.DepartmentId = departmentId;
            this.Year = year;
            this.Month = month;

        }
    }
}