using BusWeb.Core.Infrastructure;
using BusWeb.Data.Model;
using BusWeb.UI.CustomFilter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusApp.UI.Areas.Admin.Controllers
{
    public class ExcelController : Controller
    {
        #region Excel

        private readonly IStationRepository _stationRepository;
        private readonly IRouteRepository _routeRepository;
        private readonly IRouteTypeRepository _routeTypeRepository;
        private readonly ICityRepository _cityRepository;

        public ExcelController(ICityRepository cityRepository, IStationRepository stationRepository, IRouteRepository routeRepository, IRouteTypeRepository routeTypeRepository)
            {
                _cityRepository=cityRepository;
                _stationRepository = stationRepository;
                _routeRepository = routeRepository;
                _routeTypeRepository = routeTypeRepository;
            }
        #endregion
       
        [LoginFilter]
        public ActionResult Index()
        {
           

            return View();
        }

        [LoginFilter]
        public ActionResult ExportToExcelStation()
        {
            GridView gv = new GridView();
            gv.DataSource = _stationRepository.GetAll().ToList();
            gv.DataBind();
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/ms-excel";
            Response.AddHeader("content-disposition", "attachment;filename=Stations.xls");
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            return RedirectToAction("Index");
        }
        [LoginFilter]
        public ActionResult ExportToExcelRoute()
        {
            GridView gv = new GridView();
            gv.DataSource = _routeRepository.GetAll().ToList();
            gv.DataBind();
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/ms-excel";
            Response.AddHeader("content-disposition", "attachment;filename=Routes.xls");
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            return RedirectToAction("Index");
        }
        [LoginFilter]
        public ActionResult ExportToExcelRouteType()
        {
            GridView gv = new GridView();
            gv.DataSource = _routeTypeRepository.GetAll().ToList();
            gv.DataBind();
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/ms-excel";
            Response.AddHeader("content-disposition", "attachment;filename=RouteTypes.xls");
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            return RedirectToAction("Index");
        }
        [LoginFilter]

        public ActionResult ExportToExcelCity()
        {
            GridView gv = new GridView();
            gv.DataSource = _cityRepository.GetAll().ToList();
            gv.DataBind();
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/ms-excel";
            Response.AddHeader("content-disposition", "attachment;filename=Cities.xls");
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
            return RedirectToAction("Index");
        }
    }
}