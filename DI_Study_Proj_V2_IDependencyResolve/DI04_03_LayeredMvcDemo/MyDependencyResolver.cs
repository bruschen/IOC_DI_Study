using DI04_03_LayeredMvcDemo.Application;
using DI04_03_LayeredMvcDemo.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DI04_03_LayeredMvcDemo
{
    public class MyDependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            //觀察MVC框架有哪些服務會透過dependency resolver來解析
            System.Diagnostics.Debug.WriteLine(serviceType.FullName);

            //解析特定controller
            if (serviceType == typeof(CustomerController))
            {
                var customerSvc = new CustomerService();
                var controller = new CustomerController(customerSvc);
                return controller;
            }

            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }
    }
}