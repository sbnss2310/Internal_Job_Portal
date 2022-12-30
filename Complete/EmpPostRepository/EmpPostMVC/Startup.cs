using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmpPostMVC.Startup))]
namespace EmpPostMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
