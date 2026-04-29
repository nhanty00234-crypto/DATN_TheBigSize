using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBookings()
        {
            // Get all bookings from service
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingRequest request)
        {
            // Create new booking
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            // Get booking by id
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromBody] UpdateBookingRequest request)
        {
            // Update booking
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            // Delete booking
            return Ok();
        }
    }

    public class CreateBookingRequest
    {
        public int SanId { get; set; }
        public System.DateTime BookingDate { get; set; }
        public System.TimeSpan StartTime { get; set; }
    }

    public class UpdateBookingRequest
    {
        public System.DateTime BookingDate { get; set; }
        public System.TimeSpan StartTime { get; set; }
    }
}
