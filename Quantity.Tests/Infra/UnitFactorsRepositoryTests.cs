using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Infra;

namespace Quantity.Tests.Infra {

    [TestClass] public class UnitFactorsRepositoryTests : QuantityRepositoryTests<UnitFactorsRepository, UnitFactor,
        UnitFactorData> {


        protected override UnitFactorsRepository getObject(QuantityDbContext c) => new UnitFactorsRepository(c);

        protected override DbSet<UnitFactorData> getSet(QuantityDbContext c) => c.UnitFactors;

    }

}