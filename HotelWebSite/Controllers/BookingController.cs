using Hotels.Model;
using HotelWebSite.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWebSite.Controllers
{
    [CheckExpairDate]
    [AuthorizeEmployee]
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu (int id)
        {
            Session["PassengerId"] = id; 
            return View();
        }
        
        [HttpPost]
        public ActionResult SearchingInSuitOrRoom (Booking booking)
        {
            HotelDb ctx = new HotelDb();
            //var a = ctx.Bookings.Where(n => n.DateOfDeparture < DateTime.Now).Select(n => n.SuitId);
            //var d = ctx.Suits.Where(t => a.Contains(t.Id)).ToList();
            //d.ForEach(p =>
            //{
            //    p.EmptyOrFull = false;
            //});

            //var u = ctx.Bookings.Where(c => c.DateOfDeparture < DateTime.Now).ToList();
            //u.ForEach(p =>
            //{
            //    p.Expire = true;
            //});

            //ctx.SaveChanges(); // I Added In CheckExpairAttribute _ Libery
            ///////////////////
            if (booking.EntryDate < DateTime.Now || booking.EntryDate >= booking.DateOfDeparture || booking.DateOfDeparture < DateTime.Now)
            {
                ModelState.AddModelError(nameof(booking.EntryDate), "تاریخ وارد شده دارای خطا میباشد آن را اصلاح کنید");
                ModelState.AddModelError(nameof(booking.DateOfDeparture), "تاریخ وارد شده دارای خطا میباشد آن را اصلاح کنید");

            }
            if (ModelState.IsValid)
            {
                Session["DateIn"] = booking.EntryDate;
                Session["DateOut"] = booking.DateOfDeparture;
                Session["NumbeerOfPerson"] = booking.NumberOfPerson;
                Session["NumberOfChild"] = booking.NumberOfChild;
                ViewBag.Day = booking.DateOfDeparture.Day - booking.EntryDate.Day;

                var SuitSearch = ctx.Suits.Where(s => s.EmptyOrFull == false && s.Capacity >= booking.NumberOfPerson + booking.NumberOfChild);
                return View(SuitSearch);

            }
            return View("Menu", booking);
        }

        public ActionResult Create (int id , long Price)
        {
            HotelDb ctx = new HotelDb();
            var EditSuit = ctx.Suits.Find(id);
            EditSuit.EmptyOrFull = true;
            ctx.SaveChanges();
            var AddBooking = new Booking()
            {

                DateOfDeparture = (DateTime)Session["DateOut"],
                EntryDate = (DateTime)Session["DateIn"],
                DaysStays = ( (DateTime)Session["DateOut"] - (DateTime)Session["DateIn"] ).ToString(), 
                NumberOfChild = (int)Session["NumberOfChild"],
                NumberOfPerson = (int)Session["NumbeerOfPerson"],
                PassengerId = (int)Session["PassengerId"],
                Price = Price,
                SuitId = id,
                SuitOrRoom = EditSuit.Type
            };
            ctx.Bookings.Add(AddBooking);
            ctx.SaveChanges();
            return RedirectToAction("Index" , "Passenger");
        }
    }
}
