using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HCI_Project.Startup))]
namespace HCI_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
