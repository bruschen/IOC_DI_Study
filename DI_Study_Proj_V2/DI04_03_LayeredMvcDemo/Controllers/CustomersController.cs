using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DI04_03_LayeredMvcDemo.Application;
using DI04_03_LayeredMvcDemo.Domain.Models;

namespace DI04_03_LayeredMvcDemo.Controllers
{
    public class CustomersController : ApiController
    {
        private ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        public Customer Get(int id)
        {
            return _customerService.GetCustomerById(id);
        }

    }
}
