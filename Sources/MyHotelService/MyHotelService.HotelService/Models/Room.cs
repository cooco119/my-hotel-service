using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MyHotelService.Common.HotelService.Enums;
using MyHotelService.Common.HotelService.Models;
using Newtonsoft.Json;

namespace MyHotelService.HotelService.Models
{
    [JsonObject(IsReference = true)]
    public class Room : IRoom
    {
        [Key]
        [JsonProperty("id")]
        public string _id { get; set; }
        [JsonIgnore]
        public ObjectId Id { get; set; }

        [Required]
        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("hotelName")]
        public string HotelName { get; set; }

        [Required]
        [JsonProperty("status")]
        public RoomState Status { get; set; }
        [JsonProperty("allowedSmoking")]
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