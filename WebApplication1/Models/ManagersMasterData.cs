using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ManagersMasterData
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Osoba")]
        public string Name { get; set; }

        [Required]
        [Range(1,14)]
        [Display(Name = "Oddělení")]
        public string Department { get; set; }
        
        [Required]
        [UserRoleValidation]
        public string Role { get; set; }

        public ManagersMasterData(string name, string department, string role)
        {
            this.Name = name;
            this.Department = department;
            this.Role = role;
        }
        public ManagersMasterData()
        { 
        }
    }
}