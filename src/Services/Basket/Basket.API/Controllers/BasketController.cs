using Basket.Domain.BasketOfProducts;
using Basket.Pages.Common;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Basket.API.Controllers
{
    public class BasketController : PageModel
    {
        public BasketController(IBasketOfProductRepository b)
        {

        }
    }
}