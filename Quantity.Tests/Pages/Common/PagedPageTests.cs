using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Facade;
using Quantity.Pages.Common;
using Sooduskorv_MVC.Aids.Random;

namespace Quantity.Tests.Pages.Common {

    [TestClass] public class PagedPageTests : AbstractPageTests<
        PagedPage<ISystemsOfUnitsRepository, SystemOfUnits, SystemOfUnitsView, SystemOfUnitsData>,
        CrudPage<ISystemsOfUnitsRepository, SystemOfUnits, SystemOfUnitsView, SystemOfUnitsData>> {

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = new testClass(db);
        }

        [TestMethod] public void ItemsTest() {
            isReadOnlyProperty(obj, nameof(obj.Items), null);
        }

        [TestMethod] public void PageIndexTest() {
            var i = GetRandom.UInt8(3);
            obj.PageIndex = i;
            Assert.AreEqual(i, db.PageIndex);
            Assert.AreEqual(i, obj.PageIndex);
        }

        [TestMethod] public void HasPreviousPageTest() {
            db.HasPreviousPage = GetRandom.Bool();
            isReadOnlyProperty(obj, nameof(obj.HasPreviousPage), db.HasPreviousPage);
        }

        [TestMethod] public void HasNextPageTest() {
            db.HasNextPage = GetRandom.Bool();
            isReadOnlyProperty(obj, nameof(obj.HasNextPage), db.HasNextPage);
        }

        [TestMethod] public void TotalPagesTest() {
            db.TotalPages = GetRandom.UInt8();
            isReadOnlyProperty(obj, nameof(obj.TotalPages), db.TotalPages);
        }

        [TestMethod] public void GetListTest() {
            Assert.IsNull(obj.Items);
            var sortOrder = GetRandom.String();
            var currentFilter = GetRandom.String();
            var searchString = GetRandom.String();
            var fixedFilter = GetRandom.String();
            var fixedValue = GetRandom.String();
            var pageIndex = GetRandom.UInt8();
            obj.getList(sortOrder, currentFilter, searchString, pageIndex, fixedFilter, fixedValue).GetAwaiter();
            Assert.IsNotNull(obj.Items);
            Assert.AreEqual(sortOrder, obj.SortOrder);
            Assert.AreEqual(searchString, obj.SearchString);
            Assert.AreEqual(fixedFilter, obj.FixedFilter);
            Assert.AreEqual(fixedValue, obj.FixedValue);
            Assert.AreEqual(1, obj.PageIndex);
        }

        //[TestMethod] public void GetListNoArgumentsTest() {
        //    var l = obj.getList().GetAwaiter().GetResult();
        //    Assert.AreEqual(0, l.Count);

        //    for (var i = 0; i < GetRandom.UInt8(); i++) {
        //        var d = GetRandom.Object<SystemOfUnitsData>();
        //        db.Add(new SystemOfUnits(d)).GetAwaiter();
        //        l = obj.getList().GetAwaiter().GetResult();
        //        Assert.AreEqual(i + 1, l.Count);
        //    }
        //}

        [TestMethod] public void SelectedIdTest() {
            isNullableProperty(()=>obj.SelectedId, x => obj.SelectedId = x);
        }
    }

}
