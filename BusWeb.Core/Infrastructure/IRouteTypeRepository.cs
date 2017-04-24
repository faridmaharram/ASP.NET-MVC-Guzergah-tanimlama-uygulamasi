using BusWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusWeb.Core.Infrastructure
{
  public  interface IRouteTypeRepository : IRepository<ROUTE_TYPE>
    {
      IEnumerable<Data.Model.ROUTE_TYPE> GetAll();
    }
}
