using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GigueService.Startup))]

namespace GigueService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}