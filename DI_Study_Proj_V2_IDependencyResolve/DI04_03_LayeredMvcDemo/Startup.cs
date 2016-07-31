using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DI04_03_LayeredMvcDemo.Startup))]
namespace DI04_03_LayeredMvcDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
