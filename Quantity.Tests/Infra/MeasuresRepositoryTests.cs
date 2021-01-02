using Quantity.Data;
using Quantity.Domain;
using Quantity.Infra;
using Quantity.Infra.Common;

namespace Quantity.Tests.Infra {

    [TestClass] public class
        MeasuresRepositoryTests : QuantityRepositoryTests<MeasuresRepository, Measure,
            MeasureData> {

        protected override Type getBaseClass() => typeof(UniqueEntityRepository<Measure, MeasureData>);

        protected override MeasuresRepository getObject(QuantityDbContext c) => new MeasuresRepository(c);

        protected override DbSet<MeasureData> getSet(QuantityDbContext c) => c.Measures;

    }

}