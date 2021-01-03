using System.Collections.Generic;
using Web.Domain.DTO.CatalogService;

namespace Web.Domain.DTO
{
    public class ProductViewModel
    {
        public IEnumerable<CatalogDto> Products { get; private set; }
        public ProductViewModel(IEnumerable<CatalogDto> products)
        {
            Products = products;

        }
    }
}