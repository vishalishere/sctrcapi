using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SCTRC.Startup))]
namespace SCTRC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
