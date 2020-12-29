using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Aids.Random;
using Quantity.Core.Calculator;
using Quantity.Domain.Common;
using Aids.Constants;
using Aids.Random;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Domain.Common;
using Quantity.Infra;
using SystemOfUnits = global::Quantity.Core.Units.SystemOfUnits;

namespace ServicesTests.Quantity.DomainTests
{

    [TestClass] public class FunctionedUnitTests : SealedTests<FunctionedUnit, Unit> {

        private MeasuresRepository measures;
        private UnitsRepository units;
        //private RulesRepository rules;
        //private RuleElementsRepository elements;
        private Unit o;
        private string expectedShort;
        private string expectedLong;
        private string expectedMeasure;
        private byte rulesCount;
        private UnitRules siSystemRules;

        [TestMethod] public void DivideTest() {
            addMeasure(obj);
            var u = createObject();
            addMeasure(u);
            o = obj.Divide(u);
            expectedShort = $"{obj.Code} * {u.Code}^-1";
            expectedLong = $"{obj.Name} * {u.Name}^-1";
            expectedMeasure = $"{obj.Measure.Code} * {u.Measure.Code}^-1";
        }

        [TestMethod] public void DivideWithDerivedTest() {
            addMeasure(obj);
            var u = createDerived();
            o = obj.Divide(u);
            expectedShort = $"{obj.Code} * ub * ud^2 * ua^-1 * uc^-2";
            expectedLong = $"{obj.Name} * uub * uud^2 * uua^-1 * uuc^-2";
            expectedMeasure = $"{obj.Measure.Code} * b * d^2 * a^-1 * c^-2";
        }

        [TestMethod] public void DivideWithFactoredTest() {
            addMeasure(obj);
            var u = createFactored();
            addMeasure(u);
            o = obj.Divide(u);
            expectedShort = $"{obj.Code} * {u.Code}^-1";
            expectedLong = $"{obj.Name} * {u.Name}^-1";
            expectedMeasure = $"{obj.Measure.Code} * {u.Measure.Code}^-1";
        }

        [TestMethod] public void FormulaTest() {
            Assert.AreEqual(obj.Code, obj.Formula());
            Assert.AreEqual(obj.Name, obj.Formula(true));
        }

        [TestMethod] public async Task FromBaseTest() {
            await addRules(obj);
            var x = GetRandom.Double(-1000, 1000);
            var d = obj.FromBase(x);
            Assert.AreEqual(x + 274.15, d);
        }

        //[TestMethod] public async Task FromBaseUnitRuleTest() {
        //    await addRulesData(obj);
        //    Assert.AreEqual(siSystemRules.FromBaseUnitRuleId, obj.FromBaseUnitRule.Id);
        //}

        //[TestMethod] public async Task HasRulesTest() {
        //    await addRulesData(obj);

        //    var t = isReadOnlyProperty(obj, nameof(obj.Rules)) as IReadOnlyList<UnitRules>;
        //    Assert.IsNotNull(t);
        //    Assert.AreEqual(Math.Ceiling(rulesCount / 4.0), t.Count);
        //}

        [TestMethod] public void InverseTest() {
            addMeasure(obj);
            o = obj.Inverse();
            expectedShort = $"{obj.Code}^-1";
            expectedLong = $"{obj.Name}^-1";
            expectedMeasure = $"{obj.Measure.Code}^-1";
        }

        [TestMethod] public void MultiplyTest() {
            addMeasure(obj);
            var u = createObject();
            addMeasure(u);
            o = obj.Multiply(u);
            expectedShort = $"{obj.Code} * {u.Code}";
            expectedLong = $"{obj.Name} * {u.Name}";
            expectedMeasure = $"{obj.Measure.Code} * {u.Measure.Code}";
        }

        [TestMethod] public void MultiplyWithDerivedTest() {
            addMeasure(obj);
            var u = createDerived();
            o = obj.Multiply(u);
            expectedShort = $"{obj.Code} * ua * uc^2 * ub^-1 * ud^-2";
            expectedLong = $"{obj.Name} * uua * uuc^2 * uub^-1 * uud^-2";
            expectedMeasure = $"{obj.Measure.Code} * a * c^2 * b^-1 * d^-2";
        }

        [TestMethod] public void MultiplyWithFactoredTest() {
            addMeasure(obj);
            var u = createFactored();
            addMeasure(u);
            o = obj.Multiply(u);
            expectedShort = $"{obj.Code} * {u.Code}";
            expectedLong = $"{obj.Name} * {u.Name}";
            expectedMeasure = $"{obj.Measure.Code} * {u.Measure.Code}";
        }

        [TestMethod] public void PowerTest() {
            addMeasure(obj);
            var i = GetRandom.Int32(-10, 10);
            o = obj.Power(i);
            expectedShort = i == 0 ? Word.UnSpecified : i == 1 ? obj.Code : $"{obj.Code}^{i}";
            expectedLong = i == 0 ? Word.UnSpecified : i == 1 ? obj.Name : $"{obj.Name}^{i}";
            expectedMeasure = i == 0 ? Word.UnSpecified : i == 1 ? obj.Measure.Code : $"{obj.Measure.Code}^{i}";
        }

        [TestMethod] public void RulesTest() {
            Assert.IsNotNull(obj.Rules);
            Assert.AreEqual(0, obj.Rules.Count);
        }

        //[TestMethod] public async Task SiSystemRulesTest() {
        //    await addRulesData(obj);
        //    Assert.IsNotNull(obj.SiSystemRules);
        //}

        //[TestCleanup] public override void TestCleanup() {
        //    validate(o);
        //    var db = measures?.db as QuantityDbContext;
        //    removeAll(db?.Units, db);
        //    removeAll(db?.SystemsOfUnits, db);
        //    removeAll(db?.UnitFactors, db);
        //    removeAll(db?.MeasureTerms, db);
        //    removeAll(db?.Measures, db);
        //    removeAll(db?.UnitTerms, db);
        //    removeAll(db?.UnitRules, db);
        //    removeAll(rules?.dbSet, rules?.db);
        //    removeAll(elements?.dbSet, elements?.db);

        //    measures = null;
        //    units = null;
        //    rules = null;
        //    elements = null;
        //}

        private void validate(Unit u) {
            if (u is null) return;
            Assert.IsNotNull(u);
            Assert.IsInstanceOfType(u, typeof(DerivedUnit));
            Assert.AreEqual(expectedShort, u.Formula());
            Assert.AreEqual(expectedLong, u.Formula(true));
            Assert.AreEqual(expectedMeasure, u.Measure.Formula());
            Assert.AreEqual(u.Id, u.Formula());
            Assert.AreNotEqual(string.Empty, u.Id);
        }

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            measures = GetRepository.Instance<IMeasuresRepository>() as MeasuresRepository;
            //rules = GetRepository.Instance<IRulesRepository>() as RulesRepository;
            //elements = GetRepository.Instance<IRuleElementsRepository>() as RuleElementsRepository;
            units = GetRepository.Instance<IUnitsRepository>() as UnitsRepository;
            rulesCount = GetRandom.UInt8(15, 30);
        }

