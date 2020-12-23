using Quantity.Data;
using Quantity.Domain;
using Quantity.Infra.Common;

namespace Quantity.Infra {

    public sealed class UnitsRepository : UniqueEntityRepository<Unit, UnitData>, IUnitsRepository {

        public UnitsRepository(QuantityDbContext c = null) : base(c, c?.Units) { }

        protected internal override Unit toDomainObject(UnitData d) => UnitFactory.Create(d);
    }

}
