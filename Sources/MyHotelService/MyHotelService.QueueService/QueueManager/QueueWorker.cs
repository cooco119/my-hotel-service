using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHotelService.QueueService.QueueManager
{
    public class QueueWorker<T>
    {
        public bool IsBusy { get; set; }
        public MyQueueManager<T>.QueueSubscriberHandler Handler { get; set; }

        private readonly object _mutex = new object();

        public QueueWorker(MyQueueManager<T>.QueueSubscriberHandler handler)
        {
            IsBusy = false;
            Handler = handler;
        }

        public async Task<bool> InvokeWorker(T item)
        {
            lock (_mutex)
            {
                if (IsBusy)
                {
                    throw new Exception("Worker is already busy.");
                }
                IsBusy = true;
            }
            var handlerResult = await Handler(item);
            IsBusy = false;

            return handlerResult;
        }
    }
}
