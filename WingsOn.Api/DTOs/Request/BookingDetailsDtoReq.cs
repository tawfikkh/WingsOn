using System;
using System.ComponentModel.DataAnnotations;

namespace WingsOn.Api.DTOs.Request
{
    public class BookingDetailsDtoReq
    {
        [Required]
        public string FlightNumber { get; set; }

        [Required]
        public DateTime? DateBooking { get; set; }
    }
}