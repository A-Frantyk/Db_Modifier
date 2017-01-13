using DataLayer;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class HomeController : Controller
    {
        private DbTestContext _context = new DbTestContext();

        public ActionResult Index()
        {


            return View();
        }
        
        public ActionResult GetMessages()
        {
            DevTestRepository repository = new DevTestRepository(_context);

            var messages = repository.GetAll().AsEnumerable();

            return View(messages);
        }

        public void CreateNewNote(DevTestModel model)
        {
            if(model != null)
            {

            }
        }

    }
}