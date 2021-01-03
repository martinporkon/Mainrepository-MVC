using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantity.Pages.Common.Consts;
using Sooduskorv_MVC.CommonTests.OverallTests;

namespace Quantity.Tests.Pages.Common.Consts
{
    [TestClass]
    public class PartyPagesNamesTests : BaseTests
    {

        [TestInitialize] public void TestInitialize() => type = typeof(PartyPagesNames);
        [TestMethod] public void OrganizationTypesTest() => Assert.AreEqual("Organization Types", PartyPagesNames.OrganizationTypes);
        [TestMethod] public void BodyMetricTypesTest() => Assert.AreEqual("Body Metric Types", PartyPagesNames.BodyMetricTypes);
        [TestMethod] public void PartySignaturesTest() => Assert.AreEqual("Party Signatures", PartyPagesNames.PartySignatures);
    }
}
