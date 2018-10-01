using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PhonebookManager.Web.Startup))]

namespace PhonebookManager.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}