        [TestMethod] public async Task ToBaseTest() {
            await addRules(obj);
            var x = GetRandom.Double(-1000, 1000);
            var d = obj.ToBase(x);
            Assert.AreEqual(x - 274.15, d);
        }

        //[TestMethod] public async Task ToBaseUnitRuleTest() {
        //    await addRulesData(obj);
        //    Assert.AreEqual(siSystemRules.ToBaseUnitRuleId, obj.ToBaseUnitRule.Id);
        //}

        protected FactoredUnit createFactored() {
            var d = GetRandom.Object<UnitData>();
            d.UnitType = UnitType.Factored;

            return new FactoredUnit(d);
        }

        protected override FunctionedUnit createObject() {
            var d = GetRandom.Object<UnitData>();
            d.UnitType = UnitType.Functioned;

            return new FunctionedUnit(d);
        }

        //private async Task addFromBaseElements(string ruleId) {
        //    await addOperand("x", ruleId);
        //    await addVariable(274.15, ruleId);
        //    await addOperator(Operation.Add, ruleId);
        //}

        private void addMeasure(Unit u) {
            var d = GetRandom.Object<MeasureData>();
            d.Id = u.MeasureId;
            d.MeasureType = MeasureType.Base;
            measures.Add(new BaseMeasure(d)).GetAwaiter();
        }

