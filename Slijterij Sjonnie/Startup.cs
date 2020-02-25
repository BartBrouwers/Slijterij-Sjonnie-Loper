using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Slijterij_Sjonnie.Startup))]
namespace Slijterij_Sjonnie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
