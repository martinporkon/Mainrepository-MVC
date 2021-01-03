using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Infra;
using Quantity.Infra.Common;
using Sooduskorv_MVC.Aids.Random;
using Sooduskorv_MVC.CommonTests.OverallTests;
using System.Linq;
using System.Threading.Tasks;

namespace Quantity.Tests.Infra.Common
{

    [TestClass] public class FilteredRepositoryTests : AbstractClassTests<FilteredRepository<Measure, MeasureData>,
        SortedRepository<Measure, MeasureData>> {

        private class testClass : FilteredRepository<Measure, MeasureData> {

            public testClass(Microsoft.EntityFrameworkCore.DbContext c, Microsoft.EntityFrameworkCore.DbSet<MeasureData> s) : base(c, s) { }
            public override Measure toDomainObject(MeasureData d) => MeasureFactory.Create(d);
            protected override async Task<MeasureData> getData(string id) {
                await Task.CompletedTask;

                return dbSet.Find(id);
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
        [TestMethod] public void SearchStringTest()
            => isNullableProperty(() => obj.SearchString, x => obj.SearchString = x);

        [TestMethod]
        public void CurrentFilterTest()
            => isNullableProperty(() => obj.CurrentFilter, x => obj.CurrentFilter = x);
        
        [TestMethod] public void FixedFilterTest()
            => isNullableProperty(() => obj.FixedFilter, x => obj.FixedFilter = x);
        [TestMethod] public void FixedValueTest()
            => isNullableProperty(() => obj.FixedValue, x => obj.FixedValue = x);

        [TestMethod] public void GetListTest() {
            var l = obj.Get().GetAwaiter().GetResult();
            Assert.AreEqual(obj.dbSet.Count(), l.Count);
        }

        [TestMethod] public void GetFilteredListTest() {
            var s = GetRandom.String();
            var c = GetRandom.UInt8(10, 30);

            for (var i = 0; i < c; i++) {
                var d = GetRandom.Object<MeasureData>();
                addFilter(d, s, i);
                obj.Add(MeasureFactory.Create(d)).GetAwaiter();
            }

            var l = obj.Get().GetAwaiter().GetResult();
            Assert.AreEqual(obj.dbSet.Count(), l.Count);
            obj.SearchString = s;
            l = obj.Get().GetAwaiter().GetResult();
            Assert.AreEqual(c, l.Count);
        }
        private static void addFilter(DefinedEntityData d, string s, int i) {
            var x = i % 3;
            if (x == 0) d.Id += s;
            else if (x == 1) d.Name += s;
            else if (x == 2) d.Code += s;
        }
        [TestMethod] public void GetFixedListTest() {
            var s1 = GetRandom.String(10, 20);
            var s2 = GetRandom.String(10, 20);
            var c1 = GetRandom.UInt8(10, 30);
            var c2 = GetRandom.UInt8(10, 30);
            var c3 = GetRandom.UInt8(10, 30);

            for (var i = 0; i < c1; i++) {
                var d = GetRandom.Object<MeasureData>();
                addFilter(d, s1, i);
                obj.Add(MeasureFactory.Create(d)).GetAwaiter();
            }

            for (var i = 0; i < c2; i++) {
                var d = GetRandom.Object<MeasureData>();
                addFilter(d, s1, i);
                d.Definition = s2;
                obj.Add(MeasureFactory.Create(d)).GetAwaiter();
            }

            for (var i = 0; i < c3; i++) {
                var d = GetRandom.Object<MeasureData>();
                d.Definition = s2;
                obj.Add(MeasureFactory.Create(d)).GetAwaiter();
            }

            var l = obj.Get().GetAwaiter().GetResult();
            Assert.AreEqual(obj.dbSet.Count(), l.Count);
            obj.SearchString = s1;
            l = obj.Get().GetAwaiter().GetResult();
            Assert.AreEqual(c1 + c2, l.Count);
            obj.FixedFilter = "Definition";
            obj.FixedValue = s2;
            l = obj.Get().GetAwaiter().GetResult();
            Assert.AreEqual(c2, l.Count);
            obj.SearchString = null;
            l = obj.Get().GetAwaiter().GetResult();
            Assert.AreEqual(c2 + c3, l.Count);
        }

    }

}

