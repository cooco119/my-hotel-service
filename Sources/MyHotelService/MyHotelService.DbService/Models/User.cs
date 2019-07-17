using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyHotelService.Common.HotelService.Models;
using MyHotelService.Common.Utility;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using Newtonsoft.Json;

namespace MyHotelService.DbService.Models
{
    public class User : IUser
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement]
        public string Name { get; set; }

        [BsonElement]
        [JsonConverter(typeof(CustomJsonConverter<IReservation, Reservation>))]
        public IReservation Reservation { get; set; }

        [BsonElement]
        public DateTime RegistrationDateTime { get; set; }

        public User()
        {

        }

        public User(IUser user)
        {
            Name = user.Name ?? "";
            Reservation = user.Reservation != null ? new Reservation(user.Reservation) : new Reservation();
            RegistrationDateTime = user.RegistrationDateTime != null ? user.RegistrationDateTime : new DateTime();
        }
    }
}
