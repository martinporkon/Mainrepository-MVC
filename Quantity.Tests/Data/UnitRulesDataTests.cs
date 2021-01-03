using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Sooduskorv_MVC.CommonTests.OverallTests;

namespace Quantity.Tests.Data
{

    [TestClass]
    public class UnitRulesDataTests : SealedClassTests<UnitRulesData, UnitAttributeData>
    {
        [TestMethod]
        public void FromBaseUnitRuleIdTest()
            => isNullableProperty(() => obj.FromBaseUnitRuleId, x => obj.FromBaseUnitRuleId = x);

        [TestMethod]
        public void ToBaseUnitRuleIdTest()
            => isNullableProperty(() => obj.ToBaseUnitRuleId, x => obj.ToBaseUnitRuleId = x);

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