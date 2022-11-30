using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Accounting,Admin")]
    public class PrinterAccountingController : Controller
    {
        private ApplicationDbContext _context;


        public PrinterAccountingController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: PrinterAccounting
        public ActionResult Index(string submit, int? year, int? month)
        {
            //výmaz vybraného měsíce pokud button delete
            if (submit == "delete")
            {
                _context.AccountingPrinterPrints
                   .RemoveRange((_context.AccountingPrinterPrints
                   .Where(x => x.Year == year)
                   .Where(x => x.Month == month)));

                _context.AccountingPrinterRentals
                    .RemoveRange((_context.AccountingPrinterRentals
                    .Where(x => x.Year == year)
                    .Where(x => x.Month == month)));

                _context.PrinterRecords
                    .RemoveRange((_context.PrinterRecords
                    .Where(x => x.Year == year)
                    .Where(x => x.Month == month)));

                _context.PrinterRecordPrints
                    .RemoveRange((_context.PrinterRecordPrints
                    .Where(x => x.Year == year)
                    .Where(x => x.Month == month)));

                _context.SaveChanges();

                return RedirectToAction("Index");

            }
            //kalkulace vybraného měsíce pokud button calc
            if (submit == "calc")
            {
                if (_context.AccountingPrinterRentals.Where(r => r.Year == year).Where(r => r.Month == month).ToList().Count() == 0)
                {
                    var records = _context.PrinterRecords.Where(r => r.Year == year).Where(r => r.Month == month).ToList();
                    var recordsPrints = _context.PrinterRecordPrints.Where(r => r.Year == year).Where(r => r.Month == month).ToList();
                    var master = _context.PrinterMasters.Include(d => d.Department).ToList();
                    var departments = _context.Departments.ToList();

                    if (records.Count == 0)
                        return RedirectToAction("ErrorImp");
                    else { 

                    var asignedRecords = new List<PrinterRecord>();
                    var asignedRecordsPrints = new List<PrinterRecordPrint>();

                    var rentalFinalList = new List<AccountingPrinterRental>();
                    var printsFinalList = new List<AccountingPrinterPrint>();

                    decimal prize = 0;

                    //přiřazení oddělení rental
                    foreach (var r in records)
                    {
                        var dep = master.SingleOrDefault(p => p.SerialNr == r.SerialNr).DepartmentId;
                        asignedRecords.Add(new PrinterRecord(r.Name, r.ResponsiblePerson, r.Factory, r.Room, r.SerialNr, r.RentalPrize, dep, r.Year, r.Month));
                    }
                    //součet cen pro oddělení a zápis rental
                    foreach (var d in departments)
                    {
                        var recordsForDep = asignedRecords.Where(p => p.DepartmentId == d.Id);
                        foreach (var r in recordsForDep)
                        {
                            prize += r.RentalPrize;

                        }
                        rentalFinalList.Add(new AccountingPrinterRental(d.Id, asignedRecords[0].Month, asignedRecords[0].Year, prize));
                        prize = 0;
                    }

                    //stejný postup pro tisky
                    foreach (var r in recordsPrints)
                    {
                        var dep = master.SingleOrDefault(p => p.SerialNr == r.SerialNr).DepartmentId;
                        asignedRecordsPrints.Add(new PrinterRecordPrint(r.Name, r.ResponsiblePerson, r.Factory, r.Room, r.SerialNr, r.PrizeBw, r.PrizeColor, r.CountBw, r.CountColor, dep, r.Month, r.Year));
                    }

                    foreach (var d in departments)
                    {
                        decimal prizeBw = 0;
                        decimal prizeColor = 0;
                        int countBw = 0;
                        int countColor = 0;

                        var recordsForDep = asignedRecordsPrints.Where(p => p.DepartmentId == d.Id);
                        foreach (var r in recordsForDep)
                        {
                            countBw += r.CountBw;
                            countColor += r.CountColor;
                            prizeBw += r.PrizeBw;
                            prizeColor += r.PrizeColor;


                        }
                        printsFinalList.Add(new AccountingPrinterPrint(d.Id, asignedRecords[0].Year, asignedRecords[0].Month, prizeBw, prizeColor, countBw, countColor));
                        prizeBw = 0;
                        prizeColor = 0;
                        countBw = 0;
                        countColor = 0;
                    }
                    //zápis do db
                    foreach (var r in rentalFinalList)
                        _context.AccountingPrinterRentals.Add(r);

                    foreach (var r in printsFinalList)
                        _context.AccountingPrinterPrints.Add(r);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                    }
                }
                else
                    return RedirectToAction("ErrorCalc");
            }
            //Refresh na vybraný měsíc 
            else
            {
                year = year == null ? DateTime.Now.Year : year;
                month = month == null ? DateTime.Now.Month : month;

                var departments = _context.Departments.ToList();
                var rental = _context.AccountingPrinterRentals.Where(r => r.Year == year).Where(r => r.Month == month).Include(d => d.Department).ToList();
                var prints = _context.AccountingPrinterPrints.Where(r => r.Year == year).Where(r => r.Month == month).Include(d => d.Department).ToList();

                decimal summaryRental = 0;

                int summaryPrintsBw = 0;
                int summaryPrintsColor = 0;
                decimal summaryPrizeBw = 0;
                decimal summaryPrizeColor = 0;
                decimal summaryPrints = 0;
                //součet pro souhrn
                foreach (var p in rental)
                    summaryRental += p.Price;

                foreach (var p in prints)
                {
                    summaryPrintsBw += p.CountBw;
                    summaryPrintsColor += p.CountColor;
                    summaryPrizeBw += p.PriceBw;
                    summaryPrizeColor += p.PriceColor;
                }
                summaryPrints = summaryPrizeBw + summaryPrizeColor;

                var viewModel = new AccountingPrinterViewModel()
                {
                    PrinterRecords = rental,
                    PrinterRecordPrints = prints,
                    PrinterRecord = new PrinterRecord(),
                    Departments = departments,
                    Department = new Department(),
                    PrizeBw = summaryPrizeBw,
                    PrizeColor = summaryPrizeColor,
                    CountBw = summaryPrintsBw,
                    CountColor = summaryPrintsColor,
                    Rental = summaryRental,
                    PrintsSummary = summaryPrints,
                    Year = year,
                    Month = month


                };
                return View(viewModel);
            }

        }
        public ActionResult ErrorCalc()
        {
            return View();
        }
        public ActionResult ErrorImp()
        {
            return View();
        }

    }
}