using Hotels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWebSite.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int id)
        {
            Session["PassengerId"] = id;
            return View();
        }
        [HttpPost]
        public ActionResult SuitBookingSearch(Booking booking)
        {
            HotelDb ctx = new HotelDb();
            var SuitsFind = ctx.Suits.Where(b => ( b.EmptyOrFull == false || b.DateOfDeparture < booking.EntryDate ) && b.Capacity >= booking.NumberOfPerson );
            return View(SuitsFind);
        }
    }
}
