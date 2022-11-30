using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.Entity;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin,Asistent")]
    public class MasterDataController : Controller
    {
        private ApplicationDbContext _context;


        public MasterDataController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: MasterData
        public ActionResult Index()
        {
            var viewModel = new NumberMasterDataViewModel()
            {
                Records = _context.NumberMasterDatas.Include(d => d.Department).ToList(),
                NumberRecord = new NumberMasterData()
            };
            return View(viewModel);
        }
        public ActionResult New()
        {
            var deps = _context.Departments.ToList();
            var record = new NewMasterDataViewModel()
            { 
            Departments = deps,
            NumberMasterData= new NumberMasterData()
            };

            return View(record);
        }
        public ActionResult Detail(int id)
        {
            var number = _context.NumberMasterDatas.SingleOrDefault(n => n.Id == id);
            var deps = _context.Departments.ToList();
            if (number == null)
                return HttpNotFound();
            var viewModel = new NewMasterDataViewModel()
            {
                Departments = deps,
                NumberMasterData = number
            };
            return View("New", viewModel);
        }


        [HttpPost]
        public ActionResult Save(NumberMasterData numberMasterData)
        {

            if (!ModelState.IsValid)
            {
                return View("New", numberMasterData);
            }
            else
            {
                if (numberMasterData.Id == 0)
                {
                    _context.NumberMasterDatas.Add(numberMasterData);
                    var user = User.Identity.Name;
                    string oldValues ="bez záznamu";
                    string newValues =  numberMasterData.Number+ ";" + numberMasterData.Name+ ";" + numberMasterData.DepartmentId.ToString();

                    var log = new Log(user, "new", oldValues, newValues);
                    _context.Logs.Add(log);
                    _context.SaveChanges();
                }
                  else
                  {
                      var recordInDb = _context.NumberMasterDatas.Single(m => m.Id == numberMasterData.Id);
                      recordInDb.Number = numberMasterData.Number;
                      recordInDb.Name = numberMasterData.Name;
                      recordInDb.DepartmentId = numberMasterData.DepartmentId;

                    var user = User.Identity.Name;
                    string oldValues = recordInDb.Number +";"+recordInDb.Name + ";" + recordInDb.DepartmentId.ToString();
                    string newValues = numberMasterData.Number + ";" + numberMasterData.Name + ";" + numberMasterData.DepartmentId.ToString();

                    var log = new Log(user,"edit",oldValues,newValues);
                    _context.Logs.Add(log);
                    _context.SaveChanges();

                }
            }
            
           
            
            return RedirectToAction("Index");

        }
        public ActionResult DeleteMasterData(int id)
        {

            var recordInDb = _context.NumberMasterDatas.Single(m => m.Id == id);
            _context.NumberMasterDatas
                .RemoveRange((_context.NumberMasterDatas
                .Where(x => x.Id == id)));

            var user = User.Identity.Name;
            string oldValues =  "bez záznamu" ;
            string newValues =  recordInDb.Number + ";" + recordInDb.Name + ";" + recordInDb.DepartmentId.ToString() ;

            var log = new Log(user, "delete", oldValues, newValues);
            _context.Logs.Add(log);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}