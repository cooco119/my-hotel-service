using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyHotelService.Common.HotelService.Models;
using MyHotelService.Common.DbService.Controllers;
using MyHotelService.DbService.DbManager;
using MyHotelService.DbService.Models;
using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace MyHotelService.DbService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbController : ControllerBase
    {
        [HttpGet("Hotels/{name}")]
        public ActionResult<IHotel> GetHotel(string name)
        {
            var doc = MyDbManager.GetInstance().GetFromCollection("hotels", "Name", name);
            var result = BsonSerializer.Deserialize<Hotel>(doc);

            return new ActionResult<IHotel>(result);
        }

        [HttpGet("Rooms/{number}")]
        public ActionResult<IRoom> GetRoom(string number)
        {
            var doc = MyDbManager.GetInstance().GetFromCollection("rooms", "Number", number);
            var result = BsonSerializer.Deserialize<Room>(doc);

            return new ActionResult<IRoom>(result);
        }

        // POST api/values
        [HttpPost("Hotels")]
        public void PostHotel([FromBody] Hotel value)
        {
            MyDbManager.GetInstance().CreateInCollection<Hotel>("hotels", value as Hotel);
        }

        [HttpPost("Rooms")]
        public void PostRooms([FromBody] Room value)
        {
            MyDbManager.GetInstance().CreateInCollection<Room>("rooms", value as Room);
        }
    }
}
