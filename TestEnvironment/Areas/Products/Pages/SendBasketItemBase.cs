using System.Threading.Tasks;
using Catalog.Facade.Product;
using Microsoft.AspNetCore.Components;

namespace TestEnvironment.Areas.Products.Pages
{
    public class SendBasketItemBase : ComponentBase
    {
        [Inject]
        public ViewState ViewState { get; set; }

        [Inject]
        public IBasketService BasketService { get; set; }

        public async Task SendToBasket(ProductTypeView viewStateProduct)
            => await BasketService.PostToBasket(viewStateProduct);

        public async Task RemoveFromBasket(ProductTypeView viewStateProduct)
        => await BasketService.PostToBasket(viewStateProduct);

        protected override void OnInitialized()
        {
            ViewState.OnChange += async () =>
            {
                Notify();
                await SendToBasket(ViewState.Product).ConfigureAwait(false);
            };

            /*ViewState.OnChange -= () =>
            {

            };*/

            ViewState.OnRemove += async () =>
            {
                Notify();
                await RemoveFromBasket(ViewState.Product).ConfigureAwait(false);
            };
        }

        public void Notify()
        {
            StateHasChanged();
        }
        /*
        public int TotalSelectedItemsCount { get; set; } = 0;
        [Parameter]
        public RenderFragment CustomMessage { get; set; }
        */
    }
}