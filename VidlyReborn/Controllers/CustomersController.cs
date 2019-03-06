using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using VidlyReborn.Models;
using VidlyReborn.ViewModels;

namespace VidlyReborn.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Include(m => m.MembershipType).SingleOrDefault(c => c.Id == id);
            var vm = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", vm);
        }

        public ActionResult New()
        {
            var vm = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm",vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var vm = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", vm);
            }

            if(customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDn = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDn.Name = customer.Name;
                customerInDn.BirthDay = customer.BirthDay;
                customerInDn.MembershipTypeId = customer.MembershipTypeId;
                customerInDn.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}