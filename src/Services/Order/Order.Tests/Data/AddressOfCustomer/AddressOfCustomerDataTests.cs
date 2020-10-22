using CommonData;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order.Data.AddressOfCustomer;

namespace Order.Tests.Data.AddressOfCustomer
{

    [TestClass]
    public class AddressOfCustomerDataTests : SealedClassTests<AddressOfCustomerData, AddressedEntityData>
    {
        [TestMethod]
        public void CustomerIdTest() =>
           isNullableProperty(() => obj.CustomerId, x => obj.CustomerId = x);
    }
}
