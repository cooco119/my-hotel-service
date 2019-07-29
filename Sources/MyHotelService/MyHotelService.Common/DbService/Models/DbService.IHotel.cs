using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace MyHotelService.Common.DbService.Models
{
    public interface IHotel
    {
        string Id { get; set; }

        string Name { get; set; }

        DateTime BuiltDateTime { get; set; }

        IRoom Room { get; set; }
        IRoom[] Rooms { get; set; }
    }
}
