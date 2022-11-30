using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AccountingPrinterPrint
    {        
            public int Id { get; set; }
            public byte DepartmentId { get; set; }
            public Department Department { get; set; }

             [Display(Name="Měsíc")]
             public int Month { get; set; }

             [Display(Name = "Rok")]
             public int Year { get; set; }
            public decimal PriceBw { get; set; }
            public decimal PriceColor { get; set; }
            public int CountBw { get; set; }
            public int CountColor { get; set; }


            public AccountingPrinterPrint()
            { }
            public AccountingPrinterPrint(byte departmentId, int year, int month, decimal priceBw, decimal priceColor,int countBw, int countColor)
            {
                this.DepartmentId = departmentId;
                this.Month = month;
                this.Year = year;
                this.PriceBw = priceBw;
                this.PriceColor = priceColor;
                this.CountBw = countBw;
                this.CountColor = countColor;


            }
     }
    
}