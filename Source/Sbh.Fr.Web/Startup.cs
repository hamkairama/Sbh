using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sbh.Fr.Web.Startup))]
namespace Sbh.Fr.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
