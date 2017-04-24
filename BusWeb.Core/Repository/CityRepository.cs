using BusWeb.Core.Infrastructure;
using BusWeb.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations; //addorupdate

namespace BusWeb.Core.Repository
{
  public  class CityRepository : ICityRepository
    {
      private readonly BusWebModel _context = new BusWebModel();
        public IEnumerable<Data.Model.CITY> GetAll()
        {
            return _context.CITies.Select(x => x); //tum sehirler donecek
        }

        public Data.Model.CITY GetById(int id)
        {
            return _context.CITies.FirstOrDefault(x => x.CITY_ID == id);
        }

        public Data.Model.CITY Get(System.Linq.Expressions.Expression<Func<Data.Model.CITY, bool>> expression)
        {
            return _context.CITies.FirstOrDefault(expression);
        }

        public IQueryable<Data.Model.CITY> GetMany(System.Linq.Expressions.Expression<Func<Data.Model.CITY, bool>> expression)
        {
            return _context.CITies.Where(expression);
        }

        public void Insert(Data.Model.CITY obj)
        {
            _context.CITies.Add(obj);
        }

        public void Update(Data.Model.CITY obj)
        {
            _context.CITies.AddOrUpdate();
        }

        public void Delete(int id)
        {
            var CITY = GetById(id);
            if (CITY != null)
            {
                _context.CITies.Remove(CITY);
            }
        }

        public int Count()
        {
            return _context.CITies.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
