using DAL.Interfaces;
using DataLayer;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWorkRealization
{
    public class DevTestUnitOfWork : IUnitOfWork
    {
        private DbTestContext _context;
        private DbContextTransaction _transaction;

        public DevTestUnitOfWork(DbTestContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void RollBack()
        {
            _transaction.Rollback();
        }
    }
}
