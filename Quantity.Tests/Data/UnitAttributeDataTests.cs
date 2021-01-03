using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Sooduskorv_MVC.Aids.Random;
using Sooduskorv_MVC.CommonTests.OverallTests;
using Sooduskorv_MVC.Data.CommonData;

namespace Quantity.Tests.Data
{
    [TestClass]
    public class UnitAttributeDataTests: AbstractClassTests<UnitAttributeData, PeriodData> {

        private class testClass : UnitAttributeData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = GetRandom.Object<testClass>();
        }
        [TestMethod]
        public void SystemOfUnitsIdTest()
        {
            isNullableProperty(() => obj.SystemOfUnitsId, x => obj.SystemOfUnitsId = x);
        }
        [TestMethod]
        public void UnitIdTest()
        {
            isNullableProperty(() => obj.UnitId, x => obj.UnitId = x);
        }
    }
}
