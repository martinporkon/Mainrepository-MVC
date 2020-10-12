using CommonData;
using CommonTests.BaseTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order.Data.AddressOfCustomer;

namespace Order.Tests.AddressOfCustomer
{

    [TestClass]
    public class AddressOfCustomerDataTests : SealedClassTests<AddressOfCustomerData, AddressedEntityData>
    {
        [TestMethod]
        public void CustomerIdTest() =>
           isNullableProperty(() => obj.CustomerId, x => obj.CustomerId = x);
    }
}
