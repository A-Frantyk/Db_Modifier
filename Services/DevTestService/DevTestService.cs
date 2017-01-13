using DAL.Repositories;
using DAL.UnitOfWorkRealization;
using DataLayer;
using DataLayer.Model;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace Services.DevTestService
{
    public class DevTestService
    {
        private DbTestContext _context;
        private DevTestUnitOfWork _unitOfWork;
        private DevTestRepository _repository;

        public DevTestService(DbTestContext context, DevTestUnitOfWork unitOfWork, DevTestRepository repository)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public IList<DevTest> GetAll()
        {
            _unitOfWork.BeginTransaction();
            var allMessages = _repository.GetAll();
            
            return allMessages.ToList();
        }

        public void AddMessage(DevTestModel model)
        {
            if(model != null)
            {
                var devTest = new DevTest { Impressions = model.Impressions, AffiliateName = model.AffiliateName };

                _unitOfWork.BeginTransaction();

                _repository.Create(devTest);

                _unitOfWork.Commit();

                _unitOfWork.SaveChanges();
            }

            throw new InvalidOperationException("Data to insert not found");
        }
    }
}
