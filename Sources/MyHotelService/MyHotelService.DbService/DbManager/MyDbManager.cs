using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using MyHotelService.DbService.Models;

namespace MyHotelService.DbService.DbManager
{
    public class MyDbManager
    {
        private MongoClient _client;
        private IMongoDatabase _db;
        private static MyDbManager _instance;

        public static MyDbManager GetInstance()
        {
            _instance = _instance ?? new MyDbManager();
            return _instance;
        }
        private static string GetCollectionNameFromType(Type T)
        {
            if (T == typeof(Hotel))
                return "hotels";
            else if (T == typeof(Room))
                return "rooms";
            else if (T == typeof(User))
                return "users";
            else if (T == typeof(Reservation))
                return "reservations";
            else
                throw new Exception("No Type Matching");
        }

        private static bool IsDuplicateEntryExists<T>(IMongoCollection<BsonDocument> collection, T data)
        {
            var key = "";
            var valueString = "";
            var valueInt = -1;

            if (typeof(T) == typeof(Hotel))
            {
                key = "Name";
                valueString = (data as Hotel).Name;
            }
            else if (typeof(T) == typeof(Room))
            {
                key = "Number";
                valueInt = (data as Room).Number;
            }
            else if (typeof(T) == typeof(User))
            {
                key = "Name";
                valueString = (data as User).Name;
            }
            else if (typeof(T) == typeof(Reservation))
            {
                key = "ReservationCode";
                valueString = (data as Reservation).ReservationCode;
            }
            else
            {
                throw new Exception("Not A Given Type");
            }

            if (valueString == "")
            {
                var filter = Builders<BsonDocument>.Filter.Eq(key, valueInt);
                return collection.Find(filter).ToList().Count > 0;
            }
            else if (valueInt == -1)
            {
                var filter = Builders<BsonDocument>.Filter.Eq(key, valueString);
                return collection.Find(filter).ToList().Count > 0;
            }
            else
            {
                throw new InvalidOperationException("Unreachable code reached");
            }
        }

        public MyDbManager()
        {
            _client = new MongoClient(
                "mongodb://10.160.2.52:27017/test?w=majority"
            );
            _db = _client.GetDatabase("local");
        }

        public BsonDocument GetFromCollection<T>(string key, string value)
        {
            var collectionName = GetCollectionNameFromType(typeof(T));
            var filter = Builders<BsonDocument>.Filter.Eq(key, value);
            var result = _db.GetCollection<BsonDocument>(collectionName).Find(filter).Single();

            return result;
        }

        public bool CreateInCollection<T>(T data)
        {
            var collectionName = GetCollectionNameFromType(typeof(T));
            try
            {
                var collection = _db.GetCollection<BsonDocument>(collectionName);
                var document = data.ToBsonDocument();
                if (IsDuplicateEntryExists<T>(collection, data))
                    throw new DuplicateNameException();
                collection.InsertOne(document);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
