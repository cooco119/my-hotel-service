using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyHotelService.Common.UserService.Models;

namespace MyHotelService.UserService.Models
{
    public class User : IUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        public IFriend[] Friends { get; set; }

        public User()
        {

        }

        public User(string name, IFriend[] friends=null)
        {
            Name = name;
            Friends = friends;
        }
    }
}
