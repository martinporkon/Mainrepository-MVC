using CommonData;
using Quantity.Domain.Common;

namespace ServicesTests
{

    internal class uniqueRepository<TObj, TData> : periodRepository<TObj, TData>
        where TObj : IEntity<TData>
        where TData : UniqueEntityData, new() {

        protected override string getId(TData d) => d.Id;
    }

}