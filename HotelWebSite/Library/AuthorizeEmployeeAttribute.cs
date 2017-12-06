using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelWebSite.Library
{
    public class AuthorizeEmployeeAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Security.GetCurrentEmployee() == null)
            {
                filterContext.Controller.TempData["Message"] = "برای دسترسی به این قسمت ابتدا باید وارد شوید ";
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary()
                    {
                        { "action" , "Login" },
                        { "controller" , "Security" }
                    }
                    
                    );
            }

        }
    }
}