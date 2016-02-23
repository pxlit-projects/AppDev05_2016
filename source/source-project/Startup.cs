using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(source_project.Startup))]
namespace source_project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
