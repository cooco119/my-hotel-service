using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using MongoDB.Bson;
using MyHotelService.Common.HotelService.Enums;
using MyHotelService.Common.HotelService.Models;
using Newtonsoft.Json;

namespace MyHotelService.HotelService.Models
{
    [JsonObject(IsReference = true)]
    public class Hotel : IHotel
    {
        [Key]
        [JsonProperty("id")]
        public string _id { get; set; }
        [JsonIgnore]
        public ObjectId Id { get; set; }

        [Required]
        [StringLength(300)]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("builtDateTime")]
        public DateTime BuiltDateTime { get; set; }

        [ForeignKey("Rooms")]
        [JsonProperty("room")]
        public IRoom Room { get; set; }
        [JsonProperty("rooms")]
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