using System;
using System.Collections.Generic;
using System.Text;

namespace MyHotelService.Common.UserService.Models
{
    public interface IFriend
    {
        IUser User { get; set; }
    }
}
