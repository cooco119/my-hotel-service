using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyHotelService.ReservationService.Actions;
using MyHotelService.ReservationService.Models;

namespace MyHotelService.ReservationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        [HttpPost]
        public async Task<bool> Post([FromBody] ReservationRequest value)
        {
            return await ReservationAction.Reserve(value);
        }
    }
}
