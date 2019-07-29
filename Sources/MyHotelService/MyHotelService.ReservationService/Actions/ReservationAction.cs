using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MyHotelService.Common.QueueService;
using MyHotelService.Common.QueueService.Enum;
using MyHotelService.ReservationService.Models;
using Newtonsoft.Json;

namespace MyHotelService.ReservationService.Actions
{
    public class ReservationAction
    {
        private static string _dbUrl = "http://10.160.2.52:5001/api/Db";

        public static async Task<bool> Reserve(ReservationRequest request)
        {
            var user = await GetUserByName(request.UserName);
            var hotel = await GetHotelByName(request.HotelName);
            var room = await GetRoomByNumber(request.RoomNumber);

            var reservation = new Reservation(user, hotel, room);
            var queueEntry = new QueueEntry(QueueEntryType.RESERVATION, reservation: reservation);

            try
            {
                var client = new HttpClient();
                var targetUrl = QueueInfo.Url + "/publish/" + QueueInfo.QueueName;
                var content = new StringContent(JsonConvert.SerializeObject(queueEntry));
                HttpResponseMessage response = await client.PostAsync(targetUrl, content);
                response.EnsureSuccessStatusCode();

                return true;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        private static async Task<User> GetUserByName(string userName)
        {
            try
            {
                var client = new HttpClient();
                var targetUrl = _dbUrl + "/User/" + userName;
                HttpResponseMessage response = await client.GetAsync(targetUrl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<User>(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        private static async Task<Hotel> GetHotelByName(string hotelName)
        {
            try
            {
                var client = new HttpClient();
                var targetUrl = _dbUrl + "/Hotels/" + hotelName;
                HttpResponseMessage response = await client.GetAsync(targetUrl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Hotel>(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        private static async Task<Room> GetRoomByNumber(string roomNumber)
        {
            try
            {
                var client = new HttpClient();
                var targetUrl = _dbUrl + "/Rooms/" + roomNumber;
                HttpResponseMessage response = await client.GetAsync(targetUrl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Room>(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }
    }
}
