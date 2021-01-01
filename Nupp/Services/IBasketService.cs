using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nupp.Services
{
    public interface IBasketService
    {
        Task<IEnumerable<Basket>> PostToBasket();
    }
}