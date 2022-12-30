using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JobPostMVC.Startup))]
namespace JobPostMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
