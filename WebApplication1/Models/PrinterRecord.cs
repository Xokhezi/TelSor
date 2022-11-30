using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PrinterRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ResponsiblePerson { get; set; }
        public string Factory { get; set; }
        public string Room { get; set; }
        public string SerialNr { get; set; }
        public decimal RentalPrize { get; set; }
        public byte DepartmentId { get; set; }
        public Department Department { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public PrinterRecord()
        {

        }
        public PrinterRecord(string name, string responsiblePerson, string factory, string room, string serialNr, decimal rentalPrize, byte departmentId,int year,int month)
        {
            this.Name = name;
            this.ResponsiblePerson = responsiblePerson;
            this.Factory = factory;
            this.Room = room;
            this.SerialNr = serialNr;
            this.RentalPrize = rentalPrize;
            this.DepartmentId = departmentId;
            this.Year = year;
            this.Month = month;

        }

    }

    
}