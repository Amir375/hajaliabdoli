using Hotels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWebSite.Controllers
{
    public class PassengerController : Controller
    {
        // GET: Passenger
        public ActionResult Index()
        {
            HotelDb ctx = new HotelDb();
            var Passenger = ctx.Passengers.ToList();
            return View(Passenger);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Passenger Pass)
        {
            var j = "def";
            if (ModelState.IsValid)
            {
                HotelDb ctx = new HotelDb();
                ctx.Passengers.Add(Pass);
                ctx.SaveChanges();

                if (Pass.Sex == "Female")
                    j = "خانم ";
                else
                    j = "آقای ";

                TempData["Message"] = $"{j}{Pass.Name} {Pass.Family}  با موفقیت ثبت شد";
                return RedirectToAction("Index");
            }
            return View(Pass);
        }

        public ActionResult Delete(int id)
        {
            HotelDb ctx = new HotelDb();
            var Pass = ctx.Passengers.Find(id);
            return View(Pass);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePassenger(int id)
        {
            HotelDb ctx = new HotelDb();
            ctx.Passengers.Remove(ctx.Passengers.Find(id));
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            HotelDb ctx = new HotelDb();
            var Pass = ctx.Passengers.Find(id);
            return View(Pass);
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPassenger(Passenger passenger)
        {
            HotelDb ctx = new HotelDb();
            ctx.Entry<Passenger>(passenger).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}