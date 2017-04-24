using BusWeb.Core.Infrastructure;
using BusWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusWeb.UI.Controllers
{
    public class AccountController : Controller
    {
        #region Login Tanimlamalari
        private readonly IUserRepository _userRepository;
        
      
            public AccountController (IUserRepository userRepository)
            {
                _userRepository=userRepository;
            }
        #endregion

          
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login ()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login (SYSADM_USER user)
        {
            //var gelen = db.SYSADM_USER.Where(m => m.USERNAME == user.USERNAME).SingleOrDefault();
         var KullaniciVarmi = _userRepository.GetMany(x => x.USERNAME == user.USERNAME && x.PASSWORD == user.PASSWORD ).SingleOrDefault();

            if(KullaniciVarmi !=null)
            {
                Session["Name"] = KullaniciVarmi.USERNAME;
                Session["ID"] = KullaniciVarmi.SYSADM_UID;

                return RedirectToAction("Home","Admin");
            }
            ViewBag.Mesaj = "Kullanıcı Bulunamadı";


            return View();
        }

        public ActionResult Logout()
        {
            Session["ID"] = null;
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}