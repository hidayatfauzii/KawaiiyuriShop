using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ElfsLeatherStore.Startup))]
namespace ElfsLeatherStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
