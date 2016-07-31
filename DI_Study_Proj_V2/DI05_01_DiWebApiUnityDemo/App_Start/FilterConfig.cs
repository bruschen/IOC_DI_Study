using System.Web;
using System.Web.Mvc;

namespace DI05_01_DiWebApiUnityDemo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
