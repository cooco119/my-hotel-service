using System;
using System.Collections.Generic;
using System.Text;

namespace MyHotelService.Common.UserService.Models
{
    public interface IUser
    {
        int Id { get; set; }
        string Name { get; set; }
        IFriend[] Friends { get; set; }
    }
}
