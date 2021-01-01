using Aids.Reflection;
using Catalog.Data.Services;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.Tests.Data.Service
{

    [TestClass]
    public class DeliveryStatusTests : BaseTests
    {

        [TestInitialize] public void TestInitialize() => type = typeof(DeliveryStatus);

        [TestMethod]
        public void CountTest()
            => Assert.AreEqual(5, GetEnum.Count<DeliveryStatus>());

        [TestMethod]
        public void UnspecifiedTest() =>
            Assert.AreEqual(0, (int)DeliveryStatus.Unspecified);

        [TestMethod]
        public void ScheduledTest() =>
            Assert.AreEqual(1, (int)DeliveryStatus.Scheduled);

        [TestMethod]
        public void ExecutingTest() =>
            Assert.AreEqual(2, (int)DeliveryStatus.Executing);

        [TestMethod]
        public void CompletedTest() =>
            Assert.AreEqual(3, (int)DeliveryStatus.Completed);

        [TestMethod]
        public void CancelledTest() =>
            Assert.AreEqual(9, (int)DeliveryStatus.Cancelled);
    }

}