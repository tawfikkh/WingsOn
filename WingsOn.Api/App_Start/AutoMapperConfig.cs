using AutoMapper;
using WingsOn.Api.DTOs.Response;
using WingsOn.Domain;

namespace WingsOn.Api
{
    public class AutoMapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Airline, AirlineDto>();
                cfg.CreateMap<Airport, AirportDto>();
                cfg.CreateMap<Booking, BookingDto>();
                cfg.CreateMap<Flight, FlightDto>();
                cfg.CreateMap<GenderType, GenderTypeDto>();
                cfg.CreateMap<Person, PersonDto>();
            });
        }
    }
}