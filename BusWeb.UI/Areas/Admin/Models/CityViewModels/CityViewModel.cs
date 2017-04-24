using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusWeb.Data.Model;
namespace BusApp.UI.Areas.Admin.Models.CityViewModels
{
    public class CityViewModel
    {
        public List<CITY> Cities { get; set; }
        public CITY City { get; set; }
    }
}