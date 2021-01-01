using System;
using Aids.Random;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Facade;
using Quantity.Pages.Common;

namespace Quantity.Tests.Pages.Common {

    [TestClass]
    public class BasePageTests : AbstractPageTests<BasePage<ISystemsOfUnitsRepository, 
            SystemOfUnits, SystemOfUnitsView, SystemOfUnitsData>,
        PageModel> {


        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = new testClass(db);
        }

        [TestMethod] public void FixedValueTest() {
            var s = GetRandom.String();
            obj.FixedValue = s;
            Assert.AreEqual(s, db.FixedValue);
            Assert.AreEqual(s, obj.FixedValue);
        }

        [TestMethod] public void FixedFilterTest() {
            var s = GetRandom.String();
            obj.FixedFilter = s;
            Assert.AreEqual(s, db.FixedFilter);
            Assert.AreEqual(s, obj.FixedFilter);
        }

        [TestMethod] public void SetFixedFilterTest() {
            var filter = GetRandom.String();
            var value = GetRandom.String();
            obj.setFixedFilter(filter, value);
            Assert.AreEqual(filter, obj.FixedFilter);
            Assert.AreEqual(value, obj.FixedValue);
        }

        [TestMethod] public void SortOrderTest() {
            var s = GetRandom.String();
            obj.SortOrder = s;
            Assert.AreEqual(s, db.SortOrder);
            Assert.AreEqual(s, obj.SortOrder);
        }

        [TestMethod]
        public void CurrentFilterTest()
        {
            var s = GetRandom.String();
            obj.CurrentFilter = s;
            Assert.AreEqual(s, db.CurrentFilter);
            Assert.AreEqual(s, obj.CurrentFilter);
        }

        [TestMethod] public void GetSortOrderTest() {
            void test(string sortOrder, string name, bool isDesc) {
                obj.SortOrder = sortOrder;
                var actual = obj.getSortOrder(name);
                var expected = isDesc ? name + "_desc" : name;
                Assert.AreEqual(expected, actual);
            }
            test(null, GetRandom.String(), false);
            test(GetRandom.String(), GetRandom.String(), false);
            var s = GetRandom.String();
            test(s, s, true);
            test(s+"_desc", s, false);
        }

        [TestMethod] public void SearchStringTest() {
            var s = GetRandom.String();
            obj.SearchString = s;
            Assert.AreEqual(s, db.SearchString);
            Assert.AreEqual(s, obj.SearchString);
        }

        [TestMethod] public void GetSortStringTest() {
            var page = new Uri( "xxx/yyy", UriKind.Relative);
            obj.SortOrder = "Code";
            obj.SearchString = "AAA";
            obj.FixedFilter = "BBB";
            obj.FixedValue = "CCC";
            obj.CurrentFilter = "DDD";
            var sortString = obj.GetSortString(x=>x.Code, page);
            var s = "xxx/yyy?handler=Index&sortOrder=Code_desc&currentFilter=DDD&searchString=AAA&fixedFilter=BBB&fixedValue=CCC";
            Assert.AreEqual(s, sortString.ToString());
        }

        [TestMethod] public void GetSearchStringTest() {
            static void test(string filter, string searchString, int? pageIndex, bool isFirst) {
                var expectedIndex = isFirst ? 1 : pageIndex;
                var actual = BasePage<IMeasuresRepository, Measure, MeasureView, MeasureData>.getCurrentFilter(filter, searchString, ref pageIndex);
                Assert.AreEqual(searchString, actual);
                Assert.AreEqual(expectedIndex, pageIndex);
            }
            test(GetRandom.String(), GetRandom.String(), GetRandom.UInt8(3), true);
            test(GetRandom.String(), null, GetRandom.UInt8(3), true);
            var s = GetRandom.String();
            test(s, s, GetRandom.UInt8(3), false);
        }


    }

}
