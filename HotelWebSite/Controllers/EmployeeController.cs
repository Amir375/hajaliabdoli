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
            var j = "def";
            HotelDb ctx = new HotelDb();
            if (employee != null)
            {
                ctx.Employees.Add(employee);
                ctx.SaveChanges();
            }
            if (employee.Sex == "Female")
                j = "خانم ";
            else
                j = "آقای ";

            TempData["Message"] = $"{j}{employee.Name} {employee.Family}  با موفقیت ثبت شد";
            return RedirectToAction("Index");
        }

    }
}