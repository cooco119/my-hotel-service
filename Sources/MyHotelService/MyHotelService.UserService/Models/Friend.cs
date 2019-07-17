using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyHotelService.Common.UserService.Models;

namespace MyHotelService.UserService.Models
{
    public class Friend : IFriend
    {
        [Key]
        [Required]
        public IUser User { get; set; }

        public Friend()
        {

        }

        public Friend(IUser user)
        {
            User = user;
        }
    }
}
