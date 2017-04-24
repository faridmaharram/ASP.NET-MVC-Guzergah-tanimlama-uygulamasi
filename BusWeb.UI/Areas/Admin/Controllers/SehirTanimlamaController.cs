
using BusApp.UI.Areas.Admin.Models.CityViewModels;
using BusWeb.Core.Infrastructure;
using BusWeb.Data.Model;
using BusWeb.UI.CustomFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusApp.UI.Areas.Admin.Controllers
{
    public class SehirTanimlamaController : Controller
    {

        #region Sehir Tanimlama

        private readonly ICityRepository _cityRepository;

       
            public SehirTanimlamaController (ICityRepository cityRepository)
            {
                _cityRepository=cityRepository;
            }
        #endregion
            [LoginFilter]
        public ActionResult Index()
        {

            var model = new CityViewModel
            {
                Cities = _cityRepository.GetAll().ToList() ,
                City = new CITY()
            };
            return View(model);
        }

         [HttpPost, ValidateAntiForgeryToken]
         [LoginFilter]
        public ActionResult Sehir(CityViewModel model)
        {
                 if (ModelState.IsValid)
            {
                
                 
                model.City.CREATE_UID = Convert.ToInt32(Session["ID"]);

                model.City.LASTUPD_UID = Convert.ToInt32(Session["ID"]);
                model.City.CREATE_DATE = DateTime.Now;
                model.City.LASTUPD_DATE = DateTime.Now;
                _cityRepository.Insert(model.City);
                _cityRepository.Save();
             
                TempData["Ekle"] = "     <script> window.onload = function () {bootbox.alert('Ekleme İşleminiz Başarılı oldu !!! ');  }; </script>";
        
            }
                 else
                 {
                     TempData["Ekle"] = "     <script> window.onload = function () {bootbox.alert('Ekleme İşleminiz Başarısız oldu !!! ');  }; </script>";
                      RedirectToAction("Index");
                 }
                
                 
            return RedirectToAction("Index", "SehirTanimlama");
 }

        [LoginFilter]
         public ActionResult Sil(int id)
         {
             CITY dbCity = _cityRepository.GetById(id);
             if(dbCity ==null)
             {
                 TempData["Ekle"] = "     <script> window.onload = function () {bootbox.alert('Şehir Bulunamadı !!! ');  }; </script>";
             }
             else
             {
                 _cityRepository.Delete(id);
                 _cityRepository.Save();
                 TempData["Sil"] = "     <script> window.onload = function () {bootbox.alert('Silme İşleminiz Başarılı oldu');  }; </script>";
             }
         
             
             return RedirectToAction("Index");
         }

        [HttpGet]
        [LoginFilter]
         public ActionResult Duzenle(int id)
         {
             CITY dbCity = _cityRepository.GetById(id);
             if (dbCity == null)
             {
                 throw new Exception("Sehir bulunamadi");
             }
             return View(dbCity);
         }

         [HttpPost]
         [LoginFilter]
         public ActionResult Duzenle(CITY city,int id)
         {
             if(ModelState.IsValid)
             {
                 CITY dbCity = _cityRepository.GetById(id);
                 dbCity.CITY_NAME = city.CITY_NAME;
                 dbCity.LASTUPD_UID = Convert.ToInt32(Session["ID"]);
                 dbCity.LASTUPD_DATE = DateTime.Now;
                 _cityRepository.Save();
                 TempData["Duzenle"] = "     <script> window.onload = function () {bootbox.alert('Düzenleme İşlemi Başarılı oldu');  }; </script>";
               return  RedirectToAction("Index");
             }
             else
             {
                 TempData["Duzenle"] = "     <script> window.onload = function () {bootbox.alert('Düzenleme İşlemi Başarısız oldu');  }; </script>";
                 return View();
             }
            
         
         }
       
    }
}