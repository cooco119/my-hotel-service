using System;
using MongoDB.Bson;
using MyHotelService.Common.DbService.Models;
using MyHotelService.Common.Utility;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using Newtonsoft.Json;

namespace MyHotelService.DbService.Models
{
    public class Hotel : IHotel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement]
        public string Name { get; set; }

        [BsonElement]
        public DateTime BuiltDateTime { get; set; }

        [BsonElement]
        [JsonConverter(typeof(CustomJsonConverter<IRoom, Room>))]
        public IRoom Room { get; set; }
        [BsonElement]
        [JsonConverter(typeof(CustomJsonConverter<IRoom, Room>))]
        public IRoom[] Rooms { get; set; }

        public Hotel()
        {

        }

        public Hotel(IHotel hotel)
        {
            Name = hotel.Name ?? "";
            BuiltDateTime = hotel.BuiltDateTime != null ? hotel.BuiltDateTime : new DateTime();
            Room = new Room(hotel.Room);
            Rooms = new[] { Room };
        }

        public Hotel(string name, DateTime builtDateTime, IRoom[] rooms=null)
        {
            Name = name;
            BuiltDateTime = builtDateTime;
            Rooms = rooms;

        }
    }
}