using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Facade;
using Quantity.Facade.Common;

namespace Quantity.Tests.Facade {

    [TestClass] public class MeasureViewTests : SealedClassTests<MeasureView, DefinedView> {

        [TestMethod] public void MeasureTypeTest() => isProperty(() => obj.MeasureType, x => obj.MeasureType = x);

    }

}
