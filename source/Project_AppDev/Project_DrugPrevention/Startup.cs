using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project_DrugPrevention.Startup))]
namespace Project_DrugPrevention
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
