using System.ComponentModel.DataAnnotations;

namespace WingsOn.Api.DTOs.Request
{
    public class BookingDtoReq
    {
        [Required]
        public BookingPersonDtoReq Person { get; set; }

        [Required]
        public BookingDetailsDtoReq BookingDetails { get; set; }
    }
}
