using DI04_03_LayeredMvcDemo.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DI04_03_LayeredMvcDemo.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService customerService; //= new CustomerService();

        public CustomerController(ICustomerService srv)
        {
            this.customerService = srv;
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = customerService.GetCustomerList(cust => cust.Id < 4);
            return View(customers);
        }
    }
}