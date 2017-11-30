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
        private HotelDb ctx { get; set; } = new HotelDb();
        // GET: Employee
        public ActionResult Menu()
        {

            return View();
        }

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
            ctx.Employees.Add(employee);
            ctx.SaveChanges();
            if (employee.Sex == "Female")
                j = "خانم ";
            else
                j = "آقای ";

            TempData["Message"] = $"{j}{employee.Name} {employee.Family}  با موفقیت ثبت شد";
            return RedirectToAction("Index");
        }
        public ActionResult Delete (int id)
        {
            var Empo = ctx.Employees.Find(id);

            return View(Empo);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteEmployee(int id)
        {
            ctx.Employees.Remove(ctx.Employees.Find(id));
            ctx.SaveChanges();
            TempData["Message"] = "رکورد مورد نظر با موفقیت حذف شد";
            return RedirectToAction("Index");

        }
        public ActionResult Edit (int id)
        {
            var Empo = ctx.Employees.Find(id);
            return View(Empo);
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditEmployee (Employee Empo)
        {
            var j = "def";
            ctx.Entry<Employee>(Empo).State = System.Data.Entity.EntityState.Modified;
            if (string.IsNullOrEmpty(Empo.PasswordHash))
                //ctx.Entry<Employee>(employee).Property("PasswordHash").IsModified = false;
                ctx.Entry<Employee>(Empo).Property(nameof(Empo.PasswordHash)).IsModified = false;
            ctx.Entry<Employee>(Empo).Property(nameof(Empo.Sex)).CurrentValue = "Big";
            ctx.SaveChanges();
            if (Empo.Sex == "Female")
                j = "خانم ";
            else
                j = "آقای ";
            TempData["Message"] = $"اطلاعات {j} \" {Empo.Name} {Empo.Family} \"  با موفقیت ثبت شد";
            return RedirectToAction("Index");

        }
    }
}