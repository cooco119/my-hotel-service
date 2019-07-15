using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using MyHotelService.HotelService.Enums;
using Newtonsoft.Json;

namespace MyHotelService.HotelService.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        public DateTime BuiltDateTime { get; set; }

        [ForeignKey("Rooms")]
        public Room Room { get; set; }
        public Room[] Rooms { get; set; }

        public Hotel()
        {

        }

        public Hotel(string name, DateTime builtDateTime, Room[] rooms)
        {
            Name = name;
            BuiltDateTime = builtDateTime;
            Rooms = rooms;

        }
    }
}