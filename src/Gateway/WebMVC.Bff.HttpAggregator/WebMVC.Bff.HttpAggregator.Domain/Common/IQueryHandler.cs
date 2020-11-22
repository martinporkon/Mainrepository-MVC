using System.Threading;
using System.Threading.Tasks;

namespace WebMVC.Bff.HttpAggregator.Infra.Common
{
    public interface IQueryHandler<in TQuery, TQueryResult> where TQuery : IQuery<TQueryResult>
    {
        Task<TQueryResult> HandleAsync(TQuery query, CancellationToken cancellationToken);// database query segregation
    }
}