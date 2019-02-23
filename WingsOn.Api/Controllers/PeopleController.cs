using System.Web.Http;
using WingsOn.Api.Models;
using WingsOn.Dal;
using WingsOn.Domain;

namespace WingsOn.Api.Controllers
{
    public class PeopleController : ApiController
    {
        private IRepository<Person> _repo;

        public PeopleController(IRepository<Person> repo)
        {
            _repo = repo;
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var person = _repo.Get(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PATCH api/<controller>/id
        public IHttpActionResult Patch(int id, PersonDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var person = _repo.Get(id);
            if (person == null)
            {
                return NotFound();
            }

            person.Email = model.Email;
            _repo.Save(person);

            return Ok(person);
        }
    }
}