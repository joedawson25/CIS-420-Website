using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CIS420NewWebsite.Startup))]
namespace CIS420NewWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
