using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebMVC.Bff.HttpAggregator.Domain.Common
{
    public interface IQueryMethods<T>
    {
        Task<List<T>> Get();
        Task<T> Get(string id);
    }
}