using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCPracticalTest.Startup))]
namespace MVCPracticalTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
