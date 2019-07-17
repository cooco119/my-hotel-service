using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MyHotelService.Common.DbService.Enums;

namespace MyHotelService.Common.DbService.Models
{
    public interface IRoom
    {
        ObjectId Id { get; set; }

        int Number { get; set; }

        string HotelName { get; set; }

        RoomState Status { get; set; }
        bool AllowedSmoking { get; set; }
        IUser Customer { get; set; }
    }
}
