using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RADCommandSuite.Startup))]
namespace RADCommandSuite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
