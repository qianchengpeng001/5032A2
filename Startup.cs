using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_20S2_5032_A2_4.Startup))]
namespace _20S2_5032_A2_4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
