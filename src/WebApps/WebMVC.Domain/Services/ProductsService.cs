using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebMVC.Facade.Models.Catalog;

namespace WebMVC.Domain.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductsService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ProductDto> GetProducts()
        {

            var httpClient = _httpClientFactory.CreateClient("TokenAPIClient");

            var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"/api/products/allproducts");

            var response = await httpClient.SendAsync(
                request, HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();
            await using var responseStream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<ProductDto>(responseStream);

            return result;
        }
    }
}