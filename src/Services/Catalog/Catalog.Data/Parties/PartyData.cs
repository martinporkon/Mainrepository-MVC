using CommonData;
using Data.CommonData;

namespace Catalog.Data.Parties
{
    public sealed class PartyData : NamedEntityData
    {
        public string AddressId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Hours { get; set; }
        public string Organization { get; set; }
    }
}