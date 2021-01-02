using Catalog.Data.Product;
using Catalog.Domain.Product;
using Catalog.Infra.Common;

namespace Catalog.Infra.Product
{

    public sealed class ProductTypesRepository : UniqueEntityRepository<IProductType, ProductTypeData>,
        IProductTypesRepository
    {

        public ProductTypesRepository(CatalogDbContext c = null) : base(c, c?.ProductTypes) { }

        protected internal override IProductType toDomainObject(ProductTypeData d) => ProductTypeFactory.Create(d);

    }

}