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
            var j = " ";
            if (ModelState.IsValid)
            {
                ctx.Entry<Employee>(Empo).State = System.Data.Entity.EntityState.Modified;
                if (string.IsNullOrEmpty(Empo.PasswordHash))
                    //ctx.Entry<Employee>(employee).Property("PasswordHash").IsModified = false;
                    ctx.Entry<Employee>(Empo).Property(nameof(Empo.PasswordHash)).IsModified = false;
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