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
        private ICustomerService _customerService; //= new CustomerService();

        public CustomerController(ICustomerService srv)
        {
            this._customerService = srv;
        }
        
        public ActionResult Index()
        {
            var customers = _customerService.GetCustomerList(cust => cust.Id < 4);
            return View(customers);
        }
    }
}