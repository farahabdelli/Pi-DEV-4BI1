using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(projetPIWeb.Startup))]
namespace projetPIWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
