using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCPracticeProject.Startup))]
namespace MVCPracticeProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
