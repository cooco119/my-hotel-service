using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace MyHotelService.Common.HotelService.Models
{
    public interface IHotel
    {
        ObjectId Id { get; set; }

        string Name { get; set; }

        DateTime BuiltDateTime { get; set; }

        IRoom Room { get; set; }
        IRoom[] Rooms { get; set; }
    }
}
