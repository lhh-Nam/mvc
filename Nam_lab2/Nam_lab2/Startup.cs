using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nam_lab2.Startup))]
namespace Nam_lab2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
