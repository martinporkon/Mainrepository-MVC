using Aids.Random;
using Aids.Reflection;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Facade.Common;

namespace Quantity.Tests.Facade.Common {

    [TestClass]
    public class PartySignatureBaseViewTests : AbstractClassTests<PartySignatureBaseView, PartyAttributeView> {

        private class testClass : PartySignatureBaseView { }
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize();
            obj = GetRandom.Object<testClass>();
        }
        [TestMethod] public void AuthenticationIdTest() {
            isNullableProperty(() => obj.AuthenticationId, x => obj.AuthenticationId = x);
            Assert.AreEqual("Authentication",
                GetMember.DisplayName<PartySignatureBaseView>(x => x.AuthenticationId));
        }
        [TestMethod] public void SignedEntityIdTest() {
            isNullableProperty(() => obj.SignedEntityId, x => obj.SignedEntityId = x);
            Assert.AreEqual("Signed Entity",
                GetMember.DisplayName<PartySignatureBaseView>(x => x.SignedEntityId));
        }
        [TestMethod] public void SignedEntityTypeIdTest() {
            isNullableProperty(() => obj.SignedEntityTypeId, x => obj.SignedEntityTypeId = x);
            Assert.AreEqual("Signed Entity Type",
                GetMember.DisplayName<PartySignatureBaseView>(x => x.SignedEntityTypeId));
        }
        [TestMethod] public void PartySummaryIdTest() {
            isNullableProperty(() => obj.PartySummaryId, x => obj.PartySummaryId = x);
            Assert.AreEqual("Party Summary",
                GetMember.DisplayName<PartySignatureBaseView>(x => x.PartySummaryId));
        }
        [TestMethod] public void ReasonTest() {
            isNullableProperty(() => obj.Reason, x => obj.Reason = x);
        }

    }

}
