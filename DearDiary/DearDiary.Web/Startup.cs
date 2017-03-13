using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DearDiary.Web.Startup))]
namespace DearDiary.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
