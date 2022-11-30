using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ImportPrinterViewModel
    {
        public List<PrinterRecord> PrinterRecords { get; set; }
        public PrinterRecord PrinterRecord { get; set; }
        public List<PrinterRecordPrint> PrinterRecordPrints { get; set; }
        public PrinterRecordPrint PrinterRecordPrint { get; set; }
        public Department Department { get; set; }
        public List<Department> Departments { get; set; }

        [Required]
        [Display(Name = "Měsíc")]
        public int? Month { get; set; }

        [Required]
        [Display(Name = "Rok")]
        public int? Year { get; set; }
    }
}