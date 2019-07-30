using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyHotelService.Common.DbService.Models;
using MyHotelService.Common.Utility;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using Newtonsoft.Json;

namespace MyHotelService.ReservationService.Models
{
    public class User : IUser
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement]
        public string Name { get; set; }

        [BsonElement]
        [JsonConverter(typeof(CustomJsonConverter<IReservation, Reservation>))]
        public IReservation Reservation { get; set; }

        [BsonElement]
        public DateTime RegistrationDateTime { get; set; }

        public User GetSerializable()
        {
            var result = new User();
            result.Name = Name;
            result.Reservation = Reservation != null ? ((Reservation) Reservation).GetSerializable() : null;
            result.RegistrationDateTime = RegistrationDateTime;

            return result;
        }

        public User()
        {

        }

        public User(IUser user)
        {
            Id = ObjectId.GenerateNewId().ToString();
            if (user == null)
            {
                return;
            }
            Name = user.Name ?? "";
            Reservation = user.Reservation != null ? new Reservation(user.Reservation) : new Reservation();
            RegistrationDateTime = user.RegistrationDateTime != null ? user.RegistrationDateTime : new DateTime();
        }
    }
}
