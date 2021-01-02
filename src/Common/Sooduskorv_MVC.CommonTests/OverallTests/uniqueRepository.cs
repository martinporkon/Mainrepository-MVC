using Quantity.Domain.Common;
using Sooduskorv_MVC.Data.CommonData;

namespace Sooduskorv_MVC.CommonTests.OverallTests
{
    public class uniqueRepository
        <TObj, TData> : periodRepository<TObj, TData>
        where TObj : IEntity<TData>
        where TData : PeriodData, new()
    {

        protected override string getId(TData d) => d.Id;
    }
}