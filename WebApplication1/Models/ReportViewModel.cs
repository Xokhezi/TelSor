using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ReportViewModel
    {
        public List<Record> Records { get; set; }
        public Record Record { get; set; }

    }
}