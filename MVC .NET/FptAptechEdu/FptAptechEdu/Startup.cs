using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FptAptechEdu.Startup))]
namespace FptAptechEdu
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
