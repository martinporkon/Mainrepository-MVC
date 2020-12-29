using Abc.Aids.Constants;
using Aids.Constants;
using Aids.Random;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Domain.Common;
using Quantity.Infra;

namespace ServicesTests.Quantity.DomainTests
{

    [TestClass] public class FactoredUnitTests : SealedTests<FactoredUnit, Unit> {

        private double factorsCount;
        private UnitFactorsRepository factors;
        private MeasuresRepository measures;
        private UnitFactor siSystemFactor;
        private Unit o;
        private string expectedShort;
        private string expectedLong;
        private string expectedMeasure;

        protected override FactoredUnit createObject() {
            var d = GetRandom.Object<UnitData>();
            d.UnitType = UnitType.Factored;

            return new FactoredUnit(d);
        }

        protected FunctionedUnit createFunctioned() {
            var d = GetRandom.Object<UnitData>();
            d.UnitType = UnitType.Functioned;

            return new FunctionedUnit(d);
        }

        private static Unit createDerived() {
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

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            factorsCount = GetRandom.UInt8(15, 30);
            factors = GetRepository.Instance<IUnitFactorsRepository>() as UnitFactorsRepository;
            measures = GetRepository.Instance<IMeasuresRepository>() as MeasuresRepository;
            addAll(obj);
        }

        //[TestCleanup] public override void TestCleanup() {
        //    validate(o);
        //    removeAll(measures?.dbSet, measures?.db);
        //    removeAll(factors?.dbSet, factors?.db);

        //    factors = null;
        //    measures = null;

        //    base.TestCleanup();
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

        //[TestMethod] public void FactorsTest() {
        //    removeAll(factors?.dbSet, factors?.db);
        //    getListFromRepository<UnitFactor, UnitFactorData, IUnitFactorsRepository>(
        //        d => d.UnitId = obj.Id, d => new UnitFactor(d));
        //}


        //[TestMethod] public void MeasureTest() {
        //    removeAll(measures?.dbSet, measures?.db);
        //    getFromRepository<MeasureData, Measure, IMeasuresRepository>(
        //        obj.MeasureId, () => obj.Measure.Data, MeasureFactory.Create);
        //}

        [TestMethod] public void SiSystemFactorTest() => Assert.IsNotNull(obj.SiSystemFactor);

        [TestMethod] public void FactorTest() => Assert.AreEqual(siSystemFactor.Factor, obj.Factor);

        [TestMethod] public void ToBaseTest() {
            var d = GetRandom.Double(-10000, 10000);
            Assert.AreEqual(d * siSystemFactor.Factor, obj.ToBase(d));
        }

        [TestMethod] public void FromBaseTest() {
            var d = GetRandom.Double(-10000, 10000);
            Assert.AreEqual(d / siSystemFactor.Factor, obj.FromBase(d));
        }

        [TestMethod] public void FormulaTest() {
            Assert.AreEqual(obj.Code, obj.Formula());
            Assert.AreEqual(obj.Name, obj.Formula(true));
        }

        [TestMethod] public void InverseTest() {
            o = obj.Inverse();
            expectedShort = $"{obj.Code}^-1";
            expectedLong = $"{obj.Name}^-1";
            expectedMeasure = $"{obj.Measure.Code}^-1";
        }

        [TestMethod] public void PowerTest() {
            var i = GetRandom.Int32(-10, 10);
            o = obj.Power(i);
            expectedShort = i == 0 ? Word.UnSpecified : i == 1 ? obj.Code : $"{obj.Code}^{i}";
            expectedLong = i == 0 ? Word.UnSpecified : i == 1 ? obj.Name : $"{obj.Name}^{i}";
            expectedMeasure = i == 0 ? Word.UnSpecified : i == 1 ? obj.Measure.Code : $"{obj.Measure.Code}^{i}";
        }

        [TestMethod] public void MultiplyTest() {
            var u = createObject();
            addAll(u);
            o = obj.Multiply(u);
            expectedShort = $"{obj.Code} * {u.Code}";
            expectedLong = $"{obj.Name} * {u.Name}";
            expectedMeasure = $"{obj.Measure.Code} * {u.Measure.Code}";
        }

        [TestMethod] public void MultiplyWithFunctionedTest() {
            var u = createFunctioned();
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

        [TestMethod] public void DivideTest() {
            var u = createObject();
            addMeasure(u);
            o = obj.Divide(u);
            expectedShort = $"{obj.Code} * {u.Code}^-1";
            expectedLong = $"{obj.Name} * {u.Name}^-1";
            expectedMeasure = $"{obj.Measure.Code} * {u.Measure.Code}^-1";
        }

        [TestMethod] public void DivideWithFunctionedTest() {
            var u = createFunctioned();
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

        private void addAll(Unit u) {
            addMeasure(u);
            addFactors(u);
        }

        private void addMeasure(Unit u) {
            var d = GetRandom.Object<MeasureData>();
            d.Id = u.MeasureId;
            d.MeasureType = MeasureType.Base;
            measures.Add(new BaseMeasure(d)).GetAwaiter();

        }

        private void addFactors(Unit u) {

            for (var i = 0; i < factorsCount; i++) {
                var d = GetRandom.Object<UnitFactorData>();
                d.Factor = GetRandom.Double(-10, 10);
                if (i % 4 == 0) d.UnitId = u.Id;
                if (i % 8 == 0 && i < 10 && i > 1)
                    d.SystemOfUnitsId = global::Quantity.Core.Units.SystemOfUnits.SiSystemId;
                var f = new UnitFactor(d);
                factors.Add(f).GetAwaiter();
                if (f.SystemOfUnitsId == global::Quantity.Core.Units.SystemOfUnits.SiSystemId)
                    siSystemFactor = f;
            }
        }

    }

}
