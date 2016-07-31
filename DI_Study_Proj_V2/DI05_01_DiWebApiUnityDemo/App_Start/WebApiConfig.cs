using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using DI04_03_LayeredMvcDemo.Application;
using DI05_01_DiWebApiUnityDemo.Controllers;
using DI05_01_DiWebApiUnityDemo.Infrastructue;
using Microsoft.Practices.Unity;

namespace DI05_01_DiWebApiUnityDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            #region -- 設定DI 容器並註冊型別 --
            var container = new UnityContainer();
            container.RegisterType<CustomerController>();
            container.RegisterType<ICustomerService, CustomerService>();
            

            var myControllerActovator = new MyHttpControllerActivator(container);
            // 替換IHttpControllerActivator 實作
            // Services屬性,型別是ServicesContainer，用來記錄已註冊之服務
            config.Services.Replace(typeof(IHttpControllerActivator), myControllerActovator);
            #endregion


            var svc1 = config.Services.GetService(typeof(IHttpControllerActivator)) as MyHttpControllerActivator; 
            // GetService 回傳的型別是Object，須手動轉型。
            var svc2 = config.Services.GetHttpControllerActivator(); 
            // 效果同上，好處是無須轉型。

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );



        }
    }
}
