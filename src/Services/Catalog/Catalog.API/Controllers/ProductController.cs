using Catalog.Data.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    /*[Authorize]*/
    [Authorize]
    public class ProductController : ControllerBase
    {

        // TODO

        /*public async Task<ProductDetailsResponse> GetItemDetailsById(GetProductDetailsByIdRequest request, ServerCallContext context)
        {
            var products = new ProductInstanceData()
            {
                Id = Guid.NewGuid().ToString(), 
                
            };
            return Ok(products);
        }
    }
}