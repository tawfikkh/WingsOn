using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Owin;
using WingsOn.Api.Filters;

namespace WingsOn.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config, IAppBuilder appBuilder)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            // Web API configuration and services
            config.Filters.Add(new AuditFilterAttribute());
            config.Filters.Add(new ValidateModelAttribute());
            config.Filters.Add(new CustomExceptionFilterAttribute());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // send property names as camel case
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            appBuilder.UseWebApi(config);
        }
    }
}
