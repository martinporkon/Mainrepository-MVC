using Catalog.Data.UserProfiles;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sooduskorv_MVC.Aids.Reflection;

namespace Catalog.Tests.Data.UserProfiles
{
    [TestClass]
    public class LoyaltyTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => type = typeof(Loyalty);

        [TestMethod]
        public void CountTest()
            => Assert.AreEqual(2, GetEnum.Count<Loyalty>());

        [TestMethod]
        public void ATest()
           => Assert.AreEqual(0, (int)Loyalty.A);

        [TestMethod]
        public void BTest()
           => Assert.AreEqual(1, (int)Loyalty.B);
    }
}
