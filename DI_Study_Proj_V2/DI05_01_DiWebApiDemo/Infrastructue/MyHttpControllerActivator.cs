using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using DI04_03_LayeredMvcDemo.Application;
using DI05_01_DiWebApiDemo.Controllers;

namespace DI05_01_DiWebApiDemo.Infrastructue
{
    public class MyHttpControllerActivator: IHttpControllerActivator
    {
        public IHttpController Create(HttpRequestMessage request, 
            HttpControllerDescriptor controllerDescriptor, 
            Type controllerType)
        {
            if (controllerType == typeof(CustomerController))
            {
                ////create depandence object
                var customerSrv= new CustomerService();

                ////傳遞額外物件
                request.Properties.Add("Time", DateTime.Now);

                ////建立controller並注入物件
                return  new CustomerController(customerSrv);
            }

            return null;
        }
    }
}