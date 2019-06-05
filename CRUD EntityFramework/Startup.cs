using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRUD_EntityFramework.Startup))]
namespace CRUD_EntityFramework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
