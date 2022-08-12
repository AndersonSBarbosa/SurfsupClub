using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SurfsUpClubVer2.Startup))]
namespace SurfsUpClubVer2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
