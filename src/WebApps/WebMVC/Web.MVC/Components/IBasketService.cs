using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Facade.Catalog.Products;

namespace SooduskorvWebMVC.Components
{
    public interface IBasketService
    {
        Task<IEnumerable<Basket>> PostToBasket(ProductTypeView p);
    }
}