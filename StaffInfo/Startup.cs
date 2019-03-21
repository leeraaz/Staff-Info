using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StaffInfo.Startup))]
namespace StaffInfo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
