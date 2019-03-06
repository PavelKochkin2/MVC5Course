using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyReborn.Startup))]
namespace VidlyReborn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
