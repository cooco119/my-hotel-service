using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MyHotelService.Common.DbService.Models;
using MyHotelService.Common.Utility;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using Newtonsoft.Json;

namespace MyHotelService.ReservationService.Models
{
    public class Hotel : IHotel
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement]
        public string Name { get; set; }

        [BsonElement]
        public DateTime BuiltDateTime { get; set; }

        [BsonElement]
        [JsonConverter(typeof(CustomJsonConverter<IRoom, Room>))]
        public IRoom Room { get; set; }
        [BsonElement]
        [JsonIgnore]
        [JsonConverter(typeof(CustomJsonConverter<List<IRoom>, List<Room>>))]
        public List<IRoom> Rooms { get; set; }

        public Hotel GetSerializable()
        {
            var result = new Hotel();
            result.Name = Name;
            result.BuiltDateTime = BuiltDateTime;
            result.Room = Room != null ? ((Room) Room).GetSerializable() : null;
            // result.Rooms = Rooms != null ? (List<IRoom>) Rooms.Select(r => r != null ? ((Room) r).GetSerializable() : null) : null;

            return result;
        }

        public Hotel()
        {

        }

        public Hotel(IHotel hotel)
        {
            Id = ObjectId.GenerateNewId().ToString();
            if (hotel == null)
            {
                return;
            }
            Name = hotel.Name ?? "";
            BuiltDateTime = hotel.BuiltDateTime != null ? hotel.BuiltDateTime : new DateTime();
            Room = new Room(hotel.Room);
            Rooms = new List<IRoom> { Room };
        }

        public Hotel(string name, DateTime builtDateTime, List<IRoom> rooms =null)
        {
            Name = name;
            BuiltDateTime = builtDateTime;
            Rooms = rooms;

        }
    }
}