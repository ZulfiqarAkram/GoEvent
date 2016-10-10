using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoEvent.Startup))]
namespace GoEvent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
