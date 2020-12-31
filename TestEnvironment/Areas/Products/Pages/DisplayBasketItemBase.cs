using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Facade.Product;
using Microsoft.AspNetCore.Components;

namespace TestEnvironment.Areas.Products.Pages
{
    public class DisplayBasketItemBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductTypeView> Products { get; set; }

        [Parameter]
        public bool Show { get; set; }

        [Parameter]
        public EventCallback<int> OnBasketChanged { get; set; }

        [Inject]
        public ViewState ViewState { get; set; }

        /*protected int SelectedItemsCount { get; set; } = 0;
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

        }*/
        private int ProductCount;

        //TODO ostukorvi lisatakase vale toode?

        protected async Task ProductSelectionChanged(ProductTypeView Product)
        {
            this.ProductCount = Product.ProductsInUserBasket;
            ViewState.Product = Product;
            ViewState.NotifyStateChanged();
        }

        protected async Task ProductSelectionRemovedChanged(ProductTypeView Product)
        {
            this.ProductCount = Product.ProductsInUserBasket;
            ViewState.Product = Product;
            ViewState.NotifyStateRemoveChanged();
        }

        /*public async Task OnNotify()
        {
            await InvokeAsync(StateHasChanged);
        }*/
    }
}