using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Record
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public  DateTime DateOf { get; set; }                
        public decimal Price { get; set; }
        public decimal PriceWithDph { get; set; }
        public byte DepartmentId { get; set; }
        public Department Department { get; set; }
        public string InvoiceNumber { get; set; }
        public int Calls { get; set; }
        public int Msgs { get; set; }
        public int Data { get; set; }        


        public Record(string name, string number, DateTime datOf, decimal price, decimal priceWithDph, byte departmentId, string invoiceNumber, int calls, int msgs, int data)
        {
            this.Name = name;
            this.Number = number;
            this.DateOf = datOf;
            this.Price = price;
            this.PriceWithDph = priceWithDph;
            this.DepartmentId = departmentId;
            this.InvoiceNumber = invoiceNumber;
            this.Calls = calls;
            this.Msgs = msgs;
            this.Data = data;
            
        }
        public Record()
        { }
    }
}