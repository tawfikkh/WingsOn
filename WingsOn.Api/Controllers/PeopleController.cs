using AutoMapper;
using System.Web.Http;
using WingsOn.Api.DTOs.Request;
using WingsOn.Api.DTOs.Response;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.Api.Controllers
{
    [RoutePrefix("api/People")]
    public class PeopleController : BaseController
    {
        private readonly IRepository<Person> _repo;

        public PeopleController(IRepository<Person> repo)
        {
            _repo = repo;
        }

        // GET api/<controller>/5
        public IHttpActionResult GetPersonById(int id)
        {
            var person = _repo.Get(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PATCH api/<controller>/id
        [HttpPatch]
        public IHttpActionResult PatchPersonEmail(int id, [FromBody]PersonDtoReq model)
        {
            var person = _repo.Get(id);
            if (person == null)
            {
                return NotFound();
            }

            person.Email = model.Email;
            _repo.Save(person);

            PersonDtoRes response = Mapper.Map<PersonDtoRes>(person);
            return Ok(person);
        }
    }
}