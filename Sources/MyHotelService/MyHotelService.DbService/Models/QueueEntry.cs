using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyHotelService.Common.DbService.Models;
using MyHotelService.Common.QueueService.Enum;
using MyHotelService.Common.QueueService.Model;
using MyHotelService.Common.Utility;
using Newtonsoft.Json;

namespace MyHotelService.DbService.Models
{
    public class QueueEntry : IQueueEntry
    {
        public QueueEntryType Type { get; set; }

        [JsonConverter(typeof(CustomJsonConverter<IHotel, Hotel>))]
        public IHotel Hotel { get; set; }

        [JsonConverter(typeof(CustomJsonConverter<IRoom, Room>))]
        public IRoom Room { get; set; }

        [JsonConverter(typeof(CustomJsonConverter<IUser, User>))]
        public IUser User { get; set; }

        [JsonConverter(typeof(CustomJsonConverter<IReservation, Reservation>))]
        public IReservation Reservation { get; set; }

        public QueueEntry()
        {

        }

        public QueueEntry(IQueueEntry entry)
        {
            Type = entry.Type;
            Hotel = new Hotel(entry.Hotel);
            Room = new Room(entry.Room);
            User = new User(entry.User);
            Reservation = new Reservation(entry.Reservation);
        }
    }
}
