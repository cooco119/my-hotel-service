using System;
using MongoDB.Bson;
using MyHotelService.Common.HotelService.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace MyHotelService.DbService.Models
{
    public class Hotel : IHotel
    {
        [BsonElement]
        public ObjectId Id { get; set; }

        [BsonElement]
        public string Name { get; set; }

        [BsonElement]
        public DateTime BuiltDateTime { get; set; }

        [BsonElement]

        public IRoom Room { get; set; }
        [BsonElement]
        public IRoom[] Rooms { get; set; }

        public Hotel()
        {

        }

        public Hotel(string name, DateTime builtDateTime, IRoom[] rooms=null)
        {
            Name = name;
            BuiltDateTime = builtDateTime;
            Rooms = rooms;

        }
    }
}