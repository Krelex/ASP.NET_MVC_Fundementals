using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(projekt_13_1_vj.Startup))]
namespace projekt_13_1_vj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
