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
    public class CabController : ControllerBase
    {
        private readonly ICabTypeService _cabTypeService;

        public CabController(ICabTypeService cabTypeService)
        {
            _cabTypeService = cabTypeService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllCabTypes()
        {
            var types = await _cabTypeService.GetAllCabTypes();
            if (types == null)
                return NotFound("No Type Founded!");
            return Ok(types);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteCabTypeById([FromRoute] int id)
        {
            try
            {
                var delete = await _cabTypeService.DeleteCabTypeById(id);
                if (delete == null)
                    return NotFound("Id Not Found!");
                return Ok(delete);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Delete Failed Because Foreign Key Constraints");
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateCabType([FromBody] CabTypeCreateRequestModel type)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var createdType = await _cabTypeService.AddCabType(type);
            if (createdType == null)
                return StatusCode(500);
            return Ok(createdType);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateCabType([FromBody] CabTypeUpdateRequestModel type)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var updatedType = await _cabTypeService.UpdateCabType(type);
            if (updatedType == null)
                return StatusCode(500);
            return Ok(updatedType);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCabTypeById([FromRoute] int id)
        {
            var type = await _cabTypeService.GetCabTypeById(id);
            if (type == null)
                return NotFound();
            return Ok(type);
        }
    }
}
