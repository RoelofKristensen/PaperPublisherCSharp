using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Prj_IPG521SA.Startup))]
namespace Prj_IPG521SA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
