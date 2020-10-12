using CommonData;
using CommonTests.BaseTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order.Data.AddressOfParty;

namespace Order.Tests.AddressOfParties
{
    [TestClass]
    public class AddressOfPartyDataTests : SealedClassTests<AddressOfPartyData, AddressedEntityData>
    {
        [TestMethod]
        public void PartyIdTest() =>
           isNullableProperty(() => obj.PartyId, x => obj.PartyId = x);
    }
}
