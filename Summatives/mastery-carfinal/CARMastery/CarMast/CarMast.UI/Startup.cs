using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarMast.UI.Startup))]
namespace CarMast.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
