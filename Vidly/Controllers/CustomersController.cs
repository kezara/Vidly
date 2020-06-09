using Antlr.Runtime.Misc;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
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

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipType = customer.MembershipType;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        // GET: Customers
        public ActionResult Index()
        {
            //when no .ToList() Entity Framework will not query database, it is called deffered execution
            //query is actualy executed when iterate over cutoers object
            //with .ToList() EF will emidiately query the database
            //we do not need this anymore, because we render data from our API
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            //return View(customers);
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(x => x.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        //private IEnumerable<Customer> GetCustomers()
        //{
        //    var customers = new List<Customer>
        //    {
        //        new Customer {Name = "John Smith", Id = 1},
        //        new Customer {Name = "Mary Williams", Id = 2}
        //    };

        //    return customers;
        //}
    }
}