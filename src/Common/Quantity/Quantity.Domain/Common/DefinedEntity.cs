using Quantity.Data;

namespace Quantity.Domain.Common
{

    public abstract class DefinedEntity<T> : NamedEntity<T>, IDefinedEntity<T> where T : DefinedEntityData, new() {

        protected internal DefinedEntity(T d = null) : base(d) { }

        public virtual string Definition => Data?.Definition?? Unspecified;

       
    }

}

