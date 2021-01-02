using Quantity.Data;
using Quantity.Domain;
using Quantity.Infra;
using Quantity.Infra.Common;

namespace Quantity.Tests.Infra {

    [TestClass] public class
        SystemsOfUnitsRepositoryTests : QuantityRepositoryTests<SystemsOfUnitsRepository, SystemOfUnits,
            SystemOfUnitsData> {

        protected override Type getBaseClass() => typeof(UniqueEntityRepository<SystemOfUnits, SystemOfUnitsData>);

        protected override SystemsOfUnitsRepository getObject(QuantityDbContext c) => new SystemsOfUnitsRepository(c);

        protected override DbSet<SystemOfUnitsData> getSet(QuantityDbContext c) => c.SystemsOfUnits;

    }

}
