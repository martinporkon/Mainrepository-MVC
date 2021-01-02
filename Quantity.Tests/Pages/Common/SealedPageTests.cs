using Quantity.Domain.Common;
using Quantity.Facade.Common;
using Quantity.Pages.Common;

namespace Quantity.Tests.Pages.Common {

    public abstract class SealedPageTests<TClass, TBaseClass, TRepository, TObj, TView, TData>
        : BaseSealedTests<TClass, TBaseClass>
        where TClass : ViewPage<TRepository, TObj, TView, TData>
        where TRepository : class, ICrudMethods<TObj>, ISorting, IFiltering, IPaging
        where TObj : IEntity<TData>
        where TData : PeriodData, new()
        where TView : PeriodView {

        protected string sortOrder;
        protected string searchString;
        protected byte pageIndex;
        protected string fixedFilter;
        protected string fixedValue;
        protected byte createSwitch;

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            sortOrder = GetRandom.String();
            searchString = GetRandom.String();
            pageIndex = GetRandom.UInt8();
            fixedFilter = GetRandom.String();
            fixedValue = GetRandom.String();
            createSwitch = GetRandom.UInt8(0, 10);
        }

        [TestMethod] public void ItemIdTest() {
            var item = GetRandom.Object<TView>();
            obj.Item = item;
            Assert.AreEqual(getId(item), obj.ItemId);
            obj.Item = null;
            Assert.AreEqual(string.Empty, obj.ItemId);
        }

        protected abstract string getId(TView item);

        [TestMethod] public void PageTitleTest() => Assert.AreEqual(pageTitle(), obj.PageTitle);

        protected abstract string pageTitle();

        [TestMethod] public void PageUrlTest() => Assert.AreEqual(pageUrl(), obj.PageUrl.ToString());

        protected abstract string pageUrl();

        [TestMethod] public virtual void ToObjectTest() {
            var view = GetRandom.Object<TView>();
            var o = obj.toObject(view);
            arePropertiesEqual(view, o.Data);
        }

        [TestMethod] public virtual void ToViewTest() {
            var d = GetRandom.Object<TData>();
            var view = obj.toView(createObj(d));
            arePropertiesEqual(view, d);
        }

        protected abstract TObj createObj(TData d);

        protected void testPageProperties(string selId = null, int? pageIdx = null) {
            Assert.AreEqual(selId, obj.SelectedId);
            Assert.AreEqual(fixedFilter, obj.FixedFilter);
            Assert.AreEqual(fixedValue, obj.FixedValue);
            Assert.AreEqual(searchString, obj.SearchString);
            Assert.AreEqual(pageIdx ?? pageIndex, obj.PageIndex);
            Assert.AreEqual(sortOrder, obj.SortOrder);
        }

    }

}