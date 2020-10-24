using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Happystore.Startup))]
namespace Happystore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
