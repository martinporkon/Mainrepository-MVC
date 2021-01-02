using Quantity.Data;
using Quantity.Domain;
using Quantity.Facade;
using Quantity.Pages.Common;

namespace Quantity.Tests.Pages.Common {

    [TestClass]
    public class CrudPageTests : AbstractPageTests<CrudPage<ISystemsOfUnitsRepository, SystemOfUnits, SystemOfUnitsView, SystemOfUnitsData>,
        BasePage<ISystemsOfUnitsRepository, SystemOfUnits, SystemOfUnitsView, SystemOfUnitsData>> {

        private string fixedFilter;
        private string fixedValue;

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = new testClass(db);
            fixedFilter = GetRandom.String();
            fixedValue = GetRandom.String();
            Assert.AreEqual(null, obj.FixedValue);
            Assert.AreEqual(null, obj.FixedFilter);
        }

        [TestMethod] public void ItemTest() {
            isProperty(() => obj.Item, x => obj.Item = x);
        }

        [TestMethod] public void AddObjectTest() {
            var idx = db.list.Count;
            obj.Item = GetRandom.Object<SystemOfUnitsView>();
            obj.addObject(fixedFilter, fixedValue).GetAwaiter();
            Assert.AreEqual(fixedFilter, obj.FixedFilter);
            Assert.AreEqual(fixedValue, obj.FixedValue);
            arePropertiesEqual(obj.Item, db.list[idx].Data);
        }

        [TestMethod] public void UpdateObjectTest() {
            GetObjectTest();
            var idx = GetRandom.Int32(0, db.list.Count);
            var itemId = db.list[idx].Data.Id;
            obj.Item = GetRandom.Object<SystemOfUnitsView>();
            obj.Item.Id = itemId;
            obj.updateObject(fixedFilter, fixedValue).GetAwaiter();
            arePropertiesEqual(db.list[^1].Data, obj.Item);
        }

        [TestMethod] public void GetObjectTest() {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);
            for (var i = 0; i < count; i++) AddObjectTest();
            var item = db.list[idx];
            obj.getObject(item.Data.Id, fixedFilter, fixedValue).GetAwaiter();
            Assert.AreEqual(count, db.list.Count);
            arePropertiesEqual(item.Data, obj.Item);
        }

        [TestMethod] public void DeleteObjectTest() {
            AddObjectTest();
            obj.deleteObject(obj.Item.Id, fixedFilter, fixedValue).GetAwaiter();
            Assert.AreEqual(fixedFilter, obj.FixedFilter);
            Assert.AreEqual(fixedValue, obj.FixedValue);
            Assert.AreEqual(0, db.list.Count);
        }

        [TestMethod] public void ToViewTest() {
            var d = GetRandom.Object<SystemOfUnitsData>();
            var v = obj.toView(new SystemOfUnits(d));
            arePropertiesEqual(d, v);
        }

        [TestMethod] public void ToObjectTest() {
            var v = GetRandom.Object<SystemOfUnitsView>();
            var o = obj.toObject(v);
            arePropertiesEqual(v, o.Data);
        }

        [TestMethod] public void ItemIdTest() {
            obj.Item = GetRandom.Object<SystemOfUnitsView>();
            Assert.AreEqual(obj.Item.GetId(),obj.ItemId);
        }
    }

}
