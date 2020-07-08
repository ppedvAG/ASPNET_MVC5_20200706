using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Membership.Startup))]
namespace MVC_Membership
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
