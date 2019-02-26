using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using NSwag;
using WingsOn.Api.DTOs.Request;
using WingsOn.Api.DTOs.Response;
using WingsOn.Dal;
using WingsOn.Domain;
using NSwag.Annotations;

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

        /// <summary>
        /// get person details by his id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetPersonById(int id)
        {
            var person = _personRepo.Get(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        /// <summary>
        /// get all people with bookings by gender
        /// </summary>
        /// <param name="gender">defaults to Male</param>
        /// <returns></returns>
        [Route("Passengers/{gender:int=1}")]
        [SwaggerResponse("200", typeof(IEnumerable<PersonDtoRes>))]
        public IHttpActionResult GetAllMalePassengers(GenderType gender)
        {
            var passengers = _bookingRepo
                .GetAll()
                .SelectMany(b => b.Passengers.Where(p => p.Gender == gender));

            var result = Mapper.Map<IEnumerable<PersonDtoRes>>(passengers);
            return Ok(result);
        }

        /// <summary>
        /// update a person email address
        /// </summary>
        /// <param name="id">Person Id</param>
        /// <param name="model">Email address field; read from request body, use x-www-form-urlencoded or application/json as Content-Type header</param>
        /// <returns></returns>
        [HttpPatch]
        [SwaggerResponse("200", typeof(PersonDtoRes))]
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