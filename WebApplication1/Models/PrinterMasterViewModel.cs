using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PrinterMasterViewModel
    {
        public List<PrinterMaster> PrinterMasters { get; set; }
        public PrinterMaster PrinterMaster { get; set; }
        public List<Department> Departments { get; set; }
        public Department Department { get; set; }
    }
}