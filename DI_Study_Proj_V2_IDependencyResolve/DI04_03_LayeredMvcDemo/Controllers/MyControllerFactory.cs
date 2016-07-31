using DI04_03_LayeredMvcDemo.Application;
using DI04_03_LayeredMvcDemo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DI04_03_LayeredMvcDemo.Controllers
{
    public class MyControllerFactory: System.Web.Mvc.DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (controllerName == "Customer")
            {
                // 建立相依物件並注入至新建立的controller。
                var repository = new CustomerRepository();
                var service = new CustomerService(repository);
                var controller = new CustomerController(service);
                return controller;
            }
            else if (controllerName == "Order")
            {
                var orderRepository = new OrderRepository();
                var customerRepository = new CustomerRepository();
                var productRepository = new ProductRepository();

                var service = new OrderService(orderRepository, customerRepository, productRepository);
                var controller = new OrderController(service);

                return controller;
            }
            else
            {
                // 其他不需要特殊處理的controller 型別就使用MVC 內建的工廠來建立。
                return base.CreateController(requestContext, controllerName);
            }
            
        }
        public override void ReleaseController(IController controller)
        {
            // 如果需要釋放其他物件資源，可寫在這裡。
            base.ReleaseController(controller);
        }
    }
}