using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyWebAppCodeFirst.Startup))]
namespace MyWebAppCodeFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
