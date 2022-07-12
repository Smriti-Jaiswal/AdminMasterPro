using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(admin_master_pro__mvc_.Startup))]
namespace admin_master_pro__mvc_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
