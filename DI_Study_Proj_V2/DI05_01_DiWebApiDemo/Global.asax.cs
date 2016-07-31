using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DI05_01_DiWebApiDemo.Infrastructue;

namespace DI05_01_DiWebApiDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //設定webapi的工作委派給另一個函式
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var myControllerActivator = new MyHttpControllerActivator();
            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator), myControllerActivator);

        }
    }
}
