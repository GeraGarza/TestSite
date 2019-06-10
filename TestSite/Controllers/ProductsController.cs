
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
    public class ProductsController : Controller
    {
        // GET: Products


        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        public ActionResult Edit(int id)
        {
            return Content("index = " + id);
        }

        public ActionResult New()
        {


            var productTypes = _context.ProductType.ToList();

            var viewModel = new ProductFormViewModel
            {

                ProductType = productTypes
                

            };

            return View(viewModel);
        }


        public ActionResult Index(int? pageIndex, string sortBy)
        {
            var products = _context.Products.Include(p => p.ProductType).ToList();

            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            var ProductModel = new ProductsViewModel
            {
                Products = products
            };
            //return Content(String.Format("PageIndex = {0}       sortBy={1}", pageIndex, sortBy))

            return View(ProductModel);
            ;
        }

        public ActionResult Details(int id)
        {
      

            var product = _context.Products.Include(t => t.ProductType).SingleOrDefault(c => c.Id == id);
            
            return View(product);

        }




        [Route("products/released/{year:regex(\\d{4})}/{month:range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {

            return Content(year + "/" + month);


        }


    }
}