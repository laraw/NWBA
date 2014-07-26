using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NWBA.Startup))]
namespace NWBA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
