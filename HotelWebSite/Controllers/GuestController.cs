using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotels.Model;
using HotelWebSite.ViewModels;

namespace HotelWebSite.Controllers
{
    public class GuestController : Controller
    {
        // GET: Guest
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(int id)
        {
            HotelDb ctx = new HotelDb();
            var Pass = ctx.Passengers.Find(id);
            return View(Pass);
        }
        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreateGuest(Guest guest)
        { 
            HotelDb ctx = new HotelDb();
            ctx.Guests.Add(guest);
            ctx.SaveChanges();
            return RedirectToAction("Create","Guest",new { guest.PassengerId });
        }
        public ActionResult List (int id)//int id
        {
            HotelDb ctx = new HotelDb();
            var Passenger = ctx.Passengers.Where(p => p.Id == id).FirstOrDefault();
            ViewBag.PassengerSex = Passenger.Sex;
            ViewBag.PassengerName = Passenger.Name;
            ViewBag.PassengerFamily = Passenger.Family;
            var Guest = ctx.Guests.Where(g=> g.PassengerId == id); /*ctx.Guests.Where(e => e.PassengerId == id).FirstOrDefault()*/
            return View(Guest);
        }

        public ActionResult Edit(int id)
        {
            HotelDb ctx = new HotelDb();
            var Guest = ctx.Guests.Find(id);
            return View(Guest);
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditGuest(Guest guest)
        {
            HotelDb ctx = new HotelDb();
            ctx.Entry<Guest>(guest).State = System.Data.Entity.EntityState.Modified;
            ctx.Entry<Guest>(guest).Property(nameof(guest.PassengerId)).IsModified = false ;
            ctx.SaveChanges();
            TempData["Message"] = "اطلاعات همراه با موفقیت ویرایش شد";
            return RedirectToAction("Index","Passenger");
        }

        public ActionResult Delete (int id)
        {
            HotelDb ctx = new HotelDb();
            var Guest = ctx.Guests.Find(id);
            return View(Guest);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteGuest(int id)
        {
            HotelDb ctx = new HotelDb();

            ctx.Guests.Remove(ctx.Guests.Find(id));
            ctx.SaveChanges();
            TempData["Message"] = "رکورد مورد نظر با موفقیت حذف شد";
            return RedirectToAction("Index","Passenger");

        }

    }
}