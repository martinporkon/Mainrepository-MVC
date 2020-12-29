using System.Data;
using System.Threading.Tasks;
using Aids.Random;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Domain.Common;

namespace ServicesTests.Quantity.DomainTests
{

    [TestClass]
    public class UnitRulesTests : SealedTests<UnitRules, UnitAttribute<UnitRulesData>>
    {

        [TestMethod]
        public void SystemOfUnitsIdTest()
            => isReadOnlyProperty(obj, nameof(obj.SystemOfUnitsId), obj.Data.SystemOfUnitsId);
        [TestMethod]
        public void FromBaseUnitRuleIdTest() =>
            isReadOnlyProperty(obj, nameof(obj.FromBaseUnitRuleId), obj.Data.FromBaseUnitRuleId);

        [TestMethod]
        public void ToBaseUnitRuleIdTest() =>
            isReadOnlyProperty(obj, nameof(obj.ToBaseUnitRuleId), obj.Data.ToBaseUnitRuleId);


        [TestMethod]
        public async Task SystemOfUnitsTest()
        {
            var d = GetRandom.Object<SystemOfUnitsData>();
            d.Id = obj.SystemOfUnitsId;
            await GetRepository.Instance<ISystemsOfUnitsRepository>().Add(new SystemOfUnits(d));
            arePropertiesEqual(d, obj.SystemOfUnits.Data);
        }
        [TestMethod]
        public void UnitIdTest()
            => isReadOnlyProperty(obj, nameof(obj.UnitId), obj.Data.UnitId);

        [TestMethod]
        public async Task UnitTest()
        {
            var d = GetRandom.Object<UnitData>();
            d.UnitType = UnitType.Factored;
            d.Id = obj.UnitId;
            await GetRepository.Instance<IUnitsRepository>().Add(new FactoredUnit(d));

            arePropertiesEqual(d, obj.Unit.Data);
        }

        [TestMethod]
        public async Task FromBaseUnitRuleTest()
        {
            var r = GetRepository.Instance<IRulesRepository>();
            var d = GetRandom.Object<RuleData>();
            d.Id = obj.FromBaseUnitRuleId;
            d.RuleKind = RuleKind.Rule;
            await r.Add(new Rule(d));
            arePropertiesEqual(d, obj.FromBaseUnitRule.Data);
        }

        [TestMethod]
        public async Task ToBaseUnitRuleTest()
        {
            var r = GetRepository.Instance<IRulesRepository>();
            var d = GetRandom.Object<RuleData>();
            d.Id = obj.ToBaseUnitRuleId;
            d.RuleKind = RuleKind.Rule;
            await r.Add(new Rule(d));
            arePropertiesEqual(d, obj.ToBaseUnitRule.Data);
        }

    }

}