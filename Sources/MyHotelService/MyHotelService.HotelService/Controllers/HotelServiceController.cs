using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyHotelService.Common.HotelService.Models;
using MyHotelService.HotelService.Services;

namespace MyHotelService.HotelService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelServiceController : ControllerBase
    {
        private readonly Services.HotelService _hotelservice;
        public HotelServiceController()
        {
            _hotelservice = new Services.HotelService();
        }

        [HttpGet("hotels/{name}")]
        public async Task<string> GetHotel(string name)
        {
            return await _hotelservice.GetHotelAsync(name);
        }

        [HttpGet("rooms/{number}")]
        public async Task<string> GetRoom(string number)
        {
            return await _hotelservice.GetRoomAsync(number);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
