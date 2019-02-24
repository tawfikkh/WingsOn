using System.Web.Http;

namespace WingsOn.Api.Controllers
{
    [RoutePrefix("api/[controller]/{id:int?}")]
    public class BaseController : ApiController
    {
    }
}
