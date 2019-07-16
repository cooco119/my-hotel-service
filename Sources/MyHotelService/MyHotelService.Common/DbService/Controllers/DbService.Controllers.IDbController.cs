using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using MyHotelService.Common.HotelService.Models;

namespace MyHotelService.Common.DbService.Controllers
{
    public interface IDbController
    {
        ActionResult<IHotel> GetHotel(string name);

        ActionResult<IRoom> GetRoom(string number);

        void PostHotel([FromBody] string value);

        void PostRooms([FromBody] string value);
    }
}
