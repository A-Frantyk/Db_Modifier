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

        public IList<DevTestModel> GetAll()
        {
            _unitOfWork.BeginTransaction();
            var allMessages = _repository.GetAll();

            var viewModel = new List<DevTestModel>();

            foreach (var allMessage in allMessages)
            {
                var model = new DevTestModel()
                {
                    ID = allMessage.ID,
                    AffiliateName = allMessage.AffiliateName,
                    Conversions = allMessage.Conversions,
                    Clicks = allMessage.Clicks,
                    CompaignName = allMessage.CompaignName,
                    Date = allMessage.Date
                };

                viewModel.Add(model);
            }

            return viewModel;
        }

        public void AddMessage(DevTestModel model)
        {
            if(model != null)
            {
                var devTest = new DevTest()
                {
                    AffiliateName = model.AffiliateName,
                    Impressions = model.Impressions,
                    ID = model.ID,
                    Date = model.Date,
                    CompaignName = model.CompaignName,
                    Conversions = model.Conversions,
                    Clicks = model.Clicks
                };

                _unitOfWork.BeginTransaction();

                _repository.Create(devTest);

                //_unitOfWork.Commit();

                _unitOfWork.SaveChanges();
            }

            throw new InvalidOperationException("Data to insert not found");
        }

        public void RemoveMessage(DevTestModel model)
        {
            if (model != null)
            {
                var devtest = new DevTest()
                {
                    AffiliateName = model.AffiliateName,
                    Impressions = model.Impressions,
                    ID = model.ID, 
                    Date = model.Date,
                    CompaignName = model.CompaignName,
                    Conversions = model.Conversions,
                    Clicks = model.Clicks
                };

                _unitOfWork.BeginTransaction();
                _repository.Delete(devtest);

                _unitOfWork.Commit();

                _unitOfWork.SaveChanges();
            }

            throw new InvalidOperationException("No data to delete");
        }
    }
}
