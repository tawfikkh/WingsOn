using NSwag.AspNet.Owin;
using Owin;

namespace WingsOn.Api
{
    public class SwaggerConfig
    {
        public static void Register(IAppBuilder appBuilder)
        {
            appBuilder.UseSwaggerUi3(typeof(Startup).Assembly, configure =>
            {
                configure.GeneratorSettings.Title = "WingsOn.Api";
            });
        }
    }
}
