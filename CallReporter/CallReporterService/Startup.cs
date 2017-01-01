using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CallReporterService.Startup))]

namespace CallReporterService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}