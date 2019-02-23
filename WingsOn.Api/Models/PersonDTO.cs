using System.ComponentModel.DataAnnotations;

namespace WingsOn.Api.Models
{
    public class PersonDTO
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}