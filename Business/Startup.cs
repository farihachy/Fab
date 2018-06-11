using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Business.App_Start.Startup))]
namespace Business.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}