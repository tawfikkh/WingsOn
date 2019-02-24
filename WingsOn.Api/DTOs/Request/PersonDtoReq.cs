using System.ComponentModel.DataAnnotations;

namespace WingsOn.Api.DTOs.Request
{
    public class PersonDtoReq
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}