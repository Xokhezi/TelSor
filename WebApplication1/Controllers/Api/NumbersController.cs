
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using System.Web.Http.Cors;


namespace WebApplication1.Controllers.Api
{
    [EnableCors(origins: "file://sw02660.global.hvwan.net/PrivDoc$/IT/Intranet/dist/index.html", headers: "*", methods: "*")]
    public class NumbersController : ApiController
    {
        private ApplicationDbContext _context;

        
        public NumbersController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/numbers
        
        [HttpGet]
        public IEnumerable<NumberMasterData> GetNumbers()
        {             
            return _context.NumberMasterDatas.ToList(); 
        }
    }
}
