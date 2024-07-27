using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMaster.Utilities;

namespace TicketMaster.Controllers
{
    internal class RequestHandler
    {
        private readonly AuggerClient _client;
        private readonly Queue<Func<Task<string>>> _requestQueue = new Queue<Func<Task<string>>>();
        private bool _isProcessingQueue = false;
        private readonly object _queueLock = new object();

        public RequestHandler()
        {
            _client = AuggerClient.Instance(); // Get the singleton instance of AuggerClient
        }

        public async Task<string> QueueRequest(Func<Task<string>> requestFunc)
        {
            string result;

            lock (_queueLock)
            {
                _requestQueue.Enqueue(requestFunc);
                if (!_isProcessingQueue)
                {
                    _isProcessingQueue = true;
                }
                else
                {
                    return null; // Already processing requests
                }
            }

            result = await ProcessQueue(); // Start processing requests

            return result;
        }

        private async Task<string> ProcessQueue()
        {
            while (true)
            {
                Func<Task<string>> request;
                lock (_queueLock)
                {
                    if (_requestQueue.Count == 0)
                    {
                        _isProcessingQueue = false;
                        return null; // No requests left to process
                    }

                    request = _requestQueue.Dequeue(); // Dequeue the next request
                }

                // Execute the request outside of the lock
                string response = await request();
                Console.WriteLine($"Client : RequestQue Response : {response}");
                return response;
            }
        }

        ///////////////////////  Request Handlers  ///////////////////////
        //public async Task<string> LoginAsync(string username, string password) =>
        //await QueueRequest(() => SendRequestAsync($"login:{username},{password}"));

        public async Task<string> LoginAsync(string username, string password)
        {
            return await SendRequestAsync($"login:{username},{password}");
        }

        public async Task<string> GetDataAsync(string identifier) =>
            await QueueRequest(() => SendRequestAsync($"get_data:{identifier}"));

        public async Task<string> PostDataAsync(string data) =>
            await QueueRequest(() => SendRequestAsync($"post_data:{data}"));

        public async Task<string> UpdateDataAsync(string data) =>
            await QueueRequest(() => SendRequestAsync($"update_data:{data}"));

        public async Task<string> DeleteDataAsync(string identifier) =>
            await QueueRequest(() => SendRequestAsync($"delete_data:{identifier}"));

        public async Task<string> DebugAsync(string debugInfo) =>
            await QueueRequest(() => SendRequestAsync($"debug:{debugInfo}"));

        private async Task<string> SendRequestAsync(string request)
        {
            try
            {
                await _client.SendRequestAsync(request); // Send the request
                return await _client.GetResponseAsync(); // Get the response
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Client : Error sending request : {ex.Message}");
                return null;
            }
        }
    }
}
