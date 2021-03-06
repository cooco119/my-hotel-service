﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MyHotelService.Common.DbService.Models;
using MyHotelService.Common.Utility;
using Newtonsoft.Json;

namespace MyHotelService.ReservationService.Models
{
    public class Reservation : IReservation
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement]
        public string ReservationCode { get; set; }

        [BsonElement]
        [JsonConverter(typeof(CustomJsonConverter<IUser, User>))]
        public IUser User { get; set; }

        [BsonElement]
        [JsonConverter(typeof(CustomJsonConverter<IHotel, Hotel>))]
        public IHotel Hotel { get; set; }

        [BsonElement]
        [JsonConverter(typeof(CustomJsonConverter<IRoom, Room>))]
        public IRoom Room { get; set; }

        [BsonElement]
        public DateTime ReservationDateTime { get; set; }

        public Reservation GetSerializable()
        {
            var result = new Reservation();
            result.ReservationCode = ReservationCode;
            result.User = User != null ? ((User) User).GetSerializable() : null;
            result.Hotel = Hotel != null ? ((Hotel) Hotel).GetSerializable() : null;
            result.Room = Room != null ? ((Room) Room).GetSerializable() : null;
            result.ReservationDateTime = ReservationDateTime;

            return result;
        }

        public Reservation()
        {

        }

        public Reservation(User user, Hotel hotel, Room room)
        {
            Random random = new Random();
            string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            Id = ObjectId.GenerateNewId().ToString();
            ReservationCode = new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
            User = user;
            Hotel = hotel;
            Room = room;
            ReservationDateTime = DateTime.Now;
        }

        public Reservation(IReservation reservation)
        {
            Id = ObjectId.GenerateNewId().ToString();
            if (reservation == null)
            {
                return;
            }
            ReservationCode = reservation.ReservationCode ?? "";
            User = new User(reservation.User);
            Hotel = new Hotel(reservation.Hotel);
            Room = new Room(reservation.Room);
            ReservationDateTime = reservation.ReservationDateTime;
        }
    }
}
