using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dot_not.Startup))]
namespace dot_not
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}