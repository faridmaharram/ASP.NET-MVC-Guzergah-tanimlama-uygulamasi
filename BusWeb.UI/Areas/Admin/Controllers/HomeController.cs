using BusWeb.UI.CustomFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusApp.UI.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        [LoginFilter]
        public ActionResult Index()
        {
            return View();
        }
    }
}