using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace MyHotelService.Common.DbService.Models
{
    public interface IReservation
    {
        string Id { get; set; }
        string ReservationCode { get; set; }
        IUser User { get; set; }
        IHotel Hotel { get; set; }
        IRoom Room { get; set; }
        DateTime ReservationDateTime { get; set; }
    }
}
