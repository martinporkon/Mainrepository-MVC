using System;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nupp.Services;

namespace Nupp.Views.Home.Button
{
    public class SendBasketItemBase : ComponentBase
    {
        [Inject]
        public ViewState ViewState { get; set; }

        /*
        public int TotalSelectedItemsCount { get; set; } = 0;
        [Parameter]
        public RenderFragment CustomMessage { get; set; }
        */

        [Inject]
        public IBasketService BasketService { get; set; }

        public async Task SendToBasket(ProductTypeView viewStateProduct)
        {
            var test = ViewState.Product;
            await BasketService.PostToBasket(test);
        }

        public async Task RemoveFromBasket(ProductTypeView viewStateProduct)
        {
            var test = ViewState.Product;
            await BasketService.PostToBasket(test);
        }
        protected override void OnInitialized()
        {
            ViewState.OnChange += () =>
            {
                Notify();
                SendToBasket(ViewState.Product);
            };

            /*ViewState.OnChange -= () =>
            {

            };*/

            ViewState.OnRemove += () =>
            {
                Notify();
                RemoveFromBasket(ViewState.Product);
            };
        }

        public void Notify()
        {
            StateHasChanged();
        }
    }
}