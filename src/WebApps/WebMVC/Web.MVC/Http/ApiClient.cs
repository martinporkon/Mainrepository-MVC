using System;
using System.Net.Http;

namespace SooduskorvWebMVC.Http
{
    public class ApiClient
    {
        public HttpClient Client { get; set; }
        public ApiClient(HttpClient client)
        {
            Client = client;
            Client.BaseAddress = new Uri("http://localhost:12345");
            Client.Timeout = new TimeSpan(0, 0, 30);
            Client.DefaultRequestHeaders.Clear();
        }
    }
}