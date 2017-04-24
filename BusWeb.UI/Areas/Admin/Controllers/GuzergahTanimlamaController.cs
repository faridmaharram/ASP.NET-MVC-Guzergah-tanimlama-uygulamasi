using BusWeb.Data.Model;
using BusApp.UI.Areas.Admin.Models.CityViewModels;
using BusApp.UI.Areas.Admin.Models.RouterViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusWeb.Core.Infrastructure;
using BusWeb.UI.CustomFilter;

namespace BusApp.UI.Areas.Admin.Controllers
{
    public class GuzergahTanimlamaController : Controller
    {
        #region Guzergah Tanimlama
        private readonly IRouteRepository _routeRepository;
         private readonly IRouteTypeRepository _routeTypeRepository;
         private readonly ICityRepository _cityRepository;


         public GuzergahTanimlamaController(IRouteRepository routeRepository, IRouteTypeRepository routeTypeRepository, ICityRepository cityRepository)
            {
                _routeRepository=routeRepository;
                _routeTypeRepository = routeTypeRepository;
                _cityRepository = cityRepository;
            }
        #endregion
         [LoginFilter]
        public ActionResult Index()
        {
            
            ViewBag.ROUTE_TYPE_ID = new SelectList(_routeTypeRepository.GetAll().ToList(), "ROUTE_TYPE_ID", "ROUTE_TYPE_NAME");
            ViewBag.CITY_ID = new SelectList(_cityRepository.GetAll().ToList(), "CITY_ID", "CITY_NAME");
            var model = new RouterViewModel
            {
                Routes = _routeRepository.GetAll().ToList(),
                Route = new ROUTE()
            };
            return View(model);
           
        }
        [HttpPost, ValidateAntiForgeryToken]
        [LoginFilter]
        public ActionResult Guzergah(RouterViewModel model, int CITY_ID, int ROUTE_TYPE_ID)
        {
            if (ModelState.IsValid)
            {
                model.Route.CREATE_UID = Convert.ToInt32(Session["ID"]);

                model.Route.LASTUPD_UID = Convert.ToInt32(Session["ID"]);
                model.Route.CREATE_DATE = DateTime.Now;
                model.Route.CITY_ID = CITY_ID;
                model.Route.ROUTE_TYPE_ID = ROUTE_TYPE_ID;
                model.Route.LASTUPD_DATE = DateTime.Now;


                _routeRepository.Insert(model.Route);
                _routeRepository.Save();
                TempData["Ekle"] = "     <script> window.onload = function () {bootbox.alert('Ekleme İşleminiz Başarılı oldu !!! ');  }; </script>";
                
            }
            else
            {
                TempData["Ekle"] = "     <script> window.onload = function () {bootbox.alert('Ekleme İşleminiz Başarısız oldu !!! ');  }; </script>";
                RedirectToAction("Index");
               
            }
           

            return RedirectToAction("Index", "GuzergahTanimlama");
        }
        [LoginFilter]
        public ActionResult Sil(int id)
        {
            ROUTE dbRoute = _routeRepository.GetById(id);
            if (dbRoute == null)
            {
                TempData["Sil"] = "     <script> window.onload = function () {bootbox.alert('Bulunamadı !!! ');  }; </script>";
            }
            else
            {
                _routeRepository.Delete(id);
                _routeRepository.Save();
                TempData["Sil"] = "     <script> window.onload = function () {bootbox.alert('Silme İşleminiz Başarılı oldu');  }; </script>";

            }


            return RedirectToAction("Index");
        }
        [HttpGet]
        [LoginFilter]
        public ActionResult Duzenle(int id)
        {
            ViewBag.ROUTE_TYPE_ID = new SelectList(_routeTypeRepository.GetAll().ToList(), "ROUTE_TYPE_ID", "ROUTE_TYPE_NAME");
            ViewBag.CITY_ID = new SelectList(_cityRepository.GetAll().ToList(), "CITY_ID", "CITY_NAME");
            ROUTE dbRoute = _routeRepository.GetById(id);
            if (dbRoute == null)
            {
                throw new Exception("Bulunamadi");
            }
            return View(dbRoute);
        }
        [HttpPost]
        [LoginFilter]
        public ActionResult Duzenle(int id, ROUTE route)
        {
            if (ModelState.IsValid)
            {
                ROUTE dbCity = _routeRepository.GetById(id);
                dbCity.ROUTE_NAME = route.ROUTE_NAME;
                dbCity.ROUTE_TYPE_ID = route.ROUTE_TYPE_ID;
                dbCity.CITY_ID = route.CITY_ID;
                dbCity.PERON_NO = route.PERON_NO;
                dbCity.VEHICLE_TYPE = route.VEHICLE_TYPE;
                dbCity.TOT_DURATION = route.TOT_DURATION;
                dbCity.LASTUPD_UID = Convert.ToInt32(Session["ID"]);
                dbCity.LASTUPD_DATE = DateTime.Now;
                _routeRepository.Save();
                TempData["Duzenle"] = "     <script> window.onload = function () {bootbox.alert('Düzenleme İşlemi Başarılı oldu');  }; </script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Duzenle"] = "     <script> window.onload = function () {bootbox.alert('Düzenleme İşlemi Başarısız oldu');  }; </script>";
                return View();
            }


            //ViewBag.KategoriId = new SelectList(db.Kategoris, "KategoriId", "KategoriAdi");
        }


    }
}