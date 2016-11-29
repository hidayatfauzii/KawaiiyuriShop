using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudycaseRPL.Startup))]
namespace StudycaseRPL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
