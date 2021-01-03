using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Domain.DTO;
using Web.Domain.DTO.CatalogService;
using Web.Domain.Services.Catalogs;

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
                /*Measure = a.Measure,
                Name = a.Name,
                Description = a.Description,
                CategoryId = a.CategoryId,
                Supplier = a.Supplier,
                Code = a.Code,
                Composition = a.Composition,
                PartyId = a.PartyId,
                Brand = a.Brand,
                CountryOfOrigin = a.CountryOfOrigin,*/
            };
            list.Add(test);

            return View(new ProductViewModel(list));
        }
    }
}