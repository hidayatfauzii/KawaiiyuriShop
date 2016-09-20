using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kawaiisgop.Startup))]
namespace Kawaiisgop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
