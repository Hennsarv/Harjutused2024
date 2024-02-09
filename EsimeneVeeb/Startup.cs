using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EsimeneVeeb.Startup))]
namespace EsimeneVeeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
