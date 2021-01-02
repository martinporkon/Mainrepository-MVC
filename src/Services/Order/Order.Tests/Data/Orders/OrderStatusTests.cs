using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order.Data.Orders;
using Sooduskorv_MVC.Aids.Reflection;
using Sooduskorv_MVC.CommonTests.OverallTests;

namespace Order.Tests.Data.Orders
{

    [TestClass]
    public class OrderStatusTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => type = typeof(OrderStatus);

        [TestMethod]
        public void CountTest()
            => Assert.AreEqual(6, GetEnum.Count<OrderStatus>());

        [TestMethod]
        public void RejectedTest()
           => Assert.AreEqual(0, (int)OrderStatus.Rejected);

        [TestMethod]
        public void OnHoldTest()
           => Assert.AreEqual(1, (int)OrderStatus.OnHold);

        [TestMethod]
        public void CancelledTest()
           => Assert.AreEqual(2, (int)OrderStatus.Cancelled);

        [TestMethod]
        public void OpenTest()
           => Assert.AreEqual(3, (int)OrderStatus.Open);

        [TestMethod]
        public void ClosedTest()
           => Assert.AreEqual(4, (int)OrderStatus.Closed);

        [TestMethod]
        public void InitializingTest()
           => Assert.AreEqual(5, (int)OrderStatus.Initializing);
    }
}
