using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CARMASTERY.UI.Startup))]
namespace CARMASTERY.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
