using System.Collections.Generic;

namespace SooduskorvWebMVC.Models
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