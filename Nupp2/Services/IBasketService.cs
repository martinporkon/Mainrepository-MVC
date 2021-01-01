using System.Collections.Generic;
using System.Threading.Tasks;
using Nupp2.Views.Home;

namespace Nupp2.Services
{
    public interface IBasketService
    {
        Task<IEnumerable<Basket>> PostToBasket(ProductTypeView p);
    }
}