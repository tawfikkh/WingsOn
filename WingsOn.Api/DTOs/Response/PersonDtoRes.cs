using System;
using System.ComponentModel.DataAnnotations;

namespace WingsOn.Api.DTOs.Response
{
    public class PersonDtoRes
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateBirth { get; set; }

        [EnumDataType(typeof(GenderTypeDtoRes))]
        public GenderTypeDtoRes Gender { get; set; }

        public string Address { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
