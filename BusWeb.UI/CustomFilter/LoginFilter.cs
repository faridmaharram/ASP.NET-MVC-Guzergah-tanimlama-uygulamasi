using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BusWeb.UI.CustomFilter
{
    public class LoginFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            HttpContextWrapper wrapper = new HttpContextWrapper(HttpContext.Current);
            var SessionControl = context.HttpContext.Session["ID"];
            if (SessionControl == null)
            {
                //area islemini qaldirmaliyiq dyesen,. route elave eledik 
               

                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { { "controller", "Account" }, { "action", "Login" }, { "Area", String.Empty } });
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}