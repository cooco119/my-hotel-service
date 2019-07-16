using System;
using MongoDB.Bson;
using MyHotelService.Common.HotelService.Enums;
using MyHotelService.Common.HotelService.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace MyHotelService.DbService.Models
{
    public class Room : IRoom
    {
        [BsonElement]
        public ObjectId Id { get; set; }



        [BsonElement]
        public int Number { get; set; }

        [BsonElement]
        public string HotelName { get; set; }

        [BsonElement]
        public RoomState Status { get; set; }
        [BsonElement]
        public bool AllowedSmoking { get; set; }

        public Room()
        {

        }

        public Room(int number, string hotelName, RoomState status, bool allowedSmoking)
        {
            Number = number;
            HotelName = hotelName;
            Status = status;
            AllowedSmoking = allowedSmoking;
        }
    }
}