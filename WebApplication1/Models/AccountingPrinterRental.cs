using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AccountingPrinterRental
    {
        public int Id { get; set; }
        public byte DepartmentId { get; set; }
        public Department Department { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }        
        

        public AccountingPrinterRental()
        { }
        public AccountingPrinterRental(byte departmentId, int month, int year , decimal price)
        {
            this.DepartmentId = departmentId;
            this.Month = month;
            this.Year = year;
            this.Price = price;
            
            
        }
    }
}