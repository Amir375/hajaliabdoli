using Hotels.Model;
using HotelWebSite.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWebSite.Controllers
{
    public class EmployeeController : Controller
    {
        private HotelDb ctx { get; set; } = new HotelDb();
        // GET: Employee
        public ActionResult Menu()
        {

            return View();
        }

        [AuthorizeEmployee]
        public ActionResult Index()
        {
            var Emp = ctx.Employees.ToList();
            return View(Emp);
        }

        [AuthorizeEmployee]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AuthorizeEmployee]
        public ActionResult Create(Employee employee)
        {
                var j = "def";
            if (ModelState.IsValid)
            {
                ctx.Employees.Add(employee);
                ctx.SaveChanges();
                if (employee.Sex == "Female")
                    j = "خانم ";
                else
                    j = "آقای ";

                TempData["Message"] = $"{j}{employee.Name} {employee.Family}  با موفقیت ثبت شد";
                return RedirectToAction("Index");
            }
            TempData["FMessage"] = $"فرم شما دارای خطا میباشد";
            return View(employee);
        }

        [AuthorizeEmployee]
        public ActionResult Delete (int id)
        {
            var Empo = ctx.Employees.Find(id);

            return View(Empo);
        }

        [HttpPost]
        [ActionName("Delete")]
        [AuthorizeEmployee]
        public ActionResult DeleteEmployee(int id)
        {
            ctx.Employees.Remove(ctx.Employees.Find(id));
            ctx.SaveChanges();
            TempData["Message"] = "رکورد مورد نظر با موفقیت حذف شد";
            return RedirectToAction("Index");

        }

        [AuthorizeEmployee]
        public ActionResult Edit (int id)
        {
            var Empo = ctx.Employees.Find(id);
            return View(Empo);
        }

        [HttpPost]
        [ActionName("Edit")]
        [AuthorizeEmployee]
        public ActionResult EditEmployee (Employee Empo)
        {
            var j = " ";
            if (ModelState.IsValid)
            {
                ctx.Entry<Employee>(Empo).State = System.Data.Entity.EntityState.Modified;
                if (string.IsNullOrEmpty(Empo.Password))
                    ctx.Entry<Employee>(Empo).Property(nameof(Empo.Password)).IsModified = false;
                ctx.SaveChanges();
                if (Empo.Sex == "Female")
                {
                    j = "خانم ";
                }
                else if (Empo.Sex == "Man")
                {
                    j = "آقای ";
                }
                else
                    j = null;

                TempData["Message"] = $"اطلاعات {j} \" {Empo.Name} {Empo.Family} \"  با موفقیت ثبت شد";
                return RedirectToAction("Index");
            }
            TempData["FMessage"] = $"فرم شما دارای خطا میباشد";
            return View(Empo);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ctx.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}