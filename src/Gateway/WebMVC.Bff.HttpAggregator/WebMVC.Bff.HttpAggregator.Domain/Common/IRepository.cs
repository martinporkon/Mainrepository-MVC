using System.Threading;
using System.Threading.Tasks;

namespace WebMVC.Bff.HttpAggregator.Infra.Common
{
    public interface IRepository<T>
    {
        Task<T> Add(T entity, CancellationToken cancellationToken);
        Task Update(T entity, CancellationToken cancellationToken);
        Task Delete(T entity, CancellationToken cancellationToken);
    }
}