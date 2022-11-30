using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{

    public class LogViewModel
    {
        public Log Log { get; set; }
        public List<Log> Logs { get; set; }
    }
}