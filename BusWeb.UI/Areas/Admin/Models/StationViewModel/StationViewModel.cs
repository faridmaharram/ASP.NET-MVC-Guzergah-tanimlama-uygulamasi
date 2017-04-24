using BusWeb.Data.Model;
using BusWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusApp.UI.Areas.Admin.Models.StationViewModel
{
    public class StationViewModel
    {
        public List<STATION> Stations { get; set; }
        public STATION Station { get; set; }
    }
}