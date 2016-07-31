using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DI05_01_DiWebApiDemo.Startup))]
namespace DI05_01_DiWebApiDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
