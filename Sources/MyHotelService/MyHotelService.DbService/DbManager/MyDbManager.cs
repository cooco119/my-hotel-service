using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
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

        public MyDbManager()
        {
            _client = new MongoClient(
                "mongodb://10.160.2.52:27017/test?w=majority"
            );
            _db = _client.GetDatabase("local");
        }

        public BsonDocument GetFromCollection(string collectionName, string field, string name)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(field, name);
            var result = _db.GetCollection<BsonDocument>(collectionName).Find(filter).Single();

            return result;
        }

        public bool CreateInCollection(string collectionName, string data)
        {
            try
            {
                var collection = _db.GetCollection<BsonDocument>(collectionName);
                var document = new BsonDocument
                {
                    {"data", data},
                    {"timestamp", DateTime.Now}
                };
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
