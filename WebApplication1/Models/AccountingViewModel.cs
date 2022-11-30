using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    //accounting index viewModel
    public class AccountingViewModel
    {
        public AccountingRecord Record { get; set; }
        public List<AccountingRecord> Records { get; set; }
        [Display(Name="Měsíc")]
        public int Month { get; set; }
        [Display(Name = "Rok")]
        public int Year { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalPriceWithDph { get; set; }

        public List<int> NotCalculatedMonths { get; set; }

    }
}