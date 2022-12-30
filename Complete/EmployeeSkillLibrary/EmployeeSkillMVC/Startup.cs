using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeSkillMVC.Startup))]
namespace EmployeeSkillMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
