using System.Collections.Generic;
using System.Threading.Tasks;
using Nupp.Views.Home;

namespace Nupp.Services
{
    public interface IBasketService
    {
        Task<IEnumerable<Basket>> PostToBasket(ProductTypeView p);
    }
}