using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Simple.Startup))]
namespace Simple
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
