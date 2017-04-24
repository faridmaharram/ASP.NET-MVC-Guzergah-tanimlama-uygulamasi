using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BusWeb.Data.Model;

namespace BusApp.UI.Areas.Admin.Models.RouterViewModel
{
    public class RouterViewModel
    {
        public List<ROUTE> Routes { get; set; }
        public ROUTE Route { get; set; }
    }
}