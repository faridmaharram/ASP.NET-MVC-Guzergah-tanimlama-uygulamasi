using BusWeb.Core.Infrastructure;
using BusWeb.Core.Repository;
using BusWeb.Data.Model;
using BusWeb.UI.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusWeb.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        #region Ana Sayfa Tanimlama

        private readonly IStationRepository _stationRepository;
        private readonly IRouteRepository _routeRepository;
        private readonly IRouteTypeRepository _routeTypeRepository;
        private readonly ICityRepository _cityRepository;
        ICityRepository cityRepo = new CityRepository();
        IRouteTypeRepository routeTypeRepo = new RouteTypeRepository();
        IRouteRepository routeRepo = new RouteRepository();
        IStationRepository stationRepo = new StationRepository();
        BusWebModel db = new BusWebModel();


        public HomeController(IStationRepository stationRepository, IRouteRepository routeRepository, IRouteTypeRepository routeTypeRepository, ICityRepository cityRepository)
        {
            _stationRepository = stationRepository;
            _routeRepository = routeRepository;
        }
        #endregion
        public ActionResult Index()
        {
            var model = new AllViewModel
            {
                Stations = _stationRepository.GetAll().ToList(),
                Station = new STATION()
            };
            //var liste = _stationRepository.GetAll().ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(JSgelen gelen )
        {

            var sorgu = _stationRepository.GetAll().AsQueryable();

            if (gelen.City > 0)
            {
                sorgu = sorgu.Where(m => m.ROUTE.CITY_ID == gelen.City);

            }
            if (gelen.RouteType > 0)
            {
                sorgu = sorgu.Where(m => m.ROUTE.ROUTE_TYPE_ID == gelen.RouteType);
            }

            if(gelen.City>0 &&gelen.RouteType>0)
            {
                sorgu = sorgu.Where(m => m.ROUTE.ROUTE_TYPE_ID == gelen.RouteType && m.ROUTE.CITY_ID == gelen.City);
            }

            if(gelen.City>0 &&gelen.RouteType>0 && gelen.Route>0)
            {
                sorgu = sorgu.Where(m => m.ROUTE.ROUTE_TYPE_ID == gelen.RouteType && m.ROUTE.CITY_ID == gelen.City && m.ROUTE_ID==gelen.Route);
            }

            if(gelen.City>0 && gelen.Route>0)
            {
                sorgu = sorgu.Where(m => m.ROUTE_ID == gelen.Route && m.ROUTE.CITY_ID == gelen.City);
            }

          
                
            
            var model = new AllViewModel
            {
                Stations = sorgu.ToList(),
                Station = new STATION()
            };
           
            return View(model);
        }

    
       
       
        public JsonResult CityList()
        {
            var city = cityRepo.GetAll().OrderBy(x => x.CITY_NAME).Select(r => new
                    {
                        ID = r.CITY_ID,
                        NAME = r.CITY_NAME
                    });

            return Json(city, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RouteTypeList()
        {
            var routetype = routeTypeRepo.GetAll().OrderBy(x => x.ROUTE_TYPE_NAME).Select(r => new
            {
                ID = r.ROUTE_TYPE_ID,
                NAME = r.ROUTE_TYPE_NAME
            });

            return Json(routetype, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RouteList(int id)
        {

            var route = routeRepo.GetListById(id).OrderBy(x => x.ROUTE_ID).Select(r => new
            {
                ID = r.ROUTE_ID,
                NAME = r.ROUTE_NAME
            });
            return Json(route, JsonRequestBehavior.AllowGet);
        }

        public JsonResult StationList(int id)
        {

            var station = stationRepo.GetListById(id).OrderBy(x => x.ROUTE_ID).Select(r => new
            {
                ID = r.STATION_ID,
                NAME = r.STATION_NAME
            });
            return Json(station, JsonRequestBehavior.AllowGet);
        }
    
    }
}