using Aids.Reflection;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Facade.Common;

namespace Quantity.Tests.Facade.Common {

    [TestClass] public class PartyAttributeViewTests : AbstractClassTests<PartyAttributeView, UniqueEntityView> {

        private class testClass : PartyAttributeView { }

        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = new testClass();
        }

        [TestMethod] public void PartyIdTest() {
            isNullableProperty(() => obj.PartyId, x => obj.PartyId = x);
            Assert.AreEqual("Belongs to", GetMember.DisplayName<testClass>(x =>x.PartyId));
        }

    }

}
