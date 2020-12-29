using ProtoBuf;

namespace WebMVC.Bff.HttpAggregator.Domain.DTO
{
    [ProtoContract]
    public class ProductDto
    {
        [ProtoMember(1)]
        public string Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public string Description { get; set; }
    }
}