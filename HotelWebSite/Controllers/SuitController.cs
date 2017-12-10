using Hotels.Model;
using HotelWebSite.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWebSite.Controllers
{
    public class SuitController : Controller
    {
        // GET: Suit
        public ActionResult Menu()
        {
            return View();
        }
        public ActionResult Index()
        {
            HotelDb ctx = new HotelDb();
            var Emp = ctx.Suits.ToList();
            
            return View(Emp);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SuitCreate suit)
        {
            var guid = Guid.NewGuid().ToString();
            var Photo = suit.PhotoFile;
            var PhotoSize = Photo.ContentLength;
            var PhotoType = Photo.ContentType;
            var fileName = guid + Path.GetExtension(Photo.FileName);

            if (PhotoSize > 700 * 1024)
            {
                ModelState.AddModelError((nameof(suit.PhotoFile)), "سایز عکس نباید بیش از 300 کیلوبایت باشد ");
            }

            if (PhotoType != "image/jpeg" && PhotoType != "image/gif" && PhotoType != "image/png")
            {
                ModelState.AddModelError((nameof(suit.PhotoFile)), "فایل ارسالی باید عکس باشد  ");
            }

            //If ModelState

            Photo.SaveAs(Path.Combine(
                Server.MapPath("~/Photos/"),
                fileName));
            var Suit = new Suit()
            {
                Title = suit.Title,
                EmptyOrFull = suit.EmptyOrFull,
                DateOfDeparture = suit.DateOfDeparture,
                NumberOfBeds = suit.NumberOfBeds,
                NumberOfRoom = suit.NumberOfRoom,
                NumberOfDoubleBeds = suit.NumberOfDoubleBeds ,
                NumberOfSingleBeds = suit.NumberOfSingleBeds ,
                SuitType = suit.SuitType,
                Floor = suit.Floor,
                EntryDate = suit.EntryDate,
                Capacity = suit.Capacity,
                Price =suit.Price,
                
                PhotoPath = "/Photos/" + fileName
            };


            HotelDb ctx = new HotelDb();
            ctx.Suits.Add(Suit);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}