using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CommunityNetPortoAngular.Startup))]
namespace CommunityNetPortoAngular
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
