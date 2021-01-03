namespace CommonData {

    public abstract class RelationshipTypeData : EntityTypeData {

        public string ConsumerTypeId { get; set; }
        public string ProviderTypeId { get; set; }

    }

}