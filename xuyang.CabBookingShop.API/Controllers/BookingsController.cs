using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xuyang.CabBookingShop.Core.Models.Request;
using xuyang.CabBookingShop.Core.ServiceInterfaces;

namespace xuyang.CabBookingShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookings();
            if (bookings == null)
                return NotFound();
            return Ok(bookings);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteBookingById([FromRoute] int id)
        {
            var deleted = await _bookingService.DeleteBookingById(id);
            if (deleted == null)
                return NotFound();
            return Ok(deleted);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateBooking([FromBody] BookingCreateRequestModel booking)
        {
            var createdBooking = await _bookingService.AddBooking(booking);
            if (createdBooking == null)
                return StatusCode(500);
            return Ok(createdBooking);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateBooking([FromBody] BookingUpdateRequestModel booking)
        {
            var updatedBooking = await _bookingService.UpdateBooking(booking);
            if (updatedBooking == null)
                return StatusCode(500);
            return Ok(updatedBooking);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetBookingById([FromRoute] int id)
        {
            var booking = await _bookingService.GetBookingById(id);
            if (booking == null)
                return NotFound();
            return Ok(booking);
        }
    }
}
