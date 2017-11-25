using Hotels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWebSite.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            HotelDb ctx = new HotelDb();
            var Emp = ctx.Employees.ToList();

            return View(Emp);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            HotelDb ctx = new HotelDb();
            ctx.Employees.Add(employee);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}