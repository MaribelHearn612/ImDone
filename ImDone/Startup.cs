using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImDone.Startup))]
namespace ImDone
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
