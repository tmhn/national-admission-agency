using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Apollo.Startup))]
namespace Apollo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
