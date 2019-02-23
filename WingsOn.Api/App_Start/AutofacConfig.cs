using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.Api
{
    public static class AutofacConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<AirlineRepository>().As<IRepository<Airline>>().AsImplementedInterfaces();
            builder.RegisterType<AirportRepository>().As<IRepository<Airport>>().AsImplementedInterfaces();
            builder.RegisterType<BookingRepository>().As<IRepository<Booking>>().InstancePerLifetimeScope();
            builder.RegisterType<FlightRepository>().As<IRepository<Flight>>().AsImplementedInterfaces();
            builder.RegisterType<PersonRepository>().As<IRepository<Person>>().AsImplementedInterfaces();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}