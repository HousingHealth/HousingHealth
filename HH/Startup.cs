using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HH.Startup))]
namespace HH
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
