using Quantity.Data;
using Quantity.Domain;
using Quantity.Infra.Common;

namespace Quantity.Infra {

    public sealed class MeasuresRepository : UniqueEntityRepository<Measure, MeasureData>, IMeasuresRepository {

        public MeasuresRepository(QuantityDbContext c = null) : base(c, c?.Measures) { }

        public override Measure toDomainObject(MeasureData d) => MeasureFactory.Create(d);
    }

}
