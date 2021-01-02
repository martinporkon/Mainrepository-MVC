using WebMVC.Domain.CommonData;

namespace CommonData {

    public abstract class RelationshipData : DefinedEntityData {

        public string RelationshipTypeId { get; set; }
        public string ConsumerEntityId { get; set; }
        public string ProviderEntityId { get; set; }

    }

}