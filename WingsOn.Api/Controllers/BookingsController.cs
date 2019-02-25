using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using WingsOn.Api.DTOs.Request;
using WingsOn.Api.DTOs.Response;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.Api.Controllers
{
    [RoutePrefix("api/Bookings")]
    public class BookingsController : BaseController
    {
        private readonly IRepository<Flight> _flightRepository;
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<Booking> _bookingRepository;

        public BookingsController(
            IRepository<Flight> flightRepository,
            IRepository<Person> personRepository,
            IRepository<Booking> bookingRepository)
        {
            _flightRepository = flightRepository;
            _personRepository = personRepository;
            _bookingRepository = bookingRepository;
        }

        // POST api/<controller>
        public IHttpActionResult PostCreateBookingForNewCustomer([FromBody] BookingDtoReq model)
        {
            var flight = _flightRepository.GetAll().FirstOrDefault(f => string.Equals(
                f.Number,
                model.BookingDetails?.FlightNumber,
                StringComparison.OrdinalIgnoreCase));

            if (flight == null)
            {
                return NotFound();
            }

            var person = Mapper.Map<Person>(model.Person);
            person.Id = 0; // will be auto generate
            _personRepository.Save(person);

            Debug.Assert(model.BookingDetails.DateBooking != null, "model.BookingDetails.DateBooking != null");

            var booking = new Booking()
            {
                Id = _bookingRepository.GetAll().Max(b => b.Id) + 1,
                Customer = person,
                DateBooking = model.BookingDetails.DateBooking.Value,
                Flight = flight,
                Number = null, // will be autogenerate
                Passengers = new[] { person }
            };

            _bookingRepository.Save(booking);

            var response = Mapper.Map<BookingDtoRes>(booking);
            return CreatedAtRoute("GetBooking", new { bookingNumber = response.Number }, response);
        }

        [HttpGet]
        [Route("{bookingNumber}", Name = "GetBooking")]
        public IHttpActionResult GetBooking(string bookingNumber)
        {
            var booking = _bookingRepository.GetAll().FirstOrDefault(b => string.Equals(
                b.Number,
                bookingNumber,
                StringComparison.OrdinalIgnoreCase));

            if (booking == null)
            {
                return NotFound();
            }

            var response = Mapper.Map<BookingDtoRes>(booking);
            return Ok(response);
        }
    }
}