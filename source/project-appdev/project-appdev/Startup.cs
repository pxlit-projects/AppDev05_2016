using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(project_appdev.Startup))]
namespace project_appdev
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
