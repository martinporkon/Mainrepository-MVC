using Aids.Reflection;
using Catalog.Data.UserProfiles;
using CommonTests.BaseTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Tests.UserProfiles
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
