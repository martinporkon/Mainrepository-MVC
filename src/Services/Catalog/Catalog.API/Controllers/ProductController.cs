using Catalog.Data.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController() { }

        [Route("allproducts")]
        [HttpGet]
        public async  Task<IActionResult> GetAllProducts()
        {
            var products = new ProductInstanceData()
            {
                Id = Guid.NewGuid().ToString(), 
                
            };
            return Ok(products);
        }
    }
}