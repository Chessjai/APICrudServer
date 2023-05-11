using APICrudClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace APICrudClient.Controllers
{
    public class CustomerController : Controller
    {
        private readonly APIGateway aPIGateway;
        public CustomerController(APIGateway aPIGateway)
        {
            this.aPIGateway = aPIGateway;
        }
        public IActionResult Index()
        {
            List<Customer> customers;
            customers = aPIGateway.ListCustomers();
            return View(customers);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Customer customer=new Customer();

            return View(customer);
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            aPIGateway.CreateCustomers(customer);

            return RedirectToAction("index");
        }
  
        public IActionResult Details(int id)
        {
            Customer customer=new Customer();
            customer=aPIGateway.GetCustomer(id);
            return View(customer);
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {

            Customer customer;
            customer=aPIGateway.GetCustomer(Id);

            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            aPIGateway.UpdateCustomer(customer);
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Customer customer;
            customer=aPIGateway.GetCustomer(Id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            aPIGateway.DeleteCustomer(customer.id);
            return RedirectToAction("index");
        }

    }
}
