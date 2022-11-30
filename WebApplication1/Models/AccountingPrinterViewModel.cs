using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AccountingPrinterViewModel
    {
        public PrinterRecord PrinterRecord { get; set; }
        public List<AccountingPrinterRental> PrinterRecords { get; set; }
        public PrinterRecordPrint PrinterRecordPrint { get; set; }
        public List<AccountingPrinterPrint> PrinterRecordPrints { get; set; }
        public List<Department> Departments { get; set; }
        public Department Department { get; set; }
        public decimal Rental { get; set; }
        public int CountBw { get; set; }
        public int CountColor { get; set; }
        public decimal PrizeBw { get; set; }
        public decimal PrizeColor { get; set; }
        public decimal PrintsSummary { get; set; }

        [Display (Name ="Rok")]
        public int? Year { get; set; }

        [Display(Name = "Měsíc")]
        public int? Month { get; set; }
    }
}