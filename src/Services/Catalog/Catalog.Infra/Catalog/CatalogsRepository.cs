/*
using Catalog.Data.Catalog;
using Catalog.Domain.Catalog;

namespace Catalog.Infra.Catalog
{
    public sealed class CatalogsRepository : UniqueEntityRepository<Catalogs, CatalogData>,
         ICatalogsRepository
    {

        public CatalogsRepository(CatalogDbContext c = null) : base(c, c?.Catalogs) { }

        protected internal override Catalogs toDomainObject(CatalogData d) => new Catalogs(d);

    }
}
*/
