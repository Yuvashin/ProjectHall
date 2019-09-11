using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectHall5.Startup))]
namespace ProjectHall5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
