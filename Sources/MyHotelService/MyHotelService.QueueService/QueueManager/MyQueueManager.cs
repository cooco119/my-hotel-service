using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace MyHotelService.QueueService.QueueManager
{
    public class MyQueueManager<T>
    {
        private static MyQueueManager<T> _instance;
        private readonly Dictionary<RedisKey, RedisQueue<T>> _queues;
        private readonly IDatabase _db;
        private readonly string _redisKeyStoreKey = "keys";

        public delegate Task<bool> QueueSubscriberHandler(T item);

        public static MyQueueManager<T> GetInstance()
        {
            _instance = _instance ?? new MyQueueManager<T>();
            return _instance;
        }

        public void FetchDb()
        {
            var keyStoreLength = _db.ListLength(_redisKeyStoreKey);
            for (var i = 0; i < keyStoreLength; i++)
            {
                var key = _db.ListRightPop(_redisKeyStoreKey).ToString();
                var queue = new RedisQueue<T>(key, _db.ListLength(key));
                _queues.Add(key, queue);
                _db.ListLeftPush(_redisKeyStoreKey, key);
            }
        }

        public MyQueueManager()
        {
            _queues = new Dictionary<RedisKey, RedisQueue<T>>();
            var redisConnectionMultiplexer = ConnectionMultiplexer.Connect("10.160.2.52:6379");
            _db = redisConnectionMultiplexer.GetDatabase();
            FetchDb();
        }

        public RedisKey TryInitNewQueue(string name)
        {
            try
            {
                var existingQueue = _queues[name];
                return name;
            }
            catch
            {
                var newQueue = new RedisQueue<T>(name);
                _queues.Add(name, newQueue);
                _db.ListLeftPush(_redisKeyStoreKey, name);

                return name;
            }
        }

        public void PublishToQueue(RedisKey key, T item)
        {
            var targetQueue = _queues[key];
            targetQueue.Push(item);
        }

        public bool IsThereEntryInQueue(RedisKey key)
        {
            try
            {
                var targetQueue = _queues[key];
                return !targetQueue.IsEmpty();
            }
            catch
            {
                throw new Exception("No Corresponding Queue: " + key.ToString());
            }
        }

        public string GetEntry(RedisKey key)
        {
            var targetQueue = _queues[key];
            return targetQueue.Pop();
        }
    }
}
