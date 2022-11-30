using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class NewPrinterViewModel
    {
        public List<Department> Departments { get; set; }
        public PrinterMaster PrinterMaster { get; set; }
    }
}