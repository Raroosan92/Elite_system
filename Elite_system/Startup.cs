using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Elite_system.Startup))]
namespace Elite_system
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
