
using Catalog.Data.Product;
using Catalog.Domain.Product;
using Catalog.Infra.Common;

namespace Catalog.Infra.Product
{
    public sealed class BrandsRepository :
        UniqueEntityRepository<Brand, BrandData>, IBrandsRepository
    {
        public BrandsRepository(CatalogDbContext c) : base(c, c.Brands) { }
        protected internal override Brand toDomainObject(BrandData d)
            => new Brand(d);
    }
}

