using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyHotelService.DbService.RedisStore;
using MyHotelService.HotelService.Models;
using Newtonsoft.Json;

namespace MyHotelService.DbService.Controllers
{
    [Route("api")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("hotels/{id}")]
        public ActionResult<string> GetHotel(int id)
        {
            var redis = RedisStore.RedisStore.RedisCache;
            var hotels = JsonConvert.DeserializeObject(redis.StringGet("hotels"));

            return hotels[id];
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
