using Hotels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWebSite.Controllers
{
    public class PhoneController : Controller
    {
        // GET: Phone
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int id)
        {
            HotelDb ctx = new HotelDb();
            Session["PersonId"] = id;
            var model = new Phone();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(Phone phone)
        {
            HotelDb ctx = new HotelDb();
            phone.PersonId = (int)Session["PersonId"];
            ctx.Phones.Add(phone);
            ctx.SaveChanges();
            //Enum.GetName(typeof(PhoneType),phone.PhoneType);
            TempData["Message"] = Enum.GetName(typeof(PhoneType), phone.PhoneType);
            return RedirectToAction("Index","Passenger");
        }
        public ActionResult Edit(int id)
        {
            HotelDb ctx = new HotelDb();
            var Phone = ctx.Phones.Find(id);
            return View(Phone);

        }
        [HttpPost]
        public ActionResult Edit(Phone phone)
        {
            HotelDb ctx = new HotelDb();
            ctx.Entry<Phone>(phone).State = System.Data.Entity.EntityState.Modified;
            ctx.Entry<Phone>(phone).Property(nameof(phone.PersonId)).IsModified = false;
            ctx.SaveChanges();
            TempData["Message"] = "OK";
            return RedirectToAction("Index", "Passenger");
        }

        public ActionResult Delete(int id)
        {
            HotelDb ctx = new HotelDb();

            ctx.Phones.Remove(ctx.Phones.Find(id));
            ctx.SaveChanges();
            TempData["Message"] = "رکورد مورد نظر با موفقیت حذف شد";
            return RedirectToAction("Index", "Passenger");

        }
    }
}

