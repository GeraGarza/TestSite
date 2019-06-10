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
    public class CustomersController : Controller
    {

        // GET: Customers

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }




        public ActionResult New()
        {


            var membershipTypes = _context.MembershipType.ToList();

            var viewModel = new CustomerFormViewModel
            {

                MembershipType = membershipTypes
        };

            return View("CustomerForm", viewModel);
        }





        [HttpPost]      // make sure it can only be called using post and not get
        public ActionResult Save(CustomerFormViewModel viewModel)
        {

            if (viewModel.Customer.Id == 0)
                _context.Customers.Add(viewModel.Customer);
            else{
                var customerInDb = _context.Customers.Single(c => c.Id == viewModel.Customer.Id);

                //TryUpdateModel(customerInDb) // not safe since user can change everything
                //mapper.map(customer,customerinDb);

                customerInDb.Name = viewModel.Customer.Name;
                customerInDb.MembershipTypeId = viewModel.Customer.MembershipTypeId;
                customerInDb.Id = viewModel.Customer.Id;
                customerInDb.isMember = viewModel.Customer.isMember;


            }



            _context.SaveChanges();


            return RedirectToAction("Index", "Customers");

        }
      


        public ActionResult Edit(int id)
        {


            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipType = _context.MembershipType.ToList()
            };


            return View("CustomerForm", viewModel);

        }

        public ActionResult Index()
        {

            //var customers = GetCustomers();
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            var customerViewModel = new CustomersViewModel
            {
                Customers = customers
            };




            return View(customerViewModel);
        }



        public ActionResult Details(int id)
        {


            var customer = _context.Customers.Include(c=> c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);

        }


    }
}