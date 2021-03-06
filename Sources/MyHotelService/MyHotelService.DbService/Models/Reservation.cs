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

namespace MyHotelService.DbService.Models
{
    [BsonDiscriminator("Reservation")]
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

        public Reservation()
        {

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
