using DI04_03_LayeredMvcDemo.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DI04_03_LayeredMvcDemo.Controllers
{
    public class OrderController: Controller
    {
        private IOrderService orderService; 

        public OrderController(IOrderService srv)
        {
            this.orderService = srv;
        }
    }
}