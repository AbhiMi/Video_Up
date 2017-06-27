using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoUpTiles.Startup))]
namespace VideoUpTiles
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
