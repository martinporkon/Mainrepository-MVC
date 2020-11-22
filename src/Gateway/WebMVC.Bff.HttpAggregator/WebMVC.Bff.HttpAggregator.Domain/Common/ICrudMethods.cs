using System.Collections.Generic;
using System.Threading.Tasks;
using WebMVC.Bff.HttpAggregator.Domain.Common;

namespace WebMVC.Bff.HttpAggregator.Infra.Common
{
    public interface ICrudMethods<T> : ICommandMethods<T>, IQueryMethods<T>
    {

    }
}