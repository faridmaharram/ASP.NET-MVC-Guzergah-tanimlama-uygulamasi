using BusWeb.Core.Infrastructure;
using BusWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;

namespace BusWeb.Core.Repository
{
   public class RouteTypeRepository : IRouteTypeRepository
    {
        private readonly BusWebModel _context = new BusWebModel();
        public IEnumerable<Data.Model.ROUTE_TYPE> GetAll()
        {
            return _context.ROUTE_TYPE.Select(x => x); //tum sehirler donecek
        }

        public Data.Model.ROUTE_TYPE GetById(int id)
        {
            return _context.ROUTE_TYPE.FirstOrDefault(x => x.ROUTE_TYPE_ID == id);
        }

        public Data.Model.ROUTE_TYPE Get(System.Linq.Expressions.Expression<Func<Data.Model.ROUTE_TYPE, bool>> expression)
        {
            return _context.ROUTE_TYPE.FirstOrDefault(expression);
        }

        public IQueryable<Data.Model.ROUTE_TYPE> GetMany(System.Linq.Expressions.Expression<Func<Data.Model.ROUTE_TYPE, bool>> expression)
        {
            return _context.ROUTE_TYPE.Where(expression);
        }

        public void Insert(Data.Model.ROUTE_TYPE obj)
        {
            _context.ROUTE_TYPE.Add(obj);
        }

        public void Update(Data.Model.ROUTE_TYPE obj)
        {
            _context.ROUTE_TYPE.AddOrUpdate();
        }

        public void Delete(int id)
        {
            var ROUTE_TYPE = GetById(id);
            if (ROUTE_TYPE != null)
            {
                _context.ROUTE_TYPE.Remove(ROUTE_TYPE);
            }
        }

        public int Count()
        {
            return _context.ROUTE_TYPE.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
