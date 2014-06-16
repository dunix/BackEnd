using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoDiseño.Startup))]
namespace ProyectoDiseño
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
