using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(websiteConNhaNong.Startup))]
namespace websiteConNhaNong
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
