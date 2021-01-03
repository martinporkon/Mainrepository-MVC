using Quantity.Data;
using Quantity.Domain.Common;

namespace Quantity.Domain {

    public abstract class UnitAttribute<TData> : Entity<TData> 
    
        where TData: UnitAttributeData, new() {

        protected UnitAttribute(TData d = null) : base(d) { }

        public string SystemOfUnitsId => Data?.SystemOfUnitsId ?? Unspecified;

        public SystemOfUnits SystemOfUnits => new GetFrom<ISystemsOfUnitsRepository, SystemOfUnits>().ById(SystemOfUnitsId);

        public string UnitId => Data?.UnitId ?? Unspecified;
        
        public Unit Unit => new GetFrom<IUnitsRepository, Unit>().ById(UnitId);

    }

}