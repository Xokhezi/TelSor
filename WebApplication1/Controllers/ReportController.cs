using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Manager,Admin")]
    public class ReportController : Controller
    {
        private ApplicationDbContext _context;


        public ReportController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Report
        public ActionResult Index()
        {
            var currentUser = User.Identity;
            
            var manager = _context.ManagersMasterDatas.SingleOrDefault(u => u.Name == currentUser.Name);

            var depId = byte.Parse(manager.Department);
                                   
            var records = _context.Records.ToList();
            var master = _context.NumberMasterDatas.Include(r => r.Department).ToList();
            var departmentAsigned = new List<Record>();

            //department sorting
            foreach (var r in records)
            {
                var number = master.SingleOrDefault(n => n.Number == r.Number);
                if (number != null)
                {
                    var result = master.SingleOrDefault(c => c.Number == r.Number);
                    var department = result.DepartmentId;
                    r.DepartmentId = department;
                }

                departmentAsigned.Add(r);
            }

            //sorting for single department

            var recordsForDepartment = new List<Record>();
            if (departmentAsigned.ToList().Count != 0)
                 recordsForDepartment = departmentAsigned.Where(r => r.Department.Manager == depId).ToList();
            



            var viewmodel = new ReportViewModel()
            {                
                Record = new Record(),
                Records = recordsForDepartment
            };

            return View(viewmodel);
        }

    }
}