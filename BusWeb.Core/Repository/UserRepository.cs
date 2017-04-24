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
  public  class UserRepository : IUserRepository
    {

        private readonly BusWebModel _context = new BusWebModel();
        public IEnumerable<Data.Model.SYSADM_USER> GetAll()
        {
            return _context.SYSADM_USER.Select(x => x); //tum sehirler donecek
        }

        public Data.Model.SYSADM_USER GetById(int id)
        {
            return _context.SYSADM_USER.FirstOrDefault(x => x.SYSADM_UID == id);
        }

        public Data.Model.SYSADM_USER Get(System.Linq.Expressions.Expression<Func<Data.Model.SYSADM_USER, bool>> expression)
        {
            return _context.SYSADM_USER.FirstOrDefault(expression);
        }

        public IQueryable<Data.Model.SYSADM_USER> GetMany(System.Linq.Expressions.Expression<Func<Data.Model.SYSADM_USER, bool>> expression)
        {
            return _context.SYSADM_USER.Where(expression);
        }

        public void Insert(Data.Model.SYSADM_USER obj)
        {
            _context.SYSADM_USER.Add(obj);
        }

        public void Update(Data.Model.SYSADM_USER obj)
        {
            _context.SYSADM_USER.AddOrUpdate();
        }

        public void Delete(int id)
        {
            var SYSADM_USER = GetById(id);
            if (SYSADM_USER != null)
            {
                _context.SYSADM_USER.Remove(SYSADM_USER);
            }
        }

        public int Count()
        {
            return _context.SYSADM_USER.Count();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
