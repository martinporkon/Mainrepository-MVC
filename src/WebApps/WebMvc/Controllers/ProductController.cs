using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SooduskorvWebMVC.Models;
using WebMVC.Domain.Services;

namespace SooduskorvWebMVC.Controllers
{
    [AllowAnonymous]
    public class ProductController : Controller
    {
        private readonly IProductsService _productsService;

        public ProductController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        public async Task<IActionResult> Product()
        {

            var a = await _productsService.GetProducts();

            /*var a = response.Result;*/

            var list = new List<CatalogDto>();
            var test = new CatalogDto
            {
                Id = a.Id,
                
            };
            list.Add(test);

            return View(new ProductViewModel(list));
        }
    }
}