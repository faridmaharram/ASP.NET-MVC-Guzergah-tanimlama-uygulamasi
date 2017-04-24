using BusWeb.Data.Model;
using BusApp.UI.Areas.Admin.Models.CityViewModels;
using BusApp.UI.Areas.Admin.Models.RouterTypeViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusWeb.Core.Infrastructure;
using BusWeb.UI.CustomFilter;

namespace BusApp.UI.Areas.Admin.Controllers
{
    public class GuzergahTipiTanimlamaController : Controller
    {
        #region Guzergah Tipi Tanimlama

        private readonly IRouteTypeRepository _routeTypeRepository;


        public GuzergahTipiTanimlamaController(IRouteTypeRepository routeTypeRepository)
            {
                _routeTypeRepository = routeTypeRepository;
            }
        #endregion
        [LoginFilter]
        public ActionResult Index()
        {
            var model = new RouterTypeViewModel
            {
              
               Router_Types = _routeTypeRepository.GetAll().ToList(),
                Router_Type = new ROUTE_TYPE()
            };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        [LoginFilter]
        public ActionResult GuzergahTipi(RouterTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Router_Type.CREATE_UID = Convert.ToInt32(Session["ID"]);

                model.Router_Type.LASTUPD_UID = Convert.ToInt32(Session["ID"]);
                model.Router_Type.CREATE_DATE = DateTime.Now;
                model.Router_Type.LASTUPD_DATE = DateTime.Now;
                _routeTypeRepository.Insert(model.Router_Type);
                _routeTypeRepository.Save();
                TempData["Ekle"] = "     <script> window.onload = function () {bootbox.alert('Ekleme İşleminiz Başarılı oldu !!! ');  }; </script>";
            }
            else
            {
                TempData["Ekle"] = "     <script> window.onload = function () {bootbox.alert('Ekleme İşleminiz Başarısız oldu !!! ');  }; </script>";
                RedirectToAction("Index");
              
            }
           

            return RedirectToAction("Index", "GuzergahTipiTanimlama");
        }

        [LoginFilter]
        public ActionResult Sil(int id)
        {
            ROUTE_TYPE dbRouteType = _routeTypeRepository.GetById(id);
            if (dbRouteType == null)
            {
                TempData["Sil"] = "     <script> window.onload = function () {bootbox.alert('Bulunamadı !!! ');  }; </script>";
            }
            else
            {
                _routeTypeRepository.Delete(id);
                _routeTypeRepository.Save();
                TempData["Sil"] = "     <script> window.onload = function () {bootbox.alert('Silme İşleminiz Başarılı oldu');  }; </script>";
            }


            return RedirectToAction("Index");
        }

        [HttpGet]
        [LoginFilter]
        public ActionResult Duzenle(int id)
        {
            ROUTE_TYPE dbRouteType = _routeTypeRepository.GetById(id);
            if (dbRouteType == null)
            {
                throw new Exception("Sehir bulunamadi");
            }
            return View(dbRouteType);
        }

        [HttpPost]
        [LoginFilter]
        public ActionResult Duzenle(int id, ROUTE_TYPE route_type)
        {
            if (ModelState.IsValid)
            {
                ROUTE_TYPE dbRouteType = _routeTypeRepository.GetById(id);
                dbRouteType.ROUTE_TYPE_NAME = route_type.ROUTE_TYPE_NAME;
                dbRouteType.LASTUPD_UID = Convert.ToInt32(Session["ID"]);
                dbRouteType.LASTUPD_DATE = DateTime.Now;
                _routeTypeRepository.Save();
                TempData["Duzenle"] = "     <script> window.onload = function () {bootbox.alert('Düzenleme İşlemi Başarılı oldu');  }; </script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Duzenle"] = "     <script> window.onload = function () {bootbox.alert('Düzenleme İşlemi Başarısız oldu');  }; </script>";
                
                return View();
            }


        }
       

    }
}