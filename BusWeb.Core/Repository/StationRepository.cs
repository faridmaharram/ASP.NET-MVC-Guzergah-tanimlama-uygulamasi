using BusWeb.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using BusWeb.Data.Model;

namespace BusWeb.Core.Repository
{
    public class StationRepository : IStationRepository
    {

        private readonly BusWebModel _context = new BusWebModel();
        public IEnumerable<Data.Model.STATION> GetAll()
        {
            return _context.STATIONs.Select(x => x); //tum sehirler donecek
        }

        public IEnumerable<Data.Model.STATION> GetListById(int id)
        {
        //    return _context.STATIONs.FirstOrDefault(x => x.STATION_ID == id);
            return _context.STATIONs.Where(x => x.ROUTE_ID == id);
        }
        public Data.Model.STATION GetById(int id)
        {
            return _context.STATIONs.FirstOrDefault(x => x.STATION_ID == id);
        }

        public Data.Model.STATION Get(System.Linq.Expressions.Expression<Func<Data.Model.STATION, bool>> expression)
        {
            return _context.STATIONs.FirstOrDefault(expression);
        }

        public IQueryable<Data.Model.STATION> GetMany(System.Linq.Expressions.Expression<Func<Data.Model.STATION, bool>> expression)
        {
            return _context.STATIONs.Where(expression);
        }

        public void Insert(Data.Model.STATION obj)
        {
            _context.STATIONs.Add(obj);
        }

        public void Update(Data.Model.STATION obj)
        {
            _context.STATIONs.AddOrUpdate();
        }

        public void Delete(int id)
        {
            var STATION = GetById(id);
            if (STATION != null)
            {
                _context.STATIONs.Remove(STATION);
            }
        }

        public int Count()
        {
            return _context.STATIONs.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
