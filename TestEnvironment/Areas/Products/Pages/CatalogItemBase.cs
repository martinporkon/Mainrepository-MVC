using System.Threading.Tasks;
using Catalog.Facade.Product;
using Microsoft.AspNetCore.Components;

namespace TestEnvironment.Areas.Products.Pages
{
    public class CatalogItemBase : ComponentBase
    {
        [Parameter]
        public ProductTypeView Product { get; set; }

        [Parameter]
        public EventCallback<ProductTypeView> OnProductSelected { get; set; }
        [Parameter]
        public EventCallback<ProductTypeView> OnProductRemoved { get; set; }
        public async Task AddToBasketChanged()
        {
            Product.ProductsInUserBasket++;
            await OnProductSelected.InvokeAsync(Product);
            this.StateHasChanged();
        }

        public async Task RemoveBasketChanged()
        {
            var count = Product.ProductsInUserBasket--;
            if (count < 0)
            {
                Product.ProductsInUserBasket = 0;
            }
            await OnProductRemoved.InvokeAsync(Product);
            this.StateHasChanged();
        }
    }
}