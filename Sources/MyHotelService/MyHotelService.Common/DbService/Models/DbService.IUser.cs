using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace MyHotelService.Common.DbService.Models
{
    public interface IUser
    {
        string Id { get; set; }
        string Name { get; set; }
        IReservation Reservation { get; set; }
        DateTime RegistrationDateTime { get; set; }
    }
}
