using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Nupp2.Views.Home.Button
{
    public class DisplayBasketItemBase : ComponentBase
    {
        [Parameter]
        public BasketDto BasketItem { get; set; }
        public async Task OnNotify()
        {
            await InvokeAsync(StateHasChanged);
        }

        [Parameter]
        public IEnumerable<ProductTypeView> Products { get; set; }

        [Parameter]
        public bool Show { get; set; }

        [Parameter]
        public EventCallback<int> OnBasketChanged { get; set; }

        /*public async Task OnNotify()
        {
            await InvokeAsync(StateHasChanged);
        }

        protected override void OnInitialized()
        {
            State.Notify += OnNotify;
        }*/

        protected int SelectedItemsCount { get; set; } = 0;
        protected void BasketItemChanged(bool status)
        {
            if (status)
            {
                SelectedItemsCount++;
            }
            else
            {
                if (SelectedItemsCount > 0)
                {
                    SelectedItemsCount--;
                }
            }

        }
    }
}