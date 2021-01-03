using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Facade;
using Quantity.Facade.Common;
using Sooduskorv_MVC.Aids.Methods;
using Sooduskorv_MVC.CommonTests.OverallTests;

namespace Quantity.Tests.Facade
{

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
