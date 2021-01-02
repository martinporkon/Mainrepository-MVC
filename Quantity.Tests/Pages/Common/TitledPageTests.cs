using Quantity.Data;
using Quantity.Domain;
using Quantity.Facade;
using Quantity.Pages.Common;

namespace Quantity.Tests.Pages.Common {

    [TestClass] public class TitledPageTests
        : AbstractPageTests<TitledPage<ISystemsOfUnitsRepository, SystemOfUnits, SystemOfUnitsView, SystemOfUnitsData>
            , PagedPage<ISystemsOfUnitsRepository, SystemOfUnits, SystemOfUnitsView, SystemOfUnitsData>> {

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = new testClass(new testRepository());
        }

        [TestMethod] public void ItemIdTest() {
            obj.Item = GetRandom.Object<SystemOfUnitsView>();
            Assert.AreEqual(obj.Item.Id, obj.ItemId);
        }

        [TestMethod] public void PageTitleTest() {
            isReadOnlyProperty(obj, nameof(obj.PageTitle), obj.PageTitle);
        }

        [TestMethod] public void PageSubTitleTest() {
            isReadOnlyProperty(obj, nameof(obj.PageSubTitle), obj.pageSubtitle());
        }

        [TestMethod] public void GetPageSubtitleTest() {
            Assert.AreEqual(obj.PageSubTitle, obj.pageSubtitle());
        }

        [TestMethod] public void PageUrlTest() {
            isReadOnlyProperty(obj, nameof(obj.PageUrl), obj.pageUrl());
        }

        [TestMethod] public void GetPageUrlTest() {
            Assert.AreEqual(obj.PageUrl, obj.pageUrl());
        }

        //[TestMethod] public void IndexUrlTest() {
        //    isReadOnlyProperty(obj.indexUrl());
        //}

        //[TestMethod] public void CreateUrlTest() {
        //    isReadOnlyProperty( obj.createUrl());
        //}


        [TestMethod] public void GetIndexUrlTest() {
            Assert.AreEqual(obj.IndexUrl, obj.indexUrl());
        }

        [TestMethod] public void IsMasterDetailTest() {
            Assert.IsFalse(obj.IsMasterDetail());
            ((testClass) obj).subTitle = GetRandom.String();
            obj.FixedValue = GetRandom.String();
            Assert.IsTrue(obj.IsMasterDetail());
        }

    }

}
