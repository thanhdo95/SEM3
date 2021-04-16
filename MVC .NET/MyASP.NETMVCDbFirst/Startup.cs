using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyASP.NETMVCDbFirst.Startup))]
namespace MyASP.NETMVCDbFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
