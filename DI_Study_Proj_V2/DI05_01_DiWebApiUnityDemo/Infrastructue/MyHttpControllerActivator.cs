using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Microsoft.Practices.Unity;

namespace DI05_01_DiWebApiUnityDemo.Infrastructue
{
    public class MyHttpControllerActivator:IHttpControllerActivator
    {
        private IUnityContainer _container;

        public MyHttpControllerActivator(IUnityContainer container)
        {
            this._container = container;
        }

        public IHttpController Create(HttpRequestMessage request, 
            HttpControllerDescriptor controllerDescriptor, 
            Type controllerType)
        {
            var controller = _container.Resolve(controllerType);
            return controller as IHttpController;
        }
    }
}