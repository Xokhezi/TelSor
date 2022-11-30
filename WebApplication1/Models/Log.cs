using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{

    public class Log
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Action { get; set; }
        public string ActualValues { get; set; }
        public string NewValues { get; set; }

        public Log()
        {
           
        }
        public Log(string user, string action, string actualValues, string newValues)
        {
            this.User = user;
            this.Action = action;
            this.ActualValues = actualValues;
            this.NewValues = newValues;
        }
    }

}