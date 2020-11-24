using System.Collections.Generic;

namespace SooduskorvWebMVC.Models
{
    public class ProductViewModel
    {
        public IEnumerable<ProductDto> Products { get; private set; }
        public ProductViewModel(IEnumerable<ProductDto> products)
        {
            Products = products;

        }
    }
}