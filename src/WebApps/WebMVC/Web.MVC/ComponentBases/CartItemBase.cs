using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace SooduskorvWebMVC.ComponentBases
{
    public class CartItemBase : ComponentBase
    {
        [Inject]
        public IBasketService BasketService { get; set; }

        public ProductTypeView ProductTypeView { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await BasketService.PostToBasket(ProductTypeView);// TODO need the item from the UI.
        }
    }

    public interface IBasketService
    {
        Task<Task> PostToBasket(ProductTypeView item);// TODO Task<Task>?
    }

    public class CartDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }

    public class BasketService : IBasketService
    {
        private readonly IHttpClientFactory _httpClient;
        public BasketService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Task> PostToBasket(ProductTypeView item)
        {
            Task result = null;
            try
            {
                var client = _httpClient.CreateClient();
                result = client.PostJsonAsync("/api/baskets", item);
            }
            catch (Exception e)
            {

            }
            return result;
        }
    }
}