using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DI05_01_DiWebApiUnityDemo.Startup))]
namespace DI05_01_DiWebApiUnityDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
