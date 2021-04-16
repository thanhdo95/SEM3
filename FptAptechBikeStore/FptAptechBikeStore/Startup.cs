using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FptAptechBikeStore.Startup))]
namespace FptAptechBikeStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
