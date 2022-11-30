using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RecordsController : Controller
    {
        private ApplicationDbContext _context;


        public RecordsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Records
        public ActionResult Index(string submit, int? year, int? month)
        {
            if (submit == "delete")
            {
                _context.Records
                .RemoveRange((_context.Records
                .Where(x => x.DateOf.Year == year)
                .Where(x => x.DateOf.Month == month)));
                _context.SaveChanges();
                submit = "";

                return RedirectToAction("Index");
            }
            else
            {
                var records = _context.Records
                               .Include(c => c.Department)
                               .ToList();
                if (month != null)
                {
                    records = records
                              .Where(r => r.DateOf.Year == year)
                              .Where(r => r.DateOf.Month == month)
                              .ToList();
                }

                var viewModel = new ImportViewModel()
                {
                    Records = records,
                    Record = new Record()

                };

                return View(viewModel);
            }

        }

        public ActionResult Import()
        {
            return View();
        }
        public ActionResult DoImport()
        {

            //List from Excel
            var records = new List<Record>();
            //Summary of prices per numbers
            var summaryRecords = new List<Record>();

            //List of values without number
            var nonDepart = new List<Record>();

            var date = string.Empty;
            decimal noPriceValue = 0;
            decimal noPriceValueDph = 0;
            decimal noPriceValueSummary = 0;
            decimal noPriceValueDphSummary = 0;



            string connection = @"C:\inetpub\wwwroot\telsor\Import\import.csv";
            using (StreamReader sr = new StreamReader(connection, System.Text.Encoding.UTF8))
            {


                string importLine;
                sr.ReadLine();
                while ((importLine = sr.ReadLine()) != null)
                {

                    string[] split = importLine.Split(';');

                    //Controls of empty values
                    if (split[8] != "")
                        date = split[8];

                    noPriceValue = (split[13] != "") ? Convert.ToDecimal(split[13]) : 0;

                    noPriceValueDph = (split[15] != "") ? Convert.ToDecimal(split[15]) : 0;


                    //Filling lists if number has value
                    if (split[3] == "")
                    {
                        var noNumberRecord = new Record(split[16], split[3], DateTime.Parse(date), noPriceValue, noPriceValueDph, 1, split[0], 0, 0, 0);

                        if (split[5] == "Volání")
                            noNumberRecord.Calls = int.Parse(split[10]);

                        else if (split[5] == "Data")
                            noNumberRecord.Data = int.Parse(split[10]);
                        else if (split[5] == "Zprávy")
                            noNumberRecord.Msgs = int.Parse(split[10]);

                        nonDepart.Add(noNumberRecord);
                    }
                    else
                    {
                        var record = new Record(split[16], split[3], DateTime.Parse(date), noPriceValue, noPriceValueDph, 1, split[0], 0, 0, 0);
                        if (split[5] == "Volání")
                            record.Calls = int.Parse(split[10]);

                        else if (split[5] == "Data")
                            record.Data = int.Parse(split[10]);
                        else if (split[5] == "Zprávy")
                            record.Msgs = int.Parse(split[10]);
                        records.Add(record);
                    }
                }
                sr.Close();

            }

            //Summary of records<List>
            while (records.Count != 0)
            {
                var number = records[0].Number;
                var oneNumber = records.Where(r => r.Number == number).ToList();
                int calls = 0;
                int msg = 0;
                int data = 0;

                //Summary of one number
                foreach (var r in oneNumber)
                {

                    calls += r.Calls;
                    msg += r.Msgs;
                    data += r.Data;

                    noPriceValueSummary += r.Price;
                    noPriceValueDphSummary += r.PriceWithDph;
                }
                var recordSum = new Record(records[0].Name, records[0].Number, records[0].DateOf, noPriceValueSummary, noPriceValueDphSummary, 1, records[0].InvoiceNumber, calls, msg, data);
                summaryRecords.Add(recordSum);

                noPriceValueSummary = 0;
                noPriceValueDphSummary = 0;
                records.RemoveAll(r => r.Number == number);

            }
            foreach (var r in summaryRecords)
                _context.Records.Add(r);

            foreach (var r in nonDepart)
                _context.Records.Add(r);

            _context.SaveChanges();

            return RedirectToAction("Index");

        }

    }
}