using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PrinterMasterController : Controller
    {
        private ApplicationDbContext _context;


        public PrinterMasterController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: PrinterMaster
        public ActionResult Index()
        {
            var departments = _context.Departments.ToList();
            var printersMaster = _context.PrinterMasters.ToList();

            var viewModel = new PrinterMasterViewModel()
            {
            PrinterMasters =  printersMaster,
            Departments = departments,
            Department = new Department()
            }; 

            return View(viewModel);
        }

        public ActionResult New()
        {
            var deps = _context.Departments.ToList();
            var record = new NewPrinterViewModel()
            {
                Departments = deps,
                PrinterMaster = new PrinterMaster()
            };

            return View(record);
        }
        public ActionResult Detail(int id)
        {
            var printer = _context.PrinterMasters.SingleOrDefault(p => p.Id == id);
            var deps = _context.Departments.ToList();
            if (printer == null)
                return HttpNotFound();
            var viewModel = new NewPrinterViewModel()
            {
                Departments = deps,
                PrinterMaster = printer
            };
            return View("New", viewModel);
        }


        [HttpPost]
        public ActionResult Save(PrinterMaster printerMaster)
        {

            if (!ModelState.IsValid)
            {
                return View("New", printerMaster);
            }
            else
            {
                if (printerMaster.Id == 0)
                {
                    _context.PrinterMasters.Add(printerMaster);
                }
                else
                {
                    var recordInDb = _context.PrinterMasters.Single(m => m.Id == printerMaster.Id);

                    recordInDb.SerialNr = printerMaster.SerialNr;
                    recordInDb.Name = printerMaster.Name;
                    recordInDb.DepartmentId = printerMaster.DepartmentId;
                    recordInDb.Factory = printerMaster.Factory;
                    recordInDb.ResponsiblePerson = printerMaster.ResponsiblePerson;
                    

                }
            }
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DeleteMasterData(int id)
        {
            _context.PrinterMasters
                .RemoveRange((_context.PrinterMasters
                .Where(x => x.Id == id)));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}