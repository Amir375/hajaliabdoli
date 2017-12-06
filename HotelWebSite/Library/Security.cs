using Hotels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelWebSite.Library
{
    public static class Security
    {
        public static Employee GetCurrentEmployee()
        {
            if (HttpContext.Current.Request.Cookies["UserId"] != null)
            {
                var CurrentUser = Convert.ToInt32(HttpContext.Current.Request.Cookies["UserId"].Value);
                HttpContext.Current.Session["UserId"] = CurrentUser;
            }
            if (HttpContext.Current.Session["UserId"]!=null)
            {
                var CurrentEmployeeId = Convert.ToInt32(HttpContext.Current.Session["UserId"]);
                HotelDb ctx = new HotelDb();

                var Empo = ctx.Employees.Find(CurrentEmployeeId);
                return Empo; 
            }
            else
            {
                return null;
            }
        }
        public static void Logout()
        {
            HttpContext.Current.Session["UserId"] = null;
            if (HttpContext.Current.Request.Cookies["UserId"] != null)
            {
                var cookie = HttpContext.Current.Request.Cookies["UserId"];
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Set(cookie);
            }
        }
    }
}