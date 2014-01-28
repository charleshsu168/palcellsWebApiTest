using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApplication16.Startup))]
namespace WebApplication16
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
