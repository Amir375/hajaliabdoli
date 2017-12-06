using HotelWebSite.ViewModels;
using System;
using Hotels.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotels.Model.Library;
using HotelWebSite.Library;

namespace HotelWebSite.Controllers
{
    public class SecurityController : Controller
    {
        protected HotelDb ctx { get; set; } = new HotelDb();
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(SecurityLogin viewModel)
        {
            if (ModelState.IsValid)
            {
                var PasswordHashShode = PassHash.CalculateMD5Hash(viewModel.Password); 
                var CurrentUser = 
                    ctx.Employees.Where(
                        e => e.Username == viewModel.Username 
                    && e.PasswordHash == PasswordHashShode
                    )
                    .FirstOrDefault();
                if(CurrentUser != null)
                {
                    if (viewModel.RemmemberMe)
                    {
                        HttpCookie cookie = new HttpCookie("UserId", CurrentUser.Id.ToString());
                        cookie.Expires = DateTime.Now.AddDays(7);
                        Response.Cookies.Add(cookie);
                    }
                    var j = "def";
                    Session["UserId"] = CurrentUser.Id;
                    if (CurrentUser.Sex == "Female")
                        j = "خانم ";
                    else if (CurrentUser.Sex == "Man")
                        j = "آقای ";
                    else
                        j = null;

                    TempData["Message"] = $"{j} {CurrentUser.Name} {CurrentUser.Family} ورود شما موفقیت آمیز بود ";
                    return RedirectToAction("Index" , "Home");
                }
                TempData["FMessage"] = "نام کاربری یا رمز عبور اشتباه است";
                return View();
            }
            TempData["FMessage"] = "اطلاعات وارد شده دارای خطا میباشد";
            return View();
        }
        public ActionResult Logout ()
        {
            Security.Logout();
            return RedirectToAction("Index", "Home");
        }
        protected override void Dispose(bool disposing)//*//*//*//*//*//*//*//*//*//*//*//*//*//*//*//*//*//*//*//*//*//*//*//*//*//*//*//*//*//*//*//*//                                                                               
        {
            if(disposing)
            {
                ctx.Dispose();
            }
            base.Dispose(disposing);    
        }

    }
}