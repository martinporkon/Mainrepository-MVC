using ProtoBuf;
using Sooduskorv_MVC.Data.CommonData;

namespace Catalog.Data.Parties
{
    [ProtoContract]
    public sealed class PartyData : NamedEntityData
    {
        [ProtoMember(1)]
        public string AddressId { get; set; }
        [ProtoMember(2)]
        public string Latitude { get; set; }
        [ProtoMember(3)]
        public string Longitude { get; set; }
        [ProtoMember(4)]
        public string Hours { get; set; }
        [ProtoMember(5)]
        public string Organization { get; set; }
    }
}