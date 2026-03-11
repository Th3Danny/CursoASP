using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CursoASPAjax.Startup))]
namespace CursoASPAjax
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
