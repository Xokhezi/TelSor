using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class NumberMasterDataViewModel
    {
        public NumberMasterData NumberRecord { get; set; }
        public List<NumberMasterData> Records { get; set; }
    }
}