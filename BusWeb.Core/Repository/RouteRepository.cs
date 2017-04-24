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
    public class RouteRepository : IRouteRepository
    {

        private readonly BusWebModel _context = new BusWebModel();
        public IEnumerable<Data.Model.ROUTE> GetAll()
        {
            return _context.ROUTEs.Select(x => x); //tum sehirler donecek
        }
        public IEnumerable<Data.Model.ROUTE> GetListById(int id)
        {
            return _context.ROUTEs.Where(x => x.CITY_ID == id );
        }
        public Data.Model.ROUTE GetById(int id)
        {
            return _context.ROUTEs.FirstOrDefault(x => x.ROUTE_ID == id);
        }

        public Data.Model.ROUTE Get(System.Linq.Expressions.Expression<Func<Data.Model.ROUTE, bool>> expression)
        {
            return _context.ROUTEs.FirstOrDefault(expression);
        }

        public IQueryable<Data.Model.ROUTE> GetMany(System.Linq.Expressions.Expression<Func<Data.Model.ROUTE, bool>> expression)
        {
            return _context.ROUTEs.Where(expression);
        }

        public void Insert(Data.Model.ROUTE obj)
        {
            _context.ROUTEs.Add(obj);
        }

        public void Update(Data.Model.ROUTE obj)
        {
            _context.ROUTEs.AddOrUpdate();
        }

        public void Delete(int id)
        {
            var ROUTE = GetById(id);
            if (ROUTE != null)
            {
                _context.ROUTEs.Remove(ROUTE);
            }
        }

        public int Count()
        {
            return _context.ROUTEs.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
