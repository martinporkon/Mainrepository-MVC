
using Catalog.Data.CatalogedProducts;
using System.Threading.Tasks;
using Catalog.Domain.Catalog;
using Sooduskorv_MVC.Aids.Extensions;
using Catalog.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infra.Catalog
{
    public sealed class CatalogedProductsRepository : PaginatedRepository<CatalogedProduct, CatalogedProductData>,
        ICatalogedProductsRepository
    {

        public CatalogedProductsRepository(CatalogDbContext c = null) : base(c, c?.CatalogedProducts) { }

        protected internal override CatalogedProduct toDomainObject(CatalogedProductData d) => new CatalogedProduct(d);

        protected override async Task<CatalogedProductData> getData(string id)
        {
            var entryId = id?.GetHead();
            var typeId = id?.GetTail();

            return await dbSet.SingleOrDefaultAsync(
                x => x.CatalogEntryId == entryId
                     && x.ProductTypeId == typeId);
        }

        protected override CatalogedProductData getDataById(CatalogedProductData d)
            => dbSet.Find(d?.CatalogEntryId, d?.ProductTypeId);

    }
}

