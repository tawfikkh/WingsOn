using Swashbuckle.Application;
using System.Web.Http;

namespace WingsOn.Api
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "WingsOn.Api");
                    c.DescribeAllEnumsAsStrings();
                    //c.IncludeXmlComments(string.Format(@"{0}\bin\SwaggerDemoApi.XML", System.AppDomain.CurrentDomain.BaseDirectory));
                })
                .EnableSwaggerUi();
        }
    }
}
