﻿using Hotels.Model;
using HotelWebSite.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult Create(PassengerCreate model)
        {
            var guid = Guid.NewGuid().ToString();
            var postedFile = model.PhotoFile;
            int fileSize = postedFile.ContentLength;
            string fileType = postedFile.ContentType;
            string fileName = //postedFile.FileName;
                guid + Path.GetExtension(postedFile.FileName);

            if (fileSize > 500 * 1024)
            {
                ModelState.AddModelError(nameof(model.PhotoFile), "سایز فایل نباید از ۱۵۰ کیلو بایت بیشتر باشد");
            }
            if (fileType != "image/gif" && fileType != "image/jpeg" && fileType != "image/png")
            {
                ModelState.AddModelError(nameof(model.PhotoFile), "فایل ارسالی باید عکس باشد");
            }

            var j = "def";
            if (ModelState.IsValid)
            {

                HotelDb ctx = new HotelDb();
                postedFile.SaveAs(Path.Combine(
                    Server.MapPath("~/Photos/"),
                    fileName));
                var passenger = new Passenger()
                {
                    Name = model.Name,
                    Family = model.Family,
                    NationalCode = model.NationalCode,
                    PassportNumber = model.PassportNumber,
                    Sex = model.Sex,
                    Location = model.Location,
                    Age = model.Age,
                    PhotoPath = "/Photos/" + fileName
                };

                ctx.Passengers.Add(passenger);
                ctx.SaveChanges();

                if (model.Sex == "Female")
                    j = "خانم ";
                else
                    j = "آقای ";

                TempData["Message"] = $"{j}{model.Name} {model.Family}  با موفقیت ثبت شد";
                return RedirectToAction("Index");
            }
            TempData["FMessage"] = $"فرم مسافر دارای خطا میباشد";
            return View(model);
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
            if (ModelState.IsValid)
            {
                var j = " ";
                HotelDb ctx = new HotelDb();
                ctx.Entry<Passenger>(passenger).State = System.Data.Entity.EntityState.Modified;
                ctx.Entry<Passenger>(passenger).Property(nameof(passenger.PhotoPath)).IsModified = false;
                ctx.SaveChanges();
                if (passenger.Sex == "Female")
                {
                    j = "خانم ";
                }
                else if (passenger.Sex == "Man")
                {
                    j = "آقای ";
                }
                else
                    j = null;

                TempData["Message"] = $"اطلاعات {j} \" {passenger.Name} {passenger.Family} \"  با موفقیت ویرایش شد";

                return RedirectToAction("Index");
            }
            TempData["FMessage"] = $"فرم ویرایش مسافر دارای خطا میباشد";
            return View(passenger);

        }

        public ActionResult PassengerReservation (int id)
        {
            HotelDb ctx = new HotelDb();
            var pas = ctx.Bookings.Where(q => q.PassengerId == id).Count();
            if (pas == 0)
            {

                TempData["FMessage"] = "این مسافر هنوز هیچ رزروی انجام نداده است  ";
                return RedirectToAction("Index", "Passenger");
            }
            //ctx.Suits.Where(ctx.Bookings.Select(b => b.PassengerId == id));   Sum(m => m.Price)

            var TotalPrice = ctx.Bookings.Where(m => m.PassengerId == id && m.Expire != true).Select(m => m.Price).Sum();
            ViewBag.TotalSuit = ctx.Bookings.Where(a => a.PassengerId == id && a.Expire != true).LongCount(a => a.SuitId == a.SuitId);
            ViewBag.TotalPrice =  $"{TotalPrice:###,#}";
            var b = from booking in ctx.Bookings
                    join suit in ctx.Suits on booking.SuitId equals suit.Id
                    where booking.PassengerId == id && booking.Expire != true
                    select suit;


            return View(b);
            //var Er = ctx.Suits.Where(s => s.Id == ctx.Bookings.Where(b => b.PassengerId == id).Select(b => b.SuitId));
            //var a = from p in ctx.Bookings
            //        join v in ctx.Suits on p.SuitId equals v.Id
            //        where p.PassengerId == id
            //        select 


        }
    }
}