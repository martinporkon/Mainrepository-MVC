using Catalog.Domain.Common;
using CommonData;

namespace CommonTests.OverallTests {
    public class uniqueRepository
        <TObj, TData> : periodRepository<TObj, TData>
        where TObj : IEntity<TData>
        where TData : PeriodData, new()
        {

        protected override string getId(TData d) => d.Id;
    }

}