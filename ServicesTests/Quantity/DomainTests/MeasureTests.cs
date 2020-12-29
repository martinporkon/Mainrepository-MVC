using Aids.Random;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Data;
using Quantity.Domain;
using Quantity.Domain.Common;

namespace ServicesTests.Quantity.DomainTests
{

    [TestClass] public class MeasureTests : AbstractClassTests<Measure, CommonMetric<MeasureData>> {

        [TestMethod] public void DivideTest() {
            testDivide(new BaseMeasure(new MeasureData()), "Derived");
            testDivide(new DerivedMeasure(new MeasureData()), "Derived");
        }

        [TestMethod] public void FormulaTest() {
            Assert.AreEqual("True", obj.Formula(true));
            Assert.AreEqual("False", obj.Formula());
        }

        [TestMethod] public void InverseTest() {
            var x = obj.Inverse();
            Assert.IsNotNull(x);
            Assert.AreEqual("Power" + -1, (obj as testClass)?.result);
        }

        [TestMethod] public void MultiplyTest() {
            testMultiply(new BaseMeasure(new MeasureData()), "Base");
            testMultiply(new DerivedMeasure(new MeasureData()), "Derived");
        }

        [TestMethod] public void PowerTest() {
            var i = GetRandom.Int32();
            var x = obj.Power(i);
            Assert.IsNotNull(x);
            Assert.AreEqual("Power" + i, (obj as testClass)?.result);
        }

        [TestMethod] public void SqrtTest() {
            validate(obj.Sqrt(), "Sqrt");
        }

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = new testClass(GetRandom.Object<MeasureData>());
        }

        [TestMethod] public void UnitsTest() {
            getListFromRepository<Unit, UnitData, IUnitsRepository>(
                d => d.MeasureId = obj.Id,
                UnitFactory.Create);
        }

        private void testDivide(Measure m, string r) {
            validate(obj.Divide(m), r);
        }

        private void testMultiply(Measure m, string r) {
            validate(obj.Multiply(m), r);
        }

        private void validate(Measure u, string s) {
            Assert.IsNotNull(u);
            var o = obj as testClass;
            Assert.AreEqual(s, o?.result);

            if (o is null) return;
            o.result = "";
        }

        private class testClass : Measure {

            internal string result;

            public testClass(MeasureData d) : base(d) { }

            protected override string formula(bool isLong = false) {
                return isLong.ToString();
            }

            protected override Measure multiply(DerivedMeasure m, string n = null, string c = null, string d = null) {
                result += "Derived";

                return new DerivedMeasure(new MeasureData());
            }

            protected override Measure multiply(BaseMeasure m, string n = null, string c = null, string d = null) {
                result += "Base";

                return new DerivedMeasure(new MeasureData());
            }

            protected override Measure power(in int power, string n = null, string c = null, string d = null) {
                result += "Power" + power;

                return new DerivedMeasure(new MeasureData());
            }

            protected override Measure toSqrt(string n = null, string c = null, string d = null) {
                result += "Sqrt";

                return new DerivedMeasure(new MeasureData());
            }

        }

    }

}