using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(com.terriblecode.ui.Startup))]
namespace com.terriblecode.ui
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
