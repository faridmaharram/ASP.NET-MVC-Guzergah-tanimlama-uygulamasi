using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BusWeb.Data.Model;

namespace BusApp.UI.Areas.Admin.Models.RouterTypeViewModel
{
    public class RouterTypeViewModel
    {
        public List<ROUTE_TYPE> Router_Types { get; set; }
        public ROUTE_TYPE Router_Type { get; set; }

    }
}