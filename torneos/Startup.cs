using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(torneos.Startup))]
namespace torneos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
