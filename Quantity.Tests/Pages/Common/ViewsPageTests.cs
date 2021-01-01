using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Facade;
using Quantity.Pages.Common;

namespace Quantity.Tests.Pages.Common {

    [TestClass] public class ViewsPageTests : AbstractPageTests<
        ViewsPage<ISystemsOfUnitsRepository, SystemOfUnits, SystemOfUnitsView, SystemOfUnitsData>,
        ViewPage<ISystemsOfUnitsRepository, SystemOfUnits, SystemOfUnitsView, SystemOfUnitsData>> {

        private testRepository repository;
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            repository = new testRepository();
            obj = new testClass(repository);
        }
    }

}
