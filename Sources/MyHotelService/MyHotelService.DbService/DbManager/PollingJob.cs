using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MyHotelService.Common.DbService.Models;
using Quartz;
using Quartz.Impl;
using MyHotelService.Common.QueueService;
using MyHotelService.Common.QueueService.Enum;
using MyHotelService.Common.QueueService.Model;
using MyHotelService.DbService.Models;
using Newtonsoft.Json;

namespace MyHotelService.DbService.DbManager
{
    public class PollingJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var response = await GetPollingResponse();
            if (response == "empty queue")
            {
                return;
            }
            var entry = JsonConvert.DeserializeObject<QueueEntry>(response);
            DispatchHandleQueueResponse(entry);
            Console.WriteLine("Pulled from queue!");
        }

        public async Task<string> GetPollingResponse()
        {
            try
            {
                var client = new HttpClient();
                var targetUrl = QueueInfo.Url + "/poll/" + QueueInfo.QueueName;
                HttpResponseMessage response = await client.GetAsync(targetUrl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return responseBody;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        public bool DispatchHandleQueueResponse(IQueueEntry entry)
        {
            switch (entry.Type)
            {
                case QueueEntryType.HOTEL:
                    return HandleHotelEntry(new Hotel(entry.Hotel));
                case QueueEntryType.RESERVATION:
                    return HandleReservationEntry(new Reservation(entry.Reservation));
                case QueueEntryType.ROOM:
                    return HandleRoomEntry(new Room(entry.Room));
                case QueueEntryType.USER:
                    return HandleUserEntry(new User(entry.User));
                case QueueEntryType.NONE:
                    Console.Write("Got None type entry");
                    return false;
                default:
                    return false;
            }
        }

        public bool HandleHotelEntry(Hotel hotel)
        {
            return MyDbManager.GetInstance().CreateInCollection<Hotel>(hotel);
        }
        public bool HandleReservationEntry(Reservation reservation)
        {
            return MyDbManager.GetInstance().CreateInCollection<Reservation>(reservation);
        }
        public bool HandleRoomEntry(Room room)
        {
            return MyDbManager.GetInstance().CreateInCollection<Room>(room);
        }
        public bool HandleUserEntry(User user)
        {
            return MyDbManager.GetInstance().CreateInCollection<User>(user);
        }
    }
}
