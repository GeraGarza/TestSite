using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSite.Models;
using TestSite.ViewModels;
using System.Data.Entity;

namespace TestSite.Controllers
{
    public class AppsController : Controller
    {
        // GET: Applications

        private ApplicationDbContext _context;

        public AppsController()
        {
            _context = new ApplicationDbContext();
        }

        
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {


            var appTypes = _context.AppType.ToList();

            var viewModel = new AppFormViewModel
            {

                AppTypes = appTypes


            };

            return View(viewModel);
        }


        public ActionResult Save(AppFormViewModel viewModel)
        {

            if (viewModel.App.Id == 0)
                _context.Apps.Add(viewModel.App);
            else
            {
                var appInDb = _context.Apps.Single(p => p.Id == viewModel.App.Id);

                appInDb.Id = viewModel.App.Id;
                appInDb.Name = viewModel.App.Name;
                appInDb.AppTypeId = viewModel.App.AppTypeId;
                appInDb.DateAdded = viewModel.App.DateAdded;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "App");
        }




        public ActionResult Edit(int id)
        {
            return Content("index = " + id);
        }




        public ActionResult Index(int? pageIndex, string sortBy)
        {
            var apps = _context.Apps.Include(p => p.AppType).ToList();

            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            var AppModel = new AppsViewModel
            {
                Apps = apps
            };
            //return Content(String.Format("PageIndex = {0}       sortBy={1}", pageIndex, sortBy))

            return View(AppModel);
            ;
        }

        public ActionResult Details(int id)
        {


            var app = _context.Apps.Include(t => t.AppType).SingleOrDefault(c => c.Id == id);
    

            return View(app);

        }




        [Route("products/released/{year:regex(\\d{4})}/{month:range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {

            return Content(year + "/" + month);


        }


    }
}