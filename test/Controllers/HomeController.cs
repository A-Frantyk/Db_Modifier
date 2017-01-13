using DataLayer;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;
using DAL.UnitOfWorkRealization;
using Services.DevTestService;
using Services.ViewModels;

namespace test.Controllers
{
    public class HomeController : Controller
    {
        private DbTestContext _context;

        private DevTestUnitOfWork _unitOfWork;

        private DevTestRepository _repository;

        private DevTestService _devTestService;

        public HomeController()
        {
            _context = new DbTestContext();
            _unitOfWork = new DevTestUnitOfWork(_context);
            _repository = new DevTestRepository(_context);

            _devTestService = new DevTestService(_context, _unitOfWork, _repository);
        }

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult GetMessages()
        {
            var allMessages = _devTestService.GetAll();

            if(allMessages != null)
            {
                //return View(allMessages);
                return PartialView("_MessagesList", allMessages);
            }

            throw new InvalidOperationException($"Cannot load all messages.");
        }

        public void CreateNew(DevTestModel model)
        {
            if(model != null)
            {
                _devTestService.AddMessage(model);
            }
        }

    }
}