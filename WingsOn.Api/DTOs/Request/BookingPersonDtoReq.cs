using System;
using System.ComponentModel.DataAnnotations;
using WingsOn.Domain;

namespace WingsOn.Api.DTOs.Request
{
    public class BookingPersonDtoReq
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime? DateBirth { get; set; }

        [Required]
        [EnumDataType(typeof(GenderType))]
        public GenderType? Gender { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}