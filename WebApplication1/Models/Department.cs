using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    
    public class Department
    {
        public byte Id { get; set; }
                
        public string Name { get; set; }

        public string DepNumber { get; set; }
        public byte Manager { get; set; }
    }
}