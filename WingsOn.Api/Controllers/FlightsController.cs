using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WingsOn.Api.DTOs.Response;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.Api.Controllers
{
    [RoutePrefix("api/Flights")]
    public class FlightsController : BaseController
    {
        private readonly IRepository<Booking> _bookingRepo;
        private readonly IRepository<Flight> _flightRepo;

        public FlightsController(IRepository<Booking> bookingRepo, IRepository<Flight> flightRepo)
        {
            _bookingRepo = bookingRepo;
            _flightRepo = flightRepo;
        }

        [HttpGet]
        [Route("{flightNumber}/passengers")]
        public IHttpActionResult GetFlightPassengers(string flightNumber)
        {
            var flight = _flightRepo.GetAll().FirstOrDefault(f => string.Equals(
                f.Number,
                flightNumber,
                StringComparison.OrdinalIgnoreCase)
                );

            if (flight == null)
            {
                return NotFound();
            }

            var bookings = _bookingRepo.GetAll().Where(b => string.Equals(
                b.Flight?.Number,
                flightNumber,
                StringComparison.OrdinalIgnoreCase)
                );

            var passengers = bookings.Select(b => b.Customer);

            IEnumerable<PersonDtoRes> response = Mapper.Map<IEnumerable<PersonDtoRes>>(passengers);
            return Ok(response);
        }
    }
}