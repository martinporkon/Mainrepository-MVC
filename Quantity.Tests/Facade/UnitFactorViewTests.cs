using Aids.Methods;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Facade;
using Quantity.Facade.Common;

namespace Quantity.Tests.Facade {

    [TestClass] public class UnitFactorViewTests : SealedClassTests<UnitFactorView, PeriodView> {


        [TestMethod] public void UnitIdTest() =>
            isNullableProperty(() => obj.UnitId, x => obj.UnitId = x);

        [TestMethod] public void SystemOfUnitsIdTest() 
        => isNullableProperty(() => obj.SystemOfUnitsId, x => obj.SystemOfUnitsId = x);

        [TestMethod] public void FactorTest()  
            => isProperty(() => obj.Factor, x => obj.Factor = x);

        [TestMethod] public void GetIdTest() {
            var expected = Compose.Id(obj.SystemOfUnitsId, obj.UnitId);
            Assert.AreEqual(expected, obj.GetId());
        }

    }

}
