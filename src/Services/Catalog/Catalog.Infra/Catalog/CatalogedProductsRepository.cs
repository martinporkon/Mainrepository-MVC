using Catalog.Data.CatalogedProducts;
using Catalog.Infra.Common;
using Catalog.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Sooduskorv_MVC;
using Aids.Extensions;

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
