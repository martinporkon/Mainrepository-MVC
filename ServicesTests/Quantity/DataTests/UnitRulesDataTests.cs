using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;

namespace ServicesTests.Quantity.DataTests
{

    [TestClass]
    public class UnitRulesDataTests : SealedTests<UnitRulesData, UnitAttributeData>
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