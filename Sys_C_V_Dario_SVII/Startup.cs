using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sys_C_V_Dario_SVII.Startup))]
namespace Sys_C_V_Dario_SVII
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
