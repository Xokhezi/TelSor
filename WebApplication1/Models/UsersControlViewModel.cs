using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class UsersControlViewModel
    {
        public List<ApplicationUser> Users { get; set; }
        
        public ApplicationUser User { get; set; }

        public ManagersMasterData ManagerData { get; set; }
        public List<ManagersMasterData> ManagersMasterDatas { get; set; }
    }
}