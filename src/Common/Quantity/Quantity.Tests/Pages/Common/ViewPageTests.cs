using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Facade;
using Quantity.Pages.Common;
using Sooduskorv_MVC.Aids.Random;

namespace Quantity.Tests.Pages.Common {

    [TestClass] public class ViewPageTests : AbstractPageTests<
        ViewPage<ISystemsOfUnitsRepository, SystemOfUnits, SystemOfUnitsView, SystemOfUnitsData>,
        TitledPage<ISystemsOfUnitsRepository, SystemOfUnits, SystemOfUnitsView, SystemOfUnitsData>> {

        private testRepository repository;
        private int count;
        private string sortOrder;
        private string id;
        private string currentFilter;
        private string searchString;
        private byte pageIndex;
        private string fixedFilter;
        private string fixedValue;
        private byte createSwitch;

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            repository = new testRepository();
            setRandomValues();
            addRandomItems();
            obj = new testClass(repository);
        }

        private void setRandomValues() {
            sortOrder = GetRandom.String();
            id = GetRandom.String();
            currentFilter = GetRandom.String();
            searchString = GetRandom.String();
            pageIndex = GetRandom.UInt8();
            fixedFilter = GetRandom.String();
            fixedValue = GetRandom.String();
            createSwitch = GetRandom.UInt8(0, 10);
        }

        private void addRandomItems() {
            count = GetRandom.UInt8(10, 100);
            for (var i = 0; i < count; i++)
                repository.Add(new SystemOfUnits(GetRandom.Object<SystemOfUnitsData>())).GetAwaiter();
        }

        [TestMethod] public void OnGetIndexAsyncTest() {

            Assert.IsNull(obj.Items);
            obj.OnGetIndexAsync(null, null, null, null, null, null, null).GetAwaiter();
            Assert.AreEqual(count, obj.Items.Count);
        }

        [TestMethod] public void OnGetIndexAsyncArgumentsTest() {

            Assert.IsNull(obj.Items);
            obj.OnGetIndexAsync(sortOrder, id, currentFilter, searchString, pageIndex, fixedFilter, fixedValue)
                .GetAwaiter();
            Assert.AreEqual(0, obj.Items.Count);
            testPageProperties(id, 1);
        }

        [TestMethod] public void OnGetCreateTest() {

            var page = obj.OnGetCreate(sortOrder, searchString, pageIndex, fixedFilter, fixedValue, createSwitch);
            Assert.IsInstanceOfType(page, typeof(PageResult));
            testPageProperties();
        }

        [TestMethod] public void OnPostCreateAsyncTest() {
            obj.Item = GetRandom.Object<SystemOfUnitsView>();
            var o = repository.Get(obj.Item.Id).GetAwaiter().GetResult();
            Assert.IsNull(o);
            obj.OnPostCreateAsync(sortOrder, searchString, pageIndex, fixedFilter, fixedValue).GetAwaiter();
            o = repository.Get(obj.Item.Id).GetAwaiter().GetResult();
            Assert.IsNotNull(o);
            Assert.IsFalse(o.IsUnspecified);
            arePropertiesEqual(obj.Item, o.Data);
            testPageProperties();
        }

        [TestMethod] public void OnGetDeleteAsyncTest() {
            obj.OnGetDeleteAsync(id, sortOrder, searchString, pageIndex, fixedFilter, fixedValue).GetAwaiter();
            arePropertiesEqual(new SystemOfUnitsView(), obj.Item);
            var idx = GetRandom.Int32(0, count);
            var m = repository.list[idx];
            obj.OnGetDeleteAsync(m.Data.Id, sortOrder, searchString, pageIndex, fixedFilter, fixedValue).GetAwaiter();
            arePropertiesEqual(m.Data, obj.Item);
            testPageProperties();
        }

        private void testPageProperties(string selId = null, int? pageIdx = null) {
            Assert.AreEqual(selId, obj.SelectedId);
            Assert.AreEqual(fixedFilter, obj.FixedFilter);
            Assert.AreEqual(fixedValue, obj.FixedValue);
            Assert.AreEqual(searchString, obj.SearchString);
            Assert.AreEqual(pageIdx ?? pageIndex, obj.PageIndex);
            Assert.AreEqual(sortOrder, obj.SortOrder);
        }

        [TestMethod] public void OnPostDeleteAsyncTest() {
            var idx = GetRandom.Int32(0, count);
            var expected = repository.list[idx];
            var actual = repository.Get(expected.Data.Id).GetAwaiter().GetResult();
            arePropertiesEqual(expected.Data, actual.Data);
            obj.OnPostDeleteAsync(expected.Data.Id, sortOrder, searchString, pageIndex, fixedFilter, fixedValue)
                .GetAwaiter().GetResult();
            actual = repository.Get(expected.Data.Id).GetAwaiter().GetResult();
            Assert.IsNull(actual);
            testPageProperties();
        }

        [TestMethod] public void OnGetDetailsAsyncTest() {
            obj.OnGetDetailsAsync(id, sortOrder, searchString, pageIndex, fixedFilter, fixedValue).GetAwaiter();
            arePropertiesEqual(new SystemOfUnitsView(), obj.Item);
            var idx = GetRandom.Int32(0, count);
            var m = repository.list[idx];
            obj.OnGetDeleteAsync(m.Data.Id, sortOrder, searchString, pageIndex, fixedFilter, fixedValue).GetAwaiter();
            arePropertiesEqual(m.Data, obj.Item);
            testPageProperties();

        }

        [TestMethod] public void OnGetEditAsyncTest() {
            obj.OnGetEditAsync(id, sortOrder, searchString, pageIndex, fixedFilter, fixedValue).GetAwaiter();
            arePropertiesEqual(new SystemOfUnitsView(), obj.Item);
            var idx = GetRandom.Int32(0, count);
            var m = repository.list[idx];
            obj.OnGetEditAsync(m.Data.Id, sortOrder, searchString, pageIndex, fixedFilter, fixedValue).GetAwaiter();
            arePropertiesEqual(m.Data, obj.Item);
            testPageProperties();
        }

        [TestMethod] public void OnPostEditAsyncTest() {
            obj.Item = GetRandom.Object<SystemOfUnitsView>();
            var o = repository.Get(obj.Item.Id).GetAwaiter().GetResult();
            Assert.IsNull(o);
            obj.OnPostEditAsync(sortOrder, searchString, pageIndex, fixedFilter, fixedValue).GetAwaiter();
            o = repository.Get(obj.Item.Id).GetAwaiter().GetResult();
            Assert.IsNotNull(o);
            Assert.IsFalse(o.IsUnspecified);
            arePropertiesEqual(o.Data, obj.Item);
            testPageProperties();
        }

    }

}
