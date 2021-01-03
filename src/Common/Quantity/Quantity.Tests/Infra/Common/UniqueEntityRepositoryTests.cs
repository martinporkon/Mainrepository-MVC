using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Infra.Common;
using Sooduskorv_MVC.CommonTests.OverallTests;

namespace Quantity.Tests.Infra.Common
{

    [TestClass]
    public class UniqueEntityRepositoryTests : AbstractClassTests<UniqueEntityRepository<Measure, MeasureData>,
        PaginatedRepository<Measure, MeasureData>> {

        private class testClass : UniqueEntityRepository<Measure, MeasureData> {

            public testClass(DbContext c, DbSet<MeasureData> s) : base(c, s) { }

            public override Measure toDomainObject(MeasureData d) => MeasureFactory.Create(d);
        }

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = new testClass(null, null);
        }

    }

}
