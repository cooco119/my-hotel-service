using System;
using System.ComponentModel.DataAnnotations;

namespace HotelService.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        public DateTime BuiltDateTime { get; set; }

        public Hotel()
        {

        }

        public Hotel(string name, DateTime builtDateTime)
        {
            Name = name;
            BuiltDateTime = builtDateTime;
        }
    }
}