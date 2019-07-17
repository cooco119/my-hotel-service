using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyHotelService.Common.DbService.Models;
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
            var doc = MyDbManager.GetInstance().GetFromCollection<Hotel>("Name", name);
            var result = BsonSerializer.Deserialize<Hotel>(doc);

            return new ActionResult<IHotel>(result);
        }

        [HttpGet("Rooms/{number}")]
        public ActionResult<IRoom> GetRoom(string number)
        {
            var doc = MyDbManager.GetInstance().GetFromCollection<Room>("Number", number);
            var result = BsonSerializer.Deserialize<Room>(doc);

            return new ActionResult<IRoom>(result);
        }

        [HttpGet("User/{name}")]
        public ActionResult<IUser> GetUser(string name)
        {
            var doc = MyDbManager.GetInstance().GetFromCollection<User>("Name", name);
            var result = BsonSerializer.Deserialize<User>(doc);

            return new ActionResult<IUser>(result);
        }

        [HttpGet("Reservations/{code}")]
        public ActionResult<IReservation> GetReservation(string code)
        {
            var doc = MyDbManager.GetInstance().GetFromCollection<Reservation>("ReservationCode", code);
            var result = BsonSerializer.Deserialize<Reservation>(doc);

            return new ActionResult<IReservation>(result);
        }

        // POST api/values
        [HttpPost("Hotels")]
        public ActionResult<bool> PostHotel([FromBody] Hotel value)
        {
            return new ActionResult<bool>(MyDbManager.GetInstance().CreateInCollection<Hotel>(value));
        }

        [HttpPost("Rooms")]
        public ActionResult<bool> PostRoom([FromBody] Room value)
        {
            return new ActionResult<bool>(MyDbManager.GetInstance().CreateInCollection<Room>(value));
        }

        [HttpPost("Users")]
        public ActionResult<bool> PostUser([FromBody] User value)
        {
            return new ActionResult<bool>(MyDbManager.GetInstance().CreateInCollection<User>(value));
        }

        [HttpPost("Reservations")]
        public ActionResult<bool> PostRooms([FromBody] Reservation value)
        {
            return new ActionResult<bool>(MyDbManager.GetInstance().CreateInCollection<Reservation>(value));
        }
    }
}
