using Microsoft.Owin;
using Owin;
using System.IO;
using System.Web.Hosting;
using System.Web.Http;

[assembly: OwinStartup(typeof(WingsOn.Api.Startup))]

namespace WingsOn.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();

            SwaggerConfig.Register(appBuilder);
            AutofacConfig.Register(config, appBuilder);
            WebApiConfig.Register(config, appBuilder);
            AutoMapperConfig.Register();

            appBuilder.Use(async (context, next) =>
            {
                if (context.Request.Path.Value == "/")
                {
                    context.Response.ContentType = "text/html";

                    var filePath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "ascii.txt");

                    string asciiText = null;
                    using (var reader = File.OpenText(filePath))
                    {
                        asciiText = await reader.ReadToEndAsync();
                    }

                    var swaggerLink = "check <a href=\"/swagger\">/swagger</a> for the api documentation";

                    await context.Response.WriteAsync(text: $"<pre>{asciiText}\n\n{swaggerLink}</pre>");
                }
                else
                {
                    await next();
                }
            });

            config.EnsureInitialized();
        }
    }
}
