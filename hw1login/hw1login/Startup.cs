using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(hw1login.Startup))]
namespace hw1login
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
