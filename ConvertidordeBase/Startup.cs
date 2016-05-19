using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConvertidordeBase.Startup))]
namespace ConvertidordeBase
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            //ConfigureAuth(app);
        }
    }
}
