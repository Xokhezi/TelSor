using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PrinterMaster
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Název")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Oddělení")]
        public byte DepartmentId { get; set; }
        public Department Department { get; set; }

        [Required]
        [Display(Name = "Odpovědná osoba")]
        public string ResponsiblePerson { get; set; }

        [Required]
        [Display(Name = "Závod")]
        public string  Factory { get; set; }

        [Required]
        [Display(Name = "Sériové číslo")]
        public string SerialNr { get; set; }
        [Required]
        [Display(Name = "Místnost")]
        public string Room { get; set; }
    }
}