using Quantity.Data;
using Quantity.Domain;
using Quantity.Infra;

namespace Quantity.Tests.Infra {

    [TestClass] public class MeasureTermsRepositoryTests : QuantityRepositoryTests<MeasureTermsRepository, MeasureTerm,
        MeasureTermData> {

        protected override MeasureTermsRepository getObject(QuantityDbContext c) => new MeasureTermsRepository(c);

        protected override DbSet<MeasureTermData> getSet(QuantityDbContext c) => c.MeasureTerms;

    }

}