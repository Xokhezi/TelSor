using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ImportPrinterController : Controller
    {
        private ApplicationDbContext _context;


        public ImportPrinterController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: ImportPrinter
        public ActionResult Index(int? year, int? month)
        {
            if (year == null)
                year = DateTime.Now.Year;
            if (month == null)
                month = DateTime.Now.Month;

            
            var viewModel = new ImportPrinterViewModel()
            {
                PrinterRecords = _context.PrinterRecords.ToList(),
                Departments = _context.Departments.ToList(),
                PrinterRecordPrints = _context.PrinterRecordPrints.ToList(),
                Year=year,
                Month=month
                
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DoImport(string submit,int month, int year)
        {
            if (submit == "delete")
            {
                _context.PrinterRecords
                .RemoveRange((_context.PrinterRecords
                .Where(x => x.Year == year)
                .Where(x => x.Month == month)));

                _context.PrinterRecordPrints
                .RemoveRange((_context.PrinterRecordPrints
                .Where(x => x.Year == year)
                .Where(x => x.Month == month)));


                _context.SaveChanges();
                submit = "";

                return RedirectToAction("Index");
            }
            else
            {
                if (_context.PrinterRecords.Where(x => x.Year == year).Where(x => x.Month == month).ToList().Count() == 0)
                {
                    string connection = @"C:\inetpub\wwwroot\telsor\Import\rental.csv";
                    string connectionprints = @"C:\inetpub\wwwroot\telsor\Import\print.csv";
                    //rental import
                    using (StreamReader sr = new StreamReader(connection, System.Text.Encoding.UTF8))
                    {
                        string importLine;
                        var records = new List<PrinterRecord>();
                        var masterData = _context.PrinterMasters.Include(d => d.Department).ToList();
                        var asignedDepartments = new List<PrinterRecord>();

                        sr.ReadLine();
                        while ((importLine = sr.ReadLine()) != null)
                        {

                            string[] split = importLine.Split(';');
                            var record = new PrinterRecord(split[12], split[8], split[5], split[7], split[4], Convert.ToDecimal(split[20]), 1, year, month);
                            records.Add(record);


                        }

                        sr.Close();

                        foreach (var r in records)
                        {
                            var department = masterData.SingleOrDefault(p => p.SerialNr == r.SerialNr);
                            if (department != null)
                                asignedDepartments.Add(new PrinterRecord(r.Name, r.ResponsiblePerson, r.Factory, r.Room, r.SerialNr, r.RentalPrize, department.DepartmentId, r.Year, r.Month));
                            else
                            {
                                asignedDepartments.Add(new PrinterRecord(r.Name, r.ResponsiblePerson, r.Factory, r.Room, r.SerialNr, r.RentalPrize, 1, r.Year, r.Month));
                            }
                        }
                        foreach (var r in asignedDepartments)
                        {
                            _context.PrinterRecords.Add(r);
                        }


                    }
                    using (StreamReader sr = new StreamReader(connectionprints, System.Text.Encoding.UTF8))
                    {
                        string importLine;
                        var records = new List<PrinterRecordPrint>();
                        var masterData = _context.PrinterMasters.Include(d => d.Department).ToList();
                        var asignedDepartments = new List<PrinterRecordPrint>();

                        sr.ReadLine();
                        while ((importLine = sr.ReadLine()) != null)
                        {

                            string[] split = importLine.Split(';');

                            if (split[24] == "")
                                split[24] = "0";

                            if (split[35] == "")
                                split[35] = "0";

                            if (split[17] == "")
                                split[17] = "0";

                            if (split[28] == "")
                                split[28] = "0";

                            var record = new PrinterRecordPrint(split[12], split[8], split[5], split[7], split[4], Convert.ToDecimal(split[24]), Convert.ToDecimal(split[35]), int.Parse(split[17]), int.Parse(split[28]), 1, year, month);
                            records.Add(record);


                        }
                        sr.Close();

                        foreach (var r in records)
                        {
                            var department = masterData.SingleOrDefault(p => p.SerialNr == r.SerialNr);
                            if (department != null)
                                asignedDepartments.Add(new PrinterRecordPrint(r.Name, r.ResponsiblePerson, r.Factory, r.Room, r.SerialNr, r.PrizeBw, r.PrizeColor, r.CountBw, r.CountColor, department.DepartmentId, r.Year, r.Month));
                            else
                            {
                                asignedDepartments.Add(new PrinterRecordPrint(r.Name, r.ResponsiblePerson, r.Factory, r.Room, r.SerialNr, r.PrizeBw, r.PrizeColor, r.CountBw, r.CountColor, 1, r.Year, r.Month));
                            }
                        }
                        foreach (var r in asignedDepartments)
                        {
                            _context.PrinterRecordPrints.Add(r);
                        }
                        _context.SaveChanges();



                    }
                    return RedirectToAction("Index");

                }
                else
                    return RedirectToAction("ErrorImp");
            }
        }
        public ActionResult ErrorImp()
        {
            return View("");
        }
        }
}