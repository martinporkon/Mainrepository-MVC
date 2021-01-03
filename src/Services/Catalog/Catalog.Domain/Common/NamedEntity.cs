using Catalog.Domain.Common;
using Sooduskorv_MVC.Data.CommonData;

namespace Catalog.Domain.Catalog
{
    public abstract class NamedEntity<T> : UniqueEntity<T> where T : NameEntityData, new()
    {

        protected internal NamedEntity(T d = null) : base(d) { }

        public virtual string Name => Data?.Name ?? Unspecified;
    }
}
