using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHotelService.ReservationService.Models
{
    public class ReservationRequest
    {
        public string UserName { get; set; }
        public string HotelName { get; set; }
        public string RoomNumber { get; set; }

        public ReservationRequest(string username, string hotelName, string roomNumber)
        {
            UserName = username;
            HotelName = hotelName;
            RoomNumber = roomNumber;
        }
    }
}
