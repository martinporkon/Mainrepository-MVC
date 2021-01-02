using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order.Data.AddressOfCustomer;
using Sooduskorv_MVC.CommonTests.OverallTests;
using Sooduskorv_MVC.Data.CommonData;

namespace Order.Tests.Data.AddressOfCustomer
{

    [TestClass]
    public class AddressOfCustomerDataTests : SealedClassTests<AddressOfCustomerData, AddressedEntityData>
    {
        [TestMethod]
        public void CustomerIdTest() =>
           isNullableProperty(() => obj.BuyerId, x => obj.BuyerId = x);
    }
}