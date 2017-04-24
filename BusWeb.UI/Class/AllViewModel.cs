using BusWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusWeb.UI.Class
{
    public class AllViewModel
    {
        

        public List<STATION> Stations { get; set; }

        public STATION Station { get; set; }

        public List<CITY> Cities { get; set; }

        public CITY City { get; set; }
    }
}