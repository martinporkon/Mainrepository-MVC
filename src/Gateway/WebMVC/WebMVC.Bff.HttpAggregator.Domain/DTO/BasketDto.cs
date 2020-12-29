using ProtoBuf;

namespace WebMVC.Bff.HttpAggregator.Domain.DTO
{
    [ProtoContract]
    public class BasketDto
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