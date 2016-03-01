using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(hasselt_events.Startup))]
namespace hasselt_events
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
