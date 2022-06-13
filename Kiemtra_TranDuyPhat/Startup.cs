using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kiemtra_TranDuyPhat.Startup))]
namespace Kiemtra_TranDuyPhat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
