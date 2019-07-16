using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyHotelService.Common.HotelService.Models;
using MyHotelService.Common.HotelService.Enums;
using Microsoft.Extensions.Http;
using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MyHotelService.HotelService.Models;

namespace MyHotelService.HotelService.Services
{
    public class HotelService
    {
        private HttpClient _client;

        private JsonSerializerSettings _serializerSettings;
        public HotelService()
        {
            _client = new HttpClient();
            _serializerSettings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            };
        }

        public async Task<HttpResponseMessage> RequestGet(string url, HttpRequestType type, string bodyJsonString = null)
        {
            var client = _client;
            if (type == HttpRequestType.GET)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                return await client.SendAsync(request);
            }
            else if (type == HttpRequestType.POST)
            {
                var content = new StringContent(bodyJsonString);
                return await client.PostAsync(url, new StringContent(bodyJsonString, Encoding.UTF8, "application/json"));
            }
            else
            {
                return null;
            }
        }

        public async Task<string> GetHotelAsync(string name)
        {
            var response = await RequestGet("http://10.160.2.52:5001/api/Db/Hotels/" + name, HttpRequestType.GET);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return null;
            }
        }

        public async Task<string> GetRoomAsync(string number)
        {
            var response = await RequestGet("http://10.160.2.52:5001/api/Db/Rooms/" + number, HttpRequestType.GET);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return null;
            }
        }
    }
}
