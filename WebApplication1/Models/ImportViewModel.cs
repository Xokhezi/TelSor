using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    
    public class ImportViewModel
    {
        public List<Record> Records { get; set; }
        public Record Record { get; set; }

        [Display(Name="Rok")]
        public int? Year { get; set; }

        [Display(Name = "Měsíc")]
        public int? Month { get; set; }
    }
}