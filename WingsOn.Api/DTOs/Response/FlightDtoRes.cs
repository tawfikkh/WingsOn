using System;

namespace WingsOn.Api.DTOs.Response
{
    public class FlightDtoRes
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public AirlineDtoRes Carrier { get; set; }

        public AirportDtoRes DepartureAirport { get; set; }

        public DateTime DepartureDate { get; set; }

        public AirportDtoRes ArrivalAirport { get; set; }

        public DateTime ArrivalDate { get; set; }

        public decimal Price { get; set; }
    }
}
