using System;
using MongoDB.Bson;
using MyHotelService.Common.DbService.Enums;
using MyHotelService.Common.DbService.Models;
using MyHotelService.Common.Utility;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using Newtonsoft.Json;

namespace MyHotelService.DbService.Models
{
    public class Room : IRoom
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement]
        public int Number { get; set; }

        [BsonElement]
        public string HotelName { get; set; }

        [BsonElement]
        public RoomState Status { get; set; }
        [BsonElement]
        public bool AllowedSmoking { get; set; }

        [BsonElement]
        [JsonConverter(typeof(CustomJsonConverter<IUser, User>))]
        public IUser Customer { get; set; }

        public Room()
        {

        }

        public Room(IRoom room)
        {
            Number = room.Number;
            HotelName = room.HotelName ?? "";
            Status = room.Status;
            AllowedSmoking = room.AllowedSmoking;
            Customer = new User(room.Customer);
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