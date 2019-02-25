using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using Owin;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.Api
{
    public static class AutofacConfig
    {
        public static void Register(HttpConfiguration config, IAppBuilder appBuilder)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<AirlineRepository>().As<IRepository<Airline>>().SingleInstance();
            builder.RegisterType<AirportRepository>().As<IRepository<Airport>>().SingleInstance();
            builder.RegisterType<CustomBookingRepository>().As<IRepository<Booking>>().SingleInstance();
            builder.RegisterType<FlightRepository>().As<IRepository<Flight>>().SingleInstance();
            builder.RegisterType<CustomPersonRepository>().As<IRepository<Person>>().SingleInstance();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Register the Autofac middleware FIRST, then the Autofac Web API middleware
            appBuilder.UseAutofacMiddleware(container);
            appBuilder.UseAutofacWebApi(config);
        }
    }
}