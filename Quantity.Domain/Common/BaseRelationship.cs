using CommonData;


namespace Quantity.Domain.Common {

    public abstract class BaseRelationship<TEntity, TData> : DefinedEntity<TData> where TData: RelationshipData, new() {

        protected BaseRelationship(TData d = null) : base(d) { }

        public string RelationshipTypeId => Data?.RelationshipTypeId ?? Unspecified;

        public string ConsumerEntityId => Data?.ConsumerEntityId ?? Unspecified;
        
        public string ProviderEntityId => Data?.ProviderEntityId ?? Unspecified;

    }

}