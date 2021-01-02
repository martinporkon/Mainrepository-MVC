using CommonTests.OverallTests;
using Quantity.Facade;
using Quantity.Facade.Common;

namespace Quantity.Tests.Facade {

    [TestClass] public class CommonTermViewTests : AbstractClassTests<CommonTermView, PeriodView> {

        private class testClass : CommonTermView { }

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = new testClass();
        }

        [TestMethod] public void PowerTest() {
            isProperty(() => obj.Power, x => obj.Power = x);
        }

        [TestMethod] public void TermIdTest() {
            isNullableProperty(() => obj.TermId, x => obj.TermId = x);
        }

        [TestMethod] public void MasterIdTest() {
            isNullableProperty(() => obj.MasterId, x => obj.MasterId = x);
        }
        [TestMethod] public void GetIdTest() {
            var expected = Compose.Id(obj.MasterId, obj.TermId);
            Assert.AreEqual(expected, obj.GetId());
        }

    }

}
