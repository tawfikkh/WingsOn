using AutoMapper;
using System.Web.Http;
using WingsOn.Api.DTOs.Request;
using WingsOn.Api.DTOs.Response;
using WingsOn.Dal;
using WingsOn.Domain;
using System.Linq;
using System.Collections.Generic;

namespace WingsOn.Api.Controllers
{
    [RoutePrefix("api/People")]
    public class PeopleController : BaseController
    {
        private readonly IRepository<Person> _personRepo;
        private readonly IRepository<Booking> _bookingRepo;

        public PeopleController(IRepository<Person> personRepo, IRepository<Booking> bookingRepo)
        {
            _personRepo = personRepo;
            _bookingRepo = bookingRepo;
        }

        // GET api/<controller>/5
        public IHttpActionResult GetPersonById(int id)
        {
            var person = _personRepo.Get(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [Route("MalePassengers")]
        public IHttpActionResult GetAllMalePassengers()
        {
            var passengers = _bookingRepo
                .GetAll()
                .SelectMany(b => b.Passengers.Where(p => p.Gender == GenderType.Male));

            var result = Mapper.Map<IEnumerable<PersonDtoRes>>(passengers);
            return Ok(result);
        }

        // PATCH api/<controller>/id
        [HttpPatch]
        public IHttpActionResult PatchPersonEmail(int id, [FromBody]PersonDtoReq model)
        {
            var person = _personRepo.Get(id);
            if (person == null)
            {
                return NotFound();
            }

            person.Email = model.Email;
            _personRepo.Save(person);

            PersonDtoRes response = Mapper.Map<PersonDtoRes>(person);
            return Ok(person);
        }
    }
}