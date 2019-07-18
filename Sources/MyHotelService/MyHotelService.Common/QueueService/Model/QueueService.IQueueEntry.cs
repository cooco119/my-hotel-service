using System;
using System.Collections.Generic;
using System.Text;
using MyHotelService.Common.QueueService.Enum;
using MyHotelService.Common.DbService.Models;

namespace MyHotelService.Common.QueueService.Model
{
    public interface IQueueEntry
    {
        QueueEntryType Type { get; set; }
        IHotel Hotel { get; set; }
        IRoom Room { get; set; }
        IUser User { get; set; }
        IReservation Reservation { get; set; }
    }
}
