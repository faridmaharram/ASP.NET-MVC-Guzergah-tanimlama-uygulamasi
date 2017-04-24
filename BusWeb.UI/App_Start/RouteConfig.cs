using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BusWeb.UI.Controllers;
namespace BusWeb.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            var namespaces = new[] { typeof(HomeController).Namespace };
                // Bi deq gelirem indi, qardas men hele home tarafini elememisem ona gore hata verir.
                // bu ona gore deyil. Senin iki dene Home contollerin var proqram qarisdirir hansini birinci acmaq lazimdi
                //birinci normal home acilma
            // HELL oldu

            //bes eger bu ayarlamani elemeseydik home view elave eleseydik,. yene xeta verecekdi? yoxlayaq))
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

          


            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                 new { controller = "Home", action = "Index", id = UrlParameter.Optional }, namespaces
            );
        }
    }
}
