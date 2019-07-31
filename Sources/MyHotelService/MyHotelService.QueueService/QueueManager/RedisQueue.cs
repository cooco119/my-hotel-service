using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace MyHotelService.QueueService.QueueManager
{
    public class RedisQueue<T>
    {
        private long _size;
        private readonly IDatabase _db;
        private readonly RedisKey _listKey;

        public RedisQueue(string name)
        {
            _size = 0;
            var redisConnectionMultiplexer = ConnectionMultiplexer.Connect("redis:6379");
            _db = redisConnectionMultiplexer.GetDatabase();
            _listKey = name;
        }
        public RedisQueue(string name, long size)
        {
            _size = size;
            var redisConnectionMultiplexer = ConnectionMultiplexer.Connect("redis:6379");
            _db = redisConnectionMultiplexer.GetDatabase();
            _listKey = name;
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public void Push(T item)
        {
            var itemDataString = JsonConvert.SerializeObject(item);
            _db.ListLeftPush(_listKey, itemDataString);
            _size++;
        }

        public string Pop()
        {
            if (_size > 0)
            {
                var itemDataString = _db.ListRightPop(_listKey);
                _size--;

                return itemDataString;
            }
            else
            {
                throw new StackOverflowException();
            }

        }
    }
}
