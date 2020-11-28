using System.Collections.Generic;
using Catalog.Data.Products;

namespace Catalog.API.Dtos
{
    public class CreateBasketMessage : IntegrationEvent
    {
        public List<ProductData> Products { get; set; }
        public string UserId { get; set; }

    }
}