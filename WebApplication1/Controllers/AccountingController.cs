using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    [Authorize(Roles ="Accounting,Admin")]
    public class AccountingController : Controller
    {
        private ApplicationDbContext _context;


        public AccountingController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Accounting
        public ActionResult Index()
        {
            decimal totalPrice = 0;
            decimal totalPriceWithDph = 0;
            var importedRecords = _context.Records.ToList();
            var records = _context.AccountingRecords
                         .Include(r => r.Department)
                         .ToList();

            var months = new List<int>();
            for(int i=1; i<= 12; i++) 
            {
                var recordsInMonth = importedRecords
                                    .Where(r => r.DateOf.Month == i)
                                    .ToList()
                                    .Count();
                if (recordsInMonth != 0)
                    months.Add(i);             
                            
            }

            foreach (var r in records)
            {
                totalPrice += r.Price;
                totalPriceWithDph += r.PriceWithDph;
            }

            var viewModel = new AccountingViewModel()
            {
                Records = records,
                Record = new AccountingRecord(),
                Year = DateTime.Now.Year,
                Month = DateTime.Now.Month,
                TotalPrice = totalPrice,
                TotalPriceWithDph = totalPriceWithDph,
                NotCalculatedMonths=months
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult DoCalculation(int month, int year)
        {
            var records = _context.AccountingRecords.Include(r => r.Department).ToList();
            if(records.Count ==0)
            {

                var import = _context.Records
                    .Include(r => r.Department)
                    .Where(r => r.DateOf.Year == year)
                    .Where(r => r.DateOf.Month == month)
                    .ToList();

                var master = _context.NumberMasterDatas.Include(r => r.Department).ToList();
                var departments = _context.Departments.ToList();
                var departmentAsigned = new List<Record>();
                decimal departmentTotal = 0;
                decimal departmentTotalWithDph = 0;

                //Asigning of department regarding master data
                foreach (var r in import)
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


                //Calculation of all nubmers for same department and save to database
                foreach (var d in departments)
                {
                    var departmentRecords = departmentAsigned.Where(r => r.DepartmentId == d.Id);
                    foreach (var r in departmentRecords)
                    {
                        departmentTotal += r.Price;
                        departmentTotalWithDph += r.PriceWithDph;
                    }

                    var sum = new AccountingRecord(d.Id, departmentAsigned[0].DateOf, departmentTotal, departmentTotalWithDph, departmentAsigned[0].InvoiceNumber);
                    departmentTotal = 0;
                    departmentTotalWithDph = 0;

                    if (sum.Price != 0)
                        _context.AccountingRecords.Add(sum);
                }
                
                _context.SaveChanges();

                

            }
            return RedirectToAction("Index");
        }
        //delete of accountingRecords regarding date
        [HttpPost]
        public ActionResult Posting(int month, int year)
        {
            _context.AccountingRecords
                .RemoveRange((_context.AccountingRecords
                .Where(x => x.DateOf.Year == year)
                .Where(x => x.DateOf.Month == month)));
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}