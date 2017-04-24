using BusWeb.Data.Model;
using BusApp.UI.Areas.Admin.Models.StationViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusWeb.Core.Infrastructure;
using BusWeb.UI.CustomFilter;

namespace BusApp.UI.Areas.Admin.Controllers
{
    public class DurakTanimlamaController : Controller
    {
   #region Durak Tanimlama
         private readonly IStationRepository _stationRepository;
         private readonly IRouteRepository _routeRepository;
        
      
            public DurakTanimlamaController (IStationRepository stationRepository, IRouteRepository routeRepository)
            {
                _stationRepository=stationRepository;
                _routeRepository = routeRepository;
            }
   #endregion
            [LoginFilter]
        public ActionResult Index()
        {
            ViewBag.ROUTE_ID = new SelectList(_routeRepository.GetAll().ToList(), "ROUTE_ID", "ROUTE_NAME");

            var model = new StationViewModel
            {
                Stations = _stationRepository.GetAll().ToList(),
                Station = new STATION()
            };
            return View(model);           
        }

        [HttpPost, ValidateAntiForgeryToken]
        [LoginFilter]
        public ActionResult Durak(StationViewModel model,int ROUTE_ID)
        {
            if (ModelState.IsValid)
            {
                model.Station.CREATE_UID = Convert.ToInt32(Session["ID"]);

                model.Station.LASTUPD_UID = Convert.ToInt32(Session["ID"]);
                model.Station.CREATE_DATE = DateTime.Now;

                model.Station.ROUTE_ID = ROUTE_ID;
                model.Station.LASTUPD_DATE = DateTime.Now;


                _stationRepository.Insert(model.Station);
                _stationRepository.Save();
                TempData["Ekle"] = "     <script> window.onload = function () {bootbox.alert('Ekleme İşleminiz Başarılı oldu !!! ');  }; </script>";
                
            }
            else
            {
                TempData["Ekle"] = "     <script> window.onload = function () {bootbox.alert('Ekleme İşleminiz Başarısız oldu !!! ');  }; </script>";
                RedirectToAction("Index");
               
            }
          

            return RedirectToAction("Index", "DurakTanimlama");
        }
        [LoginFilter]
        public ActionResult Sil(int id)
        {
            STATION dbStation =_stationRepository.GetById(id);
            if (dbStation == null)
            {
                TempData["Sil"] = "     <script> window.onload = function () {bootbox.alert('Bulunamadı !!! ');  }; </script>";
            }
            else
            {
                _stationRepository.Delete(id);
                _stationRepository.Save();
                TempData["Sil"] = "     <script> window.onload = function () {bootbox.alert('Silme İşleminiz Başarılı oldu');  }; </script>";
            }


            return RedirectToAction("Index");
        }


        [HttpGet]
        [LoginFilter]
        public ActionResult Duzenle(int id)
        {
            ViewBag.ROUTE_ID = new SelectList(_routeRepository.GetAll().ToList(), "ROUTE_ID", "ROUTE_NAME");
            STATION dbStation = _stationRepository.GetById(id);
            if (dbStation == null)
            {
                throw new Exception("Sehir bulunamadi");
            }
            return View(dbStation);
        }

        [HttpPost]
        [LoginFilter]
        public ActionResult Duzenle(int id, STATION station)
        {
            if (ModelState.IsValid)
            {
                if(ModelState.IsValid)
                {
                    STATION dbStation = _stationRepository.GetById(id);
                    dbStation.STATION_NAME = station.STATION_NAME;

                    dbStation.ROUTE_ID = station.ROUTE_ID;
                    dbStation.STATION_NO = station.STATION_NO;
                    dbStation.ARRIVAL_TIME = station.ARRIVAL_TIME;
                    dbStation.DEPARTURE_TIME = station.DEPARTURE_TIME;
                    dbStation.LASTUPD_UID = Convert.ToInt32(Session["ID"]);
                    dbStation.LASTUPD_DATE = DateTime.Now;
                    _stationRepository.Save();
                    TempData["Duzenle"] = "     <script> window.onload = function () {bootbox.alert('Düzenleme İşlemi Başarılı oldu');  }; </script>";
                }
               
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