using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;
using System.Collections.Generic;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomersController()
        {
            _context = ApplicationDbContext.Create();
        }

        //dispose this disposable context properly
        protected override void Dispose(bool disposing)
        {
            //base.Dispose(disposing);
            _context.Dispose();
        }

        [HttpGet]
        public ActionResult New()
        {            
            /** create dropdown for MembershipType */
            ICollection<MembershipType> membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes,
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerFormViewModel viewModel)
        {
            if (ModelState.IsValid == false)
            {
                var _viewModel = new CustomerFormViewModel { Customer = viewModel.Customer, MembershipTypes = _context.MembershipTypes.ToList() };
                return View("CustomerForm", _viewModel);
            }
            if (viewModel.Customer.Id == 0)
                _context.Customers.Add(viewModel.Customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == viewModel.Customer.Id);
                //This method is not advisable & opens security holes
                //TryUpdateModel(customerInDb, "", new string[] { "Name", "BirthDate" });

                customerInDb.Name = viewModel.Customer.Name;
                customerInDb.BirthDate = viewModel.Customer.BirthDate;
                customerInDb.MembershipTypeId = viewModel.Customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = viewModel.Customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        [Authorize]
        // GET: Customers
        public ActionResult Index()
        {
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            //return View(customers);
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id = 1)
        {
            #region            
            /*
            List<Customer> customer = new List<Customer>
            {
                new Customer {Name= "Joth", Id=1},
                new Customer {Name= "Mary Williams", Id=2}
            };
            
            return View(customer.Where(c => c.Id == id));           
            */
            //var customer = GetCustomers().Where(x=> x.Id == id);
            //var customer = GetCustomers().SingleOrDefault(c=> c.Id == id);
            #endregion
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
                if (customer == null)
                    RedirectToAction("Index");
                return View(customer);
            }
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
        /*
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith"},
                new Customer { Id = 2, Name = "Mary Williams"}
            };
        }
        */
    }
}