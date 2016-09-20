using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleEcommerce.Startup))]
namespace SimpleEcommerce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
