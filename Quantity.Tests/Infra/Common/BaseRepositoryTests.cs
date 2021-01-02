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

    [TestClass] public class BaseRepositoryTests
        : AbstractClassTests<BaseRepository<Measure, MeasureData>, object> {

        private class testClass : BaseRepository<Measure, MeasureData> {

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
        }

        [TestMethod] public void GetTest() {
            var d = GetRandom.Object<MeasureData>();
            var o = obj.Get(d.Id).GetAwaiter().GetResult();
            Assert.IsNotNull(o);
            Assert.IsTrue(o.IsUnspecified);
            obj.dbSet.Add(d);
            o = obj.Get(d.Id).GetAwaiter().GetResult();
            Assert.IsNotNull(o);
            Assert.IsInstanceOfType(o, typeof(Measure));
            arePropertiesEqual(d, o.Data);
        }
        [TestMethod] public void DeleteTest() {
            var d = GetRandom.Object<MeasureData>();
            obj.dbSet.Add(d);
            var o = obj.Get(d.Id).GetAwaiter().GetResult();
            Assert.IsNotNull(o);
            obj.Delete(d.Id).GetAwaiter();
            o = obj.Get(d.Id).GetAwaiter().GetResult();
            Assert.IsTrue(o.IsUnspecified);
        }
        [TestMethod] public void AddTest() {
            var d = GetRandom.Object<MeasureData>();
            var o = obj.Get(d.Id).GetAwaiter().GetResult();
            Assert.IsTrue(o.IsUnspecified);
            obj.Add(MeasureFactory.Create(d)).GetAwaiter();
            o = obj.Get(d.Id).GetAwaiter().GetResult();
            arePropertiesEqual(d, o.Data);
        }
        [TestMethod] public void UpdateTest() {
            var d = GetRandom.Object<MeasureData>();
            var d1 = GetRandom.Object<MeasureData>();
            obj.Add(MeasureFactory.Create(d)).GetAwaiter();
            d1.Id = d.Id;
            obj.Update(MeasureFactory.Create(d1)).GetAwaiter();
            var o = obj.Get(d.Id).GetAwaiter().GetResult();
            arePropertiesEqual(d1, o.Data);
        }
        [TestMethod] public void GetListTest() {
            for (var i = 0; i < GetRandom.UInt8(10, 30); i++) {
                var d = GetRandom.Object<MeasureData>();
                obj.Add(MeasureFactory.Create(d)).GetAwaiter();
            }

            var l = obj.Get().GetAwaiter().GetResult();
            Assert.AreEqual(obj.dbSet.Count(), l.Count);
        }

        [TestMethod] public void GetByIdTest() {
            MeasureData data = new MeasureData();
            var count = GetRandom.UInt8(10, 30);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++) {
                var d = GetRandom.Object<MeasureData>();
                if (i == idx) data = d;
                obj.Add(MeasureFactory.Create(d)).GetAwaiter();
            }

            var m = obj.GetById(data.Id) as Measure;
            Assert.IsNotNull(m);
            arePropertiesEqual(data, m.Data);
        }

    }

}
