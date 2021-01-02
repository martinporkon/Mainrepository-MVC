using Catalog.Data.Product;
using Catalog.Domain.Product;
using Catalog.Infra.Common;

namespace Catalog.Infra.Product
{

    public sealed class ProductInstancesRepository : UniqueEntityRepository<IProductInstance, ProductInstanceData>,
        IProductInstancesRepository
    {

        public ProductInstancesRepository(CatalogDbContext c = null) : base(c, c?.ProductInstances) { }

        protected internal override IProductInstance toDomainObject(ProductInstanceData d) => ProductFactory.Create(d);

    }

}