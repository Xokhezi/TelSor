using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    //model logic for accountingRecords
    public class AccountingRecord
    {
        public int Id { get; set; }
        public byte DepartmentId { get; set; }
        public Department Department { get; set; }
        public DateTime DateOf { get; set; }
        public decimal Price { get; set; }
        public decimal PriceWithDph { get; set; }
        public string InvoiceNumber { get; set; }

        public AccountingRecord()
        { }
        public AccountingRecord(byte departmentId, DateTime dateOf,decimal price, decimal priceWithDph, string invoiceNumber)
        {
            this.DepartmentId = departmentId;
            this.DateOf = dateOf;
            this.Price = price;
            this.PriceWithDph = priceWithDph;
            this.InvoiceNumber = invoiceNumber;
        }
    }
    
}