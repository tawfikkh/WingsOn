using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Hosting;

[assembly: OwinStartup(typeof(WingsOn.Api.Startup))]

namespace WingsOn.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();

            AutofacConfig.Register(config, appBuilder);
            appBuilder.UseWebApi(config);

            appBuilder.Run(async context =>
            {
                context.Response.ContentType = "text/html";

                var filePath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "ascii.txt");

                string asciiText = null;
                using (var reader = File.OpenText(filePath))
                {
                    asciiText = await reader.ReadToEndAsync();
                }

                var swaggerLink = "check <a href=\"\\swagger\">/swagger</a> for the api documentation";

                await context.Response.WriteAsync(text: $"<pre>{asciiText}\n\n{swaggerLink}</pre>");
            });

            WebApiConfig.Register(config);
            SwaggerConfig.Register(config);
            AutoMapperConfig.Register();

            config.EnsureInitialized();
        }
    }
}
