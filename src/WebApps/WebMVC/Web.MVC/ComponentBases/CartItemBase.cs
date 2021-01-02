using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using SooduskorvWebMVC.Components;

namespace SooduskorvWebMVC.ComponentBases
{
    public class CartItemBase : ComponentBase
    {
        [Inject]
        public IBasketService BasketService { get; set; }

        public CartItem CartItem { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await BasketService.PostToBasket(CartItem);// TODO need the item from the UI.
        }
    }

    public interface IBasketService
    {
        Task<Task> PostToBasket(CartItem item);// TODO Task<Task>?
    }

    public class CartDto// TODO lihtsalt toode juures ei sobiks?
    {// Mingi transaction siia.
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

        public async Task<Task> PostToBasket(CartItem item)// TODO Deadlock ennetusmeetodid.
        {
            var client = _httpClient.CreateClient();
            var result = client.PostJsonAsync("/api/baskets", item);
            return result;
        }
    }
}