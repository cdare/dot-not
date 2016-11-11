using Microsoft.Owin;
using Owin;
using System.Web;
using System.IO;
using Microsoft.Owin.Extensions;

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