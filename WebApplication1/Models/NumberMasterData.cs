using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class NumberMasterData
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Jméno a Přijmení")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Telefonní číslo")]
        public string Number { get; set; }

        [Required]
        [Display(Name = "Oddělení")]
        public byte DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}