using System;
using System.Threading.Tasks;
using Catalog.Data.Products;
using Catalog.Infra.Catalog;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    /*[Authorize]*/
    public class ProductController : CatalogRepository
    {
        public ProductController()
        {

        }

        // TODO

        /*public async Task<ProductDetailsResponse> GetItemDetailsById(GetProductDetailsByIdRequest request, ServerCallContext context)
        {
            throw new NotImplementedException();
        }*/
    }
}