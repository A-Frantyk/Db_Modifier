using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Model;
using DAL.Interfaces;

namespace ServiceLayer.Repositories
{
    public class DevTestRepository : IRepository<DevTest>, IDisposable
    {
        private DbTestContext _context;
        private bool disposed = false;

        public DevTestRepository(DbTestContext context)
        {
            _context = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IQueryable<DevTest> GetAll()
        {
            return _context.DevTests;
        }

        public DevTest GetById(int id)
        {
            return _context.DevTests.FirstOrDefault(test => test.ID == id);
        }

        public void Create(DevTest entity)
        {
            _context.DevTests.Add(entity);
        }

        public void Update(DevTest entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(DevTest entity)
        {
            _context.DevTests.Remove(entity);
        }
    }
}
