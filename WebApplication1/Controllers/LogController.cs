using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LogController : Controller
    {
        private ApplicationDbContext _context;


        public LogController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var logs = _context.Logs.ToList();

            var viewModel = new LogViewModel()
            {
                Logs = logs,
            };
            return View(viewModel);
        }
        public ActionResult Delete()
        {
            _context.Logs
                .RemoveRange((_context.Logs));
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        
    }
}