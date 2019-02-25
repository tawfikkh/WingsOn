using AutoMapper;
using WingsOn.Api.DTOs.Request;
using WingsOn.Api.DTOs.Response;
using WingsOn.Domain;

namespace WingsOn.Api
{
    public class AutoMapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Airline, AirlineDtoRes>();
                cfg.CreateMap<Airport, AirportDtoRes>();
                cfg.CreateMap<Booking, BookingDtoRes>();
                cfg.CreateMap<Flight, FlightDtoRes>();
                cfg.CreateMap<Person, PersonDtoRes>();
                cfg.CreateMap<BookingPersonDtoReq, Person>();
            });
        }
    }
}