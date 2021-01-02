using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order.Data.Orders;
using Sooduskorv_MVC.CommonTests.OverallTests;
using Sooduskorv_MVC.Data.CommonData;

namespace Order.Tests.Data.Orders
{

    [TestClass]
    public class OrderDataTests : SealedClassTests<OrderData, PeriodData>
    {

        [TestMethod]
        public void ShipMethodsOfPartyIdTest() =>
            isNullableProperty(() => obj.ShipMethodsOfPartyId, x => obj.ShipMethodsOfPartyId = x);


        [TestMethod]
        public void DescriptionTest() =>
            isNullableProperty(() => obj.Description, x => obj.Description = x);



        [TestMethod]
        public void ConfirmationDateTest() =>
                    isProperty(() => obj.ConfirmationDate, x => obj.ConfirmationDate = x);

        [TestMethod]
        public void OrderStatusTest() =>
                    isProperty(() => obj.OrderStatus, x => obj.OrderStatus = x);
    }
}
