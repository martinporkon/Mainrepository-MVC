using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Infra;

namespace Quantity.Tests.Infra {

    [TestClass]
    public class UnitRulesRepositoryTests : QuantityRepositoryTests<UnitRulesRepository, UnitRules,
        UnitRulesData>
    {


        protected override UnitRulesRepository getObject(QuantityDbContext c) => new UnitRulesRepository(c);

        protected override DbSet<UnitRulesData> getSet(QuantityDbContext c) => c.UnitRules;

    }

}