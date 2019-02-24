using System.Web.Http;
using WingsOn.Api.DTOs;
using WingsOn.Api.DTOs.Response;

namespace WingsOn.Api.Controllers
{
    public class BookingsController : BaseController
    {
        // POST api/<controller>
        public void PostCreateBookingForNewCustomer([FromBody] BookingDto model)
        {
        }
    }
}