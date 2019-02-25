using System;
using System.ComponentModel.DataAnnotations;
using WingsOn.Domain;

namespace WingsOn.Api.DTOs.Response
{
    public class PersonDtoRes
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateBirth { get; set; }

        [EnumDataType(typeof(GenderType))]
        public GenderType Gender { get; set; }

        public string Address { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
