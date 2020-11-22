using Sooduskorv_MVC.Data.CommonData;

namespace Basket.Domain.Common
{
    public abstract class NamedEntity<T> : UniqueEntity<T> where T : NamedEntityData, new()
    {
        protected internal NamedEntity(T d = null) : base(d) { }
    }
}