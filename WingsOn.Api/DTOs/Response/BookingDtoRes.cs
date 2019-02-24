using System;
using System.Collections.Generic;

namespace WingsOn.Api.DTOs.Response
{
    public class BookingDtoRes
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public FlightDtoRes Flight { get; set; }

        public PersonDtoRes Customer { get; set; }

        public IEnumerable<PersonDtoRes> Passengers { get; set; }

        public DateTime DateBooking { get; set; }
    }
}
