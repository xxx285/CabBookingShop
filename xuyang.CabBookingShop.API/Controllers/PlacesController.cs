using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class PlacesController : ControllerBase
    {
        private readonly IPlaceService _placeService;
        public PlacesController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllPlaces()
        {
            var places = await _placeService.GetAllPlaces();
            if (places == null)
                return NotFound();
            return Ok(places);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreatePlace([FromBody] PlaceCreateRequestModel place)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var createdPlace = await _placeService.AddPlace(place);
            if (createdPlace == null)
                return StatusCode(500);
            return Ok(createdPlace);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeletePlaceById([FromRoute] int id)
        {
            try
            {
                var delete = await _placeService.DeletePlaceById(id);
                if (delete == null)
                    return NotFound("Id Not Found!");
                return Ok(delete);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Delete Failed Because Foreign Key Constraints");
            }
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdatePlace([FromBody] PlaceUpdateRequestModel place)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var updatedPlace = await _placeService.UpdatePlace(place);
            if (updatedPlace == null)
                return StatusCode(500);
            return Ok(updatedPlace);
        }
    }
}
