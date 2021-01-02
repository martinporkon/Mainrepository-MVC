using CommonTests.OverallTests;

namespace Quantity.Tests.Pages.Common.Consts {

    [TestClass] public class PartyPagesUrlsTests : BaseTests {

        [TestInitialize] public void TestInitialize() => type = typeof(PartyPagesUrls);

        [TestMethod] public void OrganizationTypesTest() =>
            Assert.AreEqual("/Party/OrganizationTypes", PartyPagesUrls.OrganizationTypes);

        [TestMethod]
        public void BodyMetricTypesTest() =>
            Assert.AreEqual("/Party/BodyMetricTypes", PartyPagesUrls.BodyMetricTypes);

        [TestMethod]
        public void PartySignaturesTest() =>
            Assert.AreEqual("/Party/PartySignatures", PartyPagesUrls.PartySignatures);
    }

}
