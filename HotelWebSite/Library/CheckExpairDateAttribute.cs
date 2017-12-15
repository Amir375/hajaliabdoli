using Hotels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWebSite.Library
{
    public class CheckExpairDateAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HotelDb ctx = new HotelDb();
            var a = ctx.Bookings.Where(n => n.DateOfDeparture < DateTime.Now).Select(n => n.SuitId);
            var d = ctx.Suits.Where(t => a.Contains(t.Id)).ToList();
            d.ForEach(p =>
            {
                p.EmptyOrFull = false;
            });

            var u = ctx.Bookings.Where(c => c.DateOfDeparture < DateTime.Now).ToList();
            u.ForEach(p =>
            {
                p.Expire = true;
            });

            ctx.SaveChanges();

        }

    }
}