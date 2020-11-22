using System.Threading.Tasks;

namespace WebMVC.Bff.HttpAggregator.Infra.Repositories
{
    public interface IBasketService<T>
    {
        Task<T> Get(string id);
    }
}