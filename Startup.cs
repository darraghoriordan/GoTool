using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoTool.Startup))]
namespace GoTool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
