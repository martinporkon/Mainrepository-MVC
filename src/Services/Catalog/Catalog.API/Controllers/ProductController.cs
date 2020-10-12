using System;
using System.Threading.Tasks;
using Catalog.Data.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        public ProductController() { }

        [Route("allproducts")]
        [HttpGet]
        public async  Task<IActionResult> GetAllProducts()
        {
            var products = new ProductData()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "name",
                Measure = "measure",
                Type = "Food",
                CategoryId = Guid.NewGuid().ToString(),
                SubCategoryId = "SubCategoryId" + Guid.NewGuid().ToString(),
                PartyId = "PartyId: " + Guid.NewGuid().ToString(),
                Brand = "Brand: ",
                Supplier = "Supplier: " + "Itaalia",
                CountryOfOrigin = "Country : ",
                Code = "Code: " + Guid.NewGuid().ToString(),
                Composition = "Composition: ",
                Description = "Description: "
            };
            return Ok(products);
        }
    }
}