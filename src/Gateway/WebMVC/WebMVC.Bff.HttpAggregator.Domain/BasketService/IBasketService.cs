using System.Threading.Tasks;

namespace WebMVC.Bff.HttpAggregator.Domain.BasketService
{
    public interface IBasketService<T>
    {
        Task<T> Get(string id);
    }
}