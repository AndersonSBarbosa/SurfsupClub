using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ADMSurfsupClub.Startup))]
namespace ADMSurfsupClub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