        //private async Task addOperand(string s, string ruleId) {
        //    var d = new RuleElementData {
        //        Name = s,
        //        RuleElementType = RuleElementType.Operand,
        //        RuleId = ruleId
        //    };
        //    await addRuleElement(d);
        //}

        //private async Task addOperator(Operation op, string ruleId) {
        //    var d = new RuleElementData {
        //        RuleElementType = RuleElementType.Operator,
        //        Operation = op,
        //        RuleId = ruleId
        //    };
        //    await addRuleElement(d);
        //}

        //private async Task addRuleElement(RuleElementData d) {
        //    var index = elements.GetNextElementIndex(true, d.RuleId);
        //    d.Index = index;
        //    await elements.Add(RuleElementFactory.Create(d));
        //}

        private async Task addRules(FunctionedUnit u) {
            var unitRule = GetRandom.Object<UnitRulesData>();
            unitRule.UnitId = u.Id;
            unitRule.SystemOfUnitsId = SystemOfUnits.SiSystemId;
            await GetRepository.Instance<IUnitRulesRepository>().Add(new UnitRules(unitRule));
            //var fromRule = await createRule(unitRule.FromBaseUnitRuleId);
            //var toRule = await createRule(unitRule.ToBaseUnitRuleId);
            //await addFromBaseElements(fromRule.Id);
            //await addToBaseElements(toRule.Id);
        }

        //private async Task addRulesData(Unit u) {
        //    for (var i = 0; i < rulesCount; i++) {
        //        var d = GetRandom.Object<UnitRulesData>();
        //        if (i % 4 == 0) d.UnitId = u.Id;
        //        if (i % 8 == 0 && i < 10 && i > 1)
        //            d.SystemOfUnitsId = SystemOfUnits.SiSystemId;
        //        var f = new UnitRules(d);
        //        await GetRepository.Instance<IUnitRulesRepository>().Add(f);

        //        if (f.SystemOfUnitsId != SystemOfUnits.SiSystemId) continue;
        //        siSystemRules = f;
        //        var fromRule = await createRule(f.FromBaseUnitRuleId);
        //        var toRule = await createRule(f.ToBaseUnitRuleId);
        //        await addFromBaseElements(fromRule.Id);
        //        await addToBaseElements(toRule.Id);
        //    }
        //}

        //private async Task addToBaseElements(string ruleId) {
        //    await addOperand("x", ruleId);
        //    await addVariable(274.15, ruleId);
        //    await addOperator(Operation.Subtract, ruleId);
        //}

        //private async Task addVariable(double v, string ruleId) {
        //    var d = new RuleElementData {
        //        Name = "v",
        //        RuleElementType = RuleElementType.Double,
        //        Value = Variable.ToString(v),
        //        RuleId = ruleId
        //    };
        //    await addRuleElement(d);
        //}

        private Unit createDerived() {
            var d = GetRandom.Object<MeasureData>();
            d.MeasureType = MeasureType.Derived;
            var m = new DerivedMeasure(d);
            new derivedMeasureTestData(m).add();

            var ud = GetRandom.Object<UnitData>();
            ud.UnitType = UnitType.Derived;
            ud.MeasureId = m.Id;
            var u = new DerivedUnit(ud, m);
            new derivedUnitTestData(u).add();

            return u;
        }

        //private async Task<Rule> createRule(string id) {
        //    var d = GetRandom.Object<RuleData>();
        //    d.Id = id;
        //    var r = new Rule(d);
        //    await rules.Add(r);

        //    return r;
        //}

    }

}