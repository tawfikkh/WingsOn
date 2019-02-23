using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(WingsOn.Api.Startup))]

namespace WingsOn.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();

            appBuilder.UseWebApi(config);

            WebApiConfig.Register(config);
            AutofacConfig.Register(config);
        }
    }
}
