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
    public class BookingHistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;
        public BookingHistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllBookingHistories()
        {
            var histories = await _historyService.GetAllBookingHistories();
            if (histories == null)
                return NotFound();
            return Ok(histories);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteHistoryById([FromRoute] int id)
        {
            var deleted = await _historyService.DeleteHistoryById(id);
            if (deleted == null)
                return NotFound();
            return Ok(deleted);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateHistory([FromBody] HistoryCreateRequestModel history)
        {
            var createdHistory = await _historyService.AddHistory(history);
            if (createdHistory == null)
                return StatusCode(500);
            return Ok(createdHistory);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateHistory([FromBody] HistoryUpdateRequestModel history)
        {
            var updatedHistory = await _historyService.UpdateHistory(history);
            if (updatedHistory == null)
                return StatusCode(500);
            return Ok(updatedHistory);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetBookingHistoryById([FromRoute] int id)
        {
            var history = await _historyService.GetHistoryById(id);
            if (history == null)
                return NotFound();
            return Ok(history);
        }
    }
}
