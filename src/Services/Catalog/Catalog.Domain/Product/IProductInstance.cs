using Catalog.Data.Product;
using Catalog.Domain.Common;

namespace Catalog.Domain.Product
{
    public interface IProductInstance : IUniqueEntity<ProductInstanceData>
    {
        string ProductTypeId { get; } 
        string TypeId { get; }
        ProductKind ProductKind { get; }
    }
}
