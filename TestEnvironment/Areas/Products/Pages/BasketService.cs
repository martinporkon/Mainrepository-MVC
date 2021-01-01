using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Catalog.Facade.Product;

namespace TestEnvironment.Areas.Products.Pages
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService()
        {

        }

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Basket>> PostToBasket(ProductTypeView p)
        {
            var toBasketP = p;
            var address = new Uri("http://localhost:5000/api/products");
            var values = new Dictionary<string, string> {
                { "id", "Data you want to send at id field" },
                { "type", "Data you want to send at type field"},
                { "name", "The data you went to send at name field"
                }
            };

            var content = new FormUrlEncodedContent(values);

            var test2 = _httpClient.PostAsync(address, content).Result;
            return new List<Basket> { new Basket { } };
        }
    }
}