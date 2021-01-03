using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SooduskorvWebMVC.Http
{
    public class ApiClient<T> where T : class
    {
        public HttpClient Client { get; set; }
        public ApiClient(HttpClient client)
        {
            Client = client;
            Client.BaseAddress = new Uri("http://localhost:12345");
            Client.Timeout = new TimeSpan(0, 0, 30);
            Client.DefaultRequestHeaders.Clear();
        }

        public async Task<IEnumerable<T>> GetSomething()
        {
            var response = await Client.GetAsync(
                "/api/mvc-bff/catalogs/products/");

            response.EnsureSuccessStatusCode();

            await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
            return await JsonSerializer.DeserializeAsync<IEnumerable<T>>(responseStream);
        }
    }
}