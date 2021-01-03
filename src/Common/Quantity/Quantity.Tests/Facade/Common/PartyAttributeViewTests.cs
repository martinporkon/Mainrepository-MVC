using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Facade.Common;
using Sooduskorv_MVC.Aids.Reflection;
using Sooduskorv_MVC.CommonTests.OverallTests;

namespace Quantity.Tests.Facade.Common
{

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
