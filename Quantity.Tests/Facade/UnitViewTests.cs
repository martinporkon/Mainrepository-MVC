using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Facade;
using Quantity.Facade.Common;
using Sooduskorv_MVC.CommonTests.OverallTests;

namespace Quantity.Tests.Facade
{

    [TestClass] public class UnitViewTests : SealedClassTests<UnitView, DefinedView> {

        [TestMethod] public void MeasureIdTest()
            => isNullableProperty(() => obj.MeasureId, x => obj.MeasureId = x);

        [TestMethod] public void UnitTypeTest()
            => isProperty(() => obj.UnitType, x => obj.UnitType = x);

    }

}
