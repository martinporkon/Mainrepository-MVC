using Catalog.Data.Parties;
using CommonData;
using CommonTests.OverallTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog.Tests.Data.Parties
{

    [TestClass]
    public class PartyDataTests : SealedClassTests<PartyData, NamedEntityData>
    {
        [TestMethod]
        public void AddressIdTest() =>
            isNullableProperty(() => obj.AddressId, x => obj.AddressId = x);

        [TestMethod]
        public void LatitudeTest() =>
            isNullableProperty(() => obj.Latitude, x => obj.Latitude = x);


        [TestMethod]
        public void LongitudeTest() =>
            isNullableProperty(() => obj.Longitude, x => obj.Longitude = x);

        [TestMethod]
        public void HoursTest() =>
            isNullableProperty(() => obj.Hours, x => obj.Hours = x);

        [TestMethod]
        public void OrganizationTest() =>
                    isNullableProperty(() => obj.Organization, x => obj.Organization = x);
    }
}
