using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyHotelService.HotelService.Enums;

namespace MyHotelService.HotelService.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [ForeignKey("HotelId")]
        public Hotel Hotel { get; set; }
        public int HotelId { get; set; }

        [Required]
        public RoomState Status { get; set; }
        public bool AllowedSmoking { get; set; }

        public Room()
        {

        }

        public Room(int number, int hotelId, RoomState status, bool allowedSmoking)
        {
            Number = number;
            HotelId = hotelId;
            Status = status;
            AllowedSmoking = allowedSmoking;
        }
    }
}