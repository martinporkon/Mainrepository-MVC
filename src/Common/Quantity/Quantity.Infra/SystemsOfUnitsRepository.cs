using Quantity.Data;
using Quantity.Domain;
using Quantity.Infra.Common;

namespace Quantity.Infra {

    public sealed class SystemsOfUnitsRepository : UniqueEntityRepository<SystemOfUnits, SystemOfUnitsData>,
        ISystemsOfUnitsRepository {

        public SystemsOfUnitsRepository(QuantityDbContext c = null) : base(c, c?.SystemsOfUnits) { }

        public override SystemOfUnits toDomainObject(SystemOfUnitsData d) => new SystemOfUnits(d);
    }

}

