using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Facade.Product;

namespace SooduskorvWebMVC.Components
{
    public interface IBasketService
    {
        Task<IEnumerable<Basket>> PostToBasket(ProductTypeView p);
    }
}