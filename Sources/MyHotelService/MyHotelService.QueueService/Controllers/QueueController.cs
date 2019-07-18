using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyHotelService.QueueService.QueueManager;
using MyHotelService.Common.QueueService.Model;
using MyHotelService.Common.Utility;
using MyHotelService.QueueService.Model;
using Newtonsoft.Json;

namespace MyHotelService.QueueService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        [HttpPost("subscribe/{name}")]
        public ActionResult<string> SubscribeQueue(string name)
        {
            var key = MyQueueManager<IQueueEntry>.GetInstance().TryInitNewQueue(name);

            return key.ToString();
        }

        [HttpGet("poll/{name}")]
        public ActionResult<string> PollQueue(string name)
        {
            var qm = MyQueueManager<IQueueEntry>.GetInstance();
            try
            {
                if (qm.IsThereEntryInQueue(name))
                {
                    var entry = qm.GetEntry(name);

                    return entry;
                }

                return "empty queue";
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return e.ToString();
            }
        }

        [HttpPost("publish/{name}")]
        public void Post([FromBody] QueueEntry value, string name)
        {
            var qm = MyQueueManager<IQueueEntry>.GetInstance();
            var key = qm.TryInitNewQueue(name);
            qm.PublishToQueue(key, value);
        }
    }
}
