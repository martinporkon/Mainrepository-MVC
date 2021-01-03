using System.Collections.Generic;
using System.Threading.Tasks;
using SooduskorvWebMVC.ComponentBases;

namespace SooduskorvWebMVC.Components
{
    public interface IBasketService
    {
        Task<IEnumerable<Basket>> PostToBasket(ProductTypeView p);
    }
}