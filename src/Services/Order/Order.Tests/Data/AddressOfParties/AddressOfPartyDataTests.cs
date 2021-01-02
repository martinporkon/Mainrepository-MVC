using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order.Data.AddressOfParty;
using Sooduskorv_MVC.CommonTests.OverallTests;
using Sooduskorv_MVC.Data.CommonData;

namespace Order.Tests.Data.AddressOfParties
{
    [TestClass]
    public class AddressOfPartyDataTests : SealedClassTests<AddressOfPartyData, AddressedEntityData>
    {
        [TestMethod]
        public void PartyIdTest() =>
           isNullableProperty(() => obj.PartyId, x => obj.PartyId = x);
    }
}