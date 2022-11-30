using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UsersControlController : Controller
    {
        private ApplicationDbContext _context;


        public UsersControlController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: UsersControl
        public ActionResult Index()
        {
            var users = _context.Users.Include(u=>u.Roles).ToList();
            var managers = _context.ManagersMasterDatas.ToList();
            
            foreach (var u in users)
            {
                var newmanager = new ManagersMasterData(u.UserName, "1", "Nový uživatel");
                var names = new List<string>();

                foreach (var n in managers)
                    names.Add(n.Name);

                if (!names.Contains(newmanager.Name))
                    _context.ManagersMasterDatas.Add(newmanager);            
            }
            
            _context.SaveChanges();


            var viewModel = new UsersControlViewModel()
            {
                Users = users,
                User = new ApplicationUser(),
                ManagersMasterDatas = _context.ManagersMasterDatas.ToList(),
                ManagerData = new ManagersMasterData()
            };                      

            return View(viewModel);
        }

        public ActionResult Asign()
        {
            var users = _context.Users.Include(u=>u.Roles).ToList();
            //var roles = _context.Roles.ToList()
            var viewModel = new UsersControlViewModel()
            {
                Users = users,
                User = new ApplicationUser()
            };
            return View(viewModel);
        }
        public ActionResult AsignDepartment(int id)
        {
            var user = _context.ManagersMasterDatas.SingleOrDefault(u=>u.Id==id);           
            
            
            return View(user);
        }
        [HttpPost]
        public ActionResult Save(ManagersMasterData managersMasterData)
        {

            if (!ModelState.IsValid)
            {
                return View("AsignDepartment", managersMasterData);
            }
            else
            {                
                    var recordInDb = _context.ManagersMasterDatas.Single(u => u.Id == managersMasterData.Id);
                                    
                    recordInDb.Name = managersMasterData.Name;
                    recordInDb.Department = managersMasterData.Department;
                    recordInDb.Role = managersMasterData.Role;

                    var UserManager = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
                    var user = UserManager.FindByName(managersMasterData.Name);
                    UserManager.AddToRole(user.Id, managersMasterData.Role);   
            }

            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id)
        {
            _context.ManagersMasterDatas
                .RemoveRange((_context.ManagersMasterDatas
                .Where(x => x.Id == id)));

            var userName = _context.ManagersMasterDatas.SingleOrDefault(u => u.Id == id).Name;

            var user = _context.Users.SingleOrDefault(u => u.UserName == userName);

            _context.Users.Attach(user);
            _context.Users.Remove(user);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}