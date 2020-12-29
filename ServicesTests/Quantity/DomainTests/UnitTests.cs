using Aids.Random;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Domain.Common;

namespace ServicesTests.Quantity.DomainTests
{

    [TestClass] public class UnitTests : AbstractClassTests<Unit, CommonMetric<UnitData>> {

        private class testClass : Unit {

            internal string result;

            public testClass(UnitData d) : base(d) { }

            public override double ToBase(in double amount) => amount;

            public override double FromBase(in double amount) => amount;

            protected override Unit multiply(DerivedUnit m, string n = null, string c = null, string d = null) {
                result += "Derived";

                return new DerivedUnit(new UnitData());
            }

            protected override Unit multiply(FactoredUnit m, string n = null, string c = null, string d = null) {
                result += "Factored";

                return new DerivedUnit(new UnitData());
            }

            protected override Unit multiply(FunctionedUnit m, string n = null, string c = null, string d = null) {
                result += "Functioned";

                return new DerivedUnit(new UnitData());
            }

            protected override Unit toPower(in int power, string n = null, string c = null, string d = null) {
                result += ("ToPower" + power);

                return new DerivedUnit(new UnitData());
            }

            protected override string formula(bool isLong = false) => isLong.ToString();

            protected override Unit sqrt(string n = null, string c = null, string d = null) {
                result += "Sqrt";

                return new DerivedUnit(new UnitData());
            }

        }

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = new testClass(GetRandom.Object<UnitData>());
        }

        [TestMethod] public void MeasureIdTest() => isReadOnlyProperty(obj, nameof(obj.MeasureId), obj.Data.MeasureId);

        [TestMethod] public void MeasureTest() {
            var m = GetRandom.Object<MeasureData>();
            m.MeasureType = MeasureType.Base;
            m.Id = obj.MeasureId;
            GetRepository.Instance<IMeasuresRepository>().Add(new BaseMeasure(m)).GetAwaiter();
            arePropertiesEqual(m, obj.Measure.Data);
        }

        [TestMethod] public void DivideTest() {
            testDivide(new FunctionedUnit(new UnitData()), "Derived");
            testDivide(new FactoredUnit(new UnitData()), "Derived");
            testDivide(new DerivedUnit(new UnitData()), "Derived");
        }

        [TestMethod] public void SqrtTest() => validate(obj.Sqrt(), "Sqrt");

        private void validate(Unit u, string s) {
            Assert.IsNotNull(u);
            var o = obj as testClass;
            Assert.AreEqual(s, o?.result);

            if (o is null) return;
            o.result = "";
        }

        [TestMethod] public void MultiplyTest() {
            testMultiply(new FunctionedUnit(new UnitData()), "Functioned");
            testMultiply(new FactoredUnit(new UnitData()), "Factored");
            testMultiply(new DerivedUnit(new UnitData()), "Derived");
        }

        [TestMethod] public void InverseTest() {
            var x = obj.Inverse();
            Assert.IsNotNull(x);
            Assert.AreEqual("ToPower" + -1, (obj as testClass)?.result);
        }

        [TestMethod] public void PowerTest() {
            var i = GetRandom.Int32();
            var x = obj.Power(i);
            Assert.IsNotNull(x);
            Assert.AreEqual("ToPower" + i, (obj as testClass)?.result);
        }

        [TestMethod] public void FormulaTest() {
            Assert.AreEqual("True", obj.Formula(true));
            Assert.AreEqual("False", obj.Formula());
        }

        [TestMethod] public void ToBaseTest() => isAbstractMethod(nameof(obj.ToBase));

        [TestMethod] public void FromBaseTest() => isAbstractMethod(nameof(obj.FromBase));

        private void testMultiply(Unit u, string r) => validate(obj.Multiply(u), r);

        private void testDivide(Unit u, string r) => validate(obj.Divide(u), r);

    }

}