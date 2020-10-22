using CommonData;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order.Data.AddressOfParty;

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
