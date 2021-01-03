using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Facade;
using Quantity.Pages.Common;
using Sooduskorv_MVC.CommonTests.OverallTests;
using System;
using Quantity.Pages.Common.Consts;

namespace Quantity.Tests.Pages.Common
{

    public abstract class AbstractPageTests<TClass, TBaseClass> : AbstractClassTests<TClass, TBaseClass>
        where TClass : BasePage<ISystemsOfUnitsRepository, SystemOfUnits, SystemOfUnitsView, SystemOfUnitsData>
    {

        internal testRepository db;
        internal class testClass : ViewsPage<ISystemsOfUnitsRepository, SystemOfUnits, SystemOfUnitsView, SystemOfUnitsData>
        {

            internal string subTitle { get; set; } = string.Empty;

            protected internal testClass(ISystemsOfUnitsRepository r) : base(r, QuantityPagesNames.SystemsOfUnits) { }

            public override Uri pageUrl() => new Uri(QuantityPagesUrls.SystemsOfUnits, UriKind.Relative);

            public override SystemOfUnits toObject(SystemOfUnitsView view) => SystemOfUnitsViewFactory.Create(view);

            public override SystemOfUnitsView toView(SystemOfUnits obj) => SystemOfUnitsViewFactory.Create(obj);

            public override string pageSubtitle() => subTitle;

        }

        internal class testRepository : uniqueRepository<SystemOfUnits, SystemOfUnitsData>, ISystemsOfUnitsRepository { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            db = new testRepository();
        }

    }

}
