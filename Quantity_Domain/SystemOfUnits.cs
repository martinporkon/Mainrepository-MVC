using Quantity.Data;
using Quantity.Domain.Common;

namespace Quantity.Domain {

    public sealed class SystemOfUnits : DefinedEntity<SystemOfUnitsData> {

        public SystemOfUnits() : this(null) { }

        public SystemOfUnits(SystemOfUnitsData data) : base(data) { }


    }

}