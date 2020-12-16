using System.Collections.Generic;
using Catalog.Data.Products;
using EventBus.Events;

namespace Catalog.API.DTOs
{
    public class CreateBasketMessage : IntegrationEvent
    {
        public List<ProductData> Products { get; set; }
        public string UserId { get; set; }

    }
}