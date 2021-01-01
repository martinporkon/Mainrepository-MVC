using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Facade.Product;

namespace TestEnvironment.Areas.Products.Pages
{
    public interface IBasketService
    {
        Task<IEnumerable<Basket>> PostToBasket(ProductTypeView p);
    }
}