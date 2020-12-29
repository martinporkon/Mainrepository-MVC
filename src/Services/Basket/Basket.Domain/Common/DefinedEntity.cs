using Sooduskorv_MVC.Data.CommonData;

namespace Basket.Domain.Common
{
    public abstract class DefinedEntity<T> : NamedEntity<T>, IDefinedEntity<T> where T : DescribedEntityData, new()
    {
        public string Name { get; }
        public string Code { get; }
        public string Definition { get; }
        protected internal DefinedEntity(T d = null) : base(d) { }
    }
}