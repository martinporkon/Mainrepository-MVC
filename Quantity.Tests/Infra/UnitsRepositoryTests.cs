using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Infra;
using Quantity.Infra.Common;

namespace Quantity.Tests.Infra {

    [TestClass] public class UnitsRepositoryTests : QuantityRepositoryTests<UnitsRepository, Unit, UnitData> {

        protected override Type getBaseClass() => typeof(UniqueEntityRepository<Unit, UnitData>);

        protected override UnitsRepository getObject(QuantityDbContext c) => new UnitsRepository(c);

        protected override DbSet<UnitData> getSet(QuantityDbContext c) => c.Units;

    }

}