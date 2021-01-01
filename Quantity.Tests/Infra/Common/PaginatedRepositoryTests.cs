using System;
using System.Linq;
using System.Threading.Tasks;
using Aids.Random;
using CommonTests.OverallTests;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Infra;
using Quantity.Infra.Common;

namespace Quantity.Tests.Infra.Common {

    [TestClass] public class PaginatedRepositoryTests : AbstractClassTests<PaginatedRepository<Measure, MeasureData>,
        FilteredRepository<Measure, MeasureData>> {

        private class testClass : PaginatedRepository<Measure, MeasureData> {

            public testClass(DbContext c, DbSet<MeasureData> s) : base(c, s) { }
            public override Measure toDomainObject(MeasureData d) => MeasureFactory.Create(d);
            protected override async Task<MeasureData> getData(string id) {
                await Task.CompletedTask;

                return await dbSet.FindAsync(id);
            }
            protected override MeasureData getDataById(MeasureData d) => dbSet.Find(d.Id);
        }

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            var options = new DbContextOptionsBuilder<QuantityDbContext>().UseInMemoryDatabase("TestDb").Options;
            var c = new QuantityDbContext(options);
            obj = new testClass(c, c.Measures);

            for (var i = 0; i < GetRandom.UInt8(10, 30); i++) {
                var d = GetRandom.Object<MeasureData>();
                obj.Add(MeasureFactory.Create(d)).GetAwaiter();
            }

        }
        
        [TestMethod] public void PageIndexTest() => isProperty(() => obj.PageIndex, x => obj.PageIndex = x);
        
        [TestMethod] public void TotalPagesTest() 
            => isReadOnlyProperty(obj, nameof(obj.TotalPages), 
                (int) Math.Ceiling((double) obj.dbSet.Count()/obj.PageSize));
        
        [TestMethod] public void HasNextPageTest() =>
            isReadOnlyProperty(obj, nameof(obj.HasNextPage), obj.PageIndex < obj.TotalPages);
        
        [TestMethod] public void HasPreviousPageTest()
            => isReadOnlyProperty(obj, nameof(obj.HasPreviousPage), obj.PageIndex > 1);

        [TestMethod] public void PageSizeTest() {
            Assert.AreEqual(obj.PageSize, Constants.DefaultPageSize);
            isProperty(()=> obj.PageSize, x => obj.PageSize = x);
        }

        [TestMethod]
        public void GetListTest()
        {
            for (var i = 0; i < GetRandom.UInt8(10, 30); i++)
            {
                var d = GetRandom.Object<MeasureData>();
                obj.Add(MeasureFactory.Create(d)).GetAwaiter();
            }

            obj.PageIndex = 1;
            var l = obj.Get().GetAwaiter().GetResult();
            Assert.AreEqual(obj.PageSize, l.Count);
            obj.PageIndex = -1;
            l = obj.Get().GetAwaiter().GetResult();
            Assert.AreEqual(obj.dbSet.Count(), l.Count);
        }
    }

}
