using System;
using System.Linq;
using System.Web.Http;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.Api.Controllers
{
    public class FlightsController : ApiController
    {
        IRepository<Booking> _repo;

        public FlightsController(IRepository<Booking> repo)
        {
            _repo = repo;
        }

        [Route("{flightNumber}/passengers")]
        public IHttpActionResult GetFlightPassengers(string flightNumber)
        {
            var bookings = _repo.GetAll().Where(b => string.Equals(
                b.Flight?.Number,
                flightNumber,
                StringComparison.OrdinalIgnoreCase)
                );

            if (bookings == null)
            {
                return NotFound();
            }

            return Ok(bookings.Select(b => b.Customer));
        }
    }
}