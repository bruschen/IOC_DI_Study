using DI04_03_LayeredMvcDemo.Controllers;
using DI04_03_LayeredMvcDemo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DI04_03_LayeredMvcDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            HttpContext.Current.Items["DbContext"] = new SouthwindContext();

            // 把MVC 框架的預設controller factory 換掉。
            var ctrlFactory = new MyControllerFactory();
            ControllerBuilder.Current.SetControllerFactory(ctrlFactory);
        }

        protected void Application_EndRequest()
        {
            var db = HttpContext.Current.Items["DbContext"] as SouthwindContext;
            if (db != null)
            {
                db.Dispose();
            }
        }
    }
}
