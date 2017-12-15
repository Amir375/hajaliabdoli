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

        public ActionResult Delete(int id)
        {
            
            HotelDb ctx = new HotelDb();
            var a = ctx.Bookings.Where(b => b.SuitId == id && b.DateOfDeparture >= DateTime.Now).Count();
            if (a != 0 )
            {
                TempData["FMessage"] = $"در حال حاضر در این اتاق مسافر وجود دارد و نمیتوان آن را حذف کرد  ";
                return RedirectToAction("Index");
            }
            ctx.Suits.Remove(ctx.Suits.Find(id));
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            HotelDb ctx = new HotelDb();
            var a = ctx.Bookings.Where(b => b.SuitId == id && b.DateOfDeparture >= DateTime.Now).Count();
            if (a != 0)
            {
                TempData["FMessage"] = $"در حال حاضر در این اتاق مسافر وجود دارد و نمیتوان آن را ویرایش کرد  ";
                return RedirectToAction("Index");
            }
            var FindSuit = ctx.Suits.Where(m => m.Id == id).FirstOrDefault();
            return View(FindSuit);

        }

        [HttpPost]
        public ActionResult Edit(Suit suit)
        {
            HotelDb ctx = new HotelDb();
            ctx.Entry<Suit>(suit).State = System.Data.Entity.EntityState.Modified;
            ctx.Entry<Suit>(suit).Property(nameof(suit.PhotoPath)).IsModified = false;
            ctx.SaveChanges();
            TempData["Message"] = $"اتاق / سوییت مورد نظر با موفقیت ویرایش شد ";
            return RedirectToAction("Index");
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

            Photo.SaveAs(Path.Combine(
                Server.MapPath("~/Photos/"),
                fileName));
            var AddSuit = new Suit()
            {
                Title = suit.Title,
                EmptyOrFull = suit.EmptyOrFull,
                NumberOfBeds = suit.NumberOfBeds,
                NumberOfDoubleBeds = suit.NumberOfDoubleBeds ,
                NumberOfSingleBeds = suit.NumberOfSingleBeds ,
                Type = suit.Type,
                Floor = suit.Floor,
                Capacity = suit.Capacity,
                Price =suit.Price,
                
                PhotoPath = "/Photos/" + fileName
            };

            if (suit.Type == "Suit")
            {
                AddSuit.NumberOfRoom = suit.NumberOfRoom;
            }
            else
            {
                AddSuit.NumberOfRoom = null;
            }

            HotelDb ctx = new HotelDb();
            ctx.Suits.Add(AddSuit);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        //zahra

    }
}