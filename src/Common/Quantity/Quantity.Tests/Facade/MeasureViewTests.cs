using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Facade;
using Quantity.Facade.Common;
using Sooduskorv_MVC.CommonTests.OverallTests;

namespace Quantity.Tests.Facade
{

    [TestClass] public class MeasureViewTests : SealedClassTests<MeasureView, DefinedView> {

        [TestMethod] public void MeasureTypeTest() => isProperty(() => obj.MeasureType, x => obj.MeasureType = x);

    }

}